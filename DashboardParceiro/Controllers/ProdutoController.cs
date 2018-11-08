using DashboardParceiro.Service.Cadastros.ProdutoFolder;
using Microsoft.AspNetCore.Mvc;

namespace DashboardParceiro.Controllers
{
    public class ProdutoController : Controller
    {
        private IProdutoService _produtoService;

        public ProdutoController(IProdutoService produtoService)
        {
            _produtoService = produtoService;
        }

        public IActionResult Index()
        {
            var Produtos = _produtoService.GetAll();

            if (Produtos == null)
            {
                return RedirectToAction("Error", "PageError");
            }

            return View(Produtos);
        }
    }
}