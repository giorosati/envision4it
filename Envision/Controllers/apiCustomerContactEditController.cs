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
    public class apiCustomerContactEditController : ApiController
    {
        private ICustomerContactAdapter _adapter;

        public apiCustomerContactEditController()
        {
            _adapter = new CustomerContactAdapter();
        }

        public apiCustomerContactEditController(ICustomerContactAdapter a)
        {
            _adapter = a;
        }

        public IHttpActionResult Get(int id)
        {
            AdminCustomerContactVM contact = _adapter.GetCustomerContact(id);
            return Ok(contact);
        }

        public IHttpActionResult Post(AdminCustomerContactVM contact, int id)
        {
            _adapter.EditCustomerContact(contact, id);
            return Ok();
        }
    }
}