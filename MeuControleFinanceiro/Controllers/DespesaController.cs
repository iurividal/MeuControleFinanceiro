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
    public class DespesaController : Controller
    {
        ILancamentoRepository repository;

        public DespesaController(ILancamentoRepository repository)
        {
            this.repository = repository;
        }

        // GET: Despesa
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetDespesa(DataSourceLoadOptions loadOptions)
        {

            var result = DataSourceLoader.Load(repository.GetDesepesa(), loadOptions);

            var resultJson = Newtonsoft.Json.JsonConvert.SerializeObject(result);

            //return Json(resultJson);

            return Content(resultJson, "application/json");
        }


        
    }
}