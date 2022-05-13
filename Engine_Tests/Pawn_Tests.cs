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

        #region White Pawn Tests
        [TestMethod]
        public void White_Movement_Invalid_Backwards_Test()
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
        public void White_Movement_Invalid_Diagonal_Test()
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
        public void White_Movement_Invalid_Forward_Two_Spaces()
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
        public void White_Movement_Valid_Forward_Two_Spaces()
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
        public void White_Movement_En_Passant()
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
        #endregion

        #region Black Pawn Tests
        [TestMethod]
        public void Black_Movement_Invalid_Backwards_Test()
        {
            //  arrange
            //----------------------------------------
            string board = @"^^^^^^^^
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
                            ♟^^^^^^^
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
                            ♟^^^^^^^
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
                            ♟^^^^^^^
                            ^^^^^^^^
                            ^♙^^^^^^
                            ^^^^^^^^";
            string board_final = @"^^^^^^^^
                                ^^^^^^^^
                                ^^^^^^^^
                                ^^^^^^^^
                                ^^^^^^^^
                                ^♟^^^^^^
                                ^^^^^^^^
                                ^^^^^^^^";
            b = new Board();
            b.board = b.Convert_From_ASCII(board);
            b.side_to_move = 'w';

            //  act
            b.Make_Move("b2", "b4", 'w');
            b.Make_Move("a4", "b3", 'b');

            //  assert
            Assert.IsTrue(Enumerable.SequenceEqual(b.board, b.Convert_From_ASCII(board_final)), "Test Failed: board array is not as expected");
        }
        #endregion

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
            b.board = b.Convert_From_ASCII(board);

            //  act

            // assert
        }

        [TestMethod]
        public void Pawn_Movement_Pinned()
        {
            //  arrange
            string board = @"^^^^^^^♝
                            ^^^^^^^^
                            ^^^^^^^^
                            ^^^^^^^^
                            ^^^^^^^^
                            ^^^^^^^^
                            ^♙^^^^^^
                            ♔^^^^^^^";
            string board_final = @"^^^^^^^♝
                                ^^^^^^^^
                                ^^^^^^^^
                                ^^^^^^^^
                                ^^^^^^^^
                                ^^^^^^^^
                                ^♙^^^^^^
                                ♔^^^^^^^";
            b = new Board();
            b.board = b.Convert_From_ASCII(board);

            //  act
            b.Make_Move("b2", "b4", 'w');

            // assert
            Assert.IsTrue(Enumerable.SequenceEqual(b.board, b.Convert_From_ASCII(board_final)), "Test Failed: board array is not as expected");
        }


    }
}
