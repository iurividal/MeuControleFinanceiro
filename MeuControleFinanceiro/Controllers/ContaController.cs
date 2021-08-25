using MeuControleFinanceiro.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MeuControleFinanceiro.Controllers
{
    public class ContaController : Controller
    {

        Repository.ContaRepositoty contaRepositoty = new Repository.ContaRepositoty();

        // GET: Conta
        public ActionResult Index()
        {
            var contas = contaRepositoty.GetContas().ToList();

            return View(contas);
        }

        public ActionResult AddConta()
        {
            return View(new ContaModel());
        }

        [HttpPost]
        public ActionResult AddConta(ContaModel model)
        {

            contaRepositoty.AddConta(model);

            ViewBag.Mensagem = "Conta cadastrada com sucesso";

            return View(new ContaModel());
        }

    }
}