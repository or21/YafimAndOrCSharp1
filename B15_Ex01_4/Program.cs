using System;

namespace B15_Ex01_4
{
    public class Program
    {
        public static void Main()
        {
            string inputFromUser;

            inputFromUser


        }

        //check if valid string was given
        private static bool isValidString(string i_InputFromUser)
        {
            return i_InputFromUser.Length == 10;
        }

        private static string getInputFromUser(string i_InputFromUser)
        {
            while (true)
            {
                Console.WriteLine("Please enter a string with 10 chars");
                i_InputFromUser = Console.ReadLine();

                if (!isValidString(i_InputFromUser))
                {
                    Console.WriteLine("This is not a valid string! let's try again");
                }
                break;
            }
                return i_InputFromUser;
            
        }
    }
}
