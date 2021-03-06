﻿using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScrabbleCheater
{
    public class Solver
    {

        List<string> dictionary;
        ScrabbleBoard board;

        /// <summary>
        /// Constructor for the solver that uses default WWF Dicionary
        /// </summary>
        /// <param name="board">ScrabbleBoard to be played on</param>
        public Solver(ScrabbleBoard board)
        {
            this.board = board;
            string[] lines = System.IO.File.ReadAllLines("WWFDictionary.txt");
            this.dictionary = new List<string>();
            foreach (string s in lines)
            {
                dictionary.Add(s);
            }
        }

        /// <summary>
        /// Constructor for solver that takes in custom dictionary
        /// </summary>
        /// <param name="board">ScrabbleBoard to be played on</param>
        /// <param name="dictionary">List of strings that are valid words</param>
        public Solver(ScrabbleBoard board, List<string> dictionary)
        {
            this.board = board;
            this.dictionary = dictionary;
        }

        /// <summary>
        /// Returns the best possible move, given a ScrabbleBoard and a list of strings representing the player's hand.
        /// </summary>
        /// <param name="board">ScrabbleBoard that the move will be played on</param>
        /// <param name="hand">List of length 1 strings that the player has in his/her hand</param>
        /// <returns></returns>
        public Move GetBestPlay(ScrabbleBoard board, List<string> hand)
        {
            List<Move> allMoves = new List<Move>();
            for (int c = 0; c < this.board.GetRow(0).Length; c++)
            {
                foreach (Move move in GetMovesInArray(board, hand, board.GetCol(c), true, c))
                {
                    allMoves.Add(move);
                }
            }
            for (int c = 0; c < this.board.GetCol(0).Length; c++)
            {
                foreach (Move move in GetMovesInArray(board, hand, board.GetRow(c), false, c))
                {
                    allMoves.Add(move);
                }
            }
            Move bestMove = new Move(null,null,true); ;
            int topScore = 0;
            int currentScore;
            foreach (Move move in allMoves)
            {
                currentScore = board.GetPredictedScore(move.GetWord(), move.GetPosition()[0], move.GetPosition()[1], move.GetIfNorthSouth());
                if (currentScore > topScore && !board.CheckIfRetread(move))
                {
                    System.Diagnostics.Debug.WriteLine(move.ToString());
                    topScore = currentScore;
                    bestMove = move;
                }
            }
            return bestMove;
        }

        /// <summary>
        /// Returns list of moves that can be done with a specific hand
        /// </summary>
        /// <param name="board">string array of letters on the board for that</param>
        /// <param name="hand">List of length 1 strings in the player's hand</param>
        /// <param name="rowOrCol">Position</param>
        /// <param name="col">True if it runs up/down</param>
        /// <returns>List of moves, formed in an array [string word, int[1,1] position, bool NorthSouth]</returns>
        public List<Move> GetMovesInArray(ScrabbleBoard board, List<string> hand, string[] rowOrCol, bool col, int pos)
        {
            List<Move> moves = new List<Move>();
            List<string> boardLetters = new List<string>();
            Move possibleMove;
            int[] position = new int[2];
            foreach (string letter in rowOrCol)
            {
                if (letter != null)
                {
                    boardLetters.Add(letter);
                }
            }
            foreach (string word in GetPossibleWordsForRow(hand, boardLetters))
            {
                for (int c = 0; c + word.Length < (col ? board.GetCol(pos).Length : board.GetRow(pos).Length) ; c++)
                {
                    position[0] = (col ? pos : c);
                    position[1] = (col ? board.GetRow(pos).Length - 1 - c : pos);
                    possibleMove = new Move(word, position, col);
                    if (board.CheckIfValidMove(word,position,col,hand))
                    {
                        moves.Add(possibleMove.Clone());
                    }
                }
            }
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

                    if (wordCopy.Length == 0 && inHand)
                    {
                        possibleWords.Add(word);
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
