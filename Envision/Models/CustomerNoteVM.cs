using System;

namespace Envision.Models
{
    public class CustomerNoteVM
    {
        public int CustomerNoteID { get; set; }

        public DateTime? DateEntered { get; set; }

        public DateTime? DateDeleted { get; set; }

        public string Note { get; set; }

        public string UserID { get; set; }
    }
}