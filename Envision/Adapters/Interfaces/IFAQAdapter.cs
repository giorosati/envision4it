using Envision.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Envision.Adapters.Interfaces
{
    public interface IFAQAdapter
    {
        List<AdminFaqVM> GetFAQs();

        AdminFaqVM GetFAQ(int id);

        void EditFAQ(AdminFaqVM editedFAQ, int id);

        void newFAQ(AdminFaqVM newFAQ, int id);

        void DeleteFAQ(int id);
    }
}