/*  Pause Event Args Class
 *      - Custom event argument for puasing
 *  Samuel Adamson 
 */

namespace minesweeper.Models.CustomEventArgs
{
    public class PauseEventArgs : EventArgs
    {
        // Event message
        string message;

        public PauseEventArgs(string message)
        {
            // Set fields
            this.message = message;
        }

        // Access control
        public string Message { get => message; set => message = value; }
    }
}
