//-----------------------------------------------------------------------
// <copyright file="Program.cs" company="B15_Ex01_1">
// Yafim Vodkov 308973882 Or Brand 302521034
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
            int numberOfIncreasingNumbers;
            int numberOfDecreasingNumbers;
            decimal avarageOfinputs = 0;
            decimal avarageBinaryDigits;

            // get the input from the user
            getInputFromUser(numberOfInputs, out arrayOfInputs);

            // convert to binary representation
            string[] inputsAsBinaryRepresentation = intToBinary(arrayOfInputs);
            numberOfAscendingNumbers(numberOfInputs, arrayOfInputs, out numberOfIncreasingNumbers);
            numberOfDescendingNumbers(numberOfInputs, arrayOfInputs, out numberOfDecreasingNumbers);

            // calculates the avarage of the input numbers
            bool arrayIsNull = arrayOfInputs == null;
            if (!arrayIsNull)
            {
                avarageOfinputs = (decimal) arrayOfInputs.Sum() / arrayOfInputs.Length;
            }

            avarageNumberOfBinaryDigits(numberOfInputs, inputsAsBinaryRepresentation, out avarageBinaryDigits);
            printResult(
                inputsAsBinaryRepresentation, 
                numberOfIncreasingNumbers, 
                numberOfDecreasingNumbers, 
                avarageOfinputs, 
                avarageBinaryDigits);
        }

        /// <summary>
        /// create the result that will be printed to the screen
        /// </summary>
        /// <param name="i_InputsAsBinaryRepresentation"></param>
        /// <param name="i_NumberOfIncreasingNumbers"></param>
        /// <param name="i_NumberOfDecreasingNumbers"></param>
        /// <param name="i_AvarageOfinputs"></param>
        /// <param name="i_AvarageBinaryDigits"></param>
        private static void printResult(
            string[] i_InputsAsBinaryRepresentation, 
            int i_NumberOfIncreasingNumbers, 
            int i_NumberOfDecreasingNumbers, 
            decimal i_AvarageOfinputs, 
            decimal i_AvarageBinaryDigits)
        {
            string resultOfProgram = string.Format(
@"The binary numbers are: {0} {1} {2} {3} {4}.
There are {5} numbers which are an ascending series and {6} which are descending.
The general avarege of the inserted numbers is {7}.
The avarege number of digits in the binary number is {8}.",
                i_InputsAsBinaryRepresentation[0],
                i_InputsAsBinaryRepresentation[1],
                i_InputsAsBinaryRepresentation[2],
                i_InputsAsBinaryRepresentation[3],
                i_InputsAsBinaryRepresentation[4],
                i_NumberOfIncreasingNumbers,
                i_NumberOfDecreasingNumbers,
                i_AvarageOfinputs,
                i_AvarageBinaryDigits);

            Console.WriteLine(resultOfProgram);
            Console.WriteLine("Please press 'Enter' to exit...");
            Console.ReadLine();
        }

        /// <summary>
        /// Count number of binary digits
        /// </summary>
        /// <param name="i_NumberOfInputs">The amount of inputs the user has entered</param>
        /// <param name="i_InputsAsBinaryRepresentation">The users input as a binary representation</param>
        /// <param name="o_AvarageBinaryDigits">The average amount of digits in the binary formated numbers</param>
        private static void avarageNumberOfBinaryDigits(
            int i_NumberOfInputs, 
            string[] i_InputsAsBinaryRepresentation, 
            out decimal o_AvarageBinaryDigits)
        {
            o_AvarageBinaryDigits = 0;
            int totalNumberOfBinaryDigits = 0;
            for (int index = 0; index < i_NumberOfInputs; index++)
            {
                totalNumberOfBinaryDigits += i_InputsAsBinaryRepresentation[index].Length;
                bool numberOfInputsIsIPlusOne = index + 1 == i_NumberOfInputs;
                if (numberOfInputsIsIPlusOne)
                {
                    o_AvarageBinaryDigits = (decimal)totalNumberOfBinaryDigits / i_NumberOfInputs;
                }
            }
        }

        /// <summary>
        /// finds number of descending sequences
        /// </summary>
        /// <param name="i_NumberOfInputs"></param>
        /// <param name="i_ArrayOfInputs"></param>
        /// <param name="o_NumberOfDecreasingNumbers"></param>
        private static void numberOfDescendingNumbers(
            int i_NumberOfInputs, 
            int[] i_ArrayOfInputs, 
            out int o_NumberOfDecreasingNumbers)
        {
            o_NumberOfDecreasingNumbers = 0;
            const bool v_Ascending = false;
            for (int i = 0; i < i_NumberOfInputs; i++)
            {
                bool isSequence = isStrictlySequecne(i_ArrayOfInputs[i], v_Ascending);
                if (isSequence)
                {
                    o_NumberOfDecreasingNumbers++;
                }
            }
        }

        /// <summary>
        ///  finds number of ascending sequences
        /// </summary>
        /// <param name="i_NumberOfInputs"></param>
        /// <param name="i_ArrayOfInputs"></param>
        /// <param name="o_NumberOfIncreasingNumbers"></param>
        /// <returns></returns>
        private static void numberOfAscendingNumbers(
            int i_NumberOfInputs, 
            int[] i_ArrayOfInputs, 
            out int o_NumberOfIncreasingNumbers)
        {
            o_NumberOfIncreasingNumbers = 0;
            const bool v_Ascending = true;
            for (int i = 0; i < i_NumberOfInputs; i++)
            {
                bool isSequence = isStrictlySequecne(i_ArrayOfInputs[i], v_Ascending);
                if (isSequence)
                {
                    o_NumberOfIncreasingNumbers++;
                }
            }
        }

        /// <summary>
        /// This method receives i_NumberOfInputs of 3 digits numbers and return them as array of integers
        /// </summary>
        /// <param name="i_NumberOfInputs">number of inputs</param>
        /// <param name="o_ArrayOfInputs">the array of inputs</param>
        private static void getInputFromUser(int i_NumberOfInputs, out int[] o_ArrayOfInputs)
        {
            int totalUserInputs = 0;
            o_ArrayOfInputs = new int[i_NumberOfInputs];

            Console.WriteLine("Please enter 5 numbers with 3 digits each (press enter after each one):");
            while (totalUserInputs < i_NumberOfInputs)
            {
                string intAsString = Console.ReadLine();
                bool isNumber = int.TryParse(intAsString, out o_ArrayOfInputs[totalUserInputs]);
                bool isValidNumber = intAsString != null &&
                                     isNumber && 
                                     intAsString.Length == 3 && 
                                     o_ArrayOfInputs[totalUserInputs] > 0;

                if (isValidNumber)
                {
                    totalUserInputs++;
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
            bool returnValue = true;

            for (int i = 1; i < numberAsArray.Length; i++)
            {
                int currentDigit = numberAsArray[i];
                
                // defines the operation and the expected result
                bool checkAscenOrDesc = (i_Operation && 
                    (!(previousDigit > currentDigit))) ||
                    (!i_Operation && 
                    (!(previousDigit < currentDigit)));
                
                // if the condition is true it means that the sequence is not stricty asending or descening
                if (checkAscenOrDesc)
                {
                    returnValue = false;
                    break;
                }

                previousDigit = currentDigit;
            }

            return returnValue;
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
