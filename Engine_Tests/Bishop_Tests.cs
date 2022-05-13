using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Chess_Engine_v2;
using System.Linq;

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

            //  act 
            //----------------------------------------
            // Moving backwards 2 squares
            b.Make_Move("d5", "d3", 'w');

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

            //  act 
            //----------------------------------------
            // Moving backwards 2 squares
            b.Make_Move("d5", "d7", 'w');

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

            //  act 
            //----------------------------------------
            // Moving backwards 2 squares
            b.Make_Move("d5", "f5", 'w');

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

            //  act 
            //----------------------------------------
            // Moving backwards 2 squares
            b.Make_Move("a5", "a7", 'b');

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

            //  act 
            //----------------------------------------
            // Moving diagonal
            b.Make_Move("a5", "d8", 'b');

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

            //  act 
            //----------------------------------------
            // Moving backwards 2 squares
            b.Make_Move("a5", "a3", 'b');

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

            //  act 
            //----------------------------------------
            // Moving backwards 2 squares
            b.Make_Move("a7", "a5", 'b');

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

            //  act

            // assert
            Assert.IsTrue(Enumerable.SequenceEqual(b.board, b.Convert_From_ASCII(board_final)), "Test Failed: board array is not as expected");
        }
    }
}

