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
            Random rand = new Random(); //DEBUG
            adjacent = rand.Next(5);
            // adjacent = 0;
        }

        // Access controlled
        public bool Covered { get => covered; }
        public bool Mine { get => mine; }
        public bool Flagged { get => flagged; }
        public int Adjacent { get => adjacent; set => adjacent = value; }
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

        public string Uncover()
        {
            // Update covered
            covered = false;
            //More logic

            return GetAdjacentString();
        }

        public void Flag()
        {
            flagged = true;
        }

        public void Unflag()
        {
            flagged = false;
        }

        public void SetMine()
        {

        }
    }
}
