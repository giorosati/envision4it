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
    public class apiNewProjectController : ApiController
    {
        private IAdminAdapter _adapter;

        public apiNewProjectController()
        {
            _adapter = new AdminAdapter();
        }

        public apiNewProjectController(IAdminAdapter a)
        {
            _adapter = a;
        }

        public IHttpActionResult Post(AdminVM project)
        {
            AdminVM newproject = _adapter.NewProject(project);
            return Ok(newproject);
        }
    }
}