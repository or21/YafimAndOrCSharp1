using System;
using System.Text;

namespace B15_Ex01_1
{
    public class Program
    {
        public static void Main()
        {
            int[] arrayOfInputs = new int[5];
            int i = 0;
            while (i < 5)
            {   
                Console.WriteLine("Please enter number with 3 digits (and then press enter):");
                string intAsString = Console.ReadLine();
                bool isNumber = int.TryParse(intAsString, out arrayOfInputs[i]);

                if (intAsString != null && ((isNumber) && (intAsString.Length == 3) && (arrayOfInputs[i] > 0))) {
                    i++;
                }
                else {
                    Console.WriteLine("This is not a valid number! let's try again");
                }
            }

            // convert to binary representation
            string[] inputsAsBinaryRepresentation = intToBinary(arrayOfInputs);

            // print binary representation
            foreach (string binRepresentation in inputsAsBinaryRepresentation)
            {
                Console.WriteLine(binRepresentation);
            }
            Console.ReadLine();
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
    }
}
