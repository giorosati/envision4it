using Envision.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Envision.Models
{
    public class AdminVM
    {
        public int ProjectID { get; set; }

        public string UserID { get; set; }
        public virtual ApplicationUserVM User { get; set; }

        public string UserName { get; set; }

        public DateTime StartDate { get; set; }

        public string ProjectName { get; set; }

        public DateTime? TargetDate { get; set; }

        public DateTime? CompletionDate { get; set; }

        public DateTime? DateDeleted { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public string LocationNotes { get; set; }

        public List<AdminSolutionVM> Solutions { get; set; }
    }
}