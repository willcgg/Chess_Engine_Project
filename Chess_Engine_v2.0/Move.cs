using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess_Engine_v2._0
{
    public class Move
    {
        public string START_SQUARE;
        public string TARGET_SQUARE;
        public Piece.Type PIECE;
        public Piece.Type TARGET_PIECE;
        public bool CAPTURE;
        public bool PROMOTION;
    }    
}
