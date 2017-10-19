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

// Declare the project's namespace...
namespace Project6
{

	// Declare the class that Main() enters into.
	class MainClass
    {

        // Declare path constant, assuming the data file is put where the .exe is.
        const string filePath = "pathdata.txt";
        static StreamReader reader;

		// Main() -> The console enters into here...
		public static void Main(string[] args)
        {
			// Call the struct declared above and pass the necessary information.
			ProgramDescriptions.displayClassInformation("Implement shortest patch algorithm");

            string purpose = "Implement the shortest path algorithm from source to sink.";
			ProgramDescriptions.displayPurpose(purpose);

            openFileTry();
        }

        static void openFileTry()
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
    }

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
