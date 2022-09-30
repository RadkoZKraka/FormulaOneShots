using Microsoft.AspNetCore.Mvc;

namespace FormulaOneShots.Controllers;

public class StandingsController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}