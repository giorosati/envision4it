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
    public class apiAdminHardwareController : ApiController
    {
        private IHardwareAdapter _adapter;

        public apiAdminHardwareController()
        {
            _adapter = new HardwareAdapter();
        }

        public apiAdminHardwareController(IHardwareAdapter a)
        {
            _adapter = a;
        }

        //Get all of the Hardware
        public IHttpActionResult Get()
        {
            List<AdminHardwareVM> model = _adapter.GetHardware();
            return Ok(model);
        }
    }
}