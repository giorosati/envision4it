using Envision.Data.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Envision.Data.Model
{
    public class Project
    {
        public int ProjectID { get; set; }

        public string UserID { get; set; }

        public virtual ApplicationUser User { get; set; }
        public DateTime StartDate { get; set; }

        public DateTime? DateDeleted { get; set; }

        public string ProjectName { get; set; }

        public DateTime? TargetDate { get; set; }

        public DateTime? CompletionDate { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public string LocationNotes { get; set; }

        //virtual lists
        public virtual List<Solution> Solutions { get; set; }

        public virtual List<ProjectNote> ProjectNotes { get; set; }
    }
}