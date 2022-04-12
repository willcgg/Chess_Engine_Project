﻿using Chess_Engine_v2;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Chess_Engine_Tests
{
    /// <summary>
    /// Test class to thoroughly test the pawn pieces valid movement in the engines logic
    /// </summary>
    [TestClass]
    class Pawn_Tests
    {

        Board b;

        [TestMethod]
        public void Pawn_Movement_Valid()
        {
            //  arrange
            string message;
            bool test3;
            b = new Board();

            //  act & assert
            //----------------------------------------
            // Normal 2 square move from starting pos
            try
            {
                b.Make_Move(21, 41, 'w');      
                Assert.IsTrue(b.board[21] == (int)Piece.Type.empty && b.board[41] == (int)Piece.Type.w_pawn, "Piece Successfully moved.");
                Assert.IsTrue(b.b_k_castle && b.b_q_castle && b.w_k_castle && b.w_q_castle && b.side_to_move == 'b'
                    && b.half_ply == 1 && b.full_ply == 0 && b.en_passant_target == 31, "Board game attributes correctly changed.");
            }
            catch (Exception e)
            {
                Assert.Fail("Pawn initial 2 square move failed with error code: ", e);
            }
            // Normal 1 square response from black
            try
            {
                b.Make_Move(91, 81, 'b');
                Assert.IsTrue(b.board[91] == (int)Piece.Type.empty && b.board[81] == (int)Piece.Type.b_pawn);
                Assert.IsTrue(b.b_k_castle && b.b_q_castle && b.w_k_castle && b.w_q_castle && b.side_to_move == 'w'
                    && b.half_ply == 2 && b.full_ply == 1 && b.en_passant_target == 91, "Board game attributes correctly changed.");
            }
            catch (Exception e)
            {
                Assert.Fail("Pawn 1 Square response move failed with error code: ", e);
            }
            // Illegal 3 square move
            try
            {
                b.Make_Move(22, 52, 'w');           // should throw an error
                Assert.Fail("Illegal move accepted by engine, please review Make_Move function");
            }
            catch (Exception e)
            {
                // Code failed as expected, Test PASSED
                message = "Test Passed; Illegal move declined by engine, error thrown: " + e;
                test3 = true;
                Assert.IsTrue(test3, message);
                Assert.IsTrue(b.b_k_castle && b.b_q_castle && b.w_k_castle && b.w_q_castle && b.side_to_move == 'w'
                    && b.half_ply == 1 && b.full_ply == 2 && b.en_passant_target == 91, "Board game attributes unchanged.");
            }
        }

        [TestMethod]
        public void Pawn_Movement_En_Passant()
        {
            //  arrange
            b = new Board();

            //  act
            //b.Make_Move("a7", "a6");      // Setting up en-passant
            //b.Make_Move("a4", "a5");      //
            //b.Make_Move("b7", "b5");      //
            //b.Make_Move("a5", "b6");      // Taking en-passant

            //  assert
            Assert.IsTrue(b.board[71] == (int)Piece.Type.empty);           // Checking piece has moved
            Assert.IsTrue(b.board[82] == (int)Piece.Type.w_pawn);          // 
            Assert.IsTrue(b.board[72] == (int)Piece.Type.empty);           // Checks black piece was correctly removed from the board
        }

        [TestMethod]
        public void Pawn_Movement_in_Check()
        {
            //  arrange
            b = new Board();

            //  act

            //  assert
        }

        [TestMethod]
        public void Pawn_Movement_Pinned()
        {
            //  arrange
            b = new Board();

            //  act

            //  assert
        }


    }
}
