using Microsoft.VisualStudio.TestTools.UnitTesting;
using Chess_Engine_v2;
using System.Linq;
using System;

namespace Engine_Tests
{
    /// <summary>
    /// Tests board and its attributes behave correctly
    /// </summary>
    [TestClass]
    public class Board_Tests
    {
        Board b;

        /// <summary>
        /// Tests that the function returns the correct piece value
        /// </summary>
        [TestMethod]
        public void Get_Piece_From_Square_Test()
        {
            // Arrange
            int p1, p2, p3, p4, p5, p6;
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
            p2 = b.Get_Piece_From_Square("a2");
            p3 = b.Get_Piece_From_Square("a3");
            p4 = b.Get_Piece_From_Square("a4");
            p5 = b.Get_Piece_From_Square("a5");
            p6 = b.Get_Piece_From_Square("a6");

            // Assert
            Assert.IsTrue(p1 == (int)Piece.Type.b_pawn);
            Assert.IsTrue(p2 == (int)Piece.Type.b_knight);
            Assert.IsTrue(p3 == (int)Piece.Type.b_bishop);
            Assert.IsTrue(p4 == (int)Piece.Type.b_rook);
            Assert.IsTrue(p5 == (int)Piece.Type.b_queen);
            Assert.IsTrue(p6 == (int)Piece.Type.b_king);
        }

        /// <summary>
        /// Tests the function returns only valid moves for any given piece
        /// </summary>
        [TestMethod]
        public void Get_Valid_Moves_Test()
        {

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

            // Act
            b.Make_Move("a7", "a5", 'b');

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

    }
}
