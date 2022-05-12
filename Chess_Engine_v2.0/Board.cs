using Chess_Engine_v2._0;
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
        /// Returns piece type from board poisition
        /// </summary>
        /// <returns>Piece int</returns>
        public int Get_Piece(string sqr)
        {
            int piece;
            // converting string square to actual square array location
            int square = (int)Enum.Parse(typeof(Square), sqr);
            // getting the indentifier of the piece on that square
            piece = board[square];
            return piece;
        }

        /// <summary>
        /// Function to find all valid board squares for any given piece
        /// </summary>
        /// <param name="piece"></param>
        /// <param name="square"></param>
        /// <returns>Legal move board index's</returns>
        public List<int> Get_Valid_Moves(Piece.Type piece, string start_square)
        {
            // init
            int[] offsets;
            List<int> valid_moves;
            int square;
            int index;
            // converting start square to board index
            square = (int)Enum.Parse(typeof(Square), start_square);
            // getting piece movement offset
            offsets = Piece.Get_Piece_Offsets(piece);
            // blocking pieces?
            valid_moves = new List<int>();
            foreach (int offset in offsets)
            {
                // loops through each offset
                // target square starting on first square in offset direction
                index = square + offset;
                int target_square = board[index];
                // iterating until find a blocking piece or off board pos
                while (target_square != 0)
                {
                    // move valid add to list
                    valid_moves.Add(target_square);
                    // increment index
                    index += offset;
                    // setting target square to new board position before next loop
                    target_square = board[index];
                }
            }
            // returning valid_moves
            return valid_moves;
        }

        /// <summary>
        /// Makes move in board memory
        /// </summary>
        /// <param name="start_pos"></param>
        /// <param name="end_pos"></param>
        /// <param name="colour"></param>
        /// <returns></returns>
        public void Make_Move(Move m)
        {
            // init
            Move move = m;
            int start_square;
            int target_square;
            Piece.Type piece;
            // converting string input of square to arrays location of that square
            start_square = (int)Enum.Parse(typeof(Square), move.START_SQUARE);
            target_square = (int)Enum.Parse(typeof(Square), move.TARGET_SQUARE);
            // getting piece moved
            piece = (Piece.Type)board[start_square];
            // move type?
            switch (move.FLAG)
            {
                case Move.Flag.quiet:
                    break;
                case Move.Flag.capture:
                    break;
                case Move.Flag.double_pawn_push:
                    break;
                default:
                    break;
            }



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
