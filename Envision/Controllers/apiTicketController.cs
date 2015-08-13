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
    public class apiTicketController : ApiController
    {
        private ITicketAdapter _adapter;

        public apiTicketController()
        {
            _adapter = new TicketAdapter();
        }

        public apiTicketController(ITicketAdapter a)
        {
            _adapter = a;
        }


        public IHttpActionResult Get(int id)
        {
            AdminTicketVM model = _adapter.GetTicket(id);
            return Ok(model);
        }

        //get all tickets
        public IHttpActionResult Get()
        {
            List<AdminTicketVM> model = _adapter.GetTickets();
            return Ok(model);
        }

        public IHttpActionResult Post(AdminTicketVM editedTicket, int id)
        {
            _adapter.EditTicket(editedTicket, id);
            return Ok();
        }
    }
}