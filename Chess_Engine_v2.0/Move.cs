using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess_Engine_v2._0
{
    /// <summary>
    /// Class to uniquely describe every possible chess move
    /// </summary>
    public class Move
    {
        // basic move info
        public string START_SQUARE;
        public string TARGET_SQUARE;
        public Flag FLAG;
        public bool CHECK_MOVE;
        // type of move
        public enum Flag
        {
            quiet,
            double_pawn_push,
            king_castle,
            queen_castle,
            capture,
            en_passant_capture,
            knight_promote,
            bishop_promote,
            rook_promote,
            queen_promote,
            knight_capture_promote,
            bishop_capture_promote,
            rook_capture_promote,
            queen_capture_promote
        }
    }    
}
