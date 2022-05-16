using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Chess_Engine_v2;
using System.Linq;
using Chess_Engine_v2._0;

namespace Engine_Tests
{
    /// <summary>
    /// <para>Checks all possible bishop movements</para>
    /// </summary>
    [TestClass]
    public class Bishop_Tests
    {
        Board b;

        #region White Bishop Tests
        [TestMethod]
        public void White_Movement_Invalid_Backwards_Test()
        {
            //  arrange
            //----------------------------------------
            string board = @"^^^^^^^^
                            ^^^^^^^^
                            ^^^^^^^^
                            ^^^♗^^^^
                            ^^^^^^^^
                            ^^^^^^^^
                            ^^^^^^^^
                            ^^^^^^^^";
            b = new Board();
            b.board = b.Convert_From_ASCII(board);
            Move move = new Move();
            move.START_SQUARE = "d5";
            move.TARGET_SQUARE = "d3";
            move.FLAG = Move.Flag.quiet;

            //  act 
            //----------------------------------------
            // Moving backwards 2 squares
            b.Make_Move(move);

            // assert
            //----------------------------------------
            Assert.IsTrue(Enumerable.SequenceEqual(b.board, b.Convert_From_ASCII(board)), "Test Failed: board array is not as expected");
        }

        [TestMethod]
        public void White_Movement_Invalid_Forward_Test()
        {
            //  arrange
            //----------------------------------------
            string board = @"^^^^^^^^
                            ^^^^^^^^
                            ^^^^^^^^
                            ^^^♗^^^^
                            ^^^^^^^^
                            ^^^^^^^^
                            ^^^^^^^^
                            ^^^^^^^^";
            b = new Board();
            b.board = b.Convert_From_ASCII(board);
            Move move = new Move();
            move.START_SQUARE = "d5";
            move.TARGET_SQUARE = "d7";
            move.FLAG = Move.Flag.quiet;

            //  act 
            //----------------------------------------
            // Moving backwards 2 squares
            b.Make_Move(move);

            // assert
            //----------------------------------------
            Assert.IsTrue(Enumerable.SequenceEqual(b.board, b.Convert_From_ASCII(board)), "Test Failed: board array is not as expected");
        }

        [TestMethod]
        public void White_Movement_Invalid_Left_Test()
        {
            //  arrange
            //----------------------------------------
            string board = @"^^^^^^^^
                            ^^^^^^^^
                            ^^^^^^^^
                            ^^^♗^^^^
                            ^^^^^^^^
                            ^^^^^^^^
                            ^^^^^^^^
                            ^^^^^^^^";
            b = new Board();
            b.board = b.Convert_From_ASCII(board);
            Move move = new Move();
            move.START_SQUARE = "d5";
            move.TARGET_SQUARE = "f5";
            move.FLAG = Move.Flag.quiet;

            //  act 
            //----------------------------------------
            // Moving backwards 2 squares
            b.Make_Move(move);

            // assert
            //----------------------------------------
            Assert.IsTrue(Enumerable.SequenceEqual(b.board, b.Convert_From_ASCII(board)), "Test Failed: board array is not as expected");
        }

        [TestMethod]
        public void White_Movement_Invalid_Right_Test()
        {
            //  arrange
            string board = @"^^^^^^^^
                            ^^^^^^^^
                            ^^^^^^^^
                            ^^^^^^^^
                            ^^^^^^^^
                            ^^^^^^^^
                            ^^^^^^^^
                            ^^^^^^^^";
            string board_final = @"^^^^^^^^
                                ^^^^^^^^
                                ^^^^^^^^
                                ^^^^^^^^
                                ^^^^^^^^
                                ^^^^^^^^
                                ^^^^^^^^
                                ^^^^^^^^";
            b = new Board();
            b.board = b.Convert_From_ASCII(board);
            b.side_to_move = 'b';

            //  act


            //  assert
            Assert.IsTrue(Enumerable.SequenceEqual(b.board, b.Convert_From_ASCII(board_final)), "Test Failed: board array is not as expected");
        }
        #endregion

        #region Black Bishop Tests
        [TestMethod]
        public void Black_Movement_Invalid_Backwards_Test()
        {
            //  arrange
            //----------------------------------------
            string board = @"^^^^^^^^
                            ^^^^^^^^
                            ^^^^^^^^
                            ^^^^^^^^
                            ^^^^^^^^
                            ^^^^^^^^
                            ^^^^^^^^
                            ^^^^^^^^";
            b = new Board();
            b.board = b.Convert_From_ASCII(board);
            b.side_to_move = 'b';
            Move move = new Move();
            move.START_SQUARE = "a5";
            move.TARGET_SQUARE = "a7";
            move.FLAG = Move.Flag.quiet;

            //  act 
            //----------------------------------------
            // Moving backwards 2 squares
            b.Make_Move(move);

            // assert
            //----------------------------------------
            Assert.IsTrue(Enumerable.SequenceEqual(b.board, b.Convert_From_ASCII(board)), "Test Failed: board array is not as expected");
        }

        [TestMethod]
        public void Black_Movement_Invalid_Diagonal_Test()
        {
            //  arrange
            //----------------------------------------
            string board = @"^^^^^^^^
                            ^^^^^^^^
                            ^^^^^^^^
                            ^^^^^^^^
                            ^^^^^^^^
                            ^^^^^^^^
                            ^^^^^^^^
                            ^^^^^^^^";
            b = new Board();
            b.board = b.Convert_From_ASCII(board);
            b.side_to_move = 'b';
            Move move = new Move();
            move.START_SQUARE = "a5";
            move.TARGET_SQUARE = "d8";
            move.FLAG = Move.Flag.quiet;

            //  act 
            //----------------------------------------
            // Moving diagonal
            b.Make_Move(move);

            // assert
            //----------------------------------------
            Assert.IsTrue(Enumerable.SequenceEqual(b.board, b.Convert_From_ASCII(board)), "Test Failed: board array is not as expected");
        }

        [TestMethod]
        public void Black_Movement_Invalid_Forward_Two_Spaces()
        {
            //  arrange
            //----------------------------------------
            string board = @"^^^^^^^^
                            ^^^^^^^^
                            ^^^^^^^^
                            ^^^^^^^^
                            ^^^^^^^^
                            ^^^^^^^^
                            ^^^^^^^^
                            ^^^^^^^^";
            b = new Board();
            b.board = b.Convert_From_ASCII(board);
            b.side_to_move = 'b';
            Move move = new Move();
            move.START_SQUARE = "a5";
            move.TARGET_SQUARE = "a3";
            move.FLAG = Move.Flag.quiet;

            //  act 
            //----------------------------------------
            // Moving backwards 2 squares
            b.Make_Move(move);

            // assert
            //----------------------------------------
            Assert.IsTrue(Enumerable.SequenceEqual(b.board, b.Convert_From_ASCII(board)), "Test Failed: board array is not as expected");
        }

        [TestMethod]
        public void Black_Movement_Valid_Forward_Two_Spaces()
        {
            //  arrange
            //----------------------------------------
            string board = @"^^^^^^^^
                            ^^^^^^^^
                            ^^^^^^^^
                            ^^^^^^^^
                            ^^^^^^^^
                            ^^^^^^^^
                            ^^^^^^^^
                            ^^^^^^^^";
            string board_final = @"^^^^^^^^
                                ^^^^^^^^
                                ^^^^^^^^
                                ^^^^^^^^
                                ^^^^^^^^
                                ^^^^^^^^
                                ^^^^^^^^
                                ^^^^^^^^";
            b = new Board();
            b.board = b.Convert_From_ASCII(board);
            b.side_to_move = 'b';
            Move move = new Move();
            move.START_SQUARE = "a7";
            move.TARGET_SQUARE = "a5";
            move.FLAG = Move.Flag.quiet;

            //  act 
            //----------------------------------------
            // Moving backwards 2 squares
            b.Make_Move(move);

            // assert
            //----------------------------------------
            Assert.IsTrue(Enumerable.SequenceEqual(b.board, b.Convert_From_ASCII(board_final)), "Test Failed: board array is not as expected");
        }

        [TestMethod]
        public void Black_Movement_En_Passant()
        {
            //  arrange
            string board = @"^^^^^^^^
                            ^^^^^^^^
                            ^^^^^^^^
                            ^^^^^^^^
                            ^^^^^^^^
                            ^^^^^^^^
                            ^^^^^^^^
                            ^^^^^^^^";
            string board_final = @"^^^^^^^^
                                ^^^^^^^^
                                ^^^^^^^^
                                ^^^^^^^^
                                ^^^^^^^^
                                ^^^^^^^^
                                ^^^^^^^^
                                ^^^^^^^^";
            b = new Board();
            b.board = b.Convert_From_ASCII(board);
            Move move = new Move();
            move.START_SQUARE = "a5";
            move.TARGET_SQUARE = "a7";
            move.FLAG = Move.Flag.quiet;

            //  act


            //  assert
            Assert.IsTrue(Enumerable.SequenceEqual(b.board, b.Convert_From_ASCII(board_final)), "Test Failed: board array is not as expected");
        }
        #endregion

        [TestMethod]
        public void Movement_in_Check()
        {
            //  arrange
            string board = @"^^^^^^^^
                            ^^^^^^^^
                            ^^^^^^^^
                            ^^^^^^^^
                            ^^^^^^^^
                            ^^^^^^^^
                            ^^^^^^^^
                            ^^^^^^^^";
            string board_final = @"^^^^^^^^
                                ^^^^^^^^
                                ^^^^^^^^
                                ^^^^^^^^
                                ^^^^^^^^
                                ^^^^^^^^
                                ^^^^^^^^
                                ^^^^^^^^";
            b = new Board();
            b.board = b.Convert_From_ASCII(board);
            Move move = new Move();
            move.START_SQUARE = "a5";
            move.TARGET_SQUARE = "a7";
            move.FLAG = Move.Flag.quiet;

            //  act

            // assert
            Assert.IsTrue(Enumerable.SequenceEqual(b.board, b.Convert_From_ASCII(board_final)), "Test Failed: board array is not as expected");
        }

        [TestMethod]
        public void Movement_Pinned()
        {
            //  arrange
            string board = @"^^^^^^^^
                            ^^^^^^^^
                            ^^^^^^^^
                            ^^^^^^^^
                            ^^^^^^^^
                            ^^^^^^^^
                            ^^^^^^^^
                            ^^^^^^^^";
            string board_final = @"^^^^^^^^
                                ^^^^^^^^
                                ^^^^^^^^
                                ^^^^^^^^
                                ^^^^^^^^
                                ^^^^^^^^
                                ^^^^^^^^
                                ^^^^^^^^";
            b = new Board();
            b.board = b.Convert_From_ASCII(board);
            Move move = new Move();
            move.START_SQUARE = "a5";
            move.TARGET_SQUARE = "a7";
            move.FLAG = Move.Flag.quiet;

            //  act

            // assert
            Assert.IsTrue(Enumerable.SequenceEqual(b.board, b.Convert_From_ASCII(board_final)), "Test Failed: board array is not as expected");
        }
    }
}

