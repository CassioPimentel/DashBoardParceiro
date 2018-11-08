using DashboardParceiro.Models;
using DashboardParceiro.Models.Cadastros;
using DashboardParceiro.Service.Cadastros.TamanhoFolder;
using DashboardParceiro.Service.Cadastros.TipoFolder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;

namespace DashboardParceiro.Controllers
{
    public class TamanhoController : Controller
    {
        private ITamanhoService _tamanhoService;
        private ITipoService _tipoService;

        public TamanhoController(ITamanhoService tamanhoService,
                                 ITipoService tipoService)
        {
            _tamanhoService = tamanhoService;
            _tipoService = tipoService;
        }

        public IActionResult Index()
        {
            var Tamanho = _tamanhoService.GetAll();

            if (Tamanho == null)
            {
                return RedirectToAction("Error", "PageError");
            }

            return View(Tamanho);
        }

        public IActionResult Editar(int Codigo)
        {
            TempData["Message"] = null;
            var Tamanho = _tamanhoService.Get(Codigo);
            var Tipos = _tipoService.GetAll();
            var Tipos1 = new SelectList(Tipos, "Codigo", "Descricao", Tamanho.TipoId);
            Tamanho.Tipos = Tipos1;

            return View(Tamanho);
        }

        public IActionResult AddTamanho()
        {
            var Tamanho = new Tamanho();
            return PartialView(Tamanho);
        }

        public IActionResult Create()
        {
            TempData["Message"] = null;
            var Tamanho = new Tamanho();

            var Tipos = _tipoService.GetAll();
            var Tipos1 = new SelectList(Tipos, "Codigo", "Descricao", Tamanho.TipoId);
            Tamanho.Tipos = Tipos1;

            return View(Tamanho);
        }

        [HttpPost]
        public IActionResult Save([Bind] Tamanho tamanho)
        {
            if (ModelState.IsValid)
            {
                var Codigo = tamanho.Codigo;
                var result = _tamanhoService.Save(tamanho);
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

            return RedirectToAction("Index", "Tamanho");
        }

        [HttpPost]
        public ObjectResult Excluir(int Codigo)
        {
            var retorno = new MessageReturn();
            var result = _tamanhoService.Excluir(Codigo);

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