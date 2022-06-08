using Microsoft.AspNetCore.Mvc;
using minesweeper.Models;
using System.Diagnostics;

namespace minesweeper.Controllers
{
    public class MinesweeperController : Controller
    {
        private readonly ILogger<MinesweeperController> _logger;

        public MinesweeperController(ILogger<MinesweeperController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult About()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}