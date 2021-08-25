using MeuControleFinanceiro.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MeuControleFinanceiro.Controllers
{
    public class CategoriaController : Controller
    {
        // GET: Categoria
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AddOrUpdate()
        {
            return View(new CategoriaModel());
        }

        [HttpPost]
        public ActionResult AddOrUpdate(CategoriaModel model)
        {
            return View();
        }
    }
}