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
    public class apiCustNoteNewController : ApiController
    {
        private ICustomerNoteAdapter _adapter;

        public apiCustNoteNewController()
        {
            _adapter = new CustomerNoteAdapter();
        }

        public apiCustNoteNewController(ICustomerNoteAdapter a)
        {
            _adapter = a;
        }

        public IHttpActionResult Post(string id, CustomerNoteVM customerNote)
        {
            CustomerNoteVM model = _adapter.AddCustomerNote(id, customerNote);
            return Ok(model);
        }
    }
}