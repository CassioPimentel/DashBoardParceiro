using DashboardParceiro.Models;
using DashboardParceiro.Models.Cadastros;
using DashboardParceiro.Service.Cadastros.ParceiroFolder;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace DashboardParceiro.Controllers
{
    public class ParceiroController : Controller
    {
        private IParceiroService _parceiroService;

        public ParceiroController(IParceiroService parceiroService)
        {
            _parceiroService = parceiroService;
        }

        public IActionResult Index()
        {
            var Parceiro = _parceiroService.Get(3);
            ViewBag.Codigo = Parceiro.Id;
            return View(Parceiro);
        }

        [HttpPost]
        public IActionResult Save([Bind] ParceiroModel Parceiro)
        {
            if (ModelState.IsValid)
            {
                var Codigo = ViewBag.Codigo;
                var result = _parceiroService.Save(Parceiro);
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

            return RedirectToAction("Index", "Parceiro");
        }

    }
}