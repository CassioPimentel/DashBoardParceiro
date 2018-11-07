using DashboardParceiro.Models;
using DashboardParceiro.Models.Cadastros;
using DashboardParceiro.Models.Cadastros.ModelBinding;
using DashboardParceiro.Service.Cadastros.CategoriaFolder;
using DashboardParceiro.Service.Cadastros.ComplCategoriaFolder;
using DashboardParceiro.Service.Cadastros.ComplementoFolder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;

namespace DashboardParceiro.Controllers
{
    public class ComplementoController : Controller
    {
        private IComplementoCategoriaService _complementoCategoriaService;
        private IComplementoService _complementoService;
        private ICategoriaService _categoriaService;

        public ComplementoController(IComplementoCategoriaService complementoCategoriaService, 
                                     IComplementoService complementoService,
                                     ICategoriaService categoriaService)
        {
            _complementoCategoriaService = complementoCategoriaService;
            _complementoService = complementoService;
            _categoriaService = categoriaService;
        }

        public IActionResult Index()
        {
            var Complementos = _complementoService.GetAll();
            return View(Complementos);
        }

        public IActionResult Create()
        {
            var ComplementoCateg = new ComplementoCategoriaBind();
            var Categorias = _categoriaService.GetAll();
            var Categs = new SelectList(Categorias, "Codigo", "Descricao");
            ComplementoCateg.Categorias = Categs;
            return View(ComplementoCateg);
        }

        public IActionResult Editar(int Codigo)
        {
            var ComplementoCateg = new ComplementoCategoriaBind();
            var ComplementoCategias = _complementoCategoriaService.GetCategoriaVinculado(Codigo);
            ComplementoCateg.Complemento = _complementoService.Get(Codigo);
            int[] ids = new int[ComplementoCategias.Count];

            for (int i = 0; i < ComplementoCategias.Count; i++)
            {
                ids[i] = ComplementoCategias[i].CodigoCategoria;
            }

            var Categorias = _categoriaService.GetAll();
            var ItensSelecionados = _categoriaService.GetCategorias(ids);
            var Categs = new SelectList(Categorias, "Codigo", "Descricao", ids);

            ComplementoCateg.Categorias = Categs;
            ComplementoCateg.CategoriaIds = ids;

            return View(ComplementoCateg);
        }

        [HttpPost]
        public IActionResult Save(ComplementoCategoriaBind Model)
        {
            var Codigo = Model.Complemento.Codigo;
            var Complemento = _complementoService.Save(Model.Complemento);
            Model.Complemento.Codigo = Complemento.Codigo;
            var Result = _complementoCategoriaService.Save(Model);

            if (Result != null)
            {
                var Mensagem = Codigo != 0 ? "atualizado" : "salvo";
                TempData["Message"] = JsonConvert.SerializeObject(new MessageReturn() { CssClassName = "success", Title = "Sucesso!", Message = "Item " + Mensagem + " com sucesso." });
            }
            else
            {
                var Mensagem = Codigo != 0 ? "atualizar" : "salvar";
                TempData["Message"] = JsonConvert.SerializeObject(new MessageReturn() { CssClassName = "warning", Title = "Erro!", Message = "Erro ao " + Mensagem + " item." });
            }

            return RedirectToAction("Index", "Complemento");
        }

        [HttpPost]
        public ObjectResult Excluir(int Codigo)
        {
            var retorno = new MessageReturn();
            _complementoCategoriaService.Excluir(Codigo);
            var result = _complementoService.Excluir(Codigo);

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