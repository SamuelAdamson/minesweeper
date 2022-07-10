/*  Game Class
 *      - Handle Bulk of Server Side Game Logic
 *      - Hold a 2D List of all Cells
 *      
 *  Samuel Adamson 
 */
using minesweeper.Models.CustomEventArgs;

namespace minesweeper.Models
{
    public class Game
    {
        /* Easy - 8x12 or 12x8
         * Medium - 12x16 or 16x12
         * Hard - 16x20 or 24x16
         */
        string mode; // Mode string
        bool firstSelect; // First selection 

        // Grid dimensions
        int nRows, nCols;
        Cell[,] grid;

        // Number of flags used and mines
        int numFlags;
        int numMines;

        // Coordinates of mines
        List<Tuple<int,int>> mineCoords;

        // Random Generator
        Random random;

        /// <summary>
        /// Minesweeper Constructor
        /// </summary>
        /// <param name="mode"> Mode [easy, medium, hard] </param>
        public Game(string mode)
        {
            // Initialize random generator
            random = new Random();
            firstSelect = true; // First selection is set to true

            // Set values based on mode
            SetModeValues(mode);
            numFlags = 0; // No flags used at first

            // Initialize Cell Grid
            InitializeCells();
            PlaceMines();
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
                numMines = 40;
            }
            else {
                // 16x20 Grid
                // 50 Mines
                nRows = 16;
                nCols = 20;
                numMines = 80;
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
                    grid[i, j] = new Cell(i, j); // New cell
                    grid[i, j].UserUncoverCell += HandleUncover; // Subscribe uncover
                }
            }
        }

        // Access control
		public Cell[,] Grid { get => grid; }
        public int NRows { get => nRows; }
        public int NCols { get => nCols; }
        public string Mode { get => mode; }


        /// <summary>
        /// Get adjacent coordinates of cells that are uncovered
        /// </summary>
        /// <param name="coord"> Coordinate </param>
        /// <returns> Adjacent Coordinates </returns>
        private List<Tuple<int, int>> GetAdjacentCoords(Tuple<int, int> coord)
		{
            // Adjacent coordinates
            List<Tuple<int, int>> adjacents = new List<Tuple<int, int>>();

            // Iterate potential adjacent cells
            for(int i = coord.Item1 - 1; i <= coord.Item1 + 1; i++)
			{
                for(int j = coord.Item2 - 1; j <= coord.Item2 + 1; j++)
				{
                    if((i >= 0 && j >= 0 && i < nRows && j < nCols) // Ensure within bounds
                        && !(i == coord.Item1 && j == coord.Item2) // Ensure not coordinate itself
                        && grid[i,j].Covered) // Ensure cell is not covered
                    {
                        adjacents.Add(new Tuple<int, int>(i,j));
			        }
				}
			}

            return adjacents;
		}

        /// <summary>
        /// Set mine update number of adjacent mines for each adjacent cell
        /// </summary>
        /// <param name="coord"> Coordinate of Cell </param>
        private void PlaceMine(Tuple<int,int> coord)
		{
            // Get adjacent coordinates
            List<Tuple<int, int>> adjacents = GetAdjacentCoords(coord);
            grid[coord.Item1, coord.Item2].Mine = true; // Set mine to true

            // Iterate adjacent coordinates
            foreach(Tuple<int,int> adjacent in adjacents)
			{
                // Add one to number of adjacent mines on each adjacent cell
                grid[adjacent.Item1, adjacent.Item2].Adjacent++;
                grid[adjacent.Item1, adjacent.Item2].SetAdjacentString();
            }
		}

        /// <summary>
        /// Get random coordinates for mines and place them
        /// </summary>
        private void PlaceMines()
		{
			// Set random coordinates
            mineCoords = new List<Tuple<int, int>>(); // Create list of coordinates
            SetRandomCoordinates(numMines, mineCoords); // Set random coords, pass mineCoords by ref

            // Iterate coordinates
            foreach(Tuple<int,int> coord in mineCoords)
			{
                PlaceMine(coord);
			}
        }

        /// <summary>
        /// Replace Mine if first click
        /// The first click should never be a mine, so replace mine if that is the case
        /// </summary>
        /// <param name="row"> Row </param>
        /// <param name="col"> Column </param>
        private void ReplaceMine(int row, int col)
		{
            // Unset mine at coordinate
            foreach(Tuple<int,int> adjacent in GetAdjacentCoords(new Tuple<int, int>(row, col)))
            {
                // Reduce adjacency count for each adjacent cell
                grid[adjacent.Item1, adjacent.Item2].Adjacent--;
                grid[adjacent.Item1, adjacent.Item2].SetAdjacentString();
            }
            grid[row, col].Mine = false; // Remove mine

            // Add new random coordinate
            int n = mineCoords.Count;
            SetRandomCoordinates(n + 1, mineCoords);
            PlaceMine(mineCoords[n - 1]);
		}

        /// <summary>
        /// Set random coordinates
        /// </summary>
        /// <param name="n"> Number of coordinates </param>
        /// <param name="coords"> Current List (By Reference) </param>
		private void SetRandomCoordinates(int n, List<Tuple<int, int>> coords)
		{
			while (coords.Count <= n)
			{
				// Create random coordinate
				Tuple<int, int> coord = new Tuple<int, int>(random.Next(nRows), random.Next(nCols));
				do
				{
					coord = new Tuple<int, int>(random.Next(nRows), random.Next(nCols));
				} while (coords.Contains(coord)); // Run while non-unique coordinates

                // Add coord
                coords.Add(coord);
			}
		}

        /// <summary>
        /// Handle uncover
        /// </summary>
        /// <param name="sender"> Sender </param>
        /// <param name="ce"> Cell Event Arguments </param>
        private void HandleUncover(object sender, CellEventArgs ce)
        {
            // Check first click
            if(firstSelect) {
                if (ce.Mine) { ReplaceMine(((Cell)sender).Row, ((Cell)sender).Col); }
                firstSelect = false; // Update first select value
            } 

            // Check if none adjacent
            if(((Cell)sender).Adjacent == 0)
            {

            }
        }


	}
}
