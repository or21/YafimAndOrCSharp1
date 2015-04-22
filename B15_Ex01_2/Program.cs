using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B15_Ex01_2
{
    public class Program
    {
        public static void Main() {

            // creates 5 rows of sand watch
            string result = string.Format(@"*****
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
