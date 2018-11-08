using Microsoft.AspNetCore.Mvc;

namespace DashboardParceiro.Controllers
{
    public class PageErrorController : Controller
    {
        public IActionResult Error()
        {
            return View();
        }
    }
}