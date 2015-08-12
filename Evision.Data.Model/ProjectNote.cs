using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Envision.Data.Model
{
    public class ProjectNote
    {
        public int ProjectNoteID { get; set; }

        public int ProjectID { get; set; }

        public string Note { get; set; }

        public string UserID { get; set; }

        public DateTime DateEntered { get; set; }

        public DateTime? DateDeleted { get; set; }
    }
}