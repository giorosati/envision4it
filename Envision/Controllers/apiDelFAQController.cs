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
    public class apiDelFAQController : ApiController
    {
        private ISolutionAdapter _adapter;

        public apiDelFAQController()
        {
            _adapter = new SolutionAdapter();
        }

        public apiDelFAQController(ISolutionAdapter a)
        {
            _adapter = a;
        }

        public IHttpActionResult Post(AdminFaqVM solution, int id)
        {
            _adapter.DeleteFAQ(id);
            return Ok();
        }
    }
}