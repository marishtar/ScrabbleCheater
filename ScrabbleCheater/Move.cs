using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScrabbleCheater
{
    /// <summary>
    /// Representation of a move that can be played on a board.
    /// </summary>
    public class Move
    {
        private int[] position;
        private string word;
        private bool northSouth;

        /// <summary>
        /// Constructs a move that can be played on a board.
        /// </summary>
        /// <param name="word">Word to be played</param>
        /// <param name="position">Position of first character of word</param>
        /// <param name="northSouth">True if move runs up/down</param>
        public Move(string word, int[] position, bool northSouth)
        {
            this.position = position;
            this.word = word;
            this.northSouth = northSouth;
        }

        /// <summary>
        /// Returns the word
        /// </summary>
        /// <returns>The word</returns>
        public string GetWord()
        {
            return word;
        }

        /// <summary>
        /// Returns position of the first character of the word
        /// </summary>
        /// <returns>Position of the first character of the word</returns>
        public int[] GetPosition()
        {
            return position;
        }

        /// <summary>
        /// Returns if the word runs up/down
        /// </summary>
        /// <returns>If the word runs up/down</returns>
        public bool GetIfNorthSouth()
        {
            return northSouth;
        }

        /// <summary>
        /// Returns clone of Move
        /// </summary>
        /// <returns>Clone of Move</returns>
        public Move Clone()
        {
            int[] newPos = new int[2];
            newPos[0] = this.position[0];
            newPos[1] = this.position[1];
            Move newMove = new Move(new String(this.word.ToCharArray()), newPos, this.northSouth);
            return newMove;
        }

        
        public override string ToString()
        {
            return "{" + word + ",[" + position[0].ToString() + "," + position[1].ToString() + "]," + (northSouth ? "updown}" : "leftright}");
        }
    }
}
