using Envision.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Envision.Models
{
    public class AdminSolutionNoteVM
    {
        public int SolutionNoteID { get; set; }

        public DateTime DateEntered { get; set; }

        public DateTime? DateDeleted { get; set; }

        public string Note { get; set; }

        public int SolutionID { get; set; }

        public string AdminID { get; set; }

        public string TechID { get; set; }
    }
}