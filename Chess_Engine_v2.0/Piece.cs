using System;
using System.Collections.Generic;
using System.Text;

namespace Chess_Engine_v2
{
    public class Piece
    {
        // piece offsets in board array
        public static int[] W_Pawn_Offsets = new int[] { -10, -20, -9, -11 };
        public static int[] B_Pawn_Offsets = new int[] { 10, 20, 9, 11 };
        public static int[] Bishop_Offsets = new int[] { 9, 11, -9, -11 };
        public static int[] Knight_Offsets = new int[] { 21, 19, 12, 8, -8, -12, -19, 21 };
        public static int[] Rook_Offsets = new int[] { 1, -1, 10, -10 };
        public static int[] KQ_Offsets = new int[] { 1, 9, 10, 11, -11, -10, -9, 1 };

        public enum Type
        {
            blockerPiece = -1,   //-1
            empty = 0,           //0
            w_pawn = 1,          //1
            b_pawn = 2,          //1
            w_knight = 3,        //3
            b_knight = 4,        //4
            w_bishop = 5,        //5
            b_bishop = 6,        //6
            w_rook = 7,          //7
            b_rook = 8,          //8
            w_queen = 9,         //9
            b_queen = 10,        //10
            w_king = 11,         //11
            b_king = 12          //12
        }
    }
}

