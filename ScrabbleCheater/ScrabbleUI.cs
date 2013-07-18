using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ScrabbleCheater
{
    public partial class ScrabbleUI : Form
    {
        private TextBox[,] board = new TextBox[15, 15];
        public ScrabbleUI()
        {
            InitializeComponent();
            board[0, 0] = letter0_0;
            board[0, 1] = letter0_1;
            board[0, 2] = letter0_2;
            board[0, 3] = letter0_3;
            board[0, 4] = letter0_4;
            board[0, 5] = letter0_5;
            board[0, 6] = letter0_6;
            board[0, 7] = letter0_7;
            board[0, 8] = letter0_8;
            board[0, 9] = letter0_9;
            board[0, 10] = letter0_10;
            board[0, 11] = letter0_11;
            board[0, 12] = letter0_12;
            board[0, 13] = letter0_13;
            board[0, 14] = letter0_14;
            board[1, 0] = letter1_0;
            board[1, 1] = letter1_1;
            board[1, 2] = letter1_2;
            board[1, 3] = letter1_3;
            board[1, 4] = letter1_4;
            board[1, 5] = letter1_5;
            board[1, 6] = letter1_6;
            board[1, 7] = letter1_7;
            board[1, 8] = letter1_8;
            board[1, 9] = letter1_9;
            board[1, 10] = letter1_10;
            board[1, 11] = letter1_11;
            board[1, 12] = letter1_12;
            board[1, 13] = letter1_13;
            board[1, 14] = letter1_14;
            board[2, 0] = letter2_0;
            board[2, 1] = letter2_1;
            board[2, 2] = letter2_2;
            board[2, 3] = letter2_3;
            board[2, 4] = letter2_4;
            board[2, 5] = letter2_5;
            board[2, 6] = letter2_6;
            board[2, 7] = letter2_7;
            board[2, 8] = letter2_8;
            board[2, 9] = letter2_9;
            board[2, 10] = letter2_10;
            board[2, 11] = letter2_11;
            board[2, 12] = letter2_12;
            board[2, 13] = letter2_13;
            board[2, 14] = letter2_14;
            board[3, 0] = letter3_0;
            board[3, 1] = letter3_1;
            board[3, 2] = letter3_2;
            board[3, 3] = letter3_3;
            board[3, 4] = letter3_4;
            board[3, 5] = letter3_5;
            board[3, 6] = letter3_6;
            board[3, 7] = letter3_7;
            board[3, 8] = letter3_8;
            board[3, 9] = letter3_9;
            board[3, 10] = letter3_10;
            board[3, 11] = letter3_11;
            board[3, 12] = letter3_12;
            board[3, 13] = letter3_13;
            board[3, 14] = letter3_14;
            board[4, 0] = letter4_0;
            board[4, 1] = letter4_1;
            board[4, 2] = letter4_2;
            board[4, 3] = letter4_3;
            board[4, 4] = letter4_4;
            board[4, 5] = letter4_5;
            board[4, 6] = letter4_6;
            board[4, 7] = letter4_7;
            board[4, 8] = letter4_8;
            board[4, 9] = letter4_9;
            board[4, 10] = letter4_10;
            board[4, 11] = letter4_11;
            board[4, 12] = letter4_12;
            board[4, 13] = letter4_13;
            board[4, 14] = letter4_14;
            board[5, 0] = letter5_0;
            board[5, 1] = letter5_1;
            board[5, 2] = letter5_2;
            board[5, 3] = letter5_3;
            board[5, 4] = letter5_4;
            board[5, 5] = letter5_5;
            board[5, 6] = letter5_6;
            board[5, 7] = letter5_7;
            board[5, 8] = letter5_8;
            board[5, 9] = letter5_9;
            board[5, 10] = letter5_10;
            board[5, 11] = letter5_11;
            board[5, 12] = letter5_12;
            board[5, 13] = letter5_13;
            board[5, 14] = letter5_14;
            board[6, 0] = letter6_0;
            board[6, 1] = letter6_1;
            board[6, 2] = letter6_2;
            board[6, 3] = letter6_3;
            board[6, 4] = letter6_4;
            board[6, 5] = letter6_5;
            board[6, 6] = letter6_6;
            board[6, 7] = letter6_7;
            board[6, 8] = letter6_8;
            board[6, 9] = letter6_9;
            board[6, 10] = letter6_10;
            board[6, 11] = letter6_11;
            board[6, 12] = letter6_12;
            board[6, 13] = letter6_13;
            board[6, 14] = letter6_14;
            board[7, 0] = letter7_0;
            board[7, 1] = letter7_1;
            board[7, 2] = letter7_2;
            board[7, 3] = letter7_3;
            board[7, 4] = letter7_4;
            board[7, 5] = letter7_5;
            board[7, 6] = letter7_6;
            board[7, 7] = letter7_7;
            board[7, 8] = letter7_8;
            board[7, 9] = letter7_9;
            board[7, 10] = letter7_10;
            board[7, 11] = letter7_11;
            board[7, 12] = letter7_12;
            board[7, 13] = letter7_13;
            board[7, 14] = letter7_14;
            board[8, 0] = letter8_0;
            board[8, 1] = letter8_1;
            board[8, 2] = letter8_2;
            board[8, 3] = letter8_3;
            board[8, 4] = letter8_4;
            board[8, 5] = letter8_5;
            board[8, 6] = letter8_6;
            board[8, 7] = letter8_7;
            board[8, 8] = letter8_8;
            board[8, 9] = letter8_9;
            board[8, 10] = letter8_10;
            board[8, 11] = letter8_11;
            board[8, 12] = letter8_12;
            board[8, 13] = letter8_13;
            board[8, 14] = letter8_14;
            board[9, 0] = letter9_0;
            board[9, 1] = letter9_1;
            board[9, 2] = letter9_2;
            board[9, 3] = letter9_3;
            board[9, 4] = letter9_4;
            board[9, 5] = letter9_5;
            board[9, 6] = letter9_6;
            board[9, 7] = letter9_7;
            board[9, 8] = letter9_8;
            board[9, 9] = letter9_9;
            board[9, 10] = letter9_10;
            board[9, 11] = letter9_11;
            board[9, 12] = letter9_12;
            board[9, 13] = letter9_13;
            board[9, 14] = letter9_14;
            board[10, 0] = letter10_0;
            board[10, 1] = letter10_1;
            board[10, 2] = letter10_2;
            board[10, 3] = letter10_3;
            board[10, 4] = letter10_4;
            board[10, 5] = letter10_5;
            board[10, 6] = letter10_6;
            board[10, 7] = letter10_7;
            board[10, 8] = letter10_8;
            board[10, 9] = letter10_9;
            board[10, 10] = letter10_10;
            board[10, 11] = letter10_11;
            board[10, 12] = letter10_12;
            board[10, 13] = letter10_13;
            board[10, 14] = letter10_14;
            board[11, 0] = letter11_0;
            board[11, 1] = letter11_1;
            board[11, 2] = letter11_2;
            board[11, 3] = letter11_3;
            board[11, 4] = letter11_4;
            board[11, 5] = letter11_5;
            board[11, 6] = letter11_6;
            board[11, 7] = letter11_7;
            board[11, 8] = letter11_8;
            board[11, 9] = letter11_9;
            board[11, 10] = letter11_10;
            board[11, 11] = letter11_11;
            board[11, 12] = letter11_12;
            board[11, 13] = letter11_13;
            board[11, 14] = letter11_14;
            board[12, 0] = letter12_0;
            board[12, 1] = letter12_1;
            board[12, 2] = letter12_2;
            board[12, 3] = letter12_3;
            board[12, 4] = letter12_4;
            board[12, 5] = letter12_5;
            board[12, 6] = letter12_6;
            board[12, 7] = letter12_7;
            board[12, 8] = letter12_8;
            board[12, 9] = letter12_9;
            board[12, 10] = letter12_10;
            board[12, 11] = letter12_11;
            board[12, 12] = letter12_12;
            board[12, 13] = letter12_13;
            board[12, 14] = letter12_14;
            board[13, 0] = letter13_0;
            board[13, 1] = letter13_1;
            board[13, 2] = letter13_2;
            board[13, 3] = letter13_3;
            board[13, 4] = letter13_4;
            board[13, 5] = letter13_5;
            board[13, 6] = letter13_6;
            board[13, 7] = letter13_7;
            board[13, 8] = letter13_8;
            board[13, 9] = letter13_9;
            board[13, 10] = letter13_10;
            board[13, 11] = letter13_11;
            board[13, 12] = letter13_12;
            board[13, 13] = letter13_13;
            board[13, 14] = letter13_14;
            board[14, 0] = letter14_0;
            board[14, 1] = letter14_1;
            board[14, 2] = letter14_2;
            board[14, 3] = letter14_3;
            board[14, 4] = letter14_4;
            board[14, 5] = letter14_5;
            board[14, 6] = letter14_6;
            board[14, 7] = letter14_7;
            board[14, 8] = letter14_8;
            board[14, 9] = letter14_9;
            board[14, 10] = letter14_10;
            board[14, 11] = letter14_11;
            board[14, 12] = letter14_12;
            board[14, 13] = letter14_13;
            board[14, 14] = letter14_14;
        }

        private void rectangleShape1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void ScrabbleUI_Load(object sender, EventArgs e)
        {

        }

        //generate solution
        private void button1_Click(object sender, EventArgs e)
        {
            foreach (TextBox letterBox in board)
            {
                letterBox.ForeColor = Color.Black;
            }
            int[] pos = new int[2];
            pos[0] = 5;
            pos[1] = 6;
            Move move = new Move("hi", pos, true);
            List<string> hand = new List<string>();
            hand.Add(handLetter0.Text);
            hand.Add(handLetter1.Text);
            hand.Add(handLetter2.Text);
            hand.Add(handLetter3.Text);
            hand.Add(handLetter4.Text);
            hand.Add(handLetter5.Text);
            hand.Add(handLetter6.Text);
            while (hand.Contains(""))
            {
                hand.Remove("");
            }
            string[,] baseBoard = new string[15,15];

            Dictionary<string, int> letters;
            if (WWFRadio.Checked)
            {
                letters = new Dictionary<string, int>()
                    {
                        {"a",1}, {"b",4}, {"c",4}, {"d",2}, {"e",1}, {"f",4}, {"g",3}, {"h",3}, {"i",1}, {"j",10}, {"k",5}, {"l",2}, {"m",4}, 
                        {"n",2}, {"o",1}, {"p",4}, {"q",10}, {"r",1}, {"s",1}, {"t",1}, {"u",2}, {"v",5}, {"w",4}, {"x",8}, {"y",3}, {"z",10}, 
                    };
            }
            else
            {
                letters = new Dictionary<string, int>()
                    {
                        {"a",1}, {"b",3}, {"c",3}, {"d",2}, {"e",1}, {"f",4}, {"g",2}, {"h",4}, {"i",1}, {"j",8}, {"k",5}, {"l",1}, {"m",3}, 
                        {"n",1}, {"o",1}, {"p",3}, {"q",10}, {"r",1}, {"s",1}, {"t",1}, {"u",1}, {"v",4}, {"w",4}, {"x",8}, {"y",4}, {"z",10}, 
                    };
            }

            
            string[] lines = System.IO.File.ReadAllLines("WWFDictionary.txt");
            List<string> dictionary = new List<string>();
            foreach (string s in lines)
            {
                dictionary.Add(s);
            }

            ScrabbleBoard scrabBoard = new ScrabbleBoard(baseBoard, dictionary, letters);

            int x = 0;
            int y = 0;
            string[,] boardl = new string[15, 15];
            while (x < 15)
            {
                y = 0;
                while (y < 15)
                {
                    boardl[x, y] = (board[x, y].Text.Equals("") ? null : board[x, y].Text);
                    y++;
                }
                x++;
            }
            scrabBoard.SetBoard(boardl);
            Solver solv = new Solver(scrabBoard);
            PlaceWord(solv.GetBestPlay(scrabBoard, hand),true);

        }

        private void PlaceWord(Move move,Boolean isNew)
        {
            int x = move.GetPosition()[0];
            int y = move.GetPosition()[1];
            int counter = 0;
            while (counter < move.GetWord().Length)
            {
                board[x, y].Text = move.GetWord().Substring(counter, 1);
                if (isNew)
                {
                    board[x, y].ForeColor = Color.Red;
                }
                if (move.GetIfNorthSouth())
                {
                    y--;
                }
                else
                {
                    x++;
                }
                counter++;
            }
        }

        


        
    }
}
