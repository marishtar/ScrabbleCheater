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
            
            List<string> dictionary = new List<string>();
            List<string> asdf = new List<string>();
            List<string> results;
            asdf.Add("a");
            asdf.Add("b");
            asdf.Add("c");
            ScrabbleCheater.Solver solve = new Solver(new ScrabbleBoard(new string[5,2],dictionary));
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
            ScrabbleCheater.Solver solve = new Solver(new ScrabbleBoard(new string[5, 2], dictionary));
            results = solve.GetPossibleWordsForRow(asdf,  board);
            Assert.IsTrue(results.Contains("abandonment"));
            Assert.IsTrue(results.Contains("band"));
            Assert.IsFalse(results.Contains("alpha"));
        }

        [TestMethod]
        public void PossibilityTest2()
        {

            List<string> asdf = new List<string>();
            List<string> results, dictionary;
            dictionary = new List<string>();
            asdf.Add("a");
            asdf.Add("b");
            List<string> board = new List<string>();
            board.Add("d");
            ScrabbleCheater.Solver solve = new Solver(new ScrabbleBoard(new string[5, 2],dictionary));
            results = solve.GetPossibleWordsForRow(asdf, board);
            Assert.IsTrue(results.Contains("bad"));
            Assert.IsFalse(results.Contains("a"));
            Assert.IsFalse(results.Contains("aa"));
        }

        [TestMethod]
        public void BoardColumnTest1()
        {
            string[,] baseBoard = new string[15, 15];
            string[] lines = System.IO.File.ReadAllLines("WWFDictionary.txt");
            List<string> dictionary = new List<string>();
            foreach (string s in lines)
            {
                dictionary.Add(s);
            }
            ScrabbleBoard board = new ScrabbleBoard(baseBoard, dictionary);
            board.PlaceLetter("a", 4, 5);
            board.PlaceLetter("s", 4, 4);
            board.PlaceLetter("d", 4, 3);
            board.PlaceLetter("f", 4, 2);
            Assert.IsTrue(board.CheckRowOrCol(5, false));
            Assert.IsTrue(board.CheckRowOrCol(4, false));
            Assert.IsTrue(board.CheckRowOrCol(3, false));
            Assert.IsTrue(board.CheckRowOrCol(2, false));
            Assert.IsFalse(board.CheckRowOrCol(4, true));
        }

        [TestMethod]
        public void BoardColumnTest2()
        {
            string[,] baseBoard = new string[15, 15];
            string[] lines = System.IO.File.ReadAllLines("WWFDictionary.txt");
            List<string> dictionary = new List<string>();
            foreach (string s in lines)
            {
                dictionary.Add(s);
            }
            ScrabbleBoard board = new ScrabbleBoard(baseBoard, dictionary);
            board.PlaceLetter("w", 2, 5);
            board.PlaceLetter("o", 3, 5);
            board.PlaceLetter("r", 4, 5);
            board.PlaceLetter("d", 5, 5);
            board.PlaceLetter("f", 7, 5);
            board.PlaceLetter("u", 8, 5);
            board.PlaceLetter("n", 9, 5);
            Assert.IsTrue(board.CheckRowOrCol(5,false));
        }

        [TestMethod]
        public void CheckIfValidMoveTest1()
        {
            string[,] baseBoard = new string[15, 15];
            string[] lines = System.IO.File.ReadAllLines("WWFDictionary.txt");
            List<string> dictionary = new List<string>();
            foreach (string s in lines)
            {
                dictionary.Add(s);
            }
            ScrabbleBoard board = new ScrabbleBoard(baseBoard, dictionary);
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
            string[,] baseBoard = new string[15, 15];
            string[] lines = System.IO.File.ReadAllLines("WWFDictionary.txt");
            List<string> dictionary = new List<string>();
            foreach (string s in lines)
            {
                dictionary.Add(s);
            }
            ScrabbleBoard board = new ScrabbleBoard(baseBoard, dictionary);
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
            string[,] baseBoard = new string[15, 15];
            string[] lines = System.IO.File.ReadAllLines("WWFDictionary.txt");
            List<string> dictionary = new List<string>();
            foreach (string s in lines)
            {
                dictionary.Add(s);
            }
            ScrabbleBoard board = new ScrabbleBoard(baseBoard, dictionary);
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
            string[,] baseBoard = new string[15, 15];
            string[] lines = System.IO.File.ReadAllLines("WWFDictionary.txt");
            List<string> dictionary = new List<string>();
            foreach (string s in lines)
            {
                dictionary.Add(s);
            }
            ScrabbleBoard board = new ScrabbleBoard(baseBoard, dictionary);
            board.PlaceLetter("f", 7, 5);
            board.PlaceLetter("u", 8, 5);
            board.PlaceLetter("n", 9, 5);
            List<string> hand = new List<string>() { "f", "u", "m", "n", "n", "y" };
            int[] pos = new int[2];
            pos[0] = 7;
            pos[1] = 6;
            Assert.IsFalse(board.CheckIfValidMove("fund", pos, true, hand));
        }
    }
}
