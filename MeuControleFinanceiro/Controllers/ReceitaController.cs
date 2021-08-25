using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MeuControleFinanceiro.Controllers
{
    public class ReceitaController : Controller
    {
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
    }
}