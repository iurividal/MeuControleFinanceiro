using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MeuControleFinanceiro.Controllers {
    public class HomeController : Controller {
        public ActionResult Index() {


            //Repository.CategoriaRepository.AddCategoria(new Models.CategoriaModel(1, "Outros"));
            
            return View();
        }
    }
}