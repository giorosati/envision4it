using Envision.Data.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Envision.Models
{
    public class ProjectVM
    {
        public int ProjectID { get; set; }
        public string ProjectName { get; set; }
        public string UserID { get; set; }
        public virtual ApplicationUserVM User { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? TargetDate { get; set; }
        public DateTime? CompletionDate { get; set; }
        public DateTime? DateDelted { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public string LocationNotes { get; set; }

        //virtual lists
        public List<AdminSolutionVM> Solutions { get; set; }
    }
}