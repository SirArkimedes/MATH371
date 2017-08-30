/******************************************************/
/* Andrew Robinson                                    */
/* Math 371                                           */
/* Fall 2017                                          */
/*                                                    */
/* Source at: https://github.com/SirArkimedes/MATH371 */
/******************************************************/

// Imports
using System;

// Declare the project's namespace...
namespace Project1
{

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

    // Declare a struct that represents a function in form ax + by = r
    struct Function
    {
        public double a;
        public double b;
        public double r;
    }

    // Declare the class that Main() enters into.
    class MainClass
    {
		// Declare the loop control for running again.
		static bool wantsToRunProcessAgain = true;

        // Main() -> The console enters into here...
        public static void Main(string[] args)
        {
            // Call the struct declared above and pass the necessary information.
            ProgramDescriptions.displayClassInformation("Linear System Solver");

            string purpose = "Upon input of a, b, c, d, r, and s, the solution to " +
                " the system of equations ax + by = r, cx + dy = s is produced.";
            ProgramDescriptions.displayPurpose(purpose);

            while (wantsToRunProcessAgain)
            {
				// Declare function to be added to later...
				Function f1, f2;

				// Begin user input
				userInput('a', out f1.a);
				userInput('b', out f1.b);
				userInput('r', out f1.r);

				userInput('c', out f2.a);
				userInput('d', out f2.b);
				userInput('s', out f2.r);

                // Attempt to solve.
                double x, y;
                string output = solve(f1, f2, out x, out y);

			    Console.WriteLine("{0}x + {1}y = {2}", f1.a, f1.b, f1.r);
				Console.WriteLine("{0}x + {1}y = {2}", f2.a, f2.b, f2.r);
				if (output == "success")
				{
					Console.WriteLine("x = {0:0.0000}", x);
					Console.WriteLine("y = {0:0.0000}", y);
					Console.WriteLine();
				}
				else
				{
                    // Not a success; output the string that was received.
                    Console.WriteLine(output);
                    Console.WriteLine();
				}

                // Prompt for running again.
				Console.WriteLine("Run with new equations? y/n");
				string response = Console.ReadLine();
				if (response != "y")
				{
					wantsToRunProcessAgain = false;
				}

                Console.WriteLine();
            }
        }

        // Prompt for user input for passed variable name and
        // assign the integerToSet if successful.
        static void userInput(char variable, out double doubleToSet)
        {
            // Prompt to enter the value for passed variable
            Console.Write("Input value for {0}: ", variable);

			// Check to see if the input can be a double, assign to doubleToSet if so.
			if (!double.TryParse(Console.ReadLine(), out doubleToSet))
            {
                // The integer can't be parsed. Retry.
                Console.WriteLine("Invalid input for `{0}`! Retrying...", variable);
                Console.WriteLine();
                userInput(variable, out doubleToSet); // Takes advantage of recursion.
            }
        }

        // Solve the system. Assign the x and y that was passed. Return string of success or not.
        static string solve(Function f1, Function f2, out double x, out double y)
        {
            if (!Equals(f1.a * f2.b, f2.a * f1.b))
            {
                y = (f1.a * f2.r - f2.a * f1.r) / (f1.a * f2.b - f2.a * f1.b);

                if (Equals(f1.a, 0.0)) // Prevent divide by 0.
                {
                    x = 0.0;
                }
                else
                {
                    x = (f1.r - f1.b * y) / f1.a;
                }

                return "success";
            }
            else if ((Equals(f1.a, 0.0) && Equals(f1.b, 0.0) && !Equals(f1.r, 0.0)) || // 0x + 0y = 3 is false.
                     (Equals(f2.a, 0.0) && Equals(f2.b, 0.0) && !Equals(f2.r, 0.0)))
            {
                // Assign because they have to be.
                x = double.MaxValue;
                y = double.MaxValue;
                return "No solution!";
            }
			else if ((Equals(f1.a, 0.0) && Equals(f1.b, 0.0) && Equals(f1.r, 0.0)) || 
                     (Equals(f2.a, 0.0) && Equals(f2.b, 0.0) && Equals(f2.r, 0.0)) || 
                     // If the equations are multiples of each other.
                     (Equals(f1.a / f2.a, f1.b / f2.b) && Equals(f1.a / f2.a, f1.r / f2.r)))
            {
                // Assign because they have to be.
                x = double.MaxValue;
                y = double.MaxValue;
                return "Infinitely many solutions!";
            }
            else // Catch the remaining cases as these can't be combined in the ORs.
            {
				// Assign because they have to be.
				x = double.MaxValue;
				y = double.MaxValue;
				return "No solution!";
            }
        }

    }
}

// PROGRAM OUTPUT FOR GIVEN SYSTEMS:
/*
Math 371
Fall 2017
Linear System Solver
Andrew Robinson

Purpose:
Upon input of a, b, c, d, r, and s, the solution to  the system of equations ax + by = r, cx + dy = s is produced.

Input value for a: 2
Input value for b: 3
Input value for r: 8
Input value for c: 5
Input value for d: -4
Input value for s: 9
2x + 3y = 8
5x + -4y = 9
x = 2.5652
y = 0.9565

Run with new equations? y/n
y

Input value for a: 2
Input value for b: -5
Input value for r: 8
Input value for c: -4
Input value for d: 10
Input value for s: 9
2x + -5y = 8
-4x + 10y = 9
No solution!

Run with new equations? y/n
y

Input value for a: 2
Input value for b: -5
Input value for r: 8
Input value for c: -4
Input value for d: 10
Input value for s: -16
2x + -5y = 8
-4x + 10y = -16
Infinitely many solutions!

Run with new equations? y/n
y

Input value for a: 2
Input value for b: 3
Input value for r: 8
Input value for c: 5
Input value for d: 0
Input value for s: 12
2x + 3y = 8
5x + 0y = 12
x = 2.4000
y = 1.0667

Run with new equations? y/n
y

Input value for a: 2
Input value for b: 3
Input value for r: 8
Input value for c: 0
Input value for d: 5
Input value for s: 12
2x + 3y = 8
0x + 5y = 12
x = 0.4000
y = 2.4000

Run with new equations? y/n
y

Input value for a: 0
Input value for b: 0
Input value for r: 0
Input value for c: 2
Input value for d: -3
Input value for s: 5
0x + 0y = 0
2x + -3y = 5
Infinitely many solutions!

Run with new equations? y/n
y

Input value for a: 4
Input value for b: 5
Input value for r: 8
Input value for c: 0
Input value for d: 0
Input value for s: 3
4x + 5y = 8
0x + 0y = 3
No solution!

Run with new equations? y/n
n


Press any key to continue...

*/
