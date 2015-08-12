using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Envision.Data.Model
{
    public class Roles
    {
        public const string CUSTOMER = "User";
        public const string TECH = "Tech";
        public const string ADMIN = "Admin";
        public const string ROOT = "Root";
        public virtual ApplicationUser User { get; set; }
        public int Id { get; set; }
    }
}