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
        public static int[] Knight_Offsets = new int[] { 21, 19, 12, 8, -8, -12, -19, -21 };
        public static int[] Rook_Offsets = new int[] { 1, -1, 10, -10 };
        public static int[] KQ_Offsets = new int[] { 1, 9, 10, 11, -11, -10, -9, -1 };
        public static int[] No_Offsets = new int[] { 0 };

        // W pieces odd values, B pieces even
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

        /// <summary>
        /// Gets piece array directional offsets given a piece
        /// </summary>
        /// <param name="p"></param>
        /// <returns>Returns piece's offsets</returns>
        public static int[] Get_Piece_Offsets(Piece.Type p)
        {
            // checking what piece it is then returning appropriate movement vectors
            if (p == Piece.Type.b_pawn)
                return B_Pawn_Offsets;
            else if (p == Piece.Type.w_pawn)
                return W_Pawn_Offsets;
            else if (p == Piece.Type.w_knight || p == Piece.Type.b_knight)
                return Knight_Offsets;
            else if (p == Piece.Type.b_bishop || p == Piece.Type.w_bishop)
                return Bishop_Offsets;
            else if (p == Piece.Type.b_rook || p == Piece.Type.w_rook)
                return Rook_Offsets;
            else if (p == Piece.Type.b_king || p == Piece.Type.w_king || p == Piece.Type.b_queen || p == Piece.Type.w_queen)
                return KQ_Offsets;
            else
                return No_Offsets;
        }

        /// <summary>
        /// Gets piece colour when given a piece type
        /// </summary>
        /// <param name="piece"></param>
        /// <returns>Piece colour</returns>
        public static char Get_Piece_Colour(Piece.Type piece) {
            if (piece == Type.b_bishop || piece == Type.b_king || piece == Type.b_knight || piece == Type.b_pawn
                || piece == Type.b_queen || piece == Type.b_rook)
            {
                return 'b';
            }
            else if (piece == Type.w_bishop || piece == Type.w_king || piece == Type.w_knight || piece == Type.w_pawn
                || piece == Type.w_queen || piece == Type.w_rook)
            {
                return 'w';
            }
            else
                return 'n';
        }

    }
}

