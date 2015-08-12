using Envision.Adapters.Adapters;
using Envision.Adapters.Interfaces;
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
    public class apiSolutionController : ApiController
    {
        private ISolutionAdapter _adapter;

        public apiSolutionController()
        {
            _adapter = new SolutionAdapter();
        }

        public apiSolutionController(ISolutionAdapter a)
        {
            _adapter = a;
        }

        public IHttpActionResult Get()
        {
            string userId = User.Identity.GetUserId();
            List<AdminSolutionVM> solutions = _adapter.GetSolutions();
            return Ok(solutions);
        }

        public IHttpActionResult Get(int id)
        {
            string userId = User.Identity.GetUserId();
            AdminSolutionVM solution = _adapter.GetSolution(id);
            return Ok(solution);
        }

        public IHttpActionResult Post(int id, AdminSolutionVM solution)
        {
            AdminSolutionVM model = _adapter.AddSolution(id, solution);
            return Ok(model);
        }
    }
}