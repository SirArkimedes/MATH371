/******************************************************/
/* Andrew Robinson                                    */
/* Math 371                                           */
/* Fall 2017                                          */
/*                                                    */
/* Source at: https://github.com/SirArkimedes/MATH371 */
/******************************************************/

// Imports
using System;
using System.IO;
using System.Collections.Generic;

// Declare the project's namespace...
namespace Project6
{

    // Declare the class that Main() enters into.
    class MainClass
    {

        // Declare path constant, assuming the data file is put where the .exe is.
        const string filePath = "pathdata.csv"; // REQUIRES THE NAME: pathdata.txt
        static StreamReader reader;

        // Creates a dynamically sized array. Lists are just nicer to work with.
        static List<Node> nodes = new List<Node>();
        // Handle a seperate array for faster finds.
        static List<Node> selectedNodes = new List<Node>();

        // Save the sink node so we don't have to loop through lists.
        static Node sinkNode;

        // The step-by-step control variable.
        static bool stepByStep = true;

        // Main() -> The console enters into here...
        public static void Main(string[] args)
        {
            // Call the struct declared above and pass the necessary information.
            ProgramDescriptions.displayClassInformation("Implement shortest path algorithm");

            string purpose = "Implement the shortest path algorithm from source to sink.";
            ProgramDescriptions.displayPurpose(purpose);

            tryOpenFile();
            gatherDataFromFile();

            requestSourceSink();

            // Sort the paths of each node from lowest cost to highest cost.
            foreach (Node node in nodes)
                node.sortPaths();

            // Ask if wants step by step.
            Console.Write("Would you like to run the program in step-by-step mode? (y/n) ");
            if (Console.ReadLine() != "y")
            {
                stepByStep = false;
            }

            // Do the algorithm!
            Path path = null;
            while (path == null)
            {
                // Control the step-by-step.
                if (stepByStep)
                {
                    // Grab last selected Node.
                    Node last = selectedNodes[selectedNodes.Count - 1];

                    Console.WriteLine();
                    Console.WriteLine();
                    Console.WriteLine("Last selected node: {0}", nodes.IndexOf(last) + 1);
                    Console.WriteLine("Accumulated cost to this node: {0}", last.accumulatedCost);
                    Console.WriteLine();

                    Console.WriteLine("All nodes and their paths: ");

                    int largestPathCount = int.MinValue;
                    for (int i = 0; i < nodes.Count; i++)
                    {
                        Node node = nodes[i];
                        // Find maximum paths for printing of paths.
                        if (node.paths.Count > largestPathCount)
                            largestPathCount = node.paths.Count;

                        string selectedString = string.Format("{0}", i + 1);
                        if (selectedNodes.Contains(node))
                            selectedString = string.Format("{0} *", i + 1);

                        // Print the header.
                        if (i < nodes.Count - 1)
                            Console.Write("{0, -15} ", selectedString);
                        else
                            Console.WriteLine("{0, -15} ", selectedString);
                    }

                    for (int row = 0; row < largestPathCount; row++) // Print paths
                    {
                        for (int column = 0; column < nodes.Count; column++)
                        {
                            // Print the 2D array.
                            Node node = nodes[column];

                            if (node.paths.Count > row) // Don't want any index of out bounds.
                            {
                                Path rowPath = node.paths[row];
                                string pathData =
                                    string.Format("{0} --> {1}, {2}", column + 1,
                                                   nodes.IndexOf(rowPath.destination) + 1, rowPath.cost);
                                Console.Write("{0, -15} ", pathData);
                            }
                            else
                                Console.Write("{0, 15} ", ""); // Print only spaces
                        }

                        Console.WriteLine();
                    }

                    Console.WriteLine();
                    Console.Write("Press enter to continue. ");
                    Console.ReadLine();
                }
                // End step-by-step.

                path = findPathToSinkNodeOneStep(); // Returns sink if found, otherwise null.
            }

            Console.WriteLine();
            Console.Write("THE SINK HAS BEEN FOUND!");
            tracePathBackwards(path);

            // Stop the program from closing the window.
            Console.ReadLine();
        }

        /**************************************/
        /* Data gathering                     */
        /**************************************/

        static void tryOpenFile()
        {
            try
            {
                reader = File.OpenText(filePath);
            }
            catch
            {
                Console.WriteLine("Error: {0} could not be opened\n", filePath);
                Console.ReadLine();
                Environment.Exit(1);
            }
        }

        static void gatherDataFromFile()
        {
            int row = 0; // Keep track of row for node layout.
            string line = reader.ReadLine();

            while (line != null) // Read file lines until we run out of lines.
            {
                // Get an array of the values, of this line, in the string type.
                string[] stringArray = line.Split(',');

                // Add extra source nodes that we didn't get earlier.
                if (nodes.Count <= row)
                    nodes.Add(new Node());

                // Loop through all values.
                for (int column = 0; column < stringArray.Length; column++)
                {
                    string costString = stringArray[column];
                    if (costString != "")
                    {
                        // Parse the string into a double.
                        double cost = double.Parse(costString);

                        // Make an initial guess as to how many nodes there are. Based off of this line's length.
                        if (column + 1 > nodes.Count)
                            nodes.Add(new Node());

                        if (!cost.Equals(0))  // Don't do anything if there is no cost.
                        {
                            Node source = nodes[row];

                            Path path = new Path();
                            path.cost = cost;
                            path.source = source;
                            path.destination = nodes[column];

                            source.paths.Add(path);
                        }
                    }
                }

                line = reader.ReadLine();
                row++;
            }
        }

        static void requestSourceSink()
        {
            // Verify that the entered value is able to be an index.
            bool shouldRequestSource = true;
            while (shouldRequestSource)
            {
                // Request source
                Console.Write("Enter the source index (1-{0}): ", nodes.Count);
                string sourceString = Console.ReadLine();

                try
                {
                    int source = int.Parse(sourceString);
                    Node node = nodes[source - 1];
                    node.isSource = true;
                    selectedNodes.Add(node);

                    deletePathsForDestination(node); // Delete all paths to source.

                    shouldRequestSource = false;
                }
                catch
                {
                    Console.WriteLine("Source is not an index!");
                }
            }

            // Verify that the entered value is able to be an index.
            bool shouldRequestSink = true;
            while (shouldRequestSink)
            {
                // Request sink
                Console.Write("Enter the sink index (1-{0}): ", nodes.Count);
                string sinkString = Console.ReadLine();

                try
                {
                    int sink = int.Parse(sinkString);
                    sinkNode = nodes[sink - 1];
                    shouldRequestSink = false;
                }
                catch
                {
                    Console.WriteLine("Sink is not an index!");
                }

            }

        }

        /**************************************/
        /* Algorithm                          */
        /**************************************/

        // Do one step of the algorithm and return the last path, if it is sink Node.
        static Path findPathToSinkNodeOneStep()
        {
            // Find the smallest path of selected nodes.
            Path smallestPath = null;
            double smallestValueOfPath = double.MaxValue;
            foreach (Node node in selectedNodes)
            {
                Path leastCostPath = node.getLeastCostNonSelectedPath();
                if (leastCostPath != null &&
                    leastCostPath.cost + node.accumulatedCost < smallestValueOfPath)
                {
                    smallestPath = leastCostPath;
                    smallestValueOfPath = leastCostPath.cost + node.accumulatedCost;
                }
            }

            // Making sure we actually have a smallest Path.
            if (smallestPath == null)
            {
                Console.WriteLine("All selected nodes have no least paths to choose from!");
                Console.ReadLine();
                Environment.Exit(1);
            }
            else
            {
                Node selectedDestination = smallestPath.destination;
                selectedNodes.Add(selectedDestination);

                // Make this path selected.
                smallestPath.isSelected = true;

                // Set the cost additive to smallest value.
                if (selectedDestination.accumulatedCost.Equals(0))
                    selectedDestination.accumulatedCost = smallestValueOfPath;

                // Have we found the sink? If so, don't delete paths and signal we've found it.
                if (selectedDestination == sinkNode)
                    return smallestPath;
                else
                    deletePathsForDestination(selectedDestination);
            }

            return null;
        }

        static void deletePathsForDestination(Node destination)
        {
            // Check to see if any paths go to the selectedDestination.
            foreach (Node node in nodes)
            {
                // Gather which that are needed to be removed from the node.
                List<Path> pathsToRemove = new List<Path>();
                foreach (Path path in node.paths)
                    if (path.destination == destination && // is same destination
                        !path.isSelected) // path is also not selected
                    {
                        pathsToRemove.Add(path);
                    }

                // Remove them from the node.
                foreach (Path path in pathsToRemove)
                    node.paths.Remove(path);
            }
        }

        static void tracePathBackwards(Path finalPath)
        {
            Node source = finalPath.source;

            List<Node> orderOfNodesToTravel = new List<Node>();
            orderOfNodesToTravel.Add(source);

            List<Path> orderOfPaths = new List<Path>();
            orderOfPaths.Add(finalPath);

            // Find the path, but backwards. Assumes there is only one way to get to the sink.
            while (!source.isSource)
                foreach (Node node in selectedNodes)
                    foreach (Path path in node.paths)
                        if (path.destination == source && path.isSelected)
                        {
                            // Add the node to the beginning since we're going backwards.
                            orderOfNodesToTravel.Insert(0, path.source);
                            orderOfPaths.Insert(0, path);
                            source = path.source;
                        }

            // Print the findings!
            string orderDescription = "";
            for (int orderIndex = 0; orderIndex < orderOfNodesToTravel.Count; orderIndex++)
            {
                int index = nodes.IndexOf(orderOfNodesToTravel[orderIndex]);
                orderDescription += string.Format("{0} --> ", index + 1);
            }

            orderDescription += string.Format("{0}", nodes.IndexOf(sinkNode) + 1);

            Console.WriteLine();
            Console.WriteLine("Order of nodes based on their indexes in the data file (i.e. 1 --> 3):");
            Console.WriteLine();
            Console.WriteLine(orderDescription);
            Console.WriteLine();

            // Print costs.
            double totalCost = 0;
            string costString = "";
            for (int orderIndex = 0; orderIndex < orderOfPaths.Count; orderIndex++)
            {
                Path path = orderOfPaths[orderIndex];
                if (orderIndex == orderOfPaths.Count - 1)
                    costString += string.Format("{0}", path.cost);
                else
                    costString += string.Format("{0} + ", path.cost);

                totalCost += path.cost;
            }
            Console.WriteLine("Travel costs: {0} = {1}", costString, totalCost);

        }

    }

    /**************************************/
    /* Node && Path classes               */
    /**************************************/

    // The Node class which contains properties of the A, B, C... nodes.
    class Node
    {
        public bool isSource = false; // Whether this node is designated source.

        public double accumulatedCost = 0; // The amount of cost before current Node.

        public List<Path> paths = new List<Path>(); // All of this Node's associated paths.

        public void sortPaths()
        {
            // Uses the List's .Sort method and passes a x's cost < y's cost condition to sort by.
            paths.Sort(delegate(Path x, Path y)
            {
                return x.cost.CompareTo(y.cost);
            });
        }

        public Path getLeastCostNonSelectedPath()
        {
            if (paths.Count >= 1)
            {
                for (int i = 0; i < paths.Count; i++)
                    if (!paths[i].isSelected)
                        return paths[i];

                return null;
            }
            else
                return null;
        }

    }

    class Path
    {
        public Node source;
        public Node destination;

        public double cost; // cost of going from source to destination Nodes.

        public bool isSelected = false; // or circled.
    }

    /**************************************/
    /* Program Descriptions               */
    /**************************************/

    // Declare a struct for easy reuse later in the course...
    struct ProgramDescriptions
    {
        // Accepts a string that is displayed with the standard information.
        public static void displayClassInformation(string programName)
        {
            Console.WriteLine("Math 371");
            Console.WriteLine("Fall 2017");
            Console.WriteLine(programName);
            Console.WriteLine("Andrew Robinson");
            Console.WriteLine();
        }

        // Accepts the purpose string to display in informative label.
        public static void displayPurpose(string purpose)
        {
            Console.WriteLine("Purpose:");
            Console.WriteLine(purpose);
            Console.WriteLine();
        }
    }

}
