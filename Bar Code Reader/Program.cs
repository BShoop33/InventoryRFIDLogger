using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace Bar_Code_Reader
{
    class Program
    {
        static void Main(string[] args)
        {

            string file = @"C:\Users\braxt\Desktop\Test.txt";


            //using (StreamWriter sw = File.AppendText(file))
            //{
            //    sw.WriteLine("This");
            //    sw.WriteLine("is Extra");
            //    sw.WriteLine("Text");
            //}


            // Read the file as one string.
            string output = File.ReadAllText(file);

            //List<string> listOfStrings = new List<string>();
            //listOfStrings.Add(output);


            List<string> listOfStrings = new List<string>();
            string[] bear = output.Split('e');


            foreach (var sub in bear)
            {
                Console.WriteLine(sub);
            }


            // Display the file contents to the console. Variable text is a string.
            //Console.WriteLine(bear);
        }
    }
}
