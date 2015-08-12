using Envision.Data.Model;
using Envision.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace Envision.Adapters.Interfaces
{
    public interface IUserDetailsAdapter
    {
        List<ApplicationUserVM> GetUsers();

        // ApplicationUserVM GetUser(int id);

        //void EditUser(ApplicationUserVM user, int id);

        //ApplicationUserVM NewUser(ApplicationUserVM user);

        //void DeleteUser(int id);
    }
}