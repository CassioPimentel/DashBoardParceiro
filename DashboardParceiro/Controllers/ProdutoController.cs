using DashboardParceiro.Service.Cadastros.ProdutoFolder;
using DashboardParceiro.Models.Cadastros;
using Microsoft.AspNetCore.Mvc;
using DashboardParceiro.Service.Cadastros.CategoriaFolder;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using DashboardParceiro.Models;

namespace DashboardParceiro.Controllers
{
    public class ProdutoController : Controller
    {
        private IProdutoService _produtoService;
        private ICategoriaService _categoriaService;

        public ProdutoController(IProdutoService produtoService,
                                 ICategoriaService categoriaService)
        {
            _produtoService = produtoService;
            _categoriaService = categoriaService;
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

        public IActionResult Create()
        {
            var Produto = new Produto();

            var Categorias = _categoriaService.GetAll();
            Produto.Categorias = new SelectList(Categorias, "Codigo", "Descricao");

            var Medida = new Medida();
            Produto.Medidas = new SelectList(Medida.GetAll(), "Codigo", "Descricao");

            return View(Produto);
        }

        [HttpPost]
        public IActionResult Save([Bind] Produto Produto)
        {
            if (ModelState.IsValid)
            {
                var Codigo = Produto.Codigo;
                var result = _produtoService.Save(Produto);
                if (result != null)
                {
                    var Mensagem = Codigo != 0 ? "atualizado" : "salvo";
                    TempData["Message"] = JsonConvert.SerializeObject(new MessageReturn() { CssClassName = "success", Title = "Sucesso!", Message = "Item " + Mensagem + " com sucesso." });
                }
                else
                {
                    var Mensagem = Codigo != 0 ? "atualizar" : "salvar";
                    TempData["Message"] = JsonConvert.SerializeObject(new MessageReturn() { CssClassName = "warning", Title = "Erro!", Message = "Erro ao " + Mensagem + " item." });
                }

            }

            return RedirectToAction("Index", "Produto");
        }
    }
}