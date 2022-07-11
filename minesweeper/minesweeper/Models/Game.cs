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
        HashSet<Tuple<int,int>> mineCoords;

        // Random Generator
        Random random;

        /// <summary>
        /// Minesweeper Constructor
        /// </summary>
        /// <param name="mode"> Mode [easy, medium, hard] </param>
        public Game(string mode)
        {
            System.Diagnostics.Debug.WriteLine("Constructor");
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
                // 10 Mines
                nRows = 8;
                nCols = 12;
                numMines = 10;
			}
            else if(modeStr == "medium") {
                // 12x16 Grid
                // 40 Mines
                nRows = 12;
                nCols = 16;
                numMines = 40;
            }
            else {
                // 16x20 Grid
                // 80 Mines
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
        /// Get adjacent cells from a specific coordinate
        /// If a search, mark each cell as visited
        /// </summary>
        /// <param name="coord"> Coordinate to Find Adjacent Cells</param>
        /// <param name="search"> Called in a search </param>
        /// <returns></returns>
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
                        && !(i == coord.Item1 && j == coord.Item2) // Ensure not coordinate itself)                        
                        && grid[i,j].Covered) // Ensure cell is covered
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
            mineCoords = new HashSet<Tuple<int, int>>(); // Create list of coordinates
            SetRandomCoordinates(numMines, mineCoords, false); // Set random coords, pass mineCoords by ref

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
            PlaceMine(SetRandomCoordinates(n + 1, mineCoords, true));
		}

        /// <summary>
        /// Set random coordinates
        /// Produces a HashSet of n unique random coordinates
        /// If replace is true, the last coordinate added will be returned from the function
        /// </summary>
        /// <param name="n"> Number of coordinates </param>
        /// <param name="coords"> Hash Set of Coordinates </param>
        /// <param name="replace"> Replace if True last coordinate returned </param>
        /// <returns></returns>
		private Tuple<int,int>? SetRandomCoordinates(int n, HashSet<Tuple<int, int>> coords, bool replace)
		{
            // If replace is true, this value will be returned
            Tuple<int, int>? newCoord = null;

			while (coords.Count < n)
            {   // Using hashset, so only unique items will be used (O(n) as opposed to O(n^2))
                Tuple<int, int> coord = new Tuple<int, int>(random.Next(nRows), random.Next(nCols));
                coords.Add(coord);

                if(replace) { newCoord = coord; }
            }

            return newCoord;
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
            /* If a cell is uncovered that is not adjacent to any mines,
             *  then all cells adjacent to this cell are also uncovered.
             *  This same property applies to cells that are uncovered 
             *  in the process.
             */
            if(((Cell)sender).Adjacent == 0)
            {
                
            }
        }


        private void BreadthFirstSearch(Tuple<int,int> coord)
        {
            // TODO
        }

        private void DepthFirstSearch(Tuple<int,int> coord)
        {
            // TODO
        }
	}
}
