using System;
using System.Collections.Generic;
using System.Text;

namespace Chess_Engine_v2
{
    /// <summary>
    /// Reads string from GUI FEN string input text box and generates the board it represents.
    /// <para>Paramaters: Takes in string as a paramater.</para>
    /// <para>Outputs: pieces to GUI board, creates internal board representation of position</para>
    /// <para>Also homes the Convert_To_ASCII Method which reads board state and outputs in human readable ASCII
    /// characters for use in testing</para>
    /// </summary>
    public class FEN_Handler
    {
        // Public vars
        readonly string[] FEN_Seg;
        readonly string[] FEN_Pos;
        readonly Board b;

        /*
          FEN FIELDS:
        > Piece placement. FROM WHITES PERSPECTIVE Either upper or lower case char to represent each piece, or a number to represent empty squares
        > Active color. "w" means White moves next, "b" means Black moves next.
        > Castling availability. - means neither side can castle, KQ means white can castle king and queen side, k means black can only castle king side
        > En passant target square in algebraic notation. If there's no en passant target square, this is "-". If a pawn has just made a two-square move,
        this is the position "behind" the pawn. This is recorded regardless of whether there is a pawn in position to make an en passant capture.
        > Halfmove clock: The number of halfmoves since the last capture or pawn advance, used for the fifty-move rule.
        > Fullmove number: The number of the full move. It starts at 1, and is incremented after Black's move.
        */

        public FEN_Handler(string FEN, Board board)
        {
            // init vars
            FEN_Seg = new string[6];
            FEN_Pos = new string[8];
            b = board;

            // Split string into respective fields
            // String Format:   "string char string string int int"
            FEN_Seg = FEN.Split(' ');             // Splits FEN into parts [{Position}, {Active Colour}, {Castle Availabiility}, {En-Passant Availability}, {Half-Ply}, {Full-Ply}]
            FEN_Pos = FEN_Seg[0].Split('/');      // Splits the position part of the FEN into seperate rows

            // Preparing board params
            b.board = Create_Board(FEN_Pos);                // Calling the creation of the board
            b.side_to_move = char.Parse(FEN_Seg[1]);
            Can_Castle(FEN_Seg[2]);
            try
            {
                b.en_passant_target = (int)Enum.Parse(typeof(Board.Square), FEN_Seg[3]);
            }
            catch
            {
                b.en_passant_target = 0;        // un-clickable square on UI, cannot be null
            }
            b.half_ply = int.Parse(FEN_Seg[4]);
            b.full_ply = int.Parse(FEN_Seg[5]);
            Console.WriteLine("Board Ready...");
        }

        public FEN_Handler(Board board)
        {
            b = board;
        }


        /// <summary>
        /// Takes in FEN representation of board position and returns integer array representation
        /// <para>Board Array Representation
        /// Board is in the middle of the 10x12 array with 2 sentinel rows and 1 coloumn either side
        /// <para>0  , 1 , 2 , 3, 4, 5, 6, 7, 8, 9</para>   
        /// <para>10,11,12 ...</para>   
        /// <para>20,21, ...</para>   
        /// <para>30</para>   
        /// <para>40</para>   
        /// <para>50</para>   
        /// <para>60</para>   
        /// <para>70</para>   
        /// <para>80</para>   
        /// <para>90, ..................... 98, 99</para>   
        /// <para>100, ........................ 109</para>   
        /// <para>110,111,112, ................ 119</para>   
        /// Therefore, the boards starting position in the array is 21 and ends at 98</para>
        /// </summary>
        /// <param name="FEN_Pos"></param>
        /// <returns></returns>
        public int[] Create_Board(string[] FEN_Pos) {
            // Init
            int[] b = new int[120];
            int pointer = 21;                   // real board starting pos

            foreach(string row in FEN_Pos)      // looping through each row in FEN_Pos
            {
                foreach(char piece in row)      // looping through each character in each row
                {
                    switch(piece)               // switch case to identify each character to a piece or number of empty spaces
                    {
                        case '1':
                            b[pointer] = (int)Piece.Type.empty;
                            break;
                        case '2':
                            b[pointer] = (int)Piece.Type.empty;
                            b[pointer+1] = (int)Piece.Type.empty;
                            pointer ++;
                            break;
                        case '3':
                            for(int i = pointer; i < pointer + 3; i++)
                                b[i] = (int)Piece.Type.empty;
                            pointer += 2;
                            break;
                        case '4':
                            for (int i = pointer; i < pointer + 4; i++)
                                b[i] = (int)Piece.Type.empty;
                            pointer += 3;
                            break;
                        case '5':
                            for (int i = pointer; i < pointer + 5; i++)
                                b[i] = (int)Piece.Type.empty;
                            pointer += 4;
                            break;
                        case '6':
                            for (int i = pointer; i < pointer + 6; i++)
                                b[i] = (int)Piece.Type.empty;
                            pointer += 5;
                            break;
                        case '7':
                            for (int i = pointer; i < pointer + 7; i++)
                                b[i] = (int)Piece.Type.empty;
                            pointer += 6;
                            break;
                        case 'p':
                            b[pointer] = (int)Piece.Type.b_pawn;
                            break;
                        case 'b':
                            b[pointer] = (int)Piece.Type.b_bishop;
                            break;
                        case 'n':
                            b[pointer] = (int)Piece.Type.b_knight;
                            break;
                        case 'r':
                            b[pointer] = (int)Piece.Type.b_rook;
                            break;
                        case 'q':
                            b[pointer] = (int)Piece.Type.b_queen;
                            break;
                        case 'k':
                            b[pointer] = (int)Piece.Type.b_king;
                            break;
                        case 'P':
                            b[pointer] = (int)Piece.Type.w_pawn;
                            break;
                        case 'B':
                            b[pointer] = (int)Piece.Type.w_bishop;
                            break;
                        case 'N':
                            b[pointer] = (int)Piece.Type.w_knight;
                            break;
                        case 'R':
                            b[pointer] = (int)Piece.Type.w_rook;
                            break;
                        case 'Q':
                            b[pointer] = (int)Piece.Type.w_queen;
                            break;
                        case 'K':
                            b[pointer] = (int)Piece.Type.w_king;
                            break;
                        default:
                            for (int i = pointer; i < pointer + 8; i++)
                                b[i] = (int)Piece.Type.empty;
                            pointer += 7;
                            break;
                    }
                    pointer++;  // adds one to pointer after each char
                }
                pointer += 2;   // adds 2 to the pointer to avoid sentinel columns
            }

            // blocker pieces
            for (int x = 0; x < 21; x++)        
            {
                b[x] = (int)Piece.Type.blockerPiece;        // first 2 rows
            }
            for (int x = 100; x < 120; x++)
            {
                b[x] = (int)Piece.Type.blockerPiece;        // final 2 rows
            }
            for (int x = 30; x < 91; x += 10)
            {
                b[x] = (int)Piece.Type.blockerPiece;        // left column
            }
            for (int x = 29; x < 100; x += 10)
            {
                b[x] = (int)Piece.Type.blockerPiece;        // right column
            }

            // returning the custom board from FEN
            return b;
        }

        /// <summary>
        /// Loops through param char's to determine each colours castle availability in board memory.
        /// </summary>
        /// <param name="castle_availability"></param>
        public void Can_Castle(string castle_availability)
        {
            // arrange 
            b.b_k_castle = false;
            b.b_q_castle = false;
            b.w_k_castle = false;
            b.w_q_castle = false;
            // Loop through castle_availability strings char's
            foreach (char side in castle_availability)
            {
                switch(side)        // finds if each char exists in the string and if it does sets the board objects castle availability to true
                {
                    case 'k':
                        b.b_k_castle = true;
                        break;
                    case 'q':
                        b.b_q_castle = true;
                        break;
                    case 'K':
                        b.w_k_castle = true;
                        break;
                    case 'Q':
                        b.w_q_castle = true;
                        break;
                    case '-':       // if string is '-' then no colour can castle on either side
                        b.b_k_castle = false;
                        b.b_q_castle = false;
                        b.w_k_castle = false;
                        b.w_q_castle = false;
                        break;
                    default:
                        break;
                }
            }
        }


        /// <summary>
        /// Function to convert current board state to human-readable ASCII string
        /// </summary>
        /// <returns>ASCII string chess board</returns>
        public string Convert_To_ASCII()
        {
            string board_ASCII = "";
            int file_count = 0;
            for(int x = 21; x < 99; x++)
            {
                file_count++;
                switch (b.board[x])
                {
                    case 0:
                        board_ASCII += "^";
                        break;
                    case 1:
                        board_ASCII += "♙";
                        break;
                    case 2:
                        board_ASCII += "♟";
                        break;
                    case 3:
                        board_ASCII += "♘";
                        break;
                    case 4:
                        board_ASCII += "♞";
                        break;
                    case 5:
                        board_ASCII += "♗";
                        break;
                    case 6:
                        board_ASCII += "♝";
                        break;
                    case 7:
                        board_ASCII += "♖";
                        break;
                    case 8:
                        board_ASCII += "♜";
                        break;
                    case 9:
                        board_ASCII += "♕";
                        break;
                    case 10: 
                        board_ASCII += "♛";
                        break;
                    case 11:
                        board_ASCII += "♔";
                        break;
                    case 12:
                        board_ASCII += "♚";
                        break;
                }

                if (file_count % 8 == 0)
                {
                    // skipping blocker pieces
                    x += 2;
                    // new line
                    board_ASCII += "\n";
                }
            }
            return board_ASCII;
        }
    }
}
