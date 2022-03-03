using Microsoft.VisualStudio.TestTools.UnitTesting;
using Chess_Engine;

namespace Chess_Project_Tests
{
    /// <summary>
    /// Class to call all peice movement tests
    /// </summary>
    [TestClass]
    public class Piece_Testing
    {
        /// <summary>
        /// <para>Checks all possible valid pawn moves</para>
        /// <para>Individually calls all pawn movement tests. Each test is given a good board position to
        /// check all possibilities. E.g. en passant, in-check, pinned pieces etc..</para>
        /// </summary>
        [TestMethod]
        public void Pawn_Movement() {

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

            //  act

            //  assert

        }
        /// <summary>
        /// <para>Checks all possible bishop movements</para>
        /// </summary>
        [TestMethod]
        public void Bishop_Movement()
        {
            //  arrange

            //  act

            //  assert

        }
        /// <summary>
        /// Checks all possible knight movements
        /// </summary>
        [TestMethod]
        public void Knight_Movement()
        {
            //  arrange

            //  act

            //  assert

        }
        /// <summary>
        /// Checks all possible queen movements
        /// </summary>
        [TestMethod]
        public void Queen_Movement()
        {
            //  arrange

            //  act

            //  assert

        }
        /// <summary>
        /// Checks all possible king movements
        /// </summary>
        [TestMethod]
        public void King_Movement()
        {
            //  arrange

            //  act

            //  assert

        }

    }
}
