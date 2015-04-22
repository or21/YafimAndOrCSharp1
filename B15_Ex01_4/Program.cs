﻿using System;

namespace B15_Ex01_4
{
    public class Program
    {
        static int s_SumOfNumbersInString;
        static int s_SumOfCamelInString;

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

        //check if valid string was given
        private static bool isValidString(string i_InputFromUser, ref int io_SumOfNumbersInString, ref int io_SumOfCamelInString)
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
                        io_SumOfNumbersInString += Convert.ToInt32(numericValue);
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
                        io_SumOfCamelInString++;
                    }
                }
            }

            return isValidString;
        }

        //check if valid english letter [a-Z]
        private static bool isValidChar(char i_CharToCheck)
        {
            return (i_CharToCheck >= 'A' && i_CharToCheck <= 'Z') || (i_CharToCheck >= 'a' && i_CharToCheck <= 'z');
        }


        private static string getInputFromUser()
        {
            string inputFromUser;

            while (true)
            {
                Console.WriteLine("Please enter a string with 10 chars");
                inputFromUser = Console.ReadLine();

                if (isValidString(inputFromUser, ref s_SumOfNumbersInString, ref s_SumOfCamelInString))
                {
                    break;
                }
                Console.WriteLine("Invalid Input! Try again...");
            }

            return inputFromUser;
        }

        // reverse string
        private static string reverseString(string i_String)
        {
            char[] reversedString = i_String.ToCharArray();
            Array.Reverse(reversedString);

            return new string(reversedString);
        }

        private static bool isPalindrome(string i_String)
        {
            string reversedString = reverseString(i_String);

            return reversedString.Equals(i_String);
        }
    }
}
