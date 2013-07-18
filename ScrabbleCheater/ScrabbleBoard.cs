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
        private Dictionary<string,int> letterValues;
        private List<string> dictionary;

        /// <summary>
        /// Constructor for ScrabbleBoard, taking in a 2D array of the base board (which contains only multipliers)
        /// </summary>
        /// <param name="baseBoard">2D array representing multipliers on the board</param>
        /// <param name="dictionary">Dictionary of valid words</param>
        public ScrabbleBoard(string[,] baseBoard, List<string> dictionary,Dictionary<string,int> letterVals)
        {
            this.dictionary = dictionary;
            this.baseBoard = baseBoard;
            this.lettersOnBoard = new string[baseBoard.GetLength(0), baseBoard.GetLength(1)];
            this.letterValues = letterVals;
        }

        /// <summary>
        /// Sets the lettersOnBoard to a new array
        /// </summary>
        /// <param name="newLettersOnBoard"></param>
        public void SetBoard(string[,] newLettersOnBoard)
        {
            this.lettersOnBoard = newLettersOnBoard;
        }

        /// <summary>
        /// returns array of lettersOnBoard
        /// </summary>
        /// <returns></returns>
        private string[,] GetLetterBoard()
        {
            return this.lettersOnBoard;
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
            char[] wordAr = word.ToCharArray();
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
                wordScore += letterMultiplier * letterValues[wordAr[counter].ToString()];
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
            bool boardersALetter = false;
            char[] wordAr = word.ToCharArray(); //word.Substring(positionIncrementer,positionIncrementer) was making strings 
                                                //longer than length 1.  Odd.
            while (positionIncrementer < word.Length) //checks if it is placable
            {
                charAtPosition = (northSouth ? lettersOnBoard[position[0],position[1] - positionIncrementer] 
                    : lettersOnBoard[position[0] + positionIncrementer,position[1]]);
                if (charAtPosition == null && //checks to see if the character on the board is null and that the letter
                    handCopy.Contains(wordAr[positionIncrementer].ToString())) //is also in the hand
                {
                    handCopy.Remove(charAtPosition);
                }
                else if (charAtPosition != null && //checks if character on board is not null and that it is equal to the corresponding 
                    wordAr[positionIncrementer].ToString().Equals(charAtPosition)) //character in the word to be played
                {
                    boardersALetter = true;
                }
                else
                {
                    return false;
                }

                if (northSouth)
                {
                    if ( (position[0] + 1 < lettersOnBoard.GetLength(0) && lettersOnBoard[position[0] + 1,position[1] - positionIncrementer] != null)
                        || (position[0] - 1 > 0 && lettersOnBoard[position[0] - 1, position[1] - positionIncrementer] != null))
                    {
                        boardersALetter = true;
                    }
                }
                else
                {
                    if ((position[1] + 1 < lettersOnBoard.GetLength(1) && lettersOnBoard[position[0] + positionIncrementer, position[1] + 1] != null)
                        || (position[1] - 1 > 0 && lettersOnBoard[position[0] + positionIncrementer, position[1] - 1] != null))
                    {
                        boardersALetter = true;
                    }

                }
                positionIncrementer++;
            }
            if (!boardersALetter)
            {
                return false;
            }
            //now check if if this creates any non-words in the process
            ScrabbleBoard testBoard = this.Clone();
            positionIncrementer = 0;
            foreach (char character in wordAr)
            {
                testBoard.PlaceLetter(character.ToString(), 
                    position[0] + (northSouth ? 0 : positionIncrementer ), position[1] - (northSouth ? positionIncrementer : 0 ));
                positionIncrementer++;
            }
            if (!CheckRowOrCol((northSouth ? position[0] : position[1] ), northSouth,testBoard)) //checks col/row word was placed along
            {
                return false;
            }
            for (int c = 0; c < word.Length; c++)
            {
                if (!CheckRowOrCol((northSouth ? position[1] - c : position[0] + c ), !northSouth,testBoard))
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// Checks if a move actually lays down any new letters.  False if it does.
        /// </summary>
        /// <param name="move">move to check</param>
        /// <returns></returns>
        public Boolean CheckIfRetread(Move move)
        {
            int counter = move.GetWord().Length;
            int x = move.GetPosition()[0];
            int y = move.GetPosition()[1];
            while (counter > 0)
            {
                if (lettersOnBoard[x, y] == null)
                {
                    return false;
                }
                if (move.GetIfNorthSouth())
                {
                    y--;
                }
                else
                {
                    x++;
                }
                counter--;
            }
            return true;
        }

        /// <summary>
        /// Checks the validity of the words in a row or column
        /// </summary>
        /// <param name="position">position of the row or column</param>
        /// <param name="col">True if it is a column to be checked</param>
        /// <returns>True if all words are valid words.</returns>
        public bool CheckRowOrCol(int position, bool col, ScrabbleBoard testBoard)
        {
            string[,] lettersOnBoard = testBoard.GetLetterBoard();
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

            ScrabbleBoard newBoard = new ScrabbleBoard(newBaseBoard, this.dictionary, letterValues);
            newBoard.SetBoard((string[,])this.lettersOnBoard.Clone());
            return newBoard;
        }

        /// <summary>
        /// Returns a string representation of the board.
        /// </summary>
        /// <returns></returns>
        public String ToString()
        {
            int x = 0;
            int y = lettersOnBoard.GetLength(1) - 1;
            string boardString = "";
            /**while (y >= 0)
            {
                while (x < lettersOnBoard.GetLength(1))
                {
                    if (lettersOnBoard[x, y] == null || lettersOnBoard[x, y].Equals(""))
                    {
                        boardString += ".";
                    }
                    else
                    {
                        boardString += lettersOnBoard[x, y];
                    }
                    x++;
                    boardString += "\n";
                }
                y--;
            }**/
            foreach (string s in lettersOnBoard)
            {
                boardString += s;
            }
            return boardString;
        }
    }
}
