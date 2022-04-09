using Chess_Engine_v2;
using Microsoft.VisualStudio.TestTools.UnitTesting;


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
            b = new Board();

            //  act
            b.Make_Move(21, 41, 'w');      // MakeMove takes three parameters, current board position, desired position and side to move
            b.Make_Move(91, 81, 'b');
            b.Make_Move(22, 52, 'w');      // invalid moves



            //  assert
            Assert.IsTrue(b.board[81] == (int)Piece.Type.empty);        // Checks piece has moved
            Assert.IsTrue(b.board[71] == (int)Piece.Type.w_pawn);       // 
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
