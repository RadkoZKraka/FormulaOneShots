using Microsoft.AspNetCore.Mvc;

namespace FormulaOneShots.Controllers;

public class ShotsController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}