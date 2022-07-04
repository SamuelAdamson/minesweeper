/*  Pause Event Args Class
 *      - Custom event argument for puasing
 *  Samuel Adamson 
 */

namespace minesweeper.Models.CustomEventArgs
{
    public class TimerEventArgs : EventArgs
    {
        // Event message
        string message;

        public TimerEventArgs(string message)
        {
            // Set fields
            this.message = message;
        }

        // Access control
        public string Message { get => message; }
    }
}
