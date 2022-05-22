using Microsoft.VisualStudio.TestTools.UnitTesting;
using Chess_Engine_v2;
using System.Linq;
using System;
using Chess_Engine_v2._0;
using System.Collections.Generic;

namespace Engine_Tests
{
    /// <summary>
    /// Tests board and its attributes behave correctly
    /// </summary>
    [TestClass]
    public class Board_Tests
    {
        Board b;
        Move m;

        /// <summary>
        /// Tests that the function returns the correct piece value
        /// </summary>
        [TestMethod]
        public void Get_Piece_From_Square_Test()
        {
            // Arrange
            Piece.Type p1, p2, p3, p4, p5, p6;
            string board = @"^^^^^^^^
                            ^^^^^^^^
                            ^^^^^^^^
                            ^^^^^^^^
                            ^^^^^^^^
                            ^^^^^^^^
                            ^^^^^^^^
                            ♟♞♝♜♛♚^^";
            b = new Board();
            b.Convert_From_ASCII(board);

            // Act
            p1 = b.Get_Piece_From_Square("a1");
            p2 = b.Get_Piece_From_Square("b1");
            p3 = b.Get_Piece_From_Square("c1");
            p4 = b.Get_Piece_From_Square("d1");
            p5 = b.Get_Piece_From_Square("e1");
            p6 = b.Get_Piece_From_Square("f1");

            // Assert
            Assert.IsTrue(p1 == Piece.Type.b_pawn);
            Assert.IsTrue(p2 == Piece.Type.b_knight);
            Assert.IsTrue(p3 == Piece.Type.b_bishop);
            Assert.IsTrue(p4 == Piece.Type.b_rook);
            Assert.IsTrue(p5 == Piece.Type.b_queen);
            Assert.IsTrue(p6 == Piece.Type.b_king);
        }

        /// <summary>
        /// Tests the Get_Valid_Moves function returns ALL valid moves for the pawn piece in this position
        /// </summary>
        [TestMethod]
        public void Get_Valid_Pawn_Moves_Test()
        {
            // Arrange
            List<int> move_list = new List<int>();
            Piece.Type piece;
            string board = @"^^^^^^^^
                            ^♟♙^^^^^
                            ♙^^^^^^^
                            ^^^^^^^^
                            ^^^^^^^^
                            ^^^^^^^^
                            ^^^^^^^^
                            ^^^^^^^^";
            b = new Board();
            b.Convert_From_ASCII(board);
            // setting up enpassant
            b.en_passant_target = (int)Enum.Parse(typeof(Board.Square), "c6");
            // square got when user clicks board
            piece = b.Get_Piece_From_Square("a7");

            // Act
            move_list = b.Get_Valid_Moves(piece, "a7");

            // Assert
            Assert.IsTrue(move_list.Count == 4, "Test Failed: Returned more than the precalculated 4 valid moves for this position");
            // loop through all returned valid moves and check they are what is expected
            foreach (int move in move_list)
                Assert.IsTrue(move == (int)Enum.Parse(typeof(Board.Square), "b6")
                    || move == (int)Enum.Parse(typeof(Board.Square), "b5")
                    || move == (int)Enum.Parse(typeof(Board.Square), "c6")
                    || move == (int)Enum.Parse(typeof(Board.Square), "a6"));
        }

        /// <summary>
        /// Tests the Get_Valid_Moves function works properly for knight pieces
        /// </summary>
        [TestMethod]
        public void Get_Valid_Knight_Moves()
        {
            // Arrange
            List<int> move_list = new List<int>();
            Piece.Type piece;
            string board = @"^^^^^^^^
                            ^^^^^♘^
                            ^^^^^^^^
                            ^^^♘^^^^
                            ^^^^^^^^
                            ^^^^^^^^
                            ^^^^^^^^
                            ^^^^^^^^"; // d5
            b = new Board();
            b.Convert_From_ASCII(board);
            // square got when user clicks board
            piece = b.Get_Piece_From_Square("a7");

            // Act
            move_list = b.Get_Valid_Moves(piece, "d5");

            // Assert
            Assert.IsTrue(move_list.Count == 7, "Test Failed: Returned more than expected move count");
            foreach (int move in move_list)
                Assert.IsTrue(move == (int)Enum.Parse(typeof(Board.Square), "f6")
                    || move == (int)Enum.Parse(typeof(Board.Square), "f4")
                    || move == (int)Enum.Parse(typeof(Board.Square), "e3")
                    || move == (int)Enum.Parse(typeof(Board.Square), "c3")
                    || move == (int)Enum.Parse(typeof(Board.Square), "b4")
                    || move == (int)Enum.Parse(typeof(Board.Square), "b6")
                    || move == (int)Enum.Parse(typeof(Board.Square), "c7")
                    , "Test Failed: Unexpected move returned");
        }

        /// <summary>
        /// Tests the Get_Valid_Moves function works properly for knight pieces
        /// </summary>
        [TestMethod]
        public void Get_Valid_Bishop_Moves()
        {
            // Arrange
            List<int> move_list = new List<int>();
            string board = @"^^^^^^^^
                            ^^^^^♘^
                            ^^^^^^^^
                            ^^^♘^^^^
                            ^^^^^^^^
                            ^^^^^^^^
                            ^^^^^^^^
                            ^^^^^^^^"; // d5
            b = new Board();
            int[] test_board = new int[120];
            test_board = b.Convert_From_ASCII(board);

            // Act

            // Assert
        }

        [TestMethod]
        public void Make_Move_Test()
        {
            // Arrange
            string board = @"^^^^^^^^
                            ♟^^^^^^^
                            ^^^^^^^^
                            ^^^^^^^^
                            ^^^^^^^^
                            ^^^^^^^^
                            ^^^^^^^^
                            ^^^^^^^^";
            string board_final = @"^^^^^^^^
                                 ^^^^^^^^
                                 ^^^^^^^^
                                 ♟^^^^^^^
                                 ^^^^^^^^
                                 ^^^^^^^^
                                 ^^^^^^^^
                                 ^^^^^^^^";
            b = new Board();
            b.board = b.Convert_From_ASCII(board);
            b.side_to_move = 'b';
            m = new Move();
            m.CHECK_MOVE = false;
            m.FLAG = Move.Flag.double_pawn_push;
            m.START_SQUARE = "a7";
            m.TARGET_SQUARE = "a5";
            

            // Act
            b.Make_Move(m);

            // Assert
            Assert.IsTrue(Enumerable.SequenceEqual(b.board, b.Convert_From_ASCII(board_final)), "Test Failed: Board array is not as expected");
            Assert.IsTrue(b.side_to_move == 'w', "Test Failed: Side to move incorrect");
            Assert.IsTrue(b.half_ply == 1, "Test Failed: Half-ply did not increment properly");
            Assert.IsTrue(b.full_ply == 2, "Test Failed: Full-ply did not increment properly");
            Assert.IsTrue(b.b_k_castle == true, "Test Failed: Black king side castle eligibility incorrect");
            Assert.IsTrue(b.b_q_castle == true, "Test Failed: Black queen side castle eligibility incorrect");
            Assert.IsTrue(b.w_q_castle == true, "Test Failed: White queen side castle eligiility incorrect");
            Assert.IsTrue(b.w_k_castle == true, "Test Failed: White king side castle eligiility incorrect");
            Assert.IsTrue(b.en_passant_target == (int)Enum.Parse(typeof(Board.Square), "a4"), "Test Failed: En-passant target square incorrect or not set");
        }

        [TestMethod]
        public void Unmake_Move_Test()
        {
            // Arrange
            string board = @"^^^^^^^^
                             ^^^^^^^^
                             ^^^^^^^^
                            ♟^^^^^^^
                             ^^^^^^^^
                             ^^^^^^^^
                             ^^^^^^^^
                             ^^^^^^^^";
            string board_final = @"^^^^^^^^
                            ♟^^^^^^^
                            ^^^^^^^^
                            ^^^^^^^^
                            ^^^^^^^^
                            ^^^^^^^^
                            ^^^^^^^^
                            ^^^^^^^^";
            b = new Board();
            b.board = b.Convert_From_ASCII(board);

            // Act
            //b.Unmake_Move();

            // Assert
            Assert.IsTrue(Enumerable.SequenceEqual(b.board, b.Convert_From_ASCII(board_final)), "Test Failed: Board array is not as expected");
        }

        [TestMethod]
        public void ASCII_Converter()
        {
            // needs to test text output; test each board[x] = PIECE_INTEGER outputs correct piece in ASCII
            // Arrange
            string text_board = @"^^^^^^^^
                                ^^^^^^^^
                                ^^^^^^^^
                                ^^^^^^^^
                                ^^^^^^^^
                                ^^^^^^^^
                                ^^^^^^^^
                                ^^^^^^^^";
            int[] board = new int[120] {-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
                                     -1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
                                        -1, 0, 0, 0, 0, 0, 0, 0, 0, -1,
                                        -1, 0, 0, 0, 0, 0, 0, 0, 0, -1,
                                        -1, 0, 0, 0, 0, 0, 0, 0, 0, -1,
                                        -1, 0, 0, 0, 0, 0, 0, 0, 0, -1,
                                        -1, 0, 0, 0, 0, 0, 0, 0, 0, -1,
                                        -1, 0, 0, 0, 0, 0, 0, 0, 0, -1,
                                        -1, 0, 0, 0, 0, 0, 0, 0, 0, -1,
                                        -1, 0, 0, 0, 0, 0, 0, 0, 0, -1,
                                      -1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
                                      -1, -1, -1, -1 , -1, -1, -1, -1, -1, -1};
            int[] test_text_board;
            Board b = new Board();

            // Act
            test_text_board = b.Convert_From_ASCII(text_board);

            // Assert
            // checking board generated as expected
            Assert.IsTrue(Enumerable.SequenceEqual(board, test_text_board), "Test Failed: ASCII board did not generate properly");
            // checking generated board is the same as the current real board 
            Assert.IsTrue(Enumerable.SequenceEqual(b.board, test_text_board), "Test Failed: ASCII board did not reassign the actual board properly");
        }

    }
}
