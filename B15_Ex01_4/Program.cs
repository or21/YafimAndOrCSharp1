using System;

namespace B15_Ex01_4
{
    public class Program
    {
        static int sumOfNumbersInString;
        static int sumOfCamelInString;

        public static void Main()
        {
            string inputFromUser;

            inputFromUser = getInputFromUser();

            Console.WriteLine("{0}", isPalindrome(inputFromUser));
            Console.WriteLine("Sum of Digits: {0}", sumOfNumbersInString);
            Console.WriteLine("Sum of Chars: {0}", sumOfCamelInString);
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
            bool containsNumbers = Char.IsNumber(i_InputFromUser[1]);
            
            for (int i = 0; i < 10 && isValidString; i++)
            {
                if (containsNumbers)
                {
                    if (Char.IsNumber(i_InputFromUser[i]))
                    {
                        isValidString = true;
                        double numericValue = Char.GetNumericValue(i_InputFromUser[i]);
                        io_SumOfNumbersInString += Convert.ToInt32(numericValue);
                    }
                }
                else
                {
                    isValidString = isValidChar(i_InputFromUser[i]);

                    if (Char.IsUpper(i_InputFromUser[i]))
                    {
                        io_SumOfCamelInString++;
                    }
                }
            }
            return isValidString;
        }

        //check if valid english letter [a-Z]
        private static bool isValidChar(char i_charToCheck)
        {
            return (i_charToCheck >= 'A' && i_charToCheck <= 'Z') || (i_charToCheck >= 'a' && i_charToCheck <= 'z');
        }

        
        private static string getInputFromUser()
        {
            string i_InputFromUser;

            while (true)
            {
                Console.WriteLine("Please enter a string with 10 chars");
                i_InputFromUser = Console.ReadLine();

                if (isValidString(i_InputFromUser, ref sumOfNumbersInString, ref sumOfCamelInString))
                {
                    break;
                }
                Console.WriteLine("Invalid Input! Try again...");
                
            }
                return i_InputFromUser;
            
        }

        //reverse string
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
