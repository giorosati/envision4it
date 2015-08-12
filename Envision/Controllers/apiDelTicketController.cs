using Envision.Adapters.Adapters;
using Envision.Adapters.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Envision.Controllers
{
    public class apiDelTicketController : ApiController
    {
        private ITicketAdapter _adapter;

        public apiDelTicketController()
        {
            _adapter = new TicketAdapter();
        }

        public apiDelTicketController(ITicketAdapter a)
        {
            _adapter = a;
        }

        public IHttpActionResult Post(int id)
        {
            _adapter.DeleteTicket(id);
            return Ok();
        }
    }
}