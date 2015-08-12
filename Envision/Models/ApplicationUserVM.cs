using Envision.Data.Model;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Envision.Models
{
    public class ApplicationUserVM
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

        public string Email { get; set; }

        public string UserName { get; set; }

        public string Id { get; set; }

        //vlists

        public List<AdminSolutionVM> Soutions { get; set; }

        public List<AdminTicketVM> Tickets { get; set; }

        public List<AdminSolutionNoteVM> SoultionNotes { get; set; }

        public List<AdminTicketNotesVM> TicketNotes { get; set; }

        public List<CustomerNoteVM> CustomerNotes { get; set; }

        public List<AdminCustomerContactVM> CustomerContacts { get; set; }

        //public List<Project> Projects { get; set; }
        //public List<ProjectNoteVM> ProjectNotes { get; set; }
    }
}