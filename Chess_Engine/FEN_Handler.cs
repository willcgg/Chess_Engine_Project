using System;
using System.Collections.Generic;
using System.Text;

namespace Chess_Engine
{
    /// <summary>
    /// Reads string from GUI FEN string input text box and generates the board it represents.
    /// <para>Paramaters: Takes in string as a paramater.</para>
    /// <para>Outputs: pieces to GUI board, creates internal board representation of position</para>
    /// </summary>
    class FEN_Handler
    {
        /*
         * board array representation
         * board is in the middle of the board with 2 sentinel rows and 1 coloumn either side
         *   0  , 1 , 2 , 3, 4, 5, 6, 7, 8, 9
         *   10,11,12 ...
         *   20,21, ...
         *   30
         *   40
         *   50
         *   60
         *   70
         *   80
         *   90, ..................... 98, 99
         *   100, ........................ 109
         *   110,111,112, ................ 119
         * Therefore, the boards starting position in the array is 21 and ends at 98
        */


        /*
          FEN FIELDS:
        > Piece placement (from White's perspective). Each rank is described, starting with rank 8 and ending with rank 1; within each rank,
        the contents of each square are described from file "a" through file "h". Following the Standard Algebraic Notation (SAN), each piece
        is identified by a single letter taken from the standard English names
        (pawn = "P", knight = "N", bishop = "B", rook = "R", queen = "Q" and king = "K").
        White pieces are designated using upper-case letters ("PNBRQK") while black pieces use lowercase ("pnbrqk").
        Empty squares are noted using digits 1 through 8 (the number of empty squares), and "/" separates ranks.

        > Active color. "w" means White moves next, "b" means Black moves next.

        > Castling availability. If neither side can castle, this is "-". Otherwise, this has one or more letters: "K" (White can castle kingside),
        "Q" (White can castle queenside), "k" (Black can castle kingside), and/or "q" (Black can castle queenside). A move that temporarily prevents
        castling does not negate this notation.

        > En passant target square in algebraic notation. If there's no en passant target square, this is "-". If a pawn has just made a two-square move,
        this is the position "behind" the pawn. This is recorded regardless of whether there is a pawn in position to make an en passant capture.[6]

        > Halfmove clock: The number of halfmoves since the last capture or pawn advance, used for the fifty-move rule.

        > Fullmove number: The number of the full move. It starts at 1, and is incremented after Black's move.
        */

        // Constants
        const string FEN_START = "rnbqkbnr/pppppppp/8/8/8/8/PPPPPPPP/RNBQKBNR w KQkq - 0 1";     // Default start position
        // variables
        string[] FEN_Rows;                          // User inputted FEN string, checked before passed as param
        Dictionary<string, Piece.Type> FEN_Dict;    // Dictionary to hold what piece types are represented by what letters in FEN string

        public void Handler(string FEN)
        {
            // Initialising variables 
            FEN_Dict = new Dictionary<string, Piece.Type>();
            FEN_Dict.Add("p", Piece.Type.b_pawn);
            FEN_Dict.Add("b", Piece.Type.b_bishop);
            FEN_Dict.Add("n", Piece.Type.b_knight);
            FEN_Dict.Add("r", Piece.Type.b_rook);
            FEN_Dict.Add("q", Piece.Type.b_queen);
            FEN_Dict.Add("k", Piece.Type.b_king);
            FEN_Dict.Add("P", Piece.Type.w_pawn);
            FEN_Dict.Add("B", Piece.Type.w_bishop);
            FEN_Dict.Add("N", Piece.Type.w_knight);
            FEN_Dict.Add("R", Piece.Type.w_rook);
            FEN_Dict.Add("Q", Piece.Type.w_queen);
            FEN_Dict.Add("K", Piece.Type.w_king);

            FEN_Rows = new string[13];

            // Split string into respective fields
            // String Format:   "string char string string int int"
            string[] FEN_Seg = FEN.Split(" ");             // Splits FEN into parts [{Position}, {Active Colour}, {Castle Availabiility}, {En-Passant Availability}, {Half-Ply}, {Full-Ply}]
            string[] FEN_Pos = FEN_Seg[0].Split("/");      // Splits the position part of the FEN into seperate rows

            int count = 0;
            foreach (string row in FEN_Pos)
            {
                FEN_Rows[count] = row;
                count++;
            }
            
            for(int index = 1; index < FEN_Seg.Length; index++)
            {
                FEN_Rows[count] = FEN_Seg[index];
                count++;
            }

            foreach (string i in FEN_Rows)
                Console.WriteLine(i);
            
            
        }



    }
}
