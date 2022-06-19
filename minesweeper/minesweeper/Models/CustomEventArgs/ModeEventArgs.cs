/*  Mode Event Args Class
 *      - Custom event argument for mode selection
 *  Samuel Adamson 
 */

namespace minesweeper.Models.CustomEventArgs
{
	public class ModeEventArgs : EventArgs
	{
		// New mode that was selected
		string newMode;

		public ModeEventArgs(string newMode)
		{
			// Set Values
			this.newMode = newMode;
		}

		// Access Control
		public string NewMode { get => newMode; set => newMode = value; }
	}
}
