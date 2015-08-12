using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Envision.Data.Model
{
    public class CustomerContact
    {
        public int CustomerContactID { get; set; }

        public string UserID { get; set; }

        public string Name { get; set; }

        public string Department { get; set; }

        public string Title { get; set; }

        public int MobileNumber { get; set; }

        public int WorkNumber { get; set; }

        public int FaxNumber { get; set; }

        public string Skype { get; set; }

        public string Email { get; set; }

        public DateTime? DateDeleted { get; set; }
    }
}