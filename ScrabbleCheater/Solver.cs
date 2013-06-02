using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScrabbleCheater
{
    class Solver
    {
        List<string> dictionary;
        ScrabbleBoard board;

        public Solver(ScrabbleBoard board, List<string> dictionary)
        {
            this.board = board;
            this.dictionary = dictionary;
        }

        public string[] GetBestPlay(string[,] board, List<string> hand)
        {
            return new string[3];
        }

        private List<string[]> getMovesInArray(ScrabbleBoard board, List<string> hand, string[] rowOrCol, bool col)
        {
            List<string[]> moves = new List<string[]>();
            List<string> dicopy = new List<string>(dictionary);
            foreach (string word in dicopy)
            {

            }

            return moves;
        }
    }
}
