using Microsoft.VisualStudio.TestTools.UnitTesting;
using Chess_Engine_v2;

namespace Chess_Engine_Tests
{
    [TestClass]
    class Piece_Testing
    {
        /// <summary>
        /// <para>Checks all possible valid pawn moves</para>
        /// <para>Individually calls all pawn movement tests. Each test is given a good board position to
        /// check all possibilities. E.g. en passant, in-check, pinned pieces etc..</para>
        /// </summary>
        [TestMethod]
        public void Pawn_Movement()
        {

            // Arrange
            Pawn_Tests pt = new Pawn_Tests();

            // Act & Assert
            pt.Pawn_Movement_Valid();
            pt.Pawn_Movement_En_Passant();
            pt.Pawn_Movement_in_Check();
            pt.Pawn_Movement_Pinned();
        }
        /// <summary>
        /// <para>Checks all possible rook movements</para>
        /// <para>e.g. Castling, pinned, blocking pieces e.t.c.</para>
        /// </summary>
        [TestMethod]
        public void Rook_Movement()
        {
            //  arrange
            Rook_Tests rt = new Rook_Tests();

            //  act & assert
            rt.Movement_Valid();
            rt.Movement_Castle_Tests();
            rt.Movement_in_Check();
            rt.Movement_Pinned();
        }
        /// <summary>
        /// <para>Checks all possible bishop movements</para>
        /// </summary>
        [TestMethod]
        public void Bishop_Movement()
        {
            //  arrange
            Bishop_Tests bt = new Bishop_Tests();

            //  act & assert
            bt.Movement_Valid();
            bt.Movement_in_Check();
            bt.Movement_Pinned();
        }
        /// <summary>
        /// Checks all possible knight movements
        /// </summary>
        [TestMethod]
        public void Knight_Movement()
        {
            //  arrange
            Knight_Tests kt = new Knight_Tests();

            //  act & assert
            kt.Movement_Valid();
            kt.Movement_in_Check();
            kt.Movement_Pinned();
        }
        /// <summary>
        /// Checks all possible queen movements
        /// </summary>
        [TestMethod]
        public void Queen_Movement()
        {
            //  arrange
            Queen_Tests qt = new Queen_Tests();

            //  act & assert
            qt.Movement_Valid();
            qt.Movement_in_Check();
            qt.Movement_Pinned();
        }
        /// <summary>
        /// Checks all possible king movements
        /// </summary>
        [TestMethod]
        public void King_Movement()
        {
            //  arrange
            King_Tests kt = new King_Tests();

            //  act & assert
            kt.Movement_Valid();
            kt.Movement_Castle_Tests();
            kt.Movement_in_Check();
        }
    }
}
