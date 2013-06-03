using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScrabbleCheater
{
    public class Solver
    {

        List<string> dictionary;
        ScrabbleBoard board;

        public Solver(ScrabbleBoard board)
        {
            this.board = board;
            string[] lines = System.IO.File.ReadAllLines("WWFDictionary.txt");
            dictionary = new List<string>();
            foreach (string s in lines)
            {
                dictionary.Add(s);
            }
        }

        public object[] GetBestPlay(string[,] board, List<string> hand)
        {
            return new object[3];
        }

        
        private List<object[]> GetMovesInArray(ScrabbleBoard board, List<string> hand, string[] rowOrCol, bool col)
        {
            List<object[]> moves = new List<object[]>();

            return moves;
        }

        /// <summary>
        /// Gets all words that are made up of at least one part of two lists of strings
        /// </summary>
        /// <param name="hand">Players hand, only made up of length 1 strings</param>
        /// <param name="board">Strings that were on the board of length 1</param>
        /// <returns></returns>
        public List<string> GetPossibleWordsForRow(List<string> hand, List<string> board)
        {
            List<string> handCopy, boardCopy, possibleWords;
            possibleWords = new List<string>();
            string wordSeg;
            bool inHand, onBoard;
            foreach (string word in dictionary)
            {
                string wordCopy = new String(word.ToCharArray());
                handCopy = new List<string>(hand);
                boardCopy = new List<string>(board);
                inHand = false;
                onBoard = false;
                while (wordCopy.Length > 0)
                {
                    wordSeg = wordCopy.Substring(0, 1);
                    wordCopy = wordCopy.Substring(1);
                    //sets onBoard to true if that letter is on the board and either inHand is true already
                    //or it is not in the hand
                    if ((board.Contains(wordSeg) && !hand.Contains(wordSeg)) || (board.Contains(wordSeg) && inHand))
                    {
                        onBoard = true;
                    }
                    if (hand.Contains(wordSeg)) //sets inHand to true if that letter is in the hand
                    {
                        inHand = true;
                    }

                    if (handCopy.Contains(wordSeg))
                    {
                        handCopy.Remove(wordSeg);
                    }
                    else if (boardCopy.Contains(wordSeg))
                    {
                        boardCopy.Remove(wordSeg);
                    }
                    else
                    {
                        break;
                    }

                    if (wordCopy.Length == 0 && onBoard && inHand)
                    {
                        possibleWords.Add(word);
                        System.Diagnostics.Debug.WriteLine(word);
                    }

                }
            }
            return possibleWords;
        }

        /// <summary>
        /// Gets all possible ways to append a string with a list of of strings
        /// </summary>
        /// <param name="foundation">String to be appended</param>
        /// <param name="elements">Possible parts of appendation</param>
        /// <returns>All possible ways to append a string with a list of of strings</returns>
        public List<string> GetPossibleCombinations(string foundation, List<string> elements)
        {
            List<string> combinations = new List<string>();
            List<string> elementsCopy;
            foreach (string element in elements)
            {
                combinations.Add(foundation + element);
                if (elements.Count > 1)
                {
                    elementsCopy = new List<string>(elements);
                    elementsCopy.Remove(element);
                    foreach (string newCombo in GetPossibleCombinations(foundation + element, elementsCopy))
                    {
                        combinations.Add(newCombo);
                    }
                }
            }

            return combinations;
        }

    }
}
