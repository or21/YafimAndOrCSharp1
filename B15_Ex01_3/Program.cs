//-----------------------------------------------------------------------
// <copyright file="Program.cs" company="B15_Ex01_3">
// Yafim Vodkov 308973882 Or Brand 302521034
// </copyright>
//-----------------------------------------------------------------------
using System;
using System.Text;

namespace B15_Ex01_3
{
    /// <summary>
    /// Problem 3
    /// </summary>
    public class Program
    {
        /// <summary>
        /// runs the program.
        /// </summary>
        public static void Main()
        {
            int levelsAsInt;
            
            Console.WriteLine("Please enter the number of levels in sand watch (then press enter):");

            // gets a valid input number from the user
            getNumberFromUser(out levelsAsInt);

            // prints the sand watch according to the number. 
            if (levelsAsInt == 5)
            {
                B15_Ex01_2.Program.Main();
            }
            else
            {
                // if the number is even, adds 1 and print the sand watch
                bool isEven = (levelsAsInt % 2) == 0;
                Console.WriteLine(isEven ? drawSandWatch(levelsAsInt + 1) : drawSandWatch(levelsAsInt));
            }

            Console.WriteLine("Press enter to exit");
            Console.ReadLine();
        }

        /// <summary>
        /// Create a string of sand watch according to the i_NumberOfLevels. 
        /// i_NumberOfLevels must be an odd number.
        /// </summary>
        /// <param name="i_NumberOfLevels">number of levels</param>
        /// <returns>sand watch representation</returns>
        private static string drawSandWatch(int i_NumberOfLevels)
        {
            int numberOfSpaces = 0;
            int numberOfDots = i_NumberOfLevels;
            bool isBeforeHalf = true;
            StringBuilder finalSandWatch = new StringBuilder();

            for (int i = 0; i < i_NumberOfLevels; i++)
            {
                for (int j = 0; j < numberOfSpaces / 2; j++)
                {
                    finalSandWatch.Append(" ");
                }

                for (int j = 0; j < numberOfDots; j++)
                {
                    finalSandWatch.Append("*");
                }

                if (isBeforeHalf)
                {
                    numberOfSpaces += 2;
                    numberOfDots -= 2;
                }
                else
                {
                    numberOfSpaces -= 2;
                    numberOfDots += 2;
                }

                if (numberOfDots == 1)
                {
                    isBeforeHalf = false;
                }

                finalSandWatch.Append(Environment.NewLine);
            }

            return finalSandWatch.ToString();
        }

        /// <summary>
        /// Get a valid positive integer from the user.
        /// </summary>
        /// <param name="o_LevelsAsInt">number of levels</param>
        private static void getNumberFromUser(out int o_LevelsAsInt)
        {
            int levelsAsInt = 0;
            bool isGoodNumber = false;
            while (!isGoodNumber)
            {
                string levelsAsString = Console.ReadLine();
                bool isNumber = int.TryParse(levelsAsString, out levelsAsInt);
                if ((levelsAsString != null) && isNumber && (levelsAsInt > 0))
                {
                    isGoodNumber = true;
                }
                else
                {
                    Console.WriteLine("This is not a valid number! let's try again");
                }
            }

            o_LevelsAsInt = levelsAsInt;
        }
    }
}
