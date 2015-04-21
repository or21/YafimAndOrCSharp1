using System;
using System.Text;

namespace B15_Ex01_1
{
    public class Program
    {
        public static void Main()
        {
            int numberOfInputs = 5;
            int[] arrayOfInputs;
            int numberOfIncreasingNumbers = 0;
            int numberOfDecreasingNumbers = 0;
            bool increasing = true;

            // get the input from the user
            getInputFromUser(numberOfInputs, out arrayOfInputs);

            // convert to binary representation
            string[] inputsAsBinaryRepresentation = intToBinary(arrayOfInputs);

            // finds number of increasing numbers
            for (int i = 0; i < numberOfInputs; i++)
            {
                if (isStritclySequecne(arrayOfInputs[i], increasing))
                {
                    numberOfIncreasingNumbers++;
                }
            }
            for (int i = 0; i < numberOfInputs; i++)
            {
                if (isStritclySequecne(arrayOfInputs[i], !increasing))
                {
                    numberOfDecreasingNumbers++;
                }
            }


            // print binary representation
            foreach (string binRepresentation in inputsAsBinaryRepresentation)
            {
                Console.WriteLine(binRepresentation);
            }
            Console.WriteLine("Number of increasing numbers: {0}", numberOfIncreasingNumbers);
            Console.WriteLine("Number of increasing numbers: {0}", numberOfDecreasingNumbers);
            Console.ReadLine();
        }

        // ReSharper disable once InconsistentNaming
        private static void getInputFromUser(int i_NumberOfInputs, out int[] o_ArrayOfInputs)
        {
            int i = 0;
            o_ArrayOfInputs = new int[i_NumberOfInputs];

            Console.WriteLine("Please enter 5 numbers with 3 digits each (press enter after each one):");
            while (i < i_NumberOfInputs)
            {
                string intAsString = Console.ReadLine();
                bool isNumber = int.TryParse(intAsString, out o_ArrayOfInputs[i]);

                if (intAsString != null && ((isNumber) && (intAsString.Length == 3) && (o_ArrayOfInputs[i] > 0)))
                {
                    i++;
                }
                else
                {
                    Console.WriteLine("This is not a valid number! let's try again");
                }
            }
        }

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

        private static bool isStritclySequecne(int i_NumberToCheck, bool i_Operation)
        {
            int previousDigit = i_NumberToCheck % 10;
            i_NumberToCheck /= 10;
            while (i_NumberToCheck > 0)
            {
                
                int currentDigit = i_NumberToCheck % 10;
                if (i_Operation)
                {
                    if (previousDigit > currentDigit)
                    {
                        previousDigit = currentDigit;
                        i_NumberToCheck /= 10;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    if (previousDigit < currentDigit)
                    {
                        previousDigit = currentDigit;
                        i_NumberToCheck /= 10;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}
