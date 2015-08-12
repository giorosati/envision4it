using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Envision.Models
{
    public class AdminTicketNotesVM
    {
        public int TicketNoteID { get; set; }

        public int TicketID { get; set; }

        public DateTime DateEntered { get; set; }

        public DateTime? DateDeleted { get; set; }

        public string Note { get; set; }

        public string UserID { get; set; }
    }
}