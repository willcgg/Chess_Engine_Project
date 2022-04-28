using System;
using System.Collections.Generic;
using System.Text;

namespace Chess_Engine_v2
{
    public class Board
    {
        #region Constants
        // default board pos
        const string FEN_DEFAULT = "rnbqkbnr/pppppppp/8/8/8/8/PPPPPPPP/RNBQKBNR w KQkq - 0 1";
        // piece offsets in board array
        readonly int[] W_Pawn_Offsets = new int[] { -10, -20, -9, -11 };
        readonly int[] B_Pawn_Offsets = new int[] { 10, 20, 9, 11 };
        readonly int[] Bishop_Offsets = new int[] { 9, 11, -9, -11 };
        readonly int[] Knight_Offsets = new int[] { 21, 19, 12, 8, -8, -12, -19, 21 };
        readonly int[] Rook_Offsets = new int[] { 1, -1, 10, -10 };
        readonly int[] KQ_Offsets = new int[] { 1, 9, 10, 11, -11, -10, -9, 1 };
        // square array positions
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
            // init
            Piece.Type selected_piece;
            Piece.Type target_piece;
            int[] piece_offsets;
            int start_square;
            int end_square;
            bool valid_move;

            // checking correct side is making move
            if (side_to_move == colour)
            {
                // converting string input of square to arrays location of that square
                start_square = (int)Enum.Parse(typeof(Square), start_pos);
                end_square = (int)Enum.Parse(typeof(Square), end_pos);
                // work out what piece is in the selected square
                selected_piece = (Piece.Type)start_square;
                target_piece = (Piece.Type)end_square;
                // selecting vector offset
                if (selected_piece == Piece.Type.w_pawn)
                    piece_offsets = W_Pawn_Offsets;
                else if (selected_piece == Piece.Type.b_pawn)
                    piece_offsets = B_Pawn_Offsets;
                else if (selected_piece == Piece.Type.b_knight || selected_piece == Piece.Type.b_knight)
                    piece_offsets = Knight_Offsets;
                else if (selected_piece == Piece.Type.b_queen || selected_piece == Piece.Type.w_queen || selected_piece == Piece.Type.b_king || selected_piece == Piece.Type.w_king)
                    piece_offsets = KQ_Offsets;
                else if (selected_piece == Piece.Type.b_bishop || selected_piece == Piece.Type.w_bishop)
                    piece_offsets = Bishop_Offsets;
                else
                    piece_offsets = Rook_Offsets;
                // blocking pieces?

                // move the piece


                // incrementing half-ply if no piece taken
                half_ply++;
                // changing side to move and full-ply
                if (side_to_move == 'w')
                    side_to_move = 'b';
                else
                {
                    side_to_move = 'w';
                    full_ply++;
                }

            }
            else
                Console.WriteLine("Wrong colour attempting to move");

            // return new board
            return board;
        }

        /// <summary>
        /// Converts ASCII board string to a board int[] array. Does not touch board properties due to it being impossible
        /// to tell whether the king or either rooks have moved with only board position
        /// </summary>
        /// <param name="ASCII_Board"></param>
        /// <returns>int[] board</returns>
        public int[] Convert_From_ASCII(string ASCII_Board)
        {
            // init vars
            int x = 21;
            string[] ranks = ASCII_Board.Split('\n');           // split into ranks
            // convert to board
            foreach (string rank in ranks)
            {
                foreach (char piece in rank)
                {
                    switch (piece)
                    {
                        case '^':
                            board[x] = (int)Piece.Type.empty;
                            break;
                        case '♙':
                            board[x] = (int)Piece.Type.w_pawn;
                            break;
                        case '♟':
                            board[x] = (int)Piece.Type.b_pawn;
                            break;
                        case '♘':
                            board[x] = (int)Piece.Type.w_knight;
                            break;
                        case '♞':
                            board[x] = (int)Piece.Type.b_knight;
                            break;
                        case '♗':
                            board[x] = (int)Piece.Type.w_bishop;
                            break;
                        case '♝':
                            board[x] = (int)Piece.Type.b_bishop;
                            break;
                        case '♖':
                            board[x] = (int)Piece.Type.w_rook;
                            break;
                        case '♜':
                            board[x] = (int)Piece.Type.b_rook;
                            break;
                        case '♕':
                            board[x] = (int)Piece.Type.w_queen;
                            break;
                        case '♛':
                            board[x] = (int)Piece.Type.b_queen;
                            break;
                        case '♔':
                            board[x] = (int)Piece.Type.w_king;
                            break;
                        case '♚':
                            board[x] = (int)Piece.Type.b_king;
                            break;
                    }
                    x += 1;
                }
                x += 2;         // skip blocker pieces
            }
            return board;
        }
        #endregion
    }

}
