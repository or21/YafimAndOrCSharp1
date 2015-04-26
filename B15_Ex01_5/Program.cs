//-----------------------------------------------------------------------
// <copyright file="Program.cs" company="B15_Ex01_5">
// Yafim Vodkov 308973882 Or Brand 302521034
// </copyright>
//-----------------------------------------------------------------------
using System;

namespace B15_Ex01_5
{
    /// <summary>
    /// Problem 5
    /// </summary>
    public class Program
    {
        /// <summary>
        /// runs the program.
        /// </summary>
        public static void Main()
        {
            string inputFromUser = getInput();
            int numbersGreaterThanFirst;
            int numbersSmallerThanFirst;
            countGreaterAndSmallerNumbers(inputFromUser, out numbersGreaterThanFirst, out numbersSmallerThanFirst);

            // input user is valid, get minimum and maximum values from it.
            int minValue;
            int maxValue;
            
            calculateMinAndMaxDigitsInString(inputFromUser, out minValue, out maxValue);
            string resultOfProgram = string.Format(
@"Number Greater than 1st: {0}
Number Smaller than 1st: {1} 
The min value is       : {2}
The max value is       : {3}.
Please press 'Enter' to exit..." ,
                                 numbersGreaterThanFirst,
                                 numbersSmallerThanFirst ,
                                 minValue, 
                                 maxValue);

            Console.WriteLine(resultOfProgram);
            Console.ReadLine();
        }

        /// <summary>
        /// get input from the user
        /// </summary>
        /// <returns> valid 8 digit string </returns>
        private static string getInput()
        {
            string inputFromUser;
            const bool v_GettingInput = true;
            while (v_GettingInput)
            {
                Console.WriteLine("Please enter 8 digit string: ");
                inputFromUser = Console.ReadLine();
                int inputAsInt;
                bool isNumber = int.TryParse(inputFromUser, out inputAsInt);
                bool isValidString = (inputFromUser != null) && 
                    (inputFromUser.Length == 8 && 
                    isNumber) && 
                    (inputAsInt > 0);

                if (isValidString)
                {
                    break;
                }

                Console.WriteLine("Invalid input! please try again...");
            }

            return inputFromUser;
        }

        /// <summary>
        /// counts how many numbers greater and smaller than first number
        /// </summary>
        /// <param name="i_StringOfNumbers">string to check</param>
        /// <param name="o_NumbersGreaterThanFirst"></param>
        /// <param name="o_NumbersSmallerThanFirst"></param>
        private static void countGreaterAndSmallerNumbers(
            string i_StringOfNumbers, 
            out int o_NumbersGreaterThanFirst, 
            out int o_NumbersSmallerThanFirst)
        {
            int firstNumber = int.Parse(i_StringOfNumbers[0].ToString());
            o_NumbersSmallerThanFirst = 0;
            o_NumbersGreaterThanFirst = 0;

            for (int i = 1; i < i_StringOfNumbers.Length; i++)
            {
                int numberToCompare = int.Parse(i_StringOfNumbers[i].ToString());
                bool digitIsBiggerThanFirst = numberToCompare > firstNumber;
                bool digitIsSmallerThanFirst = numberToCompare < firstNumber;

                if (digitIsBiggerThanFirst)
                {
                    o_NumbersGreaterThanFirst++;
                }
                else if (digitIsSmallerThanFirst)
                {
                    o_NumbersSmallerThanFirst++;
                }
            }
        }

        /// <summary>
        /// Calculates the minimum digit and maximum digit in a string of digits. 
        /// The string must be numbers - not checked in the method.
        /// </summary>
        /// <param name="i_InputString"></param>
        /// <param name="o_MinNumber"></param>
        /// <param name="o_MaxNumber"></param>
        private static void calculateMinAndMaxDigitsInString(string i_InputString, out int o_MinNumber, out int o_MaxNumber)
        {
            char[] inputAsArray = i_InputString.ToCharArray();
            o_MinNumber = int.Parse(inputAsArray[0].ToString());
            o_MaxNumber = int.Parse(inputAsArray[0].ToString());
            for (int i = 0; i < i_InputString.Length; i++)
            {
                o_MaxNumber = Math.Max(o_MaxNumber, int.Parse(inputAsArray[i].ToString()));
                o_MinNumber = Math.Min(o_MinNumber, int.Parse(inputAsArray[i].ToString()));
            }
        }
    }
}
