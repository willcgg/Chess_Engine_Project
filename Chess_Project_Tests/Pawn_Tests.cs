namespace Chess_Project_Tests
{
    [TestClass]
    class Pawn_Tests
    {

        Board board;

        [TestMethod]
        public void Pawn_Movement_Valid() {

            //  arrange
            board = new Board();
            PopulateBoard("rnbqkbnr/pppppppp/8/8/8/8/PPPPPPPP/RNBQKBNR");

            //  act
            Make_Move("a2", "a4");      // MakeMove takes two parameters, current board position and desired position
            

            //  assert
            Assert.True(board[81] == Peice.PeiceType.empty);        // Checks piece has moved
            Assert.True(board[71] == Peice.PeiceType.pawn);         // 
            
        }

        public void Pawn_Movement_En_Passant() {

            //  arrange
            board = new Board();
            PopulateBoard("rnbqkbnr/pppppppp/8/8/8/8/PPPPPPPP/RNBQKBNR");

            //  act
            Make_Move("a7", "a6");      // Setting up en-passant
            Make_Move("a4", "a5");      //
            Make_Move("b7", "b5");      //
            Make_Move("a5", "b6");      // Taking en-passant

            //  assert
            Assert.True(board[71] == Peice.PeiceType.empty);                                    // Checking piece has moved
            Assert.True(board[82] == Peice.PeiceType.pawn && Peice.PeiceColour.white);          // 
            Assert.True(board[72] == Peice.PeiceType.empty);                                    // Checks black piece was correctly removed from the board

        }

        public void Pawn_Movement_in_Check() {

        }

        public void Pawn_Movement_Pinned() {
            
        }


    }
}
