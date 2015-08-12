using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Envision.Data.Model
{
    public class Solution_Hardware
    {
        public int ID { get; set; }

        public int SolutionID { get; set; }

        public virtual Solution Solution { get; set; }

        public int HardwareID { get; set; }

        public virtual Hardware Hardware { get; set; }

        public DateTime? DateDeleted { get; set; }
    }
}