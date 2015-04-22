//-----------------------------------------------------------------------
// <copyright file="Program.cs" company="B15_Ex01_1">
// Yafim Vodkov 308973882 Or Brand id
// </copyright>
//-----------------------------------------------------------------------
using System;
using System.Linq;
using System.Text;

namespace B15_Ex01_1
{
    /// <summary>
    /// Problem 1
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Runs the program.
        /// </summary>
        public static void Main()
        {
            int numberOfInputs = 5;
            int[] arrayOfInputs;
            int numberOfIncreasingNumbers = 0;
            int numberOfDecreasingNumbers = 0;
            decimal avarageOfinputs = 0;
            const bool v_Increasing = true;
            int totalNumberOfBinaryDigits = 0;
            decimal avarageBinaryDigits = 0;

            // get the input from the user
            getInputFromUser(numberOfInputs, out arrayOfInputs);

            // convert to binary representation
            string[] inputsAsBinaryRepresentation = intToBinary(arrayOfInputs);

            // finds number of ascending sequences
            for (int i = 0; i < numberOfInputs; i++)
            {
                if (isStrictlySequecne(arrayOfInputs[i], v_Increasing))
                {
                    numberOfIncreasingNumbers++;
                }
            }

            // finds number of descending sequences
            for (int i = 0; i < numberOfInputs; i++)
            {
                if (isStrictlySequecne(arrayOfInputs[i], !v_Increasing))
                {
                    numberOfDecreasingNumbers++;
                }
            }

            // calculates the avarage of the input numbers
            if (arrayOfInputs != null)
            {
                avarageOfinputs = (decimal) arrayOfInputs.Sum() / arrayOfInputs.Length;
            }

            // count number of binary digits
            for (int i = 0; i < numberOfInputs; i++)
            {
                totalNumberOfBinaryDigits += inputsAsBinaryRepresentation[i].Length;
                if (i + 1 == numberOfInputs)
                {
                    avarageBinaryDigits = (decimal) totalNumberOfBinaryDigits / numberOfInputs;
                }
            }

            // create the result that will be printed to the screen
            string resultOfProgram = string.Format(@"The binary numbers are: {0} {1} {2} {3} {4}.
There are {5} numbers which are an ascending series and {6} which are descending.
The general avarege of the inserted numbers is {7}.
The avarege number of digits in the binary number is {8}.", inputsAsBinaryRepresentation[0], inputsAsBinaryRepresentation[1], 
                                                          inputsAsBinaryRepresentation[2], inputsAsBinaryRepresentation[3], 
                                                          inputsAsBinaryRepresentation[4], numberOfIncreasingNumbers, 
                                                          numberOfDecreasingNumbers, avarageOfinputs, avarageBinaryDigits);
            Console.WriteLine(resultOfProgram);
            Console.WriteLine("Please press 'Enter' to exit...");
            Console.ReadLine();
        }

        /// <summary>
        /// This method receives i_NumberOfInputs of 3 digits numbers and return them as array of integers
        /// </summary>
        /// <param name="i_NumberOfInputs">number of inputs</param>
        /// <param name="o_ArrayOfInputs">the array of inputs</param>
        private static void getInputFromUser(int i_NumberOfInputs, out int[] o_ArrayOfInputs)
        {
            int i = 0;
            o_ArrayOfInputs = new int[i_NumberOfInputs];

            Console.WriteLine("Please enter 5 numbers with 3 digits each (press enter after each one):");
            while (i < i_NumberOfInputs)
            {
                string intAsString = Console.ReadLine();
                bool isNumber = int.TryParse(intAsString, out o_ArrayOfInputs[i]);

                if (intAsString != null && (isNumber && (intAsString.Length == 3) && (o_ArrayOfInputs[i] > 0)))
                {
                    i++;
                }
                else
                {
                    Console.WriteLine("This is not a valid number! let's try again");
                }
            }
        }

        /// <summary>
        /// This method receives an array of integers and return an array of strings of their binary forms
        /// </summary>
        /// <param name="i_ArrayOfInputs">array of inputs</param>
        /// <returns>string as binary form</returns>
        private static string[] intToBinary(int[] i_ArrayOfInputs)
        {
            string[] inputsAsBinaryRepresentation = new string[i_ArrayOfInputs.Length];
            for (int i = 0; i < i_ArrayOfInputs.Length; i++)
            {
                StringBuilder stringRepresentor = new StringBuilder();
                int currentNumberToConvert = i_ArrayOfInputs[i];
                while (currentNumberToConvert > 0)
                {
                    int remainder = currentNumberToConvert % 2;
                    currentNumberToConvert /= 2;
                    stringRepresentor.Insert(0, remainder.ToString());
                }

                inputsAsBinaryRepresentation[i] = stringRepresentor.ToString();
            }

            return inputsAsBinaryRepresentation;
        }

        /// <summary>
        /// This method checks according to the i_Operation if a 3 digits number is Ascending to Descending series
        /// If i_Operation is true the method will look for strictly Ascending series.
        /// If i_Operation is false the method will look for strictly Descending series.
        /// </summary>
        /// <param name="i_NumberToCheck">The number to check</param>
        /// <param name="i_Operation">flag for operation</param>
        /// <returns>if ascending or descending series</returns>
        private static bool isStrictlySequecne(int i_NumberToCheck, bool i_Operation)
        {
            int[] numberAsArray = numberToIntArray(i_NumberToCheck);
            int previousDigit = numberAsArray[0];

            for (int i = 1; i < numberAsArray.Length; i++)
            {
                int currentDigit = numberAsArray[i];
                if (i_Operation)
                {
                    if (!(previousDigit > currentDigit))
                    {
                        return false;
                    }
                }
                else
                {
                    if (!(previousDigit < currentDigit))
                    {
                        return false;
                    }
                }

                previousDigit = currentDigit;
            }

            return true;
        }

        /// <summary>
        /// This method convert an integer to array of 3 integers where each element represent a digit in the number
        /// </summary>
        /// <param name="i_NumberToCheck">number to check</param>
        /// <returns>integer array of binary numbers</returns>
        private static int[] numberToIntArray(int i_NumberToCheck)
        {
            int[] numberAsArray = new int[3];
            for (int i = 0; i < 3; i++)
            {
                numberAsArray[i] = i_NumberToCheck % 10;
                i_NumberToCheck /= 10;
            }

            return numberAsArray;
        }
    }
}
