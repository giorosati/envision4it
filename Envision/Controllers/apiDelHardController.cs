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
    public class apiDelHardController : ApiController
    {
        private ISolutionAdapter _adapter;

        public apiDelHardController()
        {
            _adapter = new SolutionAdapter();
        }

        public apiDelHardController(ISolutionAdapter a)
        {
            _adapter = a;
        }

        public IHttpActionResult Post(AdminHardwareVM solution, int id)
        {
            _adapter.DeleteHardware(id);
            return Ok();
        }
    }
}