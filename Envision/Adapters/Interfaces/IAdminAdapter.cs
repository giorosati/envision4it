using Envision.Data.Model;
using Envision.Models;
using System.Collections.Generic;

namespace Envision.Adapters.Interfaces
{
    public interface IAdminAdapter
    {
        List<AdminVM> GetAdminControl();

        ProjectVM GetProject(int id);

        void EditProject(ProjectVM project, int id);

        AdminVM NewProject(AdminVM project);

        void DeleteProject(int id);

        AdminVM GetProject(string userId);
    }
}