using DashboardParceiro.Models.Cadastros;
using DashboardParceiro.Service.Cadastros.CategoriaFolder;
using Microsoft.AspNetCore.Mvc;
using DashboardParceiro.Models;
using Newtonsoft.Json;
using DashboardParceiro.Service.Cadastros.ComplCategoriaFolder;

namespace DashboardParceiro.Controllers
{
    public class CategoriaController : Controller
    {
        private ICategoriaService _categoriaService;
        private IComplementoCategoriaService _complementoCategoriaService;

        public CategoriaController(ICategoriaService categoriaService,
                                   IComplementoCategoriaService complementoCategoriaService)
        {
            _categoriaService = categoriaService;
            _complementoCategoriaService = complementoCategoriaService;
        }

        public IActionResult Index()
        {
            var Categoria = _categoriaService.GetAll();

            if (Categoria == null)
            {
                return RedirectToAction("Error", "PageError");
            }

            return View(Categoria);
        }

        public IActionResult Editar(int Id)
        {
            TempData["Message"] = null;
            var Categoria = _categoriaService.Get(Id);

            return View(Categoria);
        }

        public IActionResult AddCategoria()
        {
            var Categoria = new Categoria();

            return PartialView(Categoria);
        }

        public IActionResult Create()
        {
            TempData["Message"] = null;
            var Categoria = new Categoria();

            return View(Categoria);
        }

        [HttpPost]
        public IActionResult Save([Bind] Categoria categoria)
        {
            if (ModelState.IsValid)
            {
                var Codigo = categoria.Codigo;
                var result = _categoriaService.Save(categoria);
                if (result != null)
                {
                    var Mensagem = Codigo != 0 ? "atualizado" : "salvo";
                    TempData["Message"] = JsonConvert.SerializeObject(new MessageReturn() { CssClassName = "success", Title = "Sucesso!", Message = "Item " + Mensagem + " com sucesso." });
                }
                else
                {
                    var Mensagem = Codigo != 0 ? "atualizar" : "salvar";
                    TempData["Message"] = JsonConvert.SerializeObject(new MessageReturn() { CssClassName = "warning", Title = "Erro!", Message = "Erro ao " + Mensagem + " item."  });
                }
                
            }

            return RedirectToAction("Index", "Categoria");
        }

        [HttpPost]
        public ObjectResult Excluir(int Codigo)
        {
            var retorno = new MessageReturn();
            var CategoriasVinculadas = _complementoCategoriaService.GetCategorias(Codigo);
            if (CategoriasVinculadas.Count > 0)
            {
                retorno = new MessageReturn { Title = "0", Message = "Esta categoria esta vincula a um complemento, remova o vinculo no cadastro de complemento e tente novamente.", CssClassName = "warning" };
                return new ObjectResult(retorno);
            }
            var result = _categoriaService.Excluir(Codigo);

            if (result == 1)
            {
                retorno = new MessageReturn { Title = "1", Message = "Item excluido com sucesso.", CssClassName = "success" };
            }
            else
            {
                retorno = new MessageReturn { Title = "0", Message = "Erro ao excluir item.", CssClassName = "warning" };
            }

            return new ObjectResult(retorno);
        }
    }  
}