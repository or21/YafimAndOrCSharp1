using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B15_Ex01_1
{
    public class Program
    {
        static void Main()
        {
            int[] arrayOfInputs = new int[5];
            string[] inputsAsBinaryRepresentation = new String[5];
            int i = 0;
            while (i < 5)
            {   
                Console.WriteLine("Please enter number with 3 digits (and then press enter):");
                string intAsString = System.Console.ReadLine();
                Boolean isNumber = int.TryParse(intAsString, out arrayOfInputs[i]);

                if ((isNumber) && (intAsString.Length == 3) && (arrayOfInputs[i] > 0)) {
                    i++;
                }
                else {
                    Console.WriteLine("this is not a valid number! let's try again");
                }
            }

            // convert to binary representation
            for (int index = 0; index < arrayOfInputs.Length; index++)
			{
			    string stringRepresentor = null;
                int currentNumberToCovert = arrayOfInputs[index];
                int remainder;
                while (currentNumberToCovert > 0)
                {
                    remainder = currentNumberToCovert % 2;
                    currentNumberToCovert /= 2;
                    stringRepresentor = remainder.ToString() + stringRepresentor;
                }
                inputsAsBinaryRepresentation[index] = stringRepresentor;
			}

            // print binary representation
            foreach (var binRepresentation in inputsAsBinaryRepresentation)
            {
                Console.WriteLine(binRepresentation.ToString());
            }
            System.Console.ReadLine();
        }
    }
}
