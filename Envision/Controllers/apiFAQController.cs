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
    public class apiFAQController : ApiController
    {
        private IFAQAdapter _adapter;

        public apiFAQController()
        {
            _adapter = new FAQAdapter();
        }

        public apiFAQController(IFAQAdapter a)
        {
            _adapter = a;
        }

        public IHttpActionResult Get(int id)
        {
            AdminFaqVM model = _adapter.GetFAQ(id);
            return Ok(model);
        }

        //get all tickets
        public IHttpActionResult Get()
        {
            List<AdminFaqVM> model = _adapter.GetFAQs();
            return Ok(model);
        }

        public IHttpActionResult Post(AdminFaqVM editedFAQ, int id)
        {
            _adapter.EditFAQ(editedFAQ, id);
            return Ok();
        }
    }
}