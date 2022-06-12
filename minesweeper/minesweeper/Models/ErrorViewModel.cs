/*  Error View Model
 *      - Error View Handling Model
 *  Samuel Adamson 
 */

namespace minesweeper.Models
{
    public class ErrorViewModel
    {
        public string? RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}