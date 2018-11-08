using DashboardParceiro.Models;
using DashboardParceiro.Models.Cadastros;
using DashboardParceiro.Service.Cadastros.TipoFolder;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace DashboardParceiro.Controllers
{
    public class TipoController : Controller
    {
        private ITipoService _tipoService; 

        public TipoController(ITipoService tipoService)
        {
            _tipoService = tipoService;
        }

        public IActionResult Index()
        {
            var Tipo = _tipoService.GetAll();

            if (Tipo == null)
            {
                return RedirectToAction("Error", "PageError");
            }

            return View(Tipo);
        }

        public IActionResult Editar(int Id)
        {
            TempData["Message"] = null;
            var Tipo = _tipoService.Get(Id);

            return View(Tipo);
        }

        public IActionResult AddTipo()
        {
            var Tipo = new Tipo();

            return PartialView(Tipo);
        }

        public IActionResult Create()
        {
            TempData["Message"] = null;
            var Tipo = new Tipo();

            return View(Tipo);
        }

        [HttpPost]
        public IActionResult Save([Bind] Tipo tipo)
        {
            if (ModelState.IsValid)
            {
                var Codigo = tipo.Codigo;
                var result = _tipoService.Save(tipo);
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

            return RedirectToAction("Index", "Tipo");
        }

        [HttpPost]
        public ObjectResult Excluir(int Codigo)
        {
            var retorno = new MessageReturn();
            var result = _tipoService.Excluir(Codigo);

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