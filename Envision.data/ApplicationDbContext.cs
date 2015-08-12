using Envision.Data.Model;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Envision.data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<CustomerNote> CustomerNotes { get; set; }

        public DbSet<ProjectNote> ProjectNotes { get; set; }

        public DbSet<TicketNote> TicketNotes { get; set; }

        public DbSet<SolutionNote> SolutionNotes { get; set; }

        public DbSet<Project> Projects { get; set; }

        public DbSet<Solution> Solutions { get; set; }

        public DbSet<Hardware> Hardware { get; set; }

        public DbSet<FAQ> FAQS { get; set; }

        public DbSet<Document> Documents { get; set; }

        public DbSet<Ticket> Tickets { get; set; }

        public DbSet<CustomerContact> CustomerContacts { get; set; }

        public DbSet<Solution_Hardware> Solution_Hardware { get; set; }

        //  public DbSet<ApplicationUser> ApplicationUsers { get; set; }

        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}