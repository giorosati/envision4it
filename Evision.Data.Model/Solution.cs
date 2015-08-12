using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Envision.Data.Model
{
    public class Solution
    {
        public int SolutionID { get; set; }

        public string SolutionName { get; set; }

        public int ProjectID { get; set; }

        public virtual Project Project { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime? TargetCompletionDate { get; set; }

        public DateTime? DateDeleted { get; set; }

        public string Urgency { get; set; }

        // virtual lists
        public virtual List<Ticket> Tickets { get; set; }

        public virtual List<Solution_Hardware> Solution_Hardware { get; set; }

        public virtual List<SolutionNote> SolutionNotes { get; set; }
    }
}