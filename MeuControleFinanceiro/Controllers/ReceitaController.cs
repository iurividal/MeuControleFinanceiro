using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using MeuControleFinanceiro.Models;
using MeuControleFinanceiro.Repository;
using MeuControleFinanceiro.Repository.Servicos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MeuControleFinanceiro.Controllers
{
    public class ReceitaController : Controller
    {
        ILancamentoRepository repository;


        public ReceitaController(ILancamentoRepository repository)
        {
            this.repository = repository;
        }

        // GET: Receita
        public ActionResult Index()
        {
            return View("MinhaReceita");
        }

        public ActionResult MinhaReceita()
        {
            var lancamentos = repository.GetReceita();
            return View(lancamentos);
        }

        [HttpPost]
        public ActionResult AddReceita(ReceitaModel model)
        {
            model.TipoLancamento = "RECEITA";

            repository.Insert(model);

            return View(new Models.ReceitaModel());
        }


        public ActionResult GetReceita(DataSourceLoadOptions loadOptions)
        {
            var result = DataSourceLoader.Load(repository.GetReceita(), loadOptions);

            var resultJson = Newtonsoft.Json.JsonConvert.SerializeObject(result);

            //return Json(resultJson);

            return Content(resultJson, "application/json");

        }
    }
}