using DashboardParceiro.Models;
using DashboardParceiro.Models.Cadastros;
using DashboardParceiro.Service.Cadastros.ObservacaoFolder;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace DashboardParceiro.Controllers
{
    public class ObservacaoController : Controller
    {
        private IObservacaoService _observacaoService;

        public ObservacaoController(IObservacaoService observacaoService)
        {
            _observacaoService = observacaoService;
        }

        public IActionResult Index()
        {
            var Observacao = _observacaoService.GetAll();

            return View(Observacao);
        }

        public IActionResult Editar(int Id)
        {
            TempData["Message"] = null;
            var Observacao = _observacaoService.Get(Id);

            return View(Observacao);
        }

        public IActionResult AddObservacao()
        {
            var Observacao = new Observacao();

            return PartialView(Observacao);
        }

        public IActionResult Create()
        {
            TempData["Message"] = null;
            var Observacao = new Observacao();

            return View(Observacao);
        }

        [HttpPost]
        public IActionResult Save([Bind] Observacao observacao)
        {
            if (ModelState.IsValid)
            {
                var Codigo = observacao.Codigo;
                var result = _observacaoService.Save(observacao);
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

            return RedirectToAction("Index", "Observacao");
        }

        [HttpPost]
        public ObjectResult Excluir(int Codigo)
        {
            var retorno = new MessageReturn();
            var result = _observacaoService.Excluir(Codigo);

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