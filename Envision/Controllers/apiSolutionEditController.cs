using Envision.Adapters.Adapters;
using Envision.Adapters.Interfaces;
using Envision.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Envision.Controllers
{
    public class apiSolutionEditController : ApiController
    {
        private ISolutionAdapter _adapter;

        public apiSolutionEditController()
        {
            _adapter = new SolutionAdapter();
        }

        public apiSolutionEditController(ISolutionAdapter a)
        {
            _adapter = a;
        }

        public IHttpActionResult Get(int id)
        {
            AdminSolutionVM solution = _adapter.GetEditSolution(id);
            return Ok(solution);
        }

        public IHttpActionResult Post(AdminSolutionVM solution, int id)
        {
            _adapter.EditSolution(solution, id);
            return Ok();
        }
    }
}