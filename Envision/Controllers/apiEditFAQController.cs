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
    public class apiEditFAQController : ApiController
    {
        private ISolutionAdapter _adapter;

        public apiEditFAQController()
        {
            _adapter = new SolutionAdapter();
        }

        public apiEditFAQController(ISolutionAdapter a)
        {
            _adapter = a;
        }

        public IHttpActionResult Get(int id)
        {
            AdminFaqVM faq = _adapter.GetEditFaq(id);
            return Ok(faq);
        }

        public IHttpActionResult Post(AdminFaqVM faq, int id)
        {
            _adapter.EditFAQ(faq, id);
            return Ok(faq);
        }
    }
}