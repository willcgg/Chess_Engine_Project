using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess_Engine_Project
{
    public class Board
    {
        public static int[] board;

        public Board()
        {
            //10x12 board representation '-1' represents blocker piece or invalid move; 0-63 represents the actual chessboard
            board = new int[120];
            //black pieces
            board[21] = Piece.black | Piece.rook;
            board[22] = Piece.black | Piece.knight;
            board[23] = Piece.black | Piece.bishop;
            board[24] = Piece.black | Piece.queen;
            board[25] = Piece.black | Piece.king;
            board[26] = Piece.black | Piece.bishop;
            board[27] = Piece.black | Piece.knight;
            board[28] = Piece.black | Piece.rook;
            board[31] = Piece.black | Piece.pawn;
            board[32] = Piece.black | Piece.pawn;
            board[33] = Piece.black | Piece.pawn;
            board[34] = Piece.black | Piece.pawn;
            board[35] = Piece.black | Piece.pawn;
            board[36] = Piece.black | Piece.pawn;
            board[37] = Piece.black | Piece.pawn;
            board[38] = Piece.black | Piece.pawn;
            //white pieces
            board[91] = Piece.white | Piece.rook;
            board[92] = Piece.white | Piece.knight;
            board[93] = Piece.white | Piece.bishop;
            board[94] = Piece.white | Piece.queen;
            board[95] = Piece.white | Piece.king;
            board[96] = Piece.white | Piece.bishop;
            board[97] = Piece.white | Piece.knight;
            board[98] = Piece.white | Piece.rook;
            board[81] = Piece.white | Piece.pawn;
            board[82] = Piece.white | Piece.pawn;
            board[83] = Piece.white | Piece.pawn;
            board[84] = Piece.white | Piece.pawn;
            board[85] = Piece.white | Piece.pawn;
            board[86] = Piece.white | Piece.pawn;
            board[87] = Piece.white | Piece.pawn;
            board[88] = Piece.white | Piece.pawn;
        }
       

    }
}
/*{
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
           */