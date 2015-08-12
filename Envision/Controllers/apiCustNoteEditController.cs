using Envision.Adapters.Adapters;
using Envision.Adapters.Interfaces;
using Envision.Models;
using System.Web.Http;

namespace Envision.Controllers
{
    public class apiCustomerNoteEditController : ApiController
    {
        private ICustomerNoteAdapter _adapter;

        public apiCustomerNoteEditController()
        {
            _adapter = new CustomerNoteAdapter();
        }

        public apiCustomerNoteEditController
            (ICustomerNoteAdapter a)
        {
            _adapter = a;
        }

        public IHttpActionResult Get(int id)
        {
            CustomerNoteVM customerNote = _adapter.GetCustomerNote(id);
            return Ok(customerNote);
        }

        public IHttpActionResult Post(CustomerNoteVM customerNote, int id)
        {
            _adapter.EditCustomerNote(customerNote, id);
            return Ok();
        }
    }
}