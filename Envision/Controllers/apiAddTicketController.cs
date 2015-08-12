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
    public class apiAddTicketController : ApiController
    {
        private ITicketAdapter _adapter;

        public apiAddTicketController()
        {
            _adapter = new TicketAdapter();
        }

        public apiAddTicketController(ITicketAdapter a)
        {
            _adapter = a;
        }

        public IHttpActionResult Post(AdminTicketVM newTicket, int id)
        {
            _adapter.newTicket(newTicket, id);
            return Ok();
        }
    }
}