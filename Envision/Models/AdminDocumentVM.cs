using Envision.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Envision.Models
{
    public class AdminDocumentVM
    {
        public int DocumentID { get; set; }

        public int HardwareID { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Filepath { get; set; }

        public string Url { get; set; }

        public DateTime? DateDeleted { get; set; }
    }
}