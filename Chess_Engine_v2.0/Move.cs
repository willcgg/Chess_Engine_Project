using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess_Engine_v2._0
{
    public class Move
    {
        public char COLOUR;
        public int START_SQUARE;
        public int TARGET_SQUARE;
        public Piece.Type PIECE;
        public Piece.Type TARGET_PIECE;
        public bool CAPTURE;
        public bool PROMOTION;


    }    
}
