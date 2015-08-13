using Envision.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Envision.Adapters.Interfaces
{
    public interface ITicketAdapter
    {
        List<AdminTicketVM> GetTickets();
        AdminTicketVM GetTicket(int id);
        void EditTicket(AdminTicketVM editedTicket, int id);

        void newTicket(AdminTicketVM newTicket, int id);

        void DeleteTicket(int id);
    }
}