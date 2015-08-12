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
    public class apiNewCustomerContactController : ApiController
    {
        private ICustomerContactAdapter _adapter;

        public apiNewCustomerContactController()
        {
            _adapter = new CustomerContactAdapter();
        }

        public apiNewCustomerContactController(ICustomerContactAdapter a)
        {
            _adapter = a;
        }

        public IHttpActionResult Post(AdminCustomerContactVM contact)
        {
            AdminCustomerContactVM newcontact = _adapter.NewCustomerContact(contact);
            return Ok(newcontact);
        }
    }
}