//-----------------------------------------------------------------------
// <copyright file="Program.cs" company="B15_Ex01_5">
// Yafim Vodkov 308973882 Or Brand id
// </copyright>
//-----------------------------------------------------------------------
using System;
using System.Linq;

namespace B15_Ex01_5
{
    /// <summary>
    /// Problem 5
    /// </summary>
    public class Program
    {
        /// <summary>
        /// how many numbers are greater than the first number in the strings
        /// </summary>
        private static int s_NumbersGreaterThanFirst = 0;

        /// <summary>
        /// how many numbers are smaller than the first number in the strings
        /// </summary>
        private static int s_NumbersSmallerThanFirst = 0;
        
        /// <summary>
        /// runs the program.
        /// </summary>
        public static void Main()
        {
            string inputFromUser = getInput();
            countGreaterAndSmallerNumbers(inputFromUser);

            // input user is valid, get minimum and maximum values from it.
            char minValue = inputFromUser.Min();
            char maxValue = inputFromUser.Max();

            Console.WriteLine("Number Greater than 1st: {0} ", s_NumbersGreaterThanFirst);
            Console.WriteLine("Number Smaller than 1st: {0} ", s_NumbersSmallerThanFirst);
            Console.WriteLine("The min value is       : {0} ", minValue);
            Console.WriteLine("The max value is       : {0} ", maxValue);
            Console.ReadLine();
        }

        /// <summary>
        /// get input from the user
        /// </summary>
        /// <returns> valid 8 digit string </returns>
        private static string getInput()
        {
            string inputFromUser;

            while (true)
            {
                Console.WriteLine("Please enter 8 digit string: ");
                inputFromUser = Console.ReadLine();

                if (isValidString(inputFromUser))
                {
                    break;
                }

                Console.WriteLine("Invalid input! please try again...");
            }

            return inputFromUser;
        }

        /// <summary>
        /// check if valid string was given
        /// </summary>
        /// <param name="i_StringToCheck">string to check</param>
        /// <returns> true if valid string</returns>
        private static bool isValidString(string i_StringToCheck)
        {
            return i_StringToCheck.Length == 8 && containsOnlyNumbers(i_StringToCheck);
        }

        /// <summary>
        /// check if string contains only numbers
        /// </summary>
        /// <param name="i_StringToCheck">string to check</param>
        /// <returns> true if contains only numbers </returns>
        private static bool containsOnlyNumbers(string i_StringToCheck)
        {
            bool isNumber = false;

            for (int i = 0; i < i_StringToCheck.Length; i++)
            {
                isNumber = char.IsNumber(i_StringToCheck[i]);
            }

            return isNumber;
        }

        /// <summary>
        /// counts how many numbers greater and smaller than first number
        /// </summary>
        /// <param name="i_StringOfNumbers">string to check</param>
        private static void countGreaterAndSmallerNumbers(string i_StringOfNumbers)
        {
            int numberToCompare;
            int firstNumber = getNumValue(i_StringOfNumbers[0]);

            for (int i = 1; i < i_StringOfNumbers.Length; i++)
            {
                numberToCompare = getNumValue(i_StringOfNumbers[i]);

                if (numberToCompare > firstNumber)
                {
                      s_NumbersGreaterThanFirst++;
                }
                else if (numberToCompare < firstNumber)
                {
                      s_NumbersSmallerThanFirst++;
                }
            }
        }

        /// <summary>
        /// get numerical value from char
        /// </summary>
        /// <param name="i_CharToNumericValue">char to convert</param>
        /// <returns> char to integer </returns>
        private static int getNumValue(char i_CharToNumericValue)
        {
            double numericValue = char.GetNumericValue(i_CharToNumericValue);
            return Convert.ToInt32(numericValue);
        }
    }
}
