using Envision.Data.Model;
using Envision.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Envision.Adapters.Interfaces
{
    public interface IHardwareAdapter
    {
        List<AdminHardwareVM> GetHardware();

        AdminHardwareVM GetHardware(int id);

        void EditHardware(AdminHardwareVM hardware, int id);

        AdminHardwareVM NewHardware(AdminHardwareVM hardware);

        void DeleteHardware(int id);
    }
}