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
    public class apiAdminController : ApiController
    {
        private IAdminAdapter _adapter;

        public apiAdminController()
        {
            _adapter = new AdminAdapter();
        }

        public apiAdminController(IAdminAdapter a)
        {
            _adapter = a;
        }

        public IHttpActionResult Get()
        {
            List<AdminVM> admin = _adapter.GetAdminControl();
            return Ok(admin);
        }

        public IHttpActionResult Get(int id)
        {
            string userId = User.Identity.GetUserId();
            ProjectVM project = _adapter.GetProject(id);
            return Ok(project);
        }

        public IHttpActionResult Post(int id)
        {
            _adapter.DeleteProject(id);
            return Ok();
        }
    }
}