using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GAZ.CSC2022.testconsole
{
    class Program
    {
        static void Main(string[] args)
        {
            // Buffer to hold a line as it is read in
            string line;

            // Loop until no more input (Ctrl-Z in a console, or end-of-file)
            while ((line = Console.ReadLine()) != null)
            {
                // Write the results out to the console window
                Console.WriteLine(line);
            }


        }
    }
}
