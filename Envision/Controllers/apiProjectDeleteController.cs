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
    public class apiProjectDeleteController : ApiController
    {
        private IProjectAdapter _adapter;

        public apiProjectDeleteController()
        {
            _adapter = new ProjectAdapter();
        }

        public apiProjectDeleteController(IProjectAdapter a)
        {
            _adapter = a;
        }

        public IHttpActionResult Post(ProjectVM project, int id)
        {
            _adapter.DeleteProject(id);
            return Ok();
        }
    }
}