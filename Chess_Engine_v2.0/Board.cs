using System;
using System.Collections.Generic;
using System.Text;

namespace Chess_Engine_v2
{
    public class Board
    {
        #region Constants
        const string FEN_DEFAULT = "rnbqkbnr/pppppppp/8/8/8/8/PPPPPPPP/RNBQKBNR w KQkq - 0 1";
        const int a8 = 91;
        const int a7 = 81;
        const int a6 = 71;
        const int a5 = 61;
        const int a4 = 51;
        const int a3 = 41;
        const int a2 = 31;
        const int a1 = 21;
        const int b8 = 92;
        const int b7 = 82;
        const int b6 = 72;
        const int b5 = 62;
        const int b4 = 52;
        const int b3 = 42;
        const int b2 = 32;
        const int b1 = 22;
        const int c8 = 93;
        const int c7 = 83;
        const int c6 = 73;
        const int c5 = 63;
        const int c4 = 53;
        const int c3 = 43;
        const int c2 = 33;
        const int c1 = 23;
        const int d8 = 94;
        const int d7 = 84;
        const int d6 = 74;
        const int d5 = 64;
        const int d4 = 54;
        const int d3 = 44;
        const int d2 = 34;
        const int d1 = 24;
        const int e8 = 95;
        const int e7 = 85;
        const int e6 = 75;
        const int e5 = 65;
        const int e4 = 55;
        const int e3 = 45;
        const int e2 = 35;
        const int e1 = 25;
        const int f8 = 96;
        const int f7 = 86;
        const int f6 = 76;
        const int f5 = 66;
        const int f4 = 56;
        const int f3 = 46;
        const int f2 = 36;
        const int f1 = 26;
        const int g8 = 97;
        const int g7 = 87;
        const int g6 = 77;
        const int g5 = 67;
        const int g4 = 57;
        const int g3 = 47;
        const int g2 = 37;
        const int g1 = 27;
        const int h8 = 98;
        const int h7 = 88;
        const int h6 = 78;
        const int h5 = 68;
        const int h4 = 58;
        const int h3 = 48;
        const int h2 = 38;
        const int h1 = 28;
        #endregion

        #region Public Vars
        public int[] board;
        public string en_passant_target;
        public int half_ply;
        public int full_ply;
        public bool w_k_castle;
        public bool w_q_castle;
        public bool b_k_castle;
        public bool b_q_castle;
        public char side_to_move;
        #endregion

        #region Constructors
        /// <summary>
        /// Initialising board object
        /// </summary>
        public Board()
        {
            // init variables
            new FEN_Handler(FEN_DEFAULT, this);     // instatiating default start position
            Console.WriteLine("Board Initialised");
        }
        #endregion

        #region Methods
        /// <summary>
        /// Creating board based on custom FEN input
        /// </summary>
        /// <param name="FEN"></param>
        public void From_FEN(string FEN)
        {
            // init
            new FEN_Handler(FEN, this);             // setting custom fen position
            Console.WriteLine("Custom Board set in mem");
        }

        /// <summary>
        /// Makes move in board memory
        /// </summary>
        /// <param name="start_pos"></param>
        /// <param name="end_pos"></param>
        /// <param name="colour"></param>
        /// <returns></returns>
        public int[] Make_Move(int start_pos, int end_pos, char colour)
        {

            return new int[120];
        }
        #endregion
    }

}
