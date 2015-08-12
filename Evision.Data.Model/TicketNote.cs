using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Envision.Data.Model
{
    public class TicketNote
    {
        public int TicketNoteID { get; set; }

        public int TicketID { get; set; }

        public DateTime DateEntered { get; set; }

        public DateTime? DateDeleted { get; set; }

        public string Note { get; set; }

        public string UserID { get; set; }
    }
}