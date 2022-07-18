/*  Cell Event Args Class
 *      - Custom event argument for cell actions
 *  Samuel Adamson 
 */

namespace minesweeper.Models.CustomEventArgs
{
    public class CellEventArgs : EventArgs
    {
        string message; // Event message
        bool mine;  // Is the cell a mine

        public CellEventArgs(string message, bool mine)
		{
            // Set values
            this.message = message;
            this.mine = mine;
		}

        // Access control
		public string Message { get => message; }
        public bool Mine { get => mine; }
    }
}
