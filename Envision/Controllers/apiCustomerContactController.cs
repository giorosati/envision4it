using Envision.Adapters.Adapters;
using Envision.Adapters.Interfaces;
using Envision.data;
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
    public class apiCustomerContactController : ApiController
    {
        private ICustomerContactAdapter _adapter;

        public apiCustomerContactController()
        {
            _adapter = new CustomerContactAdapter();
        }

        public apiCustomerContactController(ICustomerContactAdapter a)
        {
            _adapter = a;
        }

        public IHttpActionResult Get(int id)
        {
            AdminCustomerContactVM contact = _adapter.GetCustomerContact(id);
            return Ok(contact);
        }

        public IHttpActionResult Get()
        {
            string userId = User.Identity.GetUserId();
            List<AdminCustomerContactVM> contacts = _adapter.GetCustomerContacts();
            return Ok(contacts);
        }

        public IHttpActionResult Post(AdminCustomerContactVM contact, int id)
        {
            _adapter.EditCustomerContact(contact, id);
            return Ok();
        }
    }
}