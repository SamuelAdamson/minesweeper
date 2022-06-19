/*  Cell Class
 *      - Cells used in gameboard
 *      - Model class - hidden from frontend
 *  Samuel Adamson 
 */
using minesweeper.Views.Shared.Components;
using minesweeper.Models.CustomEventArgs;
namespace minesweeper.Models
{
    public class Cell
    {
        // Properties of cell
        bool mine; // Is this cell a mine
        bool covered; // Is the cell covered
        int adjacent; // Number of adjacent mines
        int row, col; // Coordinates of cell in grid

        // GUI Component
        CellUI cellUI;

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

            // Initialize CellUI and subscribe to events
            cellUI = new CellUI();
            cellUI.Uncover += HandleUncover;
            cellUI.Flag += HandleFlag;
            cellUI.Unflag += HandleUnflag;
        }

        // Access controlled
        public bool Covered { get => covered; }
        public bool Mine { get => mine; set => mine = value; }
        public int Adjacent { get => adjacent; }
        public CellUI CellUI { get => cellUI; }

		void HandleUncover(object? sender, CellEventArgs e)
        {

        }

        void HandleFlag(object? sender, CellEventArgs e)
        {

        }

        void HandleUnflag(object? sender, CellEventArgs e)
        {

        }
    }
}
