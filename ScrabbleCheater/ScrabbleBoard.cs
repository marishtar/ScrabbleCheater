using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScrabbleCheater
{
    class ScrabbleBoard
    {
        private string[,] lettersOnBoard;
        private string[,] baseBoard;
        private Hashtable letterValues;

        
        public ScrabbleBoard(string[,] baseBoard)
        {
            this.baseBoard = baseBoard;
            this.lettersOnBoard = new string[baseBoard.GetLength(0), baseBoard.GetLength(1)];
        }

        /// <summary>
        /// Places a letter on the board, and removes multiplier on that spot.
        /// </summary>
        /// <param name="letter">Letter to be placed</param>
        /// <param name="col">Column for the letter to be placed in</param>
        /// <param name="row">Row for the letter to be placed in</param>
        public void PlaceLetter(string letter, int col, int row)
        {
            /**if (lettersOnBoard[col, row] != null)
            {
                throw new System.Exception("Tile [" + col + "," + row + "] already occupied.");
            }*/
            lettersOnBoard[col, row] = letter;
            baseBoard[col, row] = null;
        }

        /// <summary>
        /// Returns the score from placing a word at that position
        /// </summary>
        /// <param name="word">Word to be placed</param>
        /// <param name="col">Column of first character in word</param>
        /// <param name="row">Row of first character in word </param>
        /// <param name="northSouth">True if the word runs up and down the board, false
        /// if the word runs left to right</param>
        /// <returns>Score that the word </returns>
        public int GetPredictedScore(string word, int col, int row, bool northSouth)
        {
            int wordMultiplier = 1;
            int letterMultiplier = 1;
            int wordScore = 0;
            int counter = 0;
            while (counter < word.Length)
            {
                //sets the proper multiplier
                if (baseBoard[col,row] != null)
                {
                    if (baseBoard[col, row].Equals("2"))
                    {
                        letterMultiplier = 2;
                    }
                    if (baseBoard[col, row].Equals("3"))
                    {
                        letterMultiplier = 3;
                    }
                    if (baseBoard[col, row].Equals("@"))
                    {
                        wordMultiplier = wordMultiplier * 2;
                    }
                    if (baseBoard[col, row].Equals("#"))
                    {
                        wordMultiplier = wordMultiplier * 3;
                    }
                }

                //adds to the score of this word
                wordScore += letterMultiplier * (int)letterValues[lettersOnBoard[col,row]];
                letterMultiplier = 1; //resets letterMultiplier

                //increments counters, depending if the word is North-South or East-West
                if (northSouth)
                {
                    row--;
                }
                else
                {
                    col++;
                }
                counter++;
            }
            return wordScore * wordMultiplier;
        }

        /// <summary>
        /// Returns an array of the requested row
        /// </summary>
        /// <param name="col">Row number</param>
        /// <returns>Requested row of letters formt he board</returns>
        public string[] GetRow(int row)
        {
            int col = 0;
            string[] newRow = new string[lettersOnBoard.GetLength(0)];
            while (col < newRow.Length)
            {
                newRow[col] = lettersOnBoard[col, row];
                col++;
            }
            return newRow;
        }

        /// <summary>
        /// Returns an array of the requested column
        /// </summary>
        /// <param name="col">Column number</param>
        /// <returns>Requested column of letters formt he board</returns>
        public string[] GetCol(int col)
        {
            int row = 0;
            string[] newCol = new string[lettersOnBoard.GetLength(1)];
            while (row < newCol.Length)
            {
                newCol[row] = lettersOnBoard[col, row];
                row++;
            }
            return newCol;
        }
    }
}
