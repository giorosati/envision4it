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
    public class apiProjectEditController : ApiController
    {
        private IAdminAdapter _adapter;

        public apiProjectEditController()
        {
            _adapter = new AdminAdapter();
        }

        public apiProjectEditController(IAdminAdapter a)
        {
            _adapter = a;
        }

        //gets the id for the project edit to pre pop
        public IHttpActionResult Get(int id)
        {
            ProjectVM project = _adapter.GetProject(id);
            return Ok(project);
        }

        // project editing
        public IHttpActionResult Post(ProjectVM project, int id)
        {
            _adapter.EditProject(project, id);
            return Ok();
        }
    }
}