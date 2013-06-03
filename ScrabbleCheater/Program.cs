using System;
using System.Collections.Generic;
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
            Console.WriteLine("hello.\n");
            List<string> asdf = new List<string>();
            List<string> results;
            asdf.Add("a");
            asdf.Add("b");
            asdf.Add("C");
            ScrabbleCheater.Solver solve = new Solver(new ScrabbleBoard(new string[5, 2]));
            results = solve.GetPossibleCombinations("", asdf);
            foreach (string el in results)
            {
                Console.WriteLine(el);
            }
            /**
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());**/
        }
    }
}
