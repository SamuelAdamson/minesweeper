/*  Cell Event Args Class
 *      - Custom event argument for cell actions
 *  Samuel Adamson 
 */

namespace minesweeper.Models.CustomEventArgs
{
    public class CellEventArgs : EventArgs
    {
        // Event message
        string message;

        public CellEventArgs(string message)
		{
            // Set values
            this.message = message;
		}

        // Access control
		public string Message { get => message; set => message = value; }
	}
}
