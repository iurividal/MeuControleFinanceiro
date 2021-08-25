using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using MeuControleFinanceiro.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Web.Http;

namespace MeuControleFinanceiro.Controllers.Api
{
    public class CategoriaApiController : ApiController
    {
        Repository.CategoriaRepository repository = new Repository.CategoriaRepository();


        [HttpGet]
        public HttpResponseMessage Get(DataSourceLoadOptions loadOptions)
        {
            return Request.CreateResponse(DataSourceLoader.Load(Repository.CategoriaRepository.GetCategoria, loadOptions));
        }

        [HttpPost]
        public void Post(FormDataCollection form)
        {
            try
            {
                var values = form.Get("values");

                var cat = Newtonsoft.Json.JsonConvert.DeserializeObject<CategoriaModel>(values);
                var id = Repository.CategoriaRepository.GetCategoria.Count() + 1;
                cat._id = id;
                repository.AddCategoria(cat);
            }
            catch (Exception)
            {

                throw;
            }



        }
    }
}