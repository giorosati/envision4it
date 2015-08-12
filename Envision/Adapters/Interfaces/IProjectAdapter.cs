using Envision.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Envision.Adapters.Interfaces
{
    public interface IProjectAdapter
    {
        List<ProjectVM> getProjects();

        ProjectVM GetProject(int id);

        ProjectVM GetEditProject(int id);

        void EditProject(ProjectVM project, int id);

        ProjectVM AddProject(ProjectVM project);

        void DeleteProject(int id);
    }
}