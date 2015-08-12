using Envision.Data.Model;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Envision.Data.Model
{
    public class ApplicationUser : IdentityUser
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

        //public string Role { get; set; }

        //virtual lists
        public virtual List<Project> Projects { get; set; }

        //public virtual List<Solution> Soutions { get; set; }

        public virtual List<Ticket> Tickets { get; set; }

        public virtual List<ProjectNote> ProjectNotes { get; set; }

        public virtual List<SolutionNote> SoultionNotes { get; set; }

        public virtual List<TicketNote> TicketNotes { get; set; }

        public virtual List<CustomerNote> CustomerNotes { get; set; }

        public virtual List<CustomerContact> CustomerContacts { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager, string authenticationType)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, authenticationType);
            // Add custom user claims here
            return userIdentity;
        }
    }
}