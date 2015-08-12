using Envision.Adapters.Adapters;
using Envision.Adapters.Interfaces;
using Envision.Data.Model;
using Envision.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace Envision.Controllers
{
    [Authorize(Roles = Roles.ADMIN)]
    public class apiDelSolController : ApiController
    {
        private ISolutionAdapter _adapter;

        public apiDelSolController()
        {
            _adapter = new SolutionAdapter();
        }

        public apiDelSolController(ISolutionAdapter a)
        {
            _adapter = a;
        }

        public IHttpActionResult Post(AdminSolutionVM solution, int id)
        {
            _adapter.DeleteSolution(id);
            return Ok();
        }
    }
}