using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {

        private static void showMatch(string text, string expr, string exprName)
        {
            Console.WriteLine(exprName + " " + expr);
            MatchCollection mc = Regex.Matches(text,expr);
            Console.WriteLine(mc.Count + "\n");
            foreach (Match m in mc)
            {
                Console.WriteLine(m);
            }
        }
        static void Main(string[] args)
        {
            string[,] regexList = new string[,]
            {
                //{ @"[a-z0-9_-]{3,16}", "Username" },
                //{ @"[a-z0-9_-]{6,18}", "Password"},
                //{@"#?([a-f0-9]{6}|[a-f0-9]{3})", "Hex" },
                //{@"[a-z0-9-]+", "Slug" },
                { @"([a-z0-9_\.-]+)@([\da-z\.-]+)\.([a-z\.]{2,6})", "Email" },
                { @"(https?:\/\/)?([\da-z\.-]+)\.([a-z\.]{2,6})([\/\w \.-]*)*\/?", "URL" }, 
                {@"(?:(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.){3}(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)", "IP Address" }, 
                { @"<([a-z]+)([^<]+)*(?:>(.*)<\/\1>|\s+\/>)", "HTML Tag"}
                
            };
            string text = System.IO.File.ReadAllText(@"input.txt");

            // Display the file contents to the console. Variable text is a string.
            System.Console.WriteLine(text+"\n\n");

            Console.WriteLine("Matching");            
            for (int i = 0; i < regexList.GetLength(0); i++)
            {
                //Console.WriteLine(regexList[i]);
                showMatch(text, regexList[i,0], regexList[i, 1]);
                Console.WriteLine();
            }
            Console.ReadKey();
        }

    }
}
