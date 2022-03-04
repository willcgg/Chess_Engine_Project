using System;
using System.Collections.Generic;
using System.Text;

namespace Chess_Engine
{
    /// <summary>
    /// Reads string from GUI FEN string input text box and generates the board it represents.
    /// <para>Paramaters: Takes in string as a paramater.</para>
    /// <para>Outputs: pieces to GUI board, creates internal board representation of position</para>
    /// </summary>
    class FEN_Handler
    {
        /*
         * board array representation
         * board is in the middle of the board with 2 sentinel rows and 1 coloumn either side
         *   0  , 1 , 2 , 3, 4, 5, 6, 7, 8, 9
         *   10,11,12 ...
         *   20,21, ...
         *   30
         *   40
         *   50
         *   60
         *   70
         *   80
         *   90, ..................... 98, 99
         *   100, ........................ 109
         *   110,111,112, ................ 119
         * Therefore, the boards starting position in the array is 21 and ends at 98
        */

        public FEN_Handler() {
        }


    }
}
