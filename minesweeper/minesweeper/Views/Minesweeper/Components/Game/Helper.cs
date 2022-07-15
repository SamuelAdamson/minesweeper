/* Game UI Helper Classes/Functions
 * Samuel Adamson
 */


/// <summary>
/// Mode Class
/// </summary>
class Mode
{
	// Constructor for mode
	public Mode(string name, bool selected)
	{
		// Set values
		Name = name;
		this.selected = selected;
		this.status = selected ? "selected" : "unselected";
	}

	// Private membes
	private bool selected;
	private string status;

	// Access control
	public string Name { get; }
	public string Status { get { return this.status; } }
	public bool Selected
	{
		get { return selected; }
		set
		{
			// Update status along with selected value
			selected = value;
			status = value ? "selected" : "unselected";
		}
	}
}