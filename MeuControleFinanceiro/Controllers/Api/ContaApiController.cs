using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MeuControleFinanceiro.Controllers.Api
{
    public class ContaApiController : ApiController
    {
        Repository.ContaRepositoty repositoty = new Repository.ContaRepositoty();

        [HttpGet]
        public HttpResponseMessage Get(DataSourceLoadOptions loadOptions)
        {
            return Request.CreateResponse(DataSourceLoader.Load(repositoty.GetContas(), loadOptions));
        }
    }
}