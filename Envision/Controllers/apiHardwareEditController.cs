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
    public class apiHardwareEditController : ApiController
    {
        private ISolutionAdapter _adapter;

        public apiHardwareEditController()
        {
            _adapter = new SolutionAdapter();
        }

        public apiHardwareEditController(ISolutionAdapter a)
        {
            _adapter = a;
        }

        //Gets the specific Hardware To edit
        public IHttpActionResult Get(int id)
        {
            AdminHardwareVM model = _adapter.GetEditHardware(id);
            return Ok(model);
        }

        public IHttpActionResult Post(AdminHardwareVM editedHardware, int id)
        {
            _adapter.EditHardware(editedHardware, id);
            return Ok();
        }
    }
}