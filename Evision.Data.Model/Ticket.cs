using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Envision.Data.Model
{
    public class Ticket
    {
        public int TicketID { get; set; }
        public string Description { get; set; }

        public int SolutionID { get; set; }

        public virtual Solution Solution { get; set; }

        public string UserID { get; set; }

        public ApplicationUser User { get; set; }

        public DateTime DateOpened { get; set; }

        public DateTime? DateClosed { get; set; }

        public DateTime? DateDeleted { get; set; }

        public string Status { get; set; }

        public string Urgency { get; set; }

        public string TicketType { get; set; }

        //virtual lists
        public virtual List<TicketNote> TicketNotes { get; set; }
    }
}