using Envision.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Envision.Data.Model
{
    public class Hardware
    {
        public int HardwareID { get; set; }

        public string HardwareName { get; set; }

        public string Notes { get; set; }

        public string Category { get; set; }

        public DateTime? DateDeleted { get; set; }

        // virtual lists
        public virtual List<FAQ> Faq { get; set; }

        public virtual List<Document> Document { get; set; }

        public virtual List<Solution_Hardware> Solution_Hardware { get; set; }
    }
}