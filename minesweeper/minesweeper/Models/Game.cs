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
         * Hard - 16x20 or 24x16
         */
        string mode; // Mode string


        // Grid dimensions
        int nRows, nCols;
        Cell[,] grid;

        // Number of flags used and mines
        int numFlags;
        int numMines;

        /// <summary>
        /// Minesweeper Constructor
        /// </summary>
        /// <param name="mode"> Mode [easy, medium, hard] </param>
        public Game(string mode)
        {
            // Set values based on mode
            SetModeValues(mode);
            numFlags = 0; // No flags used at first

            // Initialize Cell Grid
            InitializeCells();
        }

        /// <summary>
        /// Set Grid Dimensions and number of mines based on difficulty
        /// </summary>
        /// <param name="modeStr"></param>
        private void SetModeValues(string modeStr)
		{
            // Set mode string
            this.mode = modeStr;

            if(modeStr == "easy") {
                // 8x12 Grid
                // 8 Mines
                nRows = 8;
                nCols = 12;
                numMines = 8;
			}
            else if(modeStr == "medium") {
                // 12x16 Grid
                // 20 Mines
                nRows = 12;
                nCols = 16;
                numMines = 20;
            }
            else {
                // 16x20 Grid
                // 50 Mines
                nRows = 16;
                nCols = 20;
                numMines = 50;
			}
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
        public string Mode { get => mode; }


        private void PlaceMines(int row, int col)
        {

        }
    }
}
