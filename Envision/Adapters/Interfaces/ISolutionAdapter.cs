using Envision.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Envision.Adapters.Interfaces
{
    public interface ISolutionAdapter
    {
        List<AdminSolutionVM> GetSolutions();

        AdminSolutionVM GetSolution(int id);

        AdminSolutionVM GetEditSolution(int id);

        void EditSolution(AdminSolutionVM solution, int id);

        AdminSolutionVM AddSolution(AdminSolutionVM solution, int id);

        void DeleteSolution(int id);

        AdminHardwareVM AddHardware(AdminHardwareVM hw);

        void DeleteHardware(int id);

        void DeleteFAQ(int id);

        AdminHardwareVM GetEditHardware(int id);

        AdminFaqVM GetEditFaq(int id);

        void EditHardware(AdminHardwareVM hardware, int id);

        void EditFAQ(AdminFaqVM faq, int id);

        AdminSolutionVM AddSolution(int id, AdminSolutionVM solution);

        List<AdminHardwareVM> GetHardware();

        void AddHardwareSolu(HardwareSolutionVM ids);
    }
}