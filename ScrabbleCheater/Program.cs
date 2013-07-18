using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ScrabbleCheater
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        //[STAThread]
        static void Main(string[] args)
        {
            Dictionary<string, int> letters = new Dictionary<string, int>()
                {
                    {"a",1}, {"b",4}, {"c",4}, {"d",2}, {"e",1}, {"f",4}, {"g",3}, {"h",3}, {"i",1}, {"j",10}, {"k",5}, {"l",2}, {"m",4}, 
                    {"n",2}, {"o",1}, {"p",4}, {"q",10}, {"r",1}, {"s",1}, {"t",1}, {"u",2}, {"v",5}, {"w",4}, {"x",8}, {"y",3}, {"z",10}, 
                };

            

            List<string> asdf = new List<string>();
            List<string> results;
            asdf.Add("a");
            asdf.Add("b");
            asdf.Add("c");
            ScrabbleCheater.Solver solve = new Solver(new ScrabbleBoard(new string[5, 2], asdf,letters));
            results = solve.GetPossibleCombinations("", asdf);
            /**foreach (string el in results)
            {
                Console.WriteLine(el);
            }**/

            Console.WriteLine("Hello?");
            
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new ScrabbleUI());
        }
    }
}
