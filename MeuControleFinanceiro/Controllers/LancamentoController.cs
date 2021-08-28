using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using MeuControleFinanceiro.Models;
using MeuControleFinanceiro.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Web;
using System.Web.Mvc;

namespace MeuControleFinanceiro.Controllers
{
    public class LancamentoController : Controller
    {
        ILancamentoRepository repository;

        public LancamentoController(ILancamentoRepository repository)
        {
            this.repository = repository;
        }


        public ActionResult Get(string tipolancto, DataSourceLoadOptions loadOptions)
        {
            var result = DataSourceLoader.Load(repository.GetAll().Where(a => a.TipoLancamento == tipolancto), loadOptions);

            var resultJson = Newtonsoft.Json.JsonConvert.SerializeObject(result);

            //return Json(resultJson);

            return Content(resultJson, "application/json");

        }

        public void Delete(FormDataCollection form)
        {
            var key = Convert.ToInt32(form.Get("key"));

            repository.Delete(key);

           // return new HttpStatusCodeResult(HttpStatusCode.OK);


        }

        public ActionResult AddLancamento(string tipoLancamento, string returnUrl)
        {
            TempData["ReturnUrl"] = returnUrl;

            return PartialView("AddLancamento", new LancamentoModel { TipoLancamento = tipoLancamento });
        }

        [HttpPost]
        public ActionResult AddLancamento(LancamentoModel model, string returnUrl)
        {
            repository.Insert(model);

            if (TempData["ReturnUrl"] != null)
                return Redirect(TempData["ReturnUrl"].ToString());


            return PartialView("AddLancamento", model);
        }
    }
}