using System;
using System.Collections.Generic;
using System.Text;

namespace Chess_Engine_v2
{
    public class Board
    {
        #region Constants
        const string FEN_DEFAULT = "rnbqkbnr/pppppppp/8/8/8/8/PPPPPPPP/RNBQKBNR w KQkq - 0 1";
        
        /// <summary>
        /// Defines board squares array location from Whites perspective
        /// </summary>
        public enum Square
        {
            a8 = 21,
            a7 = 31,
            a6 = 41,
            a5 = 51,
            a4 = 61,
            a3 = 71,
            a2 = 81,
            a1 = 91,
            b8 = 22,
            b7 = 32,
            b6 = 42,
            b5 = 52,
            b4 = 62,
            b3 = 72,
            b2 = 82,
            b1 = 92,
            c8 = 23,
            c7 = 33,
            c6 = 43,
            c5 = 53,
            c4 = 63,
            c3 = 73,
            c2 = 83,
            c1 = 93,
            d8 = 24,
            d7 = 34,
            d6 = 44,
            d5 = 54,
            d4 = 64,
            d3 = 74,
            d2 = 84,
            d1 = 94,
            e8 = 25,
            e7 = 35,
            e6 = 45,
            e5 = 55,
            e4 = 65,
            e3 = 75,
            e2 = 85,
            e1 = 95,
            f8 = 26,
            f7 = 36,
            f6 = 46,
            f5 = 56,
            f4 = 66,
            f3 = 76,
            f2 = 86,
            f1 = 96,
            g8 = 27,
            g7 = 37,
            g6 = 47,
            g5 = 57,
            g4 = 67,
            g3 = 77,
            g2 = 87,
            g1 = 97,
            h8 = 28,
            h7 = 38,
            h6 = 48,
            h5 = 58,
            h4 = 68,
            h3 = 78,
            h2 = 88,
            h1 = 98
        }
        #endregion

        #region Public Vars
        public int[] board;
        public int en_passant_target;
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
        public int[] Make_Move(string start_pos, string end_pos, char colour)
        {
            // checking correct side is making move
            if(side_to_move == colour)
            {
                try
                {
                    // converting string input of square to arrays location of that square
                    Square start_square = (Square)Enum.Parse(typeof(Square), start_pos.ToLower());
                    Square end_square = (Square)Enum.Parse(typeof(Square), end_pos.ToLower());
                }
                catch (Exception e)
                {
                    Console.WriteLine("Make_Move method failed with error code: \n" + e);
                }
            }
            
            // return new board
            return board;
        }
        #endregion
    }

}
