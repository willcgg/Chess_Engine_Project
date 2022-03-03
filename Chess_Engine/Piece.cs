using System;
using System.Collections.Generic;
using System.Text;

namespace Chess_Engine
{
    class Piece
    {
        public enum PieceType
        {
            blockerPiece = -1,   //-1
            pawn = 1,           //1
            knight = 2,         //3
            bishop = 3,         //4
            rook = 4,           //5
            queen = 5,          //9
            king = 6            //10
        }
        public enum PieceColour
        {
            black = 0,          //8
            white = 1           //1
        }




    }
}
