using Envision.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Envision.Models
{
    public class AdminHardwareVM
    {
        public int HardwareID { get; set; }

        public string HardwareName { get; set; }

        public string Notes { get; set; }

        public string Category { get; set; }

        public DateTime? DateDeleted { get; set; }

        // virtual lists

        public virtual List<AdminFaqVM> Faq { get; set; }

        public virtual List<AdminDocumentVM> Document { get; set; }
    }
}