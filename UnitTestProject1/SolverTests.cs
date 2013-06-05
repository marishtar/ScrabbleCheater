using System;
using System.Collections.Generic;
using ScrabbleCheater;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
    [TestClass]
    public class SolverTests
    {
        [TestMethod]
        public void ComboTest1()
        {
            Dictionary<string, int> letters = new Dictionary<string, int>()
                {
                    {"a",1}, {"b",4}, {"c",4}, {"d",2}, {"e",1}, {"f",4}, {"g",3}, {"h",3}, {"i",1}, {"j",10}, {"k",5}, {"l",2}, {"m",4}, 
                    {"n",2}, {"o",1}, {"p",4}, {"q",10}, {"r",1}, {"s",1}, {"t",1}, {"u",2}, {"v",5}, {"w",4}, {"x",8}, {"y",3}, {"z",10}, 
                };
            List<string> dictionary = new List<string>();
            List<string> asdf = new List<string>();
            List<string> results;
            asdf.Add("a");
            asdf.Add("b");
            asdf.Add("c");
            ScrabbleCheater.Solver solve = new Solver(new ScrabbleBoard(new string[5,2],dictionary,letters));
            results = solve.GetPossibleCombinations("", asdf);
            foreach (string el in results)
            {
                Console.WriteLine(el);
            }
            Assert.IsTrue(results.Contains("a"));
            Assert.IsTrue(results.Contains("b"));
            Assert.IsTrue(results.Contains("c"));
            Assert.IsTrue(results.Contains("ab"));
            Assert.IsTrue(results.Contains("ac"));
            Assert.IsTrue(results.Contains("ba"));
            Assert.IsTrue(results.Contains("bc"));
            Assert.IsTrue(results.Contains("cb"));
            Assert.IsTrue(results.Contains("ca"));
            Assert.IsTrue(results.Contains("abc"));
            Assert.IsTrue(results.Contains("acb"));
            Assert.IsTrue(results.Contains("bac"));
            Assert.IsTrue(results.Contains("bca"));
            Assert.IsTrue(results.Contains("cab"));
            Assert.IsTrue(results.Contains("cba"));
            Assert.IsTrue(results.Count == 15);
        }
        
        [TestMethod]
        public void PossibilityTest1()
        {
            Dictionary<string, int> letters = new Dictionary<string, int>()
                {
                    {"a",1}, {"b",4}, {"c",4}, {"d",2}, {"e",1}, {"f",4}, {"g",3}, {"h",3}, {"i",1}, {"j",10}, {"k",5}, {"l",2}, {"m",4}, 
                    {"n",2}, {"o",1}, {"p",4}, {"q",10}, {"r",1}, {"s",1}, {"t",1}, {"u",2}, {"v",5}, {"w",4}, {"x",8}, {"y",3}, {"z",10}, 
                };
            List<string> asdf = new List<string>();
            List<string> results, dictionary;
            dictionary = new List<string>();
            asdf.Add("a");
            asdf.Add("b");
            asdf.Add("a");
            asdf.Add("n");
            asdf.Add("d");
            asdf.Add("o");
            asdf.Add("n");
            List<string> board = new List<string>();
            board.Add("m");
            board.Add("e");
            board.Add("n");
            board.Add("t");
            ScrabbleCheater.Solver solve = new Solver(new ScrabbleBoard(new string[5, 2], dictionary,letters));
            results = solve.GetPossibleWordsForRow(asdf,  board);
            Assert.IsTrue(results.Contains("abandonment"));
            Assert.IsTrue(results.Contains("band"));
            Assert.IsFalse(results.Contains("alpha"));
        }

        [TestMethod]
        public void PossibilityTest2()
        {
            Dictionary<string, int> letters = new Dictionary<string, int>()
                {
                    {"a",1}, {"b",4}, {"c",4}, {"d",2}, {"e",1}, {"f",4}, {"g",3}, {"h",3}, {"i",1}, {"j",10}, {"k",5}, {"l",2}, {"m",4}, 
                    {"n",2}, {"o",1}, {"p",4}, {"q",10}, {"r",1}, {"s",1}, {"t",1}, {"u",2}, {"v",5}, {"w",4}, {"x",8}, {"y",3}, {"z",10}, 
                };
            List<string> asdf = new List<string>();
            List<string> results, dictionary;
            dictionary = new List<string>();
            asdf.Add("a");
            asdf.Add("b");
            List<string> board = new List<string>();
            board.Add("d");
            ScrabbleCheater.Solver solve = new Solver(new ScrabbleBoard(new string[5, 2],dictionary,letters));
            results = solve.GetPossibleWordsForRow(asdf, board);
            Assert.IsTrue(results.Contains("bad"));
            Assert.IsFalse(results.Contains("a"));
            Assert.IsFalse(results.Contains("aa"));
        }

        [TestMethod]
        public void BoardColumnTest1()
        {
            Dictionary<string, int> letters = new Dictionary<string, int>()
                {
                    {"a",1}, {"b",4}, {"c",4}, {"d",2}, {"e",1}, {"f",4}, {"g",3}, {"h",3}, {"i",1}, {"j",10}, {"k",5}, {"l",2}, {"m",4}, 
                    {"n",2}, {"o",1}, {"p",4}, {"q",10}, {"r",1}, {"s",1}, {"t",1}, {"u",2}, {"v",5}, {"w",4}, {"x",8}, {"y",3}, {"z",10}, 
                };
            string[,] baseBoard = new string[15, 15];
            string[] lines = System.IO.File.ReadAllLines("WWFDictionary.txt");
            List<string> dictionary = new List<string>();
            foreach (string s in lines)
            {
                dictionary.Add(s);
            }
            ScrabbleBoard board = new ScrabbleBoard(baseBoard, dictionary,letters);
            board.PlaceLetter("a", 4, 5);
            board.PlaceLetter("s", 4, 4);
            board.PlaceLetter("d", 4, 3);
            board.PlaceLetter("f", 4, 2);
            Assert.IsTrue(board.CheckRowOrCol(5, false,board));
            Assert.IsTrue(board.CheckRowOrCol(4, false,board));
            Assert.IsTrue(board.CheckRowOrCol(3, false,board));
            Assert.IsTrue(board.CheckRowOrCol(2, false,board));
            Assert.IsFalse(board.CheckRowOrCol(4, true,board));
        }

        [TestMethod]
        public void BoardColumnTest2()
        {
            Dictionary<string, int> letters = new Dictionary<string, int>()
                {
                    {"a",1}, {"b",4}, {"c",4}, {"d",2}, {"e",1}, {"f",4}, {"g",3}, {"h",3}, {"i",1}, {"j",10}, {"k",5}, {"l",2}, {"m",4}, 
                    {"n",2}, {"o",1}, {"p",4}, {"q",10}, {"r",1}, {"s",1}, {"t",1}, {"u",2}, {"v",5}, {"w",4}, {"x",8}, {"y",3}, {"z",10}, 
                };
            string[,] baseBoard = new string[15, 15];
            string[] lines = System.IO.File.ReadAllLines("WWFDictionary.txt");
            List<string> dictionary = new List<string>();
            foreach (string s in lines)
            {
                dictionary.Add(s);
            }
            ScrabbleBoard board = new ScrabbleBoard(baseBoard, dictionary,letters);
            board.PlaceLetter("w", 2, 5);
            board.PlaceLetter("o", 3, 5);
            board.PlaceLetter("r", 4, 5);
            board.PlaceLetter("d", 5, 5);
            board.PlaceLetter("f", 7, 5);
            board.PlaceLetter("u", 8, 5);
            board.PlaceLetter("n", 9, 5);
            Assert.IsTrue(board.CheckRowOrCol(5,false,board));
        }

        [TestMethod]
        public void CheckIfValidMoveTest1()
        {
            Dictionary<string, int> letters = new Dictionary<string, int>()
                {
                    {"a",1}, {"b",4}, {"c",4}, {"d",2}, {"e",1}, {"f",4}, {"g",3}, {"h",3}, {"i",1}, {"j",10}, {"k",5}, {"l",2}, {"m",4}, 
                    {"n",2}, {"o",1}, {"p",4}, {"q",10}, {"r",1}, {"s",1}, {"t",1}, {"u",2}, {"v",5}, {"w",4}, {"x",8}, {"y",3}, {"z",10}, 
                };
            string[,] baseBoard = new string[15, 15];
            string[] lines = System.IO.File.ReadAllLines("WWFDictionary.txt");
            List<string> dictionary = new List<string>();
            foreach (string s in lines)
            {
                dictionary.Add(s);
            }
            ScrabbleBoard board = new ScrabbleBoard(baseBoard, dictionary,letters);
            board.PlaceLetter("f", 7, 5);
            board.PlaceLetter("u", 8, 5);
            board.PlaceLetter("n", 9, 5);
            List<string> hand = new List<string>(){"f","u","m","n","n","y"};
            int[] pos = new int[2];
            pos[0] = 8;
            pos[1] = 6;
            Assert.IsTrue(board.CheckIfValidMove("funny",pos,true, hand));
        }

        [TestMethod]
        public void CheckIfValidMoveTest2()
        {
            Dictionary<string, int> letters = new Dictionary<string, int>()
                {
                    {"a",1}, {"b",4}, {"c",4}, {"d",2}, {"e",1}, {"f",4}, {"g",3}, {"h",3}, {"i",1}, {"j",10}, {"k",5}, {"l",2}, {"m",4}, 
                    {"n",2}, {"o",1}, {"p",4}, {"q",10}, {"r",1}, {"s",1}, {"t",1}, {"u",2}, {"v",5}, {"w",4}, {"x",8}, {"y",3}, {"z",10}, 
                };
            string[,] baseBoard = new string[15, 15];
            string[] lines = System.IO.File.ReadAllLines("WWFDictionary.txt");
            List<string> dictionary = new List<string>();
            foreach (string s in lines)
            {
                dictionary.Add(s);
            }
            ScrabbleBoard board = new ScrabbleBoard(baseBoard, dictionary,letters);
            board.PlaceLetter("f", 7, 5);
            board.PlaceLetter("u", 8, 5);
            board.PlaceLetter("n", 9, 5);
            List<string> hand = new List<string>() { "f", "u", "m", "n", "n", "y" };
            int[] pos = new int[2];
            pos[0] = 8;
            pos[1] = 8;
            Assert.IsFalse(board.CheckIfValidMove("funny", pos, true, hand));
        }

        [TestMethod]
        public void CheckIfValidMoveTest3()
        {
            Dictionary<string, int> letters = new Dictionary<string, int>()
                {
                    {"a",1}, {"b",4}, {"c",4}, {"d",2}, {"e",1}, {"f",4}, {"g",3}, {"h",3}, {"i",1}, {"j",10}, {"k",5}, {"l",2}, {"m",4}, 
                    {"n",2}, {"o",1}, {"p",4}, {"q",10}, {"r",1}, {"s",1}, {"t",1}, {"u",2}, {"v",5}, {"w",4}, {"x",8}, {"y",3}, {"z",10}, 
                };
            string[,] baseBoard = new string[15, 15];
            string[] lines = System.IO.File.ReadAllLines("WWFDictionary.txt");
            List<string> dictionary = new List<string>();
            foreach (string s in lines)
            {
                dictionary.Add(s);
            }
            ScrabbleBoard board = new ScrabbleBoard(baseBoard, dictionary,letters);
            board.PlaceLetter("f", 7, 5);
            board.PlaceLetter("u", 8, 5);
            board.PlaceLetter("n", 9, 5);
            List<string> hand = new List<string>() { "f", "u", "m", "n", "n", "y" };
            int[] pos = new int[2];
            pos[0] = 8;
            pos[1] = 6;
            Assert.IsFalse(board.CheckIfValidMove("fund", pos, true, hand));
        }

        [TestMethod]
        public void CheckIfValidMoveTest4()
        {
            Dictionary<string, int> letters = new Dictionary<string, int>()
                {
                    {"a",1}, {"b",4}, {"c",4}, {"d",2}, {"e",1}, {"f",4}, {"g",3}, {"h",3}, {"i",1}, {"j",10}, {"k",5}, {"l",2}, {"m",4}, 
                    {"n",2}, {"o",1}, {"p",4}, {"q",10}, {"r",1}, {"s",1}, {"t",1}, {"u",2}, {"v",5}, {"w",4}, {"x",8}, {"y",3}, {"z",10}, 
                };
            string[,] baseBoard = new string[15, 15];
            string[] lines = System.IO.File.ReadAllLines("WWFDictionary.txt");
            List<string> dictionary = new List<string>();
            foreach (string s in lines)
            {
                dictionary.Add(s);
            }
            ScrabbleBoard board = new ScrabbleBoard(baseBoard, dictionary,letters);
            board.PlaceLetter("f", 7, 5);
            board.PlaceLetter("u", 8, 5);
            board.PlaceLetter("n", 9, 5);
            List<string> hand = new List<string>() { "f", "u", "m", "n", "n", "y" };
            int[] pos = new int[2];
            pos[0] = 7;
            pos[1] = 6;
            Assert.IsFalse(board.CheckIfValidMove("fund", pos, true, hand));
        }

        [TestMethod]
        public void CheckIfValidMoveTest5()
        {
            Dictionary<string, int> letters = new Dictionary<string, int>()
                {
                    {"a",1}, {"b",4}, {"c",4}, {"d",2}, {"e",1}, {"f",4}, {"g",3}, {"h",3}, {"i",1}, {"j",10}, {"k",5}, {"l",2}, {"m",4}, 
                    {"n",2}, {"o",1}, {"p",4}, {"q",10}, {"r",1}, {"s",1}, {"t",1}, {"u",2}, {"v",5}, {"w",4}, {"x",8}, {"y",3}, {"z",10}, 
                };
            string[,] baseBoard = new string[15, 15];
            string[] lines = System.IO.File.ReadAllLines("WWFDictionary.txt");
            List<string> dictionary = new List<string>();
            foreach (string s in lines)
            {
                dictionary.Add(s);
            }
            ScrabbleBoard board = new ScrabbleBoard(baseBoard, dictionary,letters);
            board.PlaceLetter("a", 1, 4);
            board.PlaceLetter("a", 1, 5);
            board.PlaceLetter("a", 13, 4);
            board.PlaceLetter("a", 13, 5);
            board.PlaceLetter("a", 9, 13);
            board.PlaceLetter("a", 8, 13);
            board.PlaceLetter("a", 8, 1);
            board.PlaceLetter("a", 9, 1);
            List<string> hand = new List<string>() { "a", "a", "m", "n", "n", "y" };
            int[] pos = new int[2];
            pos[0] = 0;
            pos[1] = 5;
            Assert.IsTrue(board.CheckIfValidMove("aa", pos, true, hand));
            pos[0] = 14;
            pos[1] = 4;
            Assert.IsTrue(board.CheckIfValidMove("aa", pos, true, hand));
            pos[0] = 8;
            pos[1] = 0;
            Assert.IsTrue(board.CheckIfValidMove("aa", pos, false, hand));
            pos[0] = 8;
            pos[1] = 14;
            Assert.IsTrue(board.CheckIfValidMove("aa", pos, false, hand));
        }

        [TestMethod]
        public void FindMovesInArrayTest1()
        {
            Dictionary<string, int> letters = new Dictionary<string, int>()
                {
                    {"a",1}, {"b",4}, {"c",4}, {"d",2}, {"e",1}, {"f",4}, {"g",3}, {"h",3}, {"i",1}, {"j",10}, {"k",5}, {"l",2}, {"m",4}, 
                    {"n",2}, {"o",1}, {"p",4}, {"q",10}, {"r",1}, {"s",1}, {"t",1}, {"u",2}, {"v",5}, {"w",4}, {"x",8}, {"y",3}, {"z",10}, 
                };
            string[,] baseBoard = new string[15, 15];
            string[] lines = System.IO.File.ReadAllLines("WWFDictionary.txt");
            List<string> dictionary = new List<string>();
            foreach (string s in lines)
            {
                dictionary.Add(s);
            }
            ScrabbleBoard board = new ScrabbleBoard(baseBoard, dictionary,letters);
            ScrabbleCheater.Solver solve = new Solver(board);
            board.PlaceLetter("a", 1, 11);
            board.PlaceLetter("a", 1, 10);
            List<string> hand = new List<string>() { "a", "a", "m", "n", "n", "y" };
            int[] pos = new int[2];
            pos[0] = 0;
            pos[1] = 5;
            List<Move> moves = solve.GetMovesInArray(board, hand, board.GetCol(0), true, 0);
            bool passed = false;
            foreach (Move move in moves)
            {
                if (move.GetWord().Equals("aa") && move.GetPosition()[0] == 0 && move.GetPosition()[1] == 10)
                {
                    passed = true;
                }
            }
            Assert.IsTrue(passed);
            passed = false;
            moves = solve.GetMovesInArray(board, hand, board.GetRow(10), false, 11);
            foreach (Move move in moves)
            {
                if (move.GetWord().Equals("nay") && move.GetPosition()[0] == 0 && move.GetPosition()[1] == 11)
                {
                    passed = true;
                }
                System.Diagnostics.Debug.WriteLine(move.ToString());
            }
            Assert.IsTrue(passed);
        }

        [TestMethod]
        public void GetBestPlayTest1()
        {
            Dictionary<string, int> letters = new Dictionary<string, int>()
                {
                    {"a",1}, {"b",4}, {"c",4}, {"d",2}, {"e",1}, {"f",4}, {"g",3}, {"h",3}, {"i",1}, {"j",10}, {"k",5}, {"l",2}, {"m",4}, 
                    {"n",2}, {"o",1}, {"p",4}, {"q",10}, {"r",1}, {"s",1}, {"t",1}, {"u",2}, {"v",5}, {"w",4}, {"x",8}, {"y",3}, {"z",10}, 
                };
            string[,] baseBoard = new string[15, 15];
            string[] lines = System.IO.File.ReadAllLines("WWFDictionary.txt");
            List<string> dictionary = new List<string>();
            foreach (string s in lines)
            {
                dictionary.Add(s);
            }
            ScrabbleBoard board = new ScrabbleBoard(baseBoard, dictionary,letters);
            ScrabbleCheater.Solver solve = new Solver(board);
            board.PlaceLetter("a", 1, 11);
            board.PlaceLetter("a", 1, 10);
            List<string> hand = new List<string>() { "a", "a", "m", "n", "n", "y" };
            int[] pos = new int[2];
            pos[0] = 0;
            pos[1] = 5;
            List<Move> moves = solve.GetMovesInArray(board, hand, board.GetCol(0), true, 0);
            Move best = solve.GetBestPlay(board, hand);
            Assert.IsTrue(best.GetWord().Equals("mayan"));

        }

        [TestMethod]
        public void GetBestPlayTest2()
        {
            Dictionary<string, int> letters = new Dictionary<string, int>()
                {
                    {"a",1}, {"b",4}, {"c",4}, {"d",2}, {"e",1}, {"f",4}, {"g",3}, {"h",3}, {"i",1}, {"j",10}, {"k",5}, {"l",2}, {"m",4}, 
                    {"n",2}, {"o",1}, {"p",4}, {"q",10}, {"r",1}, {"s",1}, {"t",1}, {"u",2}, {"v",5}, {"w",4}, {"x",8}, {"y",3}, {"z",10}, 
                };
            string[,] baseBoard = new string[15, 15];
            string[] lines = System.IO.File.ReadAllLines("WWFDictionary.txt");
            List<string> dictionary = new List<string>();
            foreach (string s in lines)
            {
                dictionary.Add(s);
            }
            ScrabbleBoard board = new ScrabbleBoard(baseBoard, dictionary, letters);
            ScrabbleCheater.Solver solve = new Solver(board);
            board.PlaceLetter("d", 4, 14);
            board.PlaceLetter("o", 5, 14);
            board.PlaceLetter("n", 6, 14);
            board.PlaceLetter("n", 7, 14);
            board.PlaceLetter("a", 8, 14);
            board.PlaceLetter("s", 9, 14);
            board.PlaceLetter("r", 5, 13);
            board.PlaceLetter("u", 9, 13);
            board.PlaceLetter("g", 5, 12);
            board.PlaceLetter("l", 9, 12);
            board.PlaceLetter("d", 0, 11);
            board.PlaceLetter("r", 1, 11);
            board.PlaceLetter("e", 2, 11);
            board.PlaceLetter("a", 3, 11);
            board.PlaceLetter("m", 4, 11);
            board.PlaceLetter("y", 5, 11);
            board.PlaceLetter("f", 9, 11);
            board.PlaceLetter("l", 8, 10);
            board.PlaceLetter("a", 9, 10);
            board.PlaceLetter("s", 10, 10);
            board.PlaceLetter("t", 11, 10);
            board.PlaceLetter("i", 11, 9);
            board.PlaceLetter("h", 11, 8);
            board.PlaceLetter("e", 11, 8);
            board.PlaceLetter("v", 1, 7);
            board.PlaceLetter("a", 2, 7);
            board.PlaceLetter("g", 3, 7);
            board.PlaceLetter("i", 4, 7);
            board.PlaceLetter("v", 7, 7);
            board.PlaceLetter("i", 8, 7);
            board.PlaceLetter("s", 9, 7);
            board.PlaceLetter("a", 10, 7);
            board.PlaceLetter("s", 11, 7);
            board.PlaceLetter("l", 4, 6);
            board.PlaceLetter("i", 7, 6);
            board.PlaceLetter("h", 9, 6);
            board.PlaceLetter("t", 4, 5);
            board.PlaceLetter("h", 5, 5);
            board.PlaceLetter("u", 6, 5);
            board.PlaceLetter("d", 7, 5);
            board.PlaceLetter("i", 9, 5);
            board.PlaceLetter("r", 12, 5);
            board.PlaceLetter("e", 7, 4);
            board.PlaceLetter("p", 9, 4);
            board.PlaceLetter("i", 10, 4);
            board.PlaceLetter("t", 11, 4);
            board.PlaceLetter("a", 12, 4);
            board.PlaceLetter("b", 6, 3);
            board.PlaceLetter("o", 7, 3);
            board.PlaceLetter("x", 8, 3);
            board.PlaceLetter("r", 12, 3);
            board.PlaceLetter("i", 6, 2);
            board.PlaceLetter("e", 12, 2);
            board.PlaceLetter("o", 5, 1);
            board.PlaceLetter("d", 6, 1);
            board.PlaceLetter("e", 7, 1);
            board.PlaceLetter("k", 1, 0);
            board.PlaceLetter("a", 2, 0);
            board.PlaceLetter("u", 3, 0);
            board.PlaceLetter("r", 4, 0);
            board.PlaceLetter("i", 5, 0);
            List<string> hand = new List<string>() { "z", "o", "n", "y", "n", "f", "e" };
            int[] pos = new int[2];
            pos[0] = 0;
            pos[1] = 5;
            List<Move> moves = solve.GetMovesInArray(board, hand, board.GetCol(0), true, 0);
            Move best = solve.GetBestPlay(board, hand);
            System.Diagnostics.Debug.WriteLine(best.ToString());
            Assert.IsTrue(best.GetWord().Equals("fozy"));

        }
    }
}
