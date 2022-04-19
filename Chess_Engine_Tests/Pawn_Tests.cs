using Chess_Engine_v2;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace Chess_Engine_Tests
{
    /// <summary>
    /// <para>Checks all possible valid pawn moves</para>
    /// <para>Individually calls all pawn movement tests. Each test is given a good board position to
    /// check all possibilities. E.g. en passant, in-check, pinned pieces etc..</para>
    /// </summary>
    [TestClass]
    public class Pawn_Tests
    {

        Board b;

        [TestMethod]
        public void Pawn_Movement_Valid_Backwards_Test()
        {
            //  arrange
            //----------------------------------------
            string board = @"^^^^^^^^
                            ^^^^^^^^
                            ^^^^^^^^
                            ♙^^^^^^^
                            ^^^^^^^^
                            ^^^^^^^^
                            ^^^^^^^^
                            ^^^^^^^^";
            b = new Board();
            b.board = b.Convert_From_ASCII(board);

            //  act 
            //----------------------------------------
            // Moving backwards 2 squares
            b.Make_Move("a5", "a3", 'w');

            // assert
            //----------------------------------------
            Assert.IsTrue(Enumerable.SequenceEqual(b.board, b.Convert_From_ASCII(board)), "Test Failed: board array is not as expected");
        }

        [TestMethod]
        public void Pawn_Movement_Valid_Diagonal_Test()
        {
            //  arrange
            //----------------------------------------
            string board = @"^^^^^^^^
                            ^^^^^^^^
                            ^^^^^^^^
                            ♙^^^^^^^
                            ^^^^^^^^
                            ^^^^^^^^
                            ^^^^^^^^
                            ^^^^^^^^";
            b = new Board();
            b.board = b.Convert_From_ASCII(board);

            //  act 
            //----------------------------------------
            // Moving diagonal
            b.Make_Move("a5", "d8", 'w');

            // assert
            //----------------------------------------
            Assert.IsTrue(Enumerable.SequenceEqual(b.board, b.Convert_From_ASCII(board)), "Test Failed: board array is not as expected");
        }

        [TestMethod]
        public void Pawn_Movement_Invalid_Forward_Two_Spaces()
        {
            //  arrange
            //----------------------------------------
            string board = @"^^^^^^^^
                            ^^^^^^^^
                            ^^^^^^^^
                            ♙^^^^^^^
                            ^^^^^^^^
                            ^^^^^^^^
                            ^^^^^^^^
                            ^^^^^^^^";
            b = new Board();
            b.board = b.Convert_From_ASCII(board);

            //  act 
            //----------------------------------------
            // Moving backwards 2 squares
            b.Make_Move("a5", "a7", 'w');

            // assert
            //----------------------------------------
            Assert.IsTrue(Enumerable.SequenceEqual(b.board, b.Convert_From_ASCII(board)), "Test Failed: board array is not as expected");
        }

        [TestMethod]
        public void Pawn_Movement_Valid_Forward_Two_Spaces()
        {
            //  arrange
            //----------------------------------------
            string board = @"^^^^^^^^
                            ^^^^^^^^
                            ^^^^^^^^
                            ^^^^^^^^
                            ^^^^^^^^
                            ^^^^^^^^
                            ♙^^^^^^^
                            ^^^^^^^^";
            string board_final = @"^^^^^^^^
                                ^^^^^^^^
                                ^^^^^^^^
                                ^^^^^^^^
                                ♙^^^^^^^
                                ^^^^^^^^
                                ^^^^^^^^
                                ^^^^^^^^";
            b = new Board();
            b.board = b.Convert_From_ASCII(board);

            //  act 
            //----------------------------------------
            // Moving backwards 2 squares
            b.Make_Move("a2", "a4", 'w');

            // assert
            //----------------------------------------
            Assert.IsTrue(Enumerable.SequenceEqual(b.board, b.Convert_From_ASCII(board_final)), "Test Failed: board array is not as expected");
        }

        [TestMethod]
        public void Pawn_Movement_En_Passant()
        {
            //  arrange
            string board = @"^^^^^^^^
                            ^♟^^^^^^
                            ^^^^^^^^
                            ♙^^^^^^^
                            ^^^^^^^^
                            ^^^^^^^^
                            ^^^^^^^^
                            ^^^^^^^^";
            string board_final = @"^^^^^^^^
                                ^^^^^^^^
                                ^♙^^^^^^
                                ^^^^^^^^
                                ^^^^^^^^
                                ^^^^^^^^
                                ^^^^^^^^
                                ^^^^^^^^";
            b = new Board();
            b.board = b.Convert_From_ASCII(board);
            b.side_to_move = 'b';

            //  act
            b.Make_Move("b7", "b5", 'b');
            b.Make_Move("a5", "b6", 'w');

            //  assert
            Assert.IsTrue(Enumerable.SequenceEqual(b.board, b.Convert_From_ASCII(board_final)), "Test Failed: board array is not as expected");
        }

        [TestMethod]
        public void Pawn_Movement_in_Check()
        {
            //  arrange
            string board = @"^^^^^^^^
                            ^♟^^^^^^
                            ^^^^^^^^
                            ♙^^^^^^^
                            ^^^^^^^^
                            ^^^^^^^^
                            ^^^^^^^^
                            ^^^^^^^^";
            string board_final = @"^^^^^^^^
                                ^^^^^^^^
                                ^♙^^^^^^
                                ^^^^^^^^
                                ^^^^^^^^
                                ^^^^^^^^
                                ^^^^^^^^
                                ^^^^^^^^";
            b = new Board();

            //  act
            b.Make_Move("d2", "d3", 'w');
            b.Make_Move("e7", "e6", 'b');
            b.Make_Move("d3", "d4", 'w');
            b.Make_Move("f8", "b4", 'b');           // in-check
            // try moves which shouldnt work before valid move??
            try
            {
                b.Make_Move("a2", "a4", 'w');           // passive move ( should fail )
                //Assert.Fail("Test Failed: Invalid passive move accepted by engine");
            }
            catch
            {
                Console.WriteLine("Passed: move rejected by engine");
            }
            //  assert
            // test that castling eligibility is temporarily gone until the check is resolved
            Assert.IsTrue(b.b_k_castle && b.b_q_castle && b.w_k_castle == false && b.w_q_castle == false && b.side_to_move == 'w'
                && b.half_ply == 4 && b.full_ply == 3 && b.en_passant_target == 0, "Test Failed: Board game attributes incorrect.");

            // rearrange
            b.Make_Move("c2", "c3", 'w');           // blocking check

            //  re-assert
            //Assert.IsTrue(Enumerable.SequenceEqual(b_test.board, correct_board), "Test Failed: board array is not as expected");
            Assert.IsTrue(b.b_k_castle && b.b_q_castle && b.w_k_castle && b.w_q_castle && b.side_to_move == 'w'
                && b.half_ply == 5 && b.full_ply == 3 && b.en_passant_target == 0, "Test Failed: Board game attributes incorrect.");
        }

        [TestMethod]
        public void Pawn_Movement_Pinned()
        {
            //  arrange
            string board = @"^^^^^^^^
                            ^♟^^^^^^
                            ^^^^^^^^
                            ♙^^^^^^^
                            ^^^^^^^^
                            ^^^^^^^^
                            ^^^^^^^^
                            ^^^^^^^^";
            string board_final = @"^^^^^^^^
                                ^^^^^^^^
                                ^♙^^^^^^
                                ^^^^^^^^
                                ^^^^^^^^
                                ^^^^^^^^
                                ^^^^^^^^
                                ^^^^^^^^";
            b = new Board();

            //  act
            b.Make_Move("e2", "e4", 'w');
            b.Make_Move("e7", "e5", 'b');
            b.Make_Move("g8", "f3", 'w');
            b.Make_Move("f8", "b4", 'b');       // pinning pawn

            //  assert
            try
            {
                b.Make_Move("d2", "d3", 'w');   // piece pinned should not work
                //Assert.Fail("Board accepted invalid move");
            }
            catch
            {
                Assert.IsTrue(true, "Passed: Board declined invalid move");
            }

            // rearrange
            b.Make_Move("", "", 'w');

            // re-assert
            //Assert.IsTrue(Enumerable.SequenceEqual(b_test.board, correct_board), "Test Failed: board array is not as expected");
            Assert.IsTrue(b.b_k_castle && b.b_q_castle && b.w_k_castle && b.w_q_castle && b.side_to_move == 'w'
                && b.half_ply == 5 && b.full_ply == 3 && b.en_passant_target == 0, "Test Failed: Board game attributes incorrect.");
        }


    }
}
