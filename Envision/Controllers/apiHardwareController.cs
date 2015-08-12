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
    public class apiHardwareController : ApiController
    {
        private ISolutionAdapter _adapter;

        public apiHardwareController()
        {
            _adapter = new SolutionAdapter();
        }

        public apiHardwareController(ISolutionAdapter a)
        {
            _adapter = a;
        }

        //Get all of the Hardware
        public IHttpActionResult Get()
        {
            List<AdminHardwareVM> model = _adapter.GetHardware();
            return Ok(model);
        }

        //adds a hardware to a solution
        public IHttpActionResult Post(HardwareSolutionVM ids)
        {
            _adapter.AddHardwareSolu(ids);
            return Ok();
        }
    }
}