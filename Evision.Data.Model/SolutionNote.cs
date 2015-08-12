using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Envision.Data.Model
{
    public class SolutionNote
    {
        public int SolutionNoteID { get; set; }

        public int SolutionID { get; set; }

        public string Note { get; set; }

        public DateTime DateEntered { get; set; }

        public DateTime? DateDeleted { get; set; }

        [InverseProperty("UserID")]
        public string AdminID { get; set; }

        [InverseProperty("UserID")]
        public string TechID { get; set; }
    }
}