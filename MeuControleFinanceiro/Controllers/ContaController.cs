using MeuControleFinanceiro.Models;
using MeuControleFinanceiro.Repository.Servicos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MeuControleFinanceiro.Controllers
{
    public class ContaController : Controller
    {

        IContaRepository repository;

        public ContaController(IContaRepository repository)
        {
            this.repository = repository;
        }

        // GET: Conta
        public ActionResult Index()
        {
            var contas = repository.GetContaDetalhe().ToList();

            ViewBag.SaldoTotal = (contas.Sum(a => a.ValorInicial) + (contas.Sum(a => a.TotalReceita) - contas.Sum(a => a.TotalDespesa))).GetValueOrDefault().ToString("c2");

            return View(contas);
        }

        public ActionResult AddConta()
        {
            return View(new ContaModel());
        }

        [HttpPost]
        public ActionResult AddConta(ContaModel model)
        {

            repository.AddConta(model);

            ViewBag.Mensagem = "Conta cadastrada com sucesso";

            return View(new ContaModel());
        }

    }
}