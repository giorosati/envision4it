using Envision.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Envision.Models
{
    public class AdminFaqVM
    {
        public int FaqID { get; set; }

        public int HardwareID { get; set; }

        public virtual AdminHardwareVM Hardware { get; set; }

        public string Topic { get; set; }

        public string Question { get; set; }

        public string Answer { get; set; }

        public DateTime? DateDeleted { get; set; }
    }
}