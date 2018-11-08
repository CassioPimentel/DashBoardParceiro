using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace DashboardParceiro.Controllers
{
    public class PromocaoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}