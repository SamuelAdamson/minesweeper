/*  Game Class
 *      - Handle Bulk of Server Side Game Logic
 *      - Hold a 2D List of all Cells
 *      
 *  Samuel Adamson 
 */

namespace minesweeper.Models
{
    public class Game
    {
        /* Easy - 8x12 or 12x8
         * Medium - 12x16 or 16x12
         * Hard - 16x24 or 24x16
         */ 

        // Grid dimensions
        int nRows, nCols;
        Cell[,] grid;

        public Game(string mode)
        {
            // TODO Update grid dimensions for repsonsiveness
            // Initialize number of cells
            nRows = 8;
            nCols = 12;

            // Initialize grid of cells
            grid = new Cell[nRows, nCols]; 


        }

    }
}
