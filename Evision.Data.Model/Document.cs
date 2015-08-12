using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Envision.Data.Model
{
    public class Document
    {
        public int DocumentID { get; set; }

        public int HardwareID { get; set; }

        public virtual Hardware Hardware { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Filepath { get; set; }

        public string Url { get; set; }

        public DateTime? DateDeleted { get; set; }
    }
}