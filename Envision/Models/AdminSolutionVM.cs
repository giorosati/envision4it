using Envision.Data.Model;
using Envision.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Envision.Models
{
    public class AdminSolutionVM
    {
        public int SolutionID { get; set; }

        public string SolutionName { get; set; }

        public int ProjectID { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime? TargetCompletionDate { get; set; }

        public DateTime? DateDeleted { get; set; }

        public string Urgency { get; set; }

        //added these while working on the SolutionAdapter
        public List<AdminSolutionNoteVM> SolutionNotes { get; set; }

        public List<AdminTicketVM> TicketIDVM { get; set; }

        public List<AdminHardwareVM> AdminHardwareVM { get; set; }
    }
}