/*  Cell Class
 *      - Cells used in gameboard
 *      - Model class - hidden from frontend
 *  Samuel Adamson 
 */

using minesweeper.Views.Shared.Components;
namespace minesweeper.Models
{
    public class Cell
    {
        // Properties of cell
        bool mine; // Is this cell a mine
        bool covered; // Is the cell covered
        int adjacent; // Number of adjacent mines
        int row, col; // Coordinates of cell in grid
        //CellUI cellUI; // Corresponding UI

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
            adjacent = 0;

            // Initialize cellUI
            //cellUI = new CellUI();

            // Subscribe to UI events
            //cellUI.
        }

        // Access controlled
        public bool Covered { get => covered; set => covered = value; }
        public bool Mine { get => mine; set => mine = value; }
        // public CellUI CellUI { get => cellUI; }


        void HandleUncover()
        {

        }

        void HandleFlag()
        {

        }

        void HandleUnflag()
        {

        }
    }
}
