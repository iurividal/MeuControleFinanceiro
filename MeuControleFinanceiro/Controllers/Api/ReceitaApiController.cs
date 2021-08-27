using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using MeuControleFinanceiro.Repository.Servicos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MeuControleFinanceiro.Controllers.Api
{
    public class ReceitaApiController : ApiController
    {
        private readonly IReceitaRepository repository;

        public ReceitaApiController(IReceitaRepository repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        public HttpResponseMessage Get(DataSourceLoadOptions loadOptions)
        {
            return Request.CreateResponse(DataSourceLoader.Load(repository.GetReceitas(), loadOptions));
        }

    }
}