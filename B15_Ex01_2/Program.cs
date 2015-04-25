//-----------------------------------------------------------------------
// <copyright file="Program.cs" company="B15_Ex01_2">
// Yafim Vodkov 308973882 Or Brand 302521034
// </copyright>
//-----------------------------------------------------------------------
using System;

namespace B15_Ex01_2
{
    /// <summary>
    /// Problem 2
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Runs the program
        /// </summary>
        public static void Main() 
        {
            // creates 5 rows of sand watch
            string result = string.Format(
@"*****
 ***
  *
 ***
*****");
            Console.WriteLine(result);
            Console.WriteLine("Press enter to exit");
            Console.ReadLine();
        }
    }
}
