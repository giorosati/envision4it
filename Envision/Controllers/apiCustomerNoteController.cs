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
    public class apiCustomerNoteController : ApiController
    {
        private ICustomerNoteAdapter _adapter;

        public apiCustomerNoteController()
        {
            _adapter = new CustomerNoteAdapter();
        }

        public apiCustomerNoteController(ICustomerNoteAdapter a)
        {
            _adapter = a;
        }

        public IHttpActionResult Get(int id)
        {
            CustomerNoteVM note = _adapter.GetCustomerNote(id);
            return Ok(note);
        }

        //public IHttpActionResult Get(string id)
        //{
        //    string userId = User.Identity.GetUserId();
        //    List<CustomerNoteVM> notes = _adapter.GetCustomerNotes();
        //    return Ok(notes);
        //}

        public IHttpActionResult Post(CustomerNoteVM note, int id)
        {
            _adapter.EditCustomerNote(note, id);
            return Ok();
        }
    }
}