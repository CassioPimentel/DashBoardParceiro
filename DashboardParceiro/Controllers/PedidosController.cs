using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace DashboardParceiro.Controllers
{
    public class PedidosController : Controller
    {
        public IActionResult Pedidos()
        {
            return View();
        }
    }
}