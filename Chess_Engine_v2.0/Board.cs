﻿using Chess_Engine_v2._0;
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
        public int Get_Piece(string sqr) {
            int piece;
            // converting string square to actual square array location
            int square = (int)Enum.Parse(typeof(Square), sqr);
            // getting the indentifier of the piece on that square
            piece = board[square];
            return piece;
        }

        public void Get_Valid_Moves(Piece.Type piece)
        {
            // 
        }

        /// <summary>
        /// Makes move in board memory
        /// </summary>
        /// <param name="start_pos"></param>
        /// <param name="end_pos"></param>
        /// <param name="colour"></param>
        /// <returns></returns>
        public int[] Make_Move(Move m)
        {
            // init
            Move move = new Move();
            int[] piece_offsets;

            // checking correct side is making move
            if (side_to_move == move.COLOUR)
            {
                // converting string input of square to arrays location of that square
                move.START_SQUARE = (int)Enum.Parse(typeof(Square), start_pos);
                move.TARGET_SQUARE = (int)Enum.Parse(typeof(Square), end_pos);
                // work out what piece is in the selected square
                move.PIECE = (Piece.Type)move.START_SQUARE;
                move.TARGET_PIECE = (Piece.Type)move.TARGET_SQUARE;
                // selecting vector offset
                if (move.PIECE == Piece.Type.w_pawn)
                    piece_offsets = Piece.W_Pawn_Offsets;
                else if (move.PIECE == Piece.Type.b_pawn)
                    piece_offsets = Piece.B_Pawn_Offsets;
                else if (move.PIECE == Piece.Type.b_knight || move.PIECE == Piece.Type.b_knight)
                    piece_offsets = Piece.Knight_Offsets;
                else if (move.PIECE == Piece.Type.b_queen || move.PIECE == Piece.Type.w_queen || move.PIECE == Piece.Type.b_king || move.PIECE == Piece.Type.w_king)
                    piece_offsets = Piece.KQ_Offsets;
                else if (move.PIECE == Piece.Type.b_bishop || move.PIECE == Piece.Type.w_bishop)
                    piece_offsets = Piece.Bishop_Offsets;
                else
                    piece_offsets = Piece.Rook_Offsets;
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
