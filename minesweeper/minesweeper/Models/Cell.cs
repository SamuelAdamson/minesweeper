/*  Cell Class
 *      - Cells used in gameboard
 *      - Model class - hidden from frontend
 *  Samuel Adamson 
 */
using minesweeper.Models.CustomEventArgs;
namespace minesweeper.Models
{
    public class Cell
    {
        // Properties of cell
        bool mine; // Is this cell a mine
        bool covered; // Is the cell covered
        bool flagged; // Is the cell flagged
        int adjacent; // Number of adjacent mines
        string adjacentStr; // Number of adjacent mines as string
        int row, col; // Coordinates of cell in grid

        public event EventHandler<CellEventArgs> UncoverCell; // Uncover cell by logic


        /// <summary>
        /// Cell constructor
        /// </summary>
        /// <param name="row"> Cell Row </param>
        /// <param name="col"> Cell Column </param>
        public Cell(int row, int col)
        {
            // Update row, col
            this.row = row;
            this.col = col;

            // Initialize properties
            mine = false;
            covered = true;
            flagged = false;
			adjacent = 0;
            SetAdjacentString();
        }

        // Access controlled
        public bool Mine { get => mine; set => mine = value; }
        public int Adjacent { get => adjacent; set => adjacent = value; }
        public bool Covered { get => covered; }
        public bool Flagged { get => flagged; }
        public string AdjacentStr { get => adjacentStr; }
        public int Row { get => row; }
        public int Col { get => col; }

        /// <summary>
        /// Convert adjacent integer to string
        /// </summary>
        /// <returns> Adjacent Number (string) </returns>
        private string GetAdjacentString()
        {
            switch(adjacent)
            {
                case 0: return string.Empty;
                case 1: return "one";
                case 2: return "two";
                case 3: return "three";
                default: return "fourplus";
            }
        }

        /// <summary>
        /// Set adjacent string
        /// </summary>
        public void SetAdjacentString()
		{
            adjacentStr = GetAdjacentString();
		}

        public void Uncover()
        {
            // Update covered
            covered = false;
            //More logic
        }

        public void Flag()
        {
            flagged = true;
        }

        public void Unflag()
        {
            flagged = false;
        }
    }
}
