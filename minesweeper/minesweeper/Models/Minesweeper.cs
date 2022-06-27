﻿/*  Minesweeper Class
 *      - Handle Bulk of Server Side Game Logic
 *      - Hold a 2D List of all Cells
 *      
 *  Samuel Adamson 
 */

namespace minesweeper.Models
{
    public class Minesweeper
    {
        /* Easy - 8x12 or 12x8
         * Medium - 12x16 or 16x12
         * Hard - 16x24 or 24x16
         */ 

        // Grid dimensions
        int nRows, nCols;
        Cell[,] grid;

        public Minesweeper(string mode)
        {
            // TODO Update grid dimensions for repsonsiveness
            // Initialize number of cells
            nRows = 8;
            nCols = 12;

            // Initialize Cell Grid
            InitializeCells();
        }

        /// <summary>
        /// Initialize Cells in Grid of specified rows and columns
        /// </summary>
        private void InitializeCells()
        {
            // Initialize grid of cells
            grid = new Cell[nRows, nCols];

            for(int i = 0; i < nRows; i++)
            {
                for(int j = 0; j < nCols; j++)
                {
                    // New Cell
                    grid[i, j] = new Cell(i, j);

                }
            }
        }

        // Access control
		public Cell[,] Grid { get => grid; }
        public int NRows { get => nRows; }
        public int NCols { get => nCols; }


        private void PlaceMines(int row, int col)
        {

        }
    }
}
