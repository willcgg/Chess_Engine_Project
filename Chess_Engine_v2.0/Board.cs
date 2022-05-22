using Chess_Engine_v2._0;
using System;
using System.Collections.Generic;
using System.Text;

namespace Chess_Engine_v2
{
    public class Board
    {
        #region Constants
        // default board pos
        const string FEN_DEFAULT = "rnbqkbnr/pppppppp/8/8/8/8/PPPPPPPP/RNBQKBNR w KQkq - 0 1";
        // square array positions
        public enum Square
        {
            a8 = 21,
            a7 = 31,
            a6 = 41,
            a5 = 51,
            a4 = 61,
            a3 = 71,
            a2 = 81,
            a1 = 91,
            b8 = 22,
            b7 = 32,
            b6 = 42,
            b5 = 52,
            b4 = 62,
            b3 = 72,
            b2 = 82,
            b1 = 92,
            c8 = 23,
            c7 = 33,
            c6 = 43,
            c5 = 53,
            c4 = 63,
            c3 = 73,
            c2 = 83,
            c1 = 93,
            d8 = 24,
            d7 = 34,
            d6 = 44,
            d5 = 54,
            d4 = 64,
            d3 = 74,
            d2 = 84,
            d1 = 94,
            e8 = 25,
            e7 = 35,
            e6 = 45,
            e5 = 55,
            e4 = 65,
            e3 = 75,
            e2 = 85,
            e1 = 95,
            f8 = 26,
            f7 = 36,
            f6 = 46,
            f5 = 56,
            f4 = 66,
            f3 = 76,
            f2 = 86,
            f1 = 96,
            g8 = 27,
            g7 = 37,
            g6 = 47,
            g5 = 57,
            g4 = 67,
            g3 = 77,
            g2 = 87,
            g1 = 97,
            h8 = 28,
            h7 = 38,
            h6 = 48,
            h5 = 58,
            h4 = 68,
            h3 = 78,
            h2 = 88,
            h1 = 98
        }
        #endregion

        #region Public Vars
        public int[] board;
        public int en_passant_target;
        public int half_ply;
        public int full_ply;
        public bool w_k_castle;
        public bool w_q_castle;
        public bool b_k_castle;
        public bool b_q_castle;
        public char side_to_move;
        #endregion

        #region Constructors
        /// <summary>
        /// Initialising board object
        /// </summary>
        public Board()
        {
            // init variables
            new FEN_Handler(FEN_DEFAULT, this);     // instatiating default start position
            Console.WriteLine("Board Initialised");
        }
        #endregion

        #region Methods
        /// <summary>
        /// Creating board based on custom FEN input
        /// </summary>
        /// <param name="FEN"></param>
        public void From_FEN(string FEN)
        {
            // init
            new FEN_Handler(FEN, this);             // setting custom fen position
            Console.WriteLine("Custom Board set in mem");
        }

        /// <summary>
        /// Returns piece type from board poisition
        /// </summary>
        /// <returns>Piece int</returns>
        public Piece.Type Get_Piece_From_Square(string sqr)
        {
            Piece.Type piece;
            // converting string square to actual square array location
            int square = (int)Enum.Parse(typeof(Square), sqr);
            // getting the indentifier of the piece on that square
            piece = (Piece.Type)board[square];
            return piece;
        }

        /// <summary>
        /// Function to find all valid board squares for any given piece
        /// </summary>
        /// <param name="piece"></param>
        /// <param name="square"></param>
        /// <returns>Legal move board index's</returns>
        public List<int> Get_Valid_Moves(Piece.Type piece, string start_square)
        {
            // init
            int[] offsets;
            List<int> valid_moves;
            char colour_to_move;
            int square;
            // init moves list
            valid_moves = new List<int>();
            // checking piece is not empty
            if (piece == Piece.Type.empty)
                return valid_moves;
            // converting start square to board index
            square = (int)Enum.Parse(typeof(Square), start_square);
            // getting piece movement offset
            offsets = Piece.Get_Piece_Offsets(piece);
            // getting piece colour
            colour_to_move = Piece.Get_Piece_Colour(piece);
            
            // what piece is it
            if(piece == Piece.Type.b_bishop || piece == Piece.Type.w_bishop || piece == Piece.Type.b_rook 
                || piece == Piece.Type.w_rook || piece == Piece.Type.b_queen || piece == Piece.Type.w_queen)
            {
                // sliding pieces
                valid_moves = Generate_Sliding_Moves(square, offsets, colour_to_move);
            }
            else if(piece == Piece.Type.b_knight || piece == Piece.Type.w_knight)
            {
                // knights
                valid_moves = Generate_Knight_Moves(square, offsets, colour_to_move);
            }
            else if (piece == Piece.Type.b_pawn || piece == Piece.Type.w_pawn)
            {
                // pawns
                valid_moves = Generate_Pawn_Moves(square, offsets, colour_to_move);
            }
            else if (piece == Piece.Type.w_king || piece == Piece.Type.b_king)
            {
                // kings
                valid_moves = Generate_King_Moves(square, offsets, colour_to_move);
            }
            // returning valid_moves
            return valid_moves;
        }

        /// <summary>
        /// Gets valid moves for king piece
        /// </summary>
        /// <param name="square"></param>
        /// <param name="offsets"></param>
        /// <param name="colour_to_move"></param>
        /// <returns></returns>
        private List<int> Generate_King_Moves(int square, int[] offsets, char colour_to_move)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets valid moves for pawns
        /// </summary>
        /// <param name="square"></param>
        /// <param name="offsets"></param>
        /// <param name="colour_to_move"></param>
        /// <returns></returns>
        private List<int> Generate_Pawn_Moves(int square, int[] offsets, char colour_to_move)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets valid knight moves
        /// </summary>
        /// <param name="start_square"></param>
        /// <param name="offsets"></param>
        /// <param name="col"></param>
        /// <returns></returns>
        private List<int> Generate_Knight_Moves(int start_square, int[] offsets, char col)
        {
            // init
            int index;
            int opps;
            List<int> moves = new List<int>();
            // opponent piece indentifier
            opps = Is_Opponent_Piece(col);

            foreach (int offset in offsets)
            {
                // loops through each offset of selected piece
                // target square starting on first square in offset direction
                index = start_square + offset;
                int target_square = board[index];

                // if target square is either empty, NOT a blocker piece or an opponent pieces
                if (target_square == 0 && target_square != -1 && target_square % 2 == opps)
                {
                    // move valid add to list
                    moves.Add(index);
                }
            }
            return moves;
        }

        /// <summary>
        /// Gets valid moves for sliding pieces
        /// </summary>
        /// <param name="start_square"></param>
        /// <param name="offsets"></param>
        /// <param name="col"></param>
        /// <returns></returns>
        private List<int> Generate_Sliding_Moves(int start_square, int[] offsets, char col)
        {
            int index;
            int opps;
            List<int> valid_moves = new List<int>();
            // opponent piece indentifier
            opps = Is_Opponent_Piece(col);
            foreach (int offset in offsets)
            {
                // loops through each offset of selected piece
                // target square starting on first square in offset direction
                index = 0;
                index = start_square + offset;
                int target_square = board[index];
                bool is_opp_piece = target_square % 2 == opps;

                // while target square is either empty, NOT a blocker piece or equal to the opponents pieces
                while (target_square == 0 && target_square != -1 && is_opp_piece)
                {
                    // move valid add to list
                    valid_moves.Add(index);
                    // increment index
                    index += offset;
                    // setting target square to new board position before next loop
                    target_square = board[index];
                }
            }
            return valid_moves;
        }

        /// <summary>
        /// Gets opponent piece remainder used to indentify opponent pieces
        /// </summary>
        /// <param name="col"></param>
        /// <returns></returns>
        public int Is_Opponent_Piece(char col)
        {
            // init
            int opps;
            // defining oponent pieces
            if (col == 'b')
                opps = 1;
            else
                opps = 0;
            return opps;
        }

        /// <summary>
        /// Makes move in board memory
        /// </summary>
        /// <param name="start_pos"></param>
        /// <param name="end_pos"></param>
        /// <param name="colour"></param>
        /// <returns></returns>
        public void Make_Move(Move m)
        {
            // init
            Move move = m;
            int start_square;
            int target_square;
            Piece.Type piece;
            // converting string input of square to arrays location of that square
            start_square = (int)Enum.Parse(typeof(Square), move.START_SQUARE);
            target_square = (int)Enum.Parse(typeof(Square), move.TARGET_SQUARE);
            // getting piece moved
            piece = (Piece.Type)board[start_square];
            // move type?
            switch (move.FLAG)
            {
                case Move.Flag.quiet:
                    break;
                case Move.Flag.capture:
                    break;
                case Move.Flag.double_pawn_push:
                    break;
                default:
                    break;
            }



            // incrementing half-ply if no piece taken
            half_ply++;
            // changing side to move and full-ply
            if (side_to_move == 'w')
                side_to_move = 'b';
            else
            {
                side_to_move = 'w';
                full_ply++;
            }
        }

        /// <summary>
        /// Converts ASCII board string to a board int[] array. Does not touch board properties due to it being impossible
        /// to tell whether the king or either rooks have moved with only board position
        /// </summary>
        /// <param name="ASCII_Board"></param>
        /// <returns>int[] board</returns>
        public int[] Convert_From_ASCII(string ASCII_Board)
        {
            // init vars
            int x = 21;                                         // starting board index
            string[] ranks = ASCII_Board.Split('\n');           // split into ranks
            int[] newBoard = new int[120];
            Create_Blocker_Border(newBoard);
            // cleaning string before passing into function
            for (int y = 0; y < 8; y++)
                ranks[y] = ranks[y].Trim();
            // convert to board
            foreach (string rank in ranks)
            {
                foreach (char piece in rank)
                {
                    switch (piece)
                    {
                        case '^':
                            newBoard[x] = (int)Piece.Type.empty;
                            break;
                        case '♙':
                            newBoard[x] = (int)Piece.Type.w_pawn;
                            break;
                        case '♟':
                            newBoard[x] = (int)Piece.Type.b_pawn;
                            break;
                        case '♘':
                            newBoard[x] = (int)Piece.Type.w_knight;
                            break;
                        case '♞':
                            newBoard[x] = (int)Piece.Type.b_knight;
                            break;
                        case '♗':
                            newBoard[x] = (int)Piece.Type.w_bishop;
                            break;
                        case '♝':
                            newBoard[x] = (int)Piece.Type.b_bishop;
                            break;
                        case '♖':
                            newBoard[x] = (int)Piece.Type.w_rook;
                            break;
                        case '♜':
                            newBoard[x] = (int)Piece.Type.b_rook;
                            break;
                        case '♕':
                            newBoard[x] = (int)Piece.Type.w_queen;
                            break;
                        case '♛':
                            newBoard[x] = (int)Piece.Type.b_queen;
                            break;
                        case '♔':
                            newBoard[x] = (int)Piece.Type.w_king;
                            break;
                        case '♚':
                            newBoard[x] = (int)Piece.Type.b_king;
                            break;
                    }
                    x += 1;
                }
                x += 2;         // skip blocker pieces
            }
            // assigning class board array to equal the new board
            board = newBoard;
            // returning newBoard back to test class
            return newBoard;
        }

        /// <summary>
        /// Populates board array with blocker pieces
        /// </summary>
        /// <param name="b"></param>
        public static void Create_Blocker_Border(int[] b)
        {
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
            #endregion

        }

    }

    

}
