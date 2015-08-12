using Envision.Data.Model;
using Envision.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Envision.Adapters.Interfaces
{
    public interface ICustomerContactAdapter
    {
        List<AdminCustomerContactVM> GetCustomerContacts();

        AdminCustomerContactVM GetCustomerContact(int id);

        void EditCustomerContact(AdminCustomerContactVM contact, int id);

        AdminCustomerContactVM NewCustomerContact(AdminCustomerContactVM contact);

        void DeleteCustomerContact(int id);
    }
}