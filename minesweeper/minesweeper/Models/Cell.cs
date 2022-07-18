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
        bool _stored; // Value to assist in search

        public event EventHandler<CellEventArgs> LogicUncoverCell; // Uncover cell by logic
        public event EventHandler<CellEventArgs> UserUncoverCell;  // User uncovers cell

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
            _stored = false;
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
        public bool Stored { get => _stored; set => _stored = value; }


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

        /// <summary>
        /// Uncover by user
        /// </summary>
        public void UncoverByUser()
        {
            covered = false;
            RaiseUncoverByUser(); // This event hits Game Logic
        }

        /// <summary>
        /// Uncover by logic
        /// </summary>
        public void UncoverByLogic()
        {
            covered = false;
            RaiseUncoverByLogic(); // This event hits CellUI
        }

        public void Flag()
        {
            flagged = true;
        }

        public void Unflag()
        {
            flagged = false;
        }

        /// <summary>
        /// Raise cell uncovered by user event
        /// </summary>
        protected virtual void RaiseUncoverByUser()
        {
            UserUncoverCell?.Invoke(this, new CellEventArgs("Cell uncovered by user!", mine));
        }

        /// <summary>
        /// Raise cell uncovered by logic event
        /// </summary>
        protected virtual void RaiseUncoverByLogic()
        {
            LogicUncoverCell?.Invoke(this, new CellEventArgs("Cell uncovered by logic!", mine));
        }
    }
}
