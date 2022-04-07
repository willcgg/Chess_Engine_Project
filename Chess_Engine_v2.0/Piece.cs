﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Chess_Engine_v2
{
    public class Piece
    {
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
