/*  Cell Class
 *      - Cells used in gameboard
 *      - Model class - hidden from frontend
 *  Samuel Adamson 
 */
using minesweeper.Models.CustomEventArgs;
using minesweeper.Views.Minesweeper.Components;
namespace minesweeper.Models
{
    public class Cell
    {
        // Properties of cell
        bool mine; // Is this cell a mine
        bool covered; // Is the cell covered
        bool flagged; // Is the cell flagged
        int adjacent; // Number of adjacent mines
        int row, col; // Coordinates of cell in grid

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
        }

        // Access controlled
        public bool Covered { get => covered; }
        public bool Mine { get => mine; }
        public bool Flagged { get => flagged; }
        public int Adjacent { get => adjacent; set => adjacent = value; }
        public int Row { get => row; }
        public int Col { get => col; }

        /// <summary>
        /// Handle uncovering of cell
        /// </summary>
        /// <param name="sender"> Sender </param>
        /// <param name="e"> Args </param>
        public void HandleUncover(object? sender, CellEventArgs e)
        {
            // Update covered
            covered = false;

            
        }

        public void HandleFlag(object? sender, CellEventArgs e)
        {

        }

        public void SetMine()
        {

        }
    }
}
