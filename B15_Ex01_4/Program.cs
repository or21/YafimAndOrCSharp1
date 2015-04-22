//-----------------------------------------------------------------------
// <copyright file="Program.cs" company="B15_Ex01_4">
// Yafim Vodkov 308973882 Or Brand id
// </copyright>
//-----------------------------------------------------------------------
using System;

namespace B15_Ex01_4
{
    /// <summary>
    /// Problem 4
    /// </summary>
    public class Program
    {
        /// <summary>
        /// sum of all numbers in string
        /// </summary>
        private static int s_SumOfNumbersInString;

        /// <summary>
        /// sum of all camel cases in string
        /// </summary>
        private static int s_SumOfCamelInString;

        /// <summary>
        /// runs the program
        /// </summary>
        public static void Main()
        {
            string inputFromUser = getInputFromUser();

            string resultOfProgram = string.Format(@"Does the program is palindroime: {0}.
The sum of the digits if the input contains just digits: {1}.
The amount of chars that are camel case if the input contains just letters: {2}.", 
            isPalindrome(inputFromUser), s_SumOfNumbersInString, s_SumOfCamelInString);
            
            Console.WriteLine(resultOfProgram);
            Console.WriteLine("Please press 'Enter' to exit...");
            Console.ReadLine();
        }

        /// <summary>
        /// check if valid string was given
        /// </summary>
        /// <param name="i_InputFromUser">string to check</param>
        /// <returns>true if valid string</returns>
        private static bool isValidString(string i_InputFromUser)
        {
            if (i_InputFromUser.Length != 10)
            {
                return false;
            }

            bool isValidString = true;
            bool containsNumbers = char.IsNumber(i_InputFromUser[0]);

            for (int i = 0; i < 10 && isValidString; i++)
            {
                if (containsNumbers)
                {
                    if (char.IsNumber(i_InputFromUser[i]))
                    {
                        double numericValue = char.GetNumericValue(i_InputFromUser[i]);
                        s_SumOfNumbersInString += Convert.ToInt32(numericValue);
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    isValidString = isValidChar(i_InputFromUser[i]);

                    if (char.IsUpper(i_InputFromUser[i]))
                    {
                        s_SumOfCamelInString++;
                    }
                }
            }

            return isValidString;
        }

        /// <summary>
        /// check if valid english letter [a-Z]
        /// </summary>
        /// <param name="i_CharToCheck">char to check</param>
        /// <returns>true if valid</returns>
        private static bool isValidChar(char i_CharToCheck)
        {
            return (i_CharToCheck >= 'A' && i_CharToCheck <= 'Z') || (i_CharToCheck >= 'a' && i_CharToCheck <= 'z');
        }

        /// <summary>
        /// get input from the user.
        /// </summary>
        /// <returns>input from user</returns>
        private static string getInputFromUser()
        {
            string inputFromUser;

            while (true)
            {
                Console.WriteLine("Please enter a string with 10 chars");
                inputFromUser = Console.ReadLine();

                if (isValidString(inputFromUser))
                {
                    break;
                }

                Console.WriteLine("Invalid Input! Try again...");
            }

            return inputFromUser;
        }

        /// <summary>
        /// reverse string
        /// </summary>
        /// <param name="i_String">string to reverse</param>
        /// <returns>reversed string</returns>
        private static string reverseString(string i_String)
        {
            char[] reversedString = i_String.ToCharArray();
            Array.Reverse(reversedString);

            return new string(reversedString);
        }

        /// <summary>
        /// check if palindrome
        /// </summary>
        /// <param name="i_String">string to check</param>
        /// <returns>true if palindrome</returns>
        private static bool isPalindrome(string i_String)
        {
            string reversedString = reverseString(i_String);
            return reversedString.Equals(i_String);
        }
    }
}
