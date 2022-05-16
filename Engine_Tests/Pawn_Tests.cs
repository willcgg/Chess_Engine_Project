using Chess_Engine_v2;
using Chess_Engine_v2._0;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace Engine_Tests
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
            Assert.IsTrue(Enumerable.SequenceEqual(b.board, b.Convert_From_ASCII(board_final)), "Test Failed: board array is not as expected");
        }

        [TestMethod]
        public void White_Movement_En_Passant()
        {
            //  arrange
            string board = @"^^^^^^^^
                            ^^^^^^^^
                            ^^^^^^^^
                            ♙♟^^^^^^
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
            b.en_passant_target = 42;
            Move move = new Move();
            move.START_SQUARE = "a5";
            move.TARGET_SQUARE = "b6";
            move.FLAG = Move.Flag.en_passant_capture;

            //  act
            b.Make_Move(move);

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
                            ♟^^^^^^^
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
                            ♟^^^^^^^
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
                            ♟♙^^^^^^
                            ^^^^^^^^
                            ^^^^^^^^
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
            b.en_passant_target = (int)Enum.Parse(typeof(Board.Square), "b3");
            Move move = new Move();
            move.START_SQUARE = "a4";
            move.TARGET_SQUARE = "b3";
            move.FLAG = Move.Flag.en_passant_capture;


            //  act
            b.Make_Move(move);

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
            Move move = new Move();
            move.START_SQUARE = "a5";
            move.TARGET_SQUARE = "b6";
            move.FLAG = Move.Flag.quiet;

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
            Move move = new Move();
            move.START_SQUARE = "b2";
            move.TARGET_SQUARE = "b4";
            move.FLAG = Move.Flag.quiet;

            //  act
            b.Make_Move(move);

            // assert
            Assert.IsTrue(Enumerable.SequenceEqual(b.board, b.Convert_From_ASCII(board_final)), "Test Failed: board array is not as expected");
        }


    }
}
