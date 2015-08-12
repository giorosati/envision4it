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
    public class apiHardwareDeleteController : ApiController
    {
        private ISolutionAdapter _adapter;

        public apiHardwareDeleteController()
        {
            _adapter = new SolutionAdapter();
        }

        public apiHardwareDeleteController(ISolutionAdapter a)
        {
            _adapter = a;
        }

        //Deletes a hardware from a solution
        public IHttpActionResult Post(HardwareSolutionVM ids)
        {
            //_adapter.DeleteHardware(ids);
            return Ok();
        }
    }
}