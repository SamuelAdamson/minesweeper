/*  Game End Event Args Class
 *      - Custom event argument for game end (win/loss)
 *  Samuel Adamson 
 */

namespace minesweeper.Models.CustomEventArgs
{
    public class GameEndEventArgs : EventArgs
    {
        string message; // Message to be displayed on alert
        bool win;   // Did the game result in a win

        public GameEndEventArgs(string message, bool win)
        {
            // Set values
            this.message = message;
            this.win = win;
        }

        // Access control
        public string Message { get => message; }
        public bool Win { get => win; } 
    }
}
