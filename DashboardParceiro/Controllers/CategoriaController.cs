using DashboardParceiro.Models.Cadastros;
using DashboardParceiro.Service.Cadastros.CategoriaFolder;
using Microsoft.AspNetCore.Mvc;

namespace DashboardParceiro.Controllers
{
    public class CategoriaController : Controller
    {
        private ICategoriaService _categoriaService;

        public CategoriaController(ICategoriaService categoriaService)
        {
            _categoriaService = categoriaService;
        }

        public IActionResult Index()
        {
            var Categoria = _categoriaService.GetAll();

            return View(Categoria);
        }

        public IActionResult AddCategoria()
        {
            var Categoria = new Categoria();

            return PartialView(Categoria);
        }

        [HttpPost]
        public JsonResult Save(Categoria categoria)
        {
            _categoriaService.Save(categoria);

            return Json("0");
        }
    }
}