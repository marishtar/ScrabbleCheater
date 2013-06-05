using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScrabbleCheater
{
    public class ScrabbleBoard
    {
        private string[,] lettersOnBoard;
        private string[,] baseBoard;
        private Hashtable letterValues;
        private List<string> dictionary;

        /// <summary>
        /// Constructor for ScrabbleBoard, taking in a 2D array of the base board (which contains only multipliers)
        /// </summary>
        /// <param name="baseBoard">2D array representing multipliers on the board</param>
        /// <param name="dictionary">Dictionary of valid words</param>
        public ScrabbleBoard(string[,] baseBoard, List<string> dictionary)
        {
            this.dictionary = dictionary;
            this.baseBoard = baseBoard;
            this.lettersOnBoard = new string[baseBoard.GetLength(0), baseBoard.GetLength(1)];
            letterValues = new Hashtable();
        }

        private void SetBoard(string[,] newLettersOnBoard)
        {
            this.lettersOnBoard = newLettersOnBoard;
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

        /// <summary>
        /// Checks to see if a move is a valid move, given also the hand that will play it.
        /// </summary>
        /// <param name="word">Word to be played</param>
        /// <param name="position">(x,y) position of the first letter in the word</param>
        /// <param name="northSouth">True if the play runs up/down.</param>
        /// <returns>True if the move is valid</returns>
        public bool CheckIfValidMove(string word, int[] position, bool northSouth, List<string> hand)
        {
            List<string> handCopy = new List<string>(hand);
            int positionIncrementer = 0;
            string charAtPosition;
            while (positionIncrementer < word.Length) //checks if it is placable
            {
                charAtPosition = (northSouth ? lettersOnBoard[position[0],position[1] - positionIncrementer] 
                    : lettersOnBoard[position[0] + positionIncrementer,position[1]]);
                if (charAtPosition == null && //checks to see if the character on the board is null and that the letter
                    handCopy.Contains(word.Substring(positionIncrementer, positionIncrementer + 1))) //is also in the hand
                {
                    handCopy.Remove(charAtPosition);
                }
                else if (charAtPosition != null && //checks if character on board is not null and that it is equal to the corresponding 
                    word.Substring(positionIncrementer, positionIncrementer + 1).Equals(charAtPosition)) //character in the word to be played
                {} //do nothing
                else
                {
                    return false;
                }
                positionIncrementer++;
            }
            //now check if if this creates any non-words in the process


            return true;
        }

        /// <summary>
        /// Checks the validity of the words in a row or column
        /// </summary>
        /// <param name="position">position of the row or column</param>
        /// <param name="col">True if it is a column to be checked</param>
        /// <returns>True if all words are valid words.</returns>
        public bool CheckRowOrCol(int position, bool col)
        {
            int counter = 0;
            string charAtPos;
            string wordSegment = "";
            List<string> wordsToCheck = new List<string>();
            while (counter < lettersOnBoard.GetLength(col ? 1 : 0)) //find what individual words are seperated by blank space
            {
                charAtPos = (col ? lettersOnBoard[position,lettersOnBoard.GetLength(1) -1 - counter] : lettersOnBoard[counter,position]);
                if (charAtPos == null)
                {
                    if (!wordSegment.Equals(""))
                    {
                        wordsToCheck.Add(new String(wordSegment.ToCharArray()));
                        wordSegment = "";
                    }
                }
                else
                {
                    wordSegment = wordSegment + charAtPos;
                }
                counter++;
            }
            System.Diagnostics.Debug.WriteLine("Words:");
            foreach (string word in wordsToCheck) //check if the words greater than length 1 are in the dictionary
            {
                System.Diagnostics.Debug.WriteLine(word);
                if (word.Length != 1 && !dictionary.Contains(word))
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Returns a deep copy of this ScrabbleBoard
        /// </summary>
        /// <returns>Clone of ScrabbleBoard</returns>
        public ScrabbleBoard Clone()
        {
            string[,] newBaseBoard = (string[,])this.baseBoard.Clone();

            ScrabbleBoard newBoard = new ScrabbleBoard(newBaseBoard, this.dictionary);
            newBoard.SetBoard((string[,])this.lettersOnBoard);
            return newBoard;
        }
    }
}
