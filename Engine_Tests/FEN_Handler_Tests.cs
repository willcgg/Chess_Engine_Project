using Microsoft.VisualStudio.TestTools.UnitTesting;
using Chess_Engine_v2;
using System.Linq;

namespace Engine_Tests
{
    /// <summary>
    /// Class to test the FEN_Handler class and its functions create the board correctly under every given circumstance
    /// </summary>
    [TestClass]
    public class FEN_Handler_Tests
    {
        /// <summary>
        /// Method to test the default board position along with its attributes
        /// </summary>
        [TestMethod]
        public void FEN_Handler_Default()
        {
            // Arrange
            // Initialising Test Var's 
            string board = @"♖♘♗♕♔♗♘♖
♙♙♙♙♙♙♙♙
^^^^^^^^
^^^^^^^^
^^^^^^^^
^^^^^^^^
♟♟♟♟♟♟♟♟
♜♞♝♛♚♝♞♜";
            int[] default_board = new int[120];
            int en_passant_target = 0;
            int half_ply = 0;
            int full_ply = 1;
            bool w_k_castle = true;
            bool w_q_castle = true;
            bool b_k_castle = true;
            bool b_q_castle = true;
            char side_to_move = 'w';

            // Act
            // Creating board object to test
            Board b_test = new Board();
            default_board = b_test.Convert_From_ASCII(board);

            // Assert
            Assert.IsTrue(Enumerable.SequenceEqual(b_test.board, default_board), "Test Failed: board array is not as expected");
            Assert.IsTrue(b_test.en_passant_target == en_passant_target, "Test Failed: En_Passant target not correct");
            Assert.IsTrue(b_test.half_ply == half_ply);
            Assert.IsTrue(b_test.full_ply == full_ply);
            Assert.IsTrue(b_test.w_k_castle == w_k_castle);
            Assert.IsTrue(b_test.w_q_castle == w_q_castle);
            Assert.IsTrue(b_test.b_k_castle == b_k_castle);
            Assert.IsTrue(b_test.b_q_castle == b_q_castle);
            Assert.IsTrue(b_test.side_to_move == side_to_move);
        }

        /// <summary>
        /// Method to test a custom board position along with its attributes
        /// </summary>
        [TestMethod]
        public void FEN_Handler_Custom()
        {
            // Arrange
            // Initialising Test Var's      Setting them to what they should be on starting board position
            string board = @"♙♙♙♙♙♙♙♙
♙♙♙♙♙♙♙♙
^^^^^^^^
^^^^^^^^
^^^^^^^^
^^^^^^^^
♟♟♟♟♟♟♟♟
♟♟♟♟♟♟♟♟";
            int[] default_board = new int[120];
            int en_passant_target = 35;
            int half_ply = 28;
            int full_ply = 14;
            bool w_k_castle = false;
            bool w_q_castle = true;
            bool b_k_castle = true;
            bool b_q_castle = false;
            char side_to_move = 'b';

            // Act
            // Creating board object to test
            Board b_test = new Board();
            b_test.From_FEN("pppppppp/pppppppp/8/8/8/8/PPPPPPPP/PPPPPPPP b Qk e7 28 14");       // tests all aspects of FEN_Handler
            default_board = b_test.Convert_From_ASCII(board);

            // Assert
            Assert.IsTrue(Enumerable.SequenceEqual(b_test.board, default_board), "Test Failed: board array is not as expected");
            Assert.IsTrue(b_test.en_passant_target == en_passant_target, "Test Failed: En_Passant target not correct");
            Assert.IsTrue(b_test.half_ply == half_ply);
            Assert.IsTrue(b_test.full_ply == full_ply);
            Assert.IsTrue(b_test.w_k_castle == w_k_castle);
            Assert.IsTrue(b_test.w_q_castle == w_q_castle);
            Assert.IsTrue(b_test.b_k_castle == b_k_castle);
            Assert.IsTrue(b_test.b_q_castle == b_q_castle);
            Assert.IsTrue(b_test.side_to_move == side_to_move);
        }
    }
}
