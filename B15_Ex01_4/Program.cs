//-----------------------------------------------------------------------
// <copyright file="Program.cs" company="B15_Ex01_4">
// Yafim Vodkov 308973882 Or Brand 302521034
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
        private static int s_sumOfNumbersInString;

        /// <summary>
        /// sum of all camel cases in string
        /// </summary>
        private static int s_sumOfCamelInString;

        /// <summary>
        /// runs the program
        /// </summary>
        public static void Main()
        {
            string inputFromUser = getInputFromUser();

            string resultOfProgram = string.Format(
@"Does the program is palindroime: {0}.
The sum of the digits if the input contains just digits: {1}.
The amount of chars that are camel case if the input contains just letters: {2}.",
            isPalindrome(inputFromUser),
            s_sumOfNumbersInString,
            s_sumOfCamelInString);

            Console.WriteLine(resultOfProgram);
            Console.WriteLine("Please press 'Enter' to exit...");
            Console.ReadLine();
        }

        /// <summary>
        /// check if valid string was given. if valid, sum all camel cases / numbers in it.
        /// </summary>
        /// <param name="i_InputFromUser">string to check</param>
        /// <returns>true if valid string</returns>
        private static bool isValidString(string i_InputFromUser)
        {
            bool isValidString = false;
            bool validLength = i_InputFromUser.Length == 10;
            if (validLength)
            {
                isValidString = true;

                // determine what first char is
                bool containsNumbers = char.IsNumber(i_InputFromUser[0]);

                for (int i = 0; i < 10 && isValidString; i++)
                {
                    // if contains only numbers, sum them. Otherwise error.
                    if (containsNumbers)
                    {
                        bool charIsNumer = char.IsNumber(i_InputFromUser[i]);
                        if (charIsNumer)
                        {
                            s_sumOfNumbersInString += int.Parse(i_InputFromUser[i].ToString());
                        }
                        else
                        {
                            isValidString = false;
                            break;
                        }
                    }
                    else
                    {
                        isValidString = isValidChar(i_InputFromUser[i]);
                        bool charIsUpperCase = char.IsUpper(i_InputFromUser[i]);

                        // sum all the camel cases in string.
                        if (charIsUpperCase)
                        {
                            s_sumOfCamelInString++;
                        }
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
            return (i_CharToCheck >= 'A' && 
                i_CharToCheck <= 'Z') ||
                (i_CharToCheck >= 'a' && 
                i_CharToCheck <= 'z');
        }

        /// <summary>
        /// get input from the user.
        /// </summary>
        /// <returns>input from user</returns>
        private static string getInputFromUser()
        {
            string inputFromUser;
            const bool v_GettingInput = true;
            while (v_GettingInput)
            {
                Console.WriteLine("Please enter a string with 10 chars");
                inputFromUser = Console.ReadLine();
                bool checkIfStringIsValid = isValidString(inputFromUser);
                if (checkIfStringIsValid)
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
