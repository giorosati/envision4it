using Envision.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Envision.Adapters.Interfaces
{
    public interface ICustomerNoteAdapter
    {
        List<CustomerNoteVM> GetCustomerNotes(string id);

        CustomerNoteVM GetCustomerNote(int id);

        CustomerNoteVM GetEditCustomerNote(int id);

        void EditCustomerNote(CustomerNoteVM customerNote, int id);

        void DeleteCustomerNote(int id);

        CustomerNoteVM AddCustomerNote(string id, CustomerNoteVM customerNote);
    }
}