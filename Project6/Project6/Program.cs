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
        const string filePath = "pathdata.txt"; // REQUIRES THE NAME: pathdata.txt
        static StreamReader reader;

        // Creates a dynamically sized array. Lists are just nicer to work with.
        static List<Node> nodes = new List<Node>();

        // Main() -> The console enters into here...
        public static void Main(string[] args)
        {
            // Call the struct declared above and pass the necessary information.
            ProgramDescriptions.displayClassInformation("Implement shortest patch algorithm");

            string purpose = "Implement the shortest path algorithm from source to sink.";
            ProgramDescriptions.displayPurpose(purpose);

            tryOpenFile();
            gatherDataFromFile();

            // Sort the paths of each node from lowest to highest.
            foreach (Node node in nodes)
            {
                node.sortPaths();
            }

        }

        ////////////////////////////////////////
        /* Data gathering                     */
        ////////////////////////////////////////

        static void tryOpenFile()
        {
            try
            {
                reader = File.OpenText(filePath);
            }
            catch
            {
                Console.WriteLine("Error: {0} could not be opened\n", filePath);
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
                string[] stringArray = line.Split(' ');

                // Loop through all values.
                for (int column = 1; column <= stringArray.Length; column++)
                {
                    // Parse the string into a unsigned integer.
                    uint cost = uint.Parse(stringArray[column - 1]);

                    // Create the nodes in the list. Create them only on the first line, though.
                    if (column > nodes.Count)
                        nodes.Add(new Node());
                    
                    if (cost != 0) // Don't do anything if there is no cost.
                    {
                        Node node = nodes[row];

                        Path path = new Path();
                        path.cost = cost;
                        path.source = node;
                        path.destination = nodes[column - 1];

                        node.paths.Add(path);
                    }
                }

                line = reader.ReadLine();
                row++;
            }
        }

    }

    /**************************************/
    /* Node && Path classes               */
    /**************************************/

    // The Node class which contains properties of the A, B, C... nodes.
    class Node
    {
        public bool isSource = false; // Whether this node is designated source.
        public bool isSink = false; // Whether this node is designated sink.

        public bool isSelected = false; // or starred.
        public uint accumulatedCost = 0; // The amount of cost before current Node.

        public List<Path> paths = new List<Path>(); // All of this Node's associated paths.

        public void sortPaths()
        {
            // Uses the List's .Sort method and passes a x's cost < y's cost condition to sort by.
            paths.Sort(delegate(Path x, Path y)
            {
                return x.cost.CompareTo(y.cost);
            });
        }

    }

    class Path
    {
        public Node source;
        public Node destination;

        public uint cost; // cost of going from source to destination Nodes.
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
