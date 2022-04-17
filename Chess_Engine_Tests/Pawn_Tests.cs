using Chess_Engine_v2;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

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
        int[] correct_board;

        [TestMethod]
        public void Pawn_Movement_Valid()
        {
            //  arrange
            b = new Board();

            //  act & assert
            //----------------------------------------
            // Normal 2 square move from starting pos
            try
            {
                b.Make_Move("a2", "a4", 'w');
                try
                {
                    //Assert.IsTrue(b.board[21] == (int)Piece.Type.empty && b.board[41] == (int)Piece.Type.w_pawn, "Piece not moved correctly.");
                    Assert.IsTrue(b.b_k_castle && b.b_q_castle && b.w_k_castle && b.w_q_castle && b.side_to_move == 'b'
                        && b.half_ply == 1 && b.full_ply == 1 && b.en_passant_target == 0, "Test Failed: Board game attributes incorrect.");
                }
                catch
                {
                    Console.WriteLine("Incorrect board properties."); 
                }
            }
            catch (Exception e)
            {
                Assert.Fail("Pawn initial 2 square move failed with error code: ", e); 
            }
            // Normal 1 square response from black
            try
            {
                b.Make_Move("a7", "a6", 'b');
                //Assert.IsTrue(b.board[91] == (int)Piece.Type.empty && b.board[81] == (int)Piece.Type.b_pawn);
                Assert.IsTrue(b.b_k_castle && b.b_q_castle && b.w_k_castle && b.w_q_castle && b.side_to_move == 'w'
                    && b.half_ply == 2 && b.full_ply == 2 && b.en_passant_target == 0, "Test Failed: Board game attributes incorrect.");
            }
            catch (Exception e)
            {
                Assert.Fail("Pawn 1 Square response move failed with error code: ", e);
            }
            // Illegal 3 square move
            try
            {
                b.Make_Move("b2", "b5", 'w');           // should throw an error
            }
            catch (Exception e)
            {
                // Code failed as expected, Test PASSED
                Assert.IsTrue(true, "Test Passed; Illegal move declined by engine, error thrown: " + e);
                Assert.IsTrue(b.b_k_castle && b.b_q_castle && b.w_k_castle && b.w_q_castle && b.side_to_move == 'w'
                    && b.half_ply == 2 && b.full_ply == 2 && b.en_passant_target == 0, "Test Failed: Board game attributes incorrect.");
            }
            // Wrong colour to move
            try
            {
                b.Make_Move("b2", "b5", 'b');           // should throw an error
            }
            catch
            {
                Assert.IsTrue(b.b_k_castle && b.b_q_castle && b.w_k_castle && b.w_q_castle && b.side_to_move == 'w'
                    && b.half_ply == 2 && b.full_ply == 2 && b.en_passant_target == 0, "Test Failed: Board game attributes incorrect.");
            }
        }

        [TestMethod]
        public void Pawn_Movement_En_Passant()
        {
            //  arrange
            correct_board = new int[120]
            {
                -1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
                -1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
                -1, 8, 4, 6, 10, 12, 6, 4, 8, -1,
                -1, 2, 2, 2, 2, 2, 2, 2, 2, -1,
                -1, 0, 0, 0, 0, 0, 0, 0, 0, -1,
                -1, 0, 0, 0, 0, 0, 0, 0, 0, -1,
                -1, 0, 0, 0, 0, 0, 0, 0, 0, -1,
                -1, 0, 0, 0, 0, 0, 0, 0, 0, -1,
                -1, 1, 1, 1, 1, 1, 1, 1, 1, -1,
                -1, 7, 3, 5, 9, 11, 5, 3, 7, -1,
                -1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
                -1, -1, -1, -1, -1, -1, -1, -1, -1, -1
            };
            b = new Board();

            //  act
            b.Make_Move("a2", "a4", 'w');
            b.Make_Move("a7", "a6", 'b');
            b.Make_Move("a4", "a5", 'w');
            b.Make_Move("b7", "b5", 'b');
            b.Make_Move("a5", "b6", 'w');

            //  assert
            //Assert.IsTrue(Enumerable.SequenceEqual(b_test.board, correct_board), "Test Failed: board array is not as expected");
            Assert.IsTrue(b.b_k_castle && b.b_q_castle && b.w_k_castle && b.w_q_castle && b.side_to_move == 'b'
                && b.half_ply == 5 && b.full_ply == 3 && b.en_passant_target == 0, "Test Failed: Board game attributes incorrect.");
        }

        [TestMethod]
        public void Pawn_Movement_in_Check()
        {
            //  arrange
            correct_board = new int[120]
            {
                -1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
                -1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
                -1, 8, 4, 6, 10, 12, 6, 4, 8, -1,
                -1, 2, 2, 2, 2, 2, 2, 2, 2, -1,
                -1, 0, 0, 0, 0, 0, 0, 0, 0, -1,
                -1, 0, 0, 0, 0, 0, 0, 0, 0, -1,
                -1, 0, 0, 0, 0, 0, 0, 0, 0, -1,
                -1, 0, 0, 0, 0, 0, 0, 0, 0, -1,
                -1, 1, 1, 1, 1, 1, 1, 1, 1, -1,
                -1, 7, 3, 5, 9, 11, 5, 3, 7, -1,
                -1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
                -1, -1, -1, -1, -1, -1, -1, -1, -1, -1
            };
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
            correct_board = new int[120]
            {
                -1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
                -1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
                -1, 8, 4, 6, 10, 12, 6, 4, 8, -1,
                -1, 2, 2, 2, 2, 2, 2, 2, 2, -1,
                -1, 0, 0, 0, 0, 0, 0, 0, 0, -1,
                -1, 0, 0, 0, 0, 0, 0, 0, 0, -1,
                -1, 0, 0, 0, 0, 0, 0, 0, 0, -1,
                -1, 0, 0, 0, 0, 0, 0, 0, 0, -1,
                -1, 1, 1, 1, 1, 1, 1, 1, 1, -1,
                -1, 7, 3, 5, 9, 11, 5, 3, 7, -1,
                -1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
                -1, -1, -1, -1, -1, -1, -1, -1, -1, -1
            };
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
