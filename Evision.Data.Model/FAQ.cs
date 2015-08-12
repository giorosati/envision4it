using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Envision.Data.Model
{
    public class FAQ
    {
        public int FaqID { get; set; }

        public int HardwareID { get; set; }

        public virtual Hardware Hardware { get; set; }

        public string Topic { get; set; }

        public string Question { get; set; }

        public string Answer { get; set; }

        public DateTime? DateDeleted { get; set; }
    }
}