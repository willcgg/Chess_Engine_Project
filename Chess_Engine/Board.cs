using System;
using System.Collections.Generic;
using System.Text;

namespace Chess_Engine
{
    class Board
    {
        int[] board;

        public Board()
        {
            /*
            10x12 board representation '-1' represents blocker piece or invalid move; 0-63 represents the actual chessboard
            Board will look like below in memory
            {
               -1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
               -1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
               -1,  0,  1,  2,  3,  4,  5,  6,  7, -1,
               -1,  8,  9, 10, 11, 12, 13, 14, 15, -1,
               -1, 16, 17, 18, 19, 20, 21, 22, 23, -1,
               -1, 24, 25, 26, 27, 28, 29, 30, 31, -1,
               -1, 32, 33, 34, 35, 36, 37, 38, 39, -1,
               -1, 40, 41, 42, 43, 44, 45, 46, 47, -1,
               -1, 48, 49, 50, 51, 52, 53, 54, 55, -1,
               -1, 56, 57, 58, 59, 60, 61, 62, 63, -1,
               -1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
               -1, -1, -1, -1, -1, -1, -1, -1, -1, -1
           };
           

            //initialising board state
            board = new int[120];
            //black pieces
            for (int x = 31; x < 39; x++)
            {
                board[x] = PieceColour.black | PieceType.pawn;
            }
            board[21] = Piece.PieceColour.black + Piece.PieceType.rook;
            board[22] = Piece.black | Piece.knight;
            board[23] = Piece.black | Piece.bishop;
            board[24] = Piece.black | Piece.queen;
            board[25] = Piece.black | Piece.king;
            board[26] = Piece.black | Piece.bishop;
            board[27] = Piece.black | Piece.knight;
            board[28] = Piece.black | Piece.rook;

            //white pieces
            for (int x = 81; x < 89; x++)
            {
                board[x] = Piece.white | Piece.pawn;
            }
            board[91] = Piece.white | Piece.rook;
            board[92] = Piece.white | Piece.knight;
            board[93] = Piece.white | Piece.bishop;
            board[94] = Piece.white | Piece.queen;
            board[95] = Piece.white | Piece.king;
            board[96] = Piece.white | Piece.bishop;
            board[97] = Piece.white | Piece.knight;
            board[98] = Piece.white | Piece.rook;

            //empty squares
            for (int x = 41; x < 79; x++)
            {
                board[x] = Piece.empty;
            }


            //blocker pieces
            for (int x = 0; x < 21; x++)
            {
                board[x] = Piece.blockerPiece;
            }
            for (int x = 100; x < 120; x++)
            {
                board[x] = Piece.blockerPiece;
            }
            for (int x = 29; x < 100; x += 10)
            {
                board[x] = Piece.blockerPiece;
            }
            for (int x = 30; x < 100; x += 10)
            {
                board[x] = Piece.blockerPiece;
            }
            */
        }
    }
}
