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
    public class apiProjectDetailsController : ApiController
    {
        private IProjectAdapter _adapter;

        public apiProjectDetailsController()
        {
            _adapter = new ProjectAdapter();
        }

        public apiProjectDetailsController(IProjectAdapter a)
        {
            _adapter = a;
        }

        public IHttpActionResult Get()
        {
            List<ProjectVM> projects = _adapter.getProjects();
            return Ok(projects);
        }

        public IHttpActionResult Get(int id)
        {
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