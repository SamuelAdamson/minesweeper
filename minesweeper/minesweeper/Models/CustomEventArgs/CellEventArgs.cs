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
        int? numAdjacent;
        bool? flagsAvailable;

        public CellEventArgs(string message, int? numAdjacent, bool? flagsAvailable)
		{
            // Set values
            this.message = message;
            this.numAdjacent = numAdjacent;
            this.flagsAvailable = flagsAvailable;
		}

        // Access control
		public string Message { get => message; }
        public int? NumAdjacent { get => numAdjacent; }
        public bool? FlagsAvailable { get => flagsAvailable; }
    }
}
