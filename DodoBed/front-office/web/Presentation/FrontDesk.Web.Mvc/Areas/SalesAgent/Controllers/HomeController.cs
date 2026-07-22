using Microsoft.AspNetCore.Mvc;

namespace FrontDesk.Web.Mvc.Areas.SalesAgent.Controllers;

[Area("SalesAgent")]
public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
