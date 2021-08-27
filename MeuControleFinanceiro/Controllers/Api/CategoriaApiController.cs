using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using MeuControleFinanceiro.DB;
using MeuControleFinanceiro.Models;
using MeuControleFinanceiro.Repository;
using SimpleInjector;
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
        //  private readonly IDBContext db;
        private readonly ICategoriaRepository repository;

        public CategoriaApiController(ICategoriaRepository repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        public HttpResponseMessage Get(DataSourceLoadOptions loadOptions)
        {
            return Request.CreateResponse(DataSourceLoader.Load(repository.GetCategoria(), loadOptions));
        }

        [HttpPost]
        public void Post(FormDataCollection form)
        {
            try
            {
                var values = form.Get("values");

                var cat = Newtonsoft.Json.JsonConvert.DeserializeObject<CategoriaModel>(values);
                var id = repository.GetCategoria().Count() + 1;
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