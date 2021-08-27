using MeuControleFinanceiro.Models;
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
        IReceitaRepository repository;


        public ReceitaController(IReceitaRepository repository)
        {
            this.repository = repository;
        }

        // GET: Receita
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult MinhaReceita()
        {
            return View();
        }

        public ActionResult AddReceita()
        {
            return View(new Models.ReceitaModel());
        }

        [HttpPost]
        public ActionResult AddReceita(ReceitaModel model)
        {

            repository.AddReceita(model);

            return View(new Models.ReceitaModel());
        }
    }
}