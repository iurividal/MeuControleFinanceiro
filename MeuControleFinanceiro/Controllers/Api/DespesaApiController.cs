﻿using DevExtreme.AspNet.Data;
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
    public class DespesaApiController : ApiController
    {
        private readonly IDespesaRepository repository;

        public DespesaApiController(IDespesaRepository repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        public HttpResponseMessage Get(DataSourceLoadOptions loadOptions)
        {
            return Request.CreateResponse(DataSourceLoader.Load(repository.Get(), loadOptions));
        }
    }
}