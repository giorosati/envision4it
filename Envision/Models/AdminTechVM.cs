using Envision.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Envision.Models
{
    public class AdminTechVM
    {
        public string Name { get; set; }

        public string Company { get; set; }

        public string Address1 { get; set; }

        public string Address2 { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public int Zip { get; set; }

        public int Phone { get; set; }

        public int Fax { get; set; }

        public virtual List<Solution> Soutions { get; set; }

        public virtual List<TicketNote> TicketNotes { get; set; }

        public virtual List<CustomerNote> CustomerNotes { get; set; }

        public virtual List<ProjectNote> ProjectNotes { get; set; }

        public virtual List<SolutionNote> SoultionNotes { get; set; }

        public virtual List<Project> Projects { get; set; }

        public virtual List<Ticket> Tickets { get; set; }

        public virtual List<CustomerContact> CustomerContacts { get; set; }
    }
}