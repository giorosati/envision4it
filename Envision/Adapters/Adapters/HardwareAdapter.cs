using Envision.Adapters.Interfaces;
using Envision.data;
using Envision.Data.Model;
using Envision.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Envision.Adapters.Adapters
{
    public class HardwareAdapter : IHardwareAdapter
    {
        public List<AdminHardwareVM> GetHardware()
        {
            List<AdminHardwareVM> model;
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                model = db.Hardware.Where(x => x.DateDeleted == null).OrderBy(x => x.HardwareName).Select(x => new AdminHardwareVM()
                {
                    HardwareID = x.HardwareID,
                    HardwareName = x.HardwareName,
                    Notes = x.Notes,
                    Category = x.Category,
                    DateDeleted = x.DateDeleted,
                    //add list of FAQ's here
                    Faq = x.Faq.Select(f => new AdminFaqVM()
                    {
                        FaqID = f.FaqID,
                        HardwareID = f.HardwareID,
                        Topic = f.Topic,
                        Question = f.Question,
                        Answer = f.Answer
                    }).ToList(),
                    Document = x.Document.Select(d => new AdminDocumentVM()
                    {
                        DocumentID = d.DocumentID,
                        Name = d.Name,
                        Description = d.Description
                    }).ToList(),
                }).ToList();
            }
            return model;
        }

        public AdminHardwareVM GetHardware(int id)
        {
            AdminHardwareVM model;
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                model = db.Hardware.Where(x => x.HardwareID == id).Select(x => new AdminHardwareVM()
                {
                    HardwareID = x.HardwareID,
                    HardwareName = x.HardwareName,
                    Notes = x.Notes,
                    Category = x.Category,
                    DateDeleted = x.DateDeleted,
                }).FirstOrDefault();
            }
            return model;
        }

        public void EditHardware(AdminHardwareVM hardware, int id)
        {
            if (hardware != null)
            {
                Hardware model;
                using (ApplicationDbContext db = new ApplicationDbContext())
                {
                    model = db.Hardware.FirstOrDefault(x => x.HardwareID == id);
                    model.HardwareName = hardware.HardwareName;
                    model.Notes = hardware.Notes;
                    model.Category = hardware.Category;
                    model.DateDeleted = hardware.DateDeleted;
                    db.SaveChanges();
                };
            };
        }

        public AdminHardwareVM NewHardware(AdminHardwareVM hardware)
        {
            if (hardware != null)
            {
                Hardware model = new Hardware()
                {
                    HardwareName = hardware.HardwareName,
                    Notes = hardware.Notes,
                    Category = hardware.Category,
                };
                using (ApplicationDbContext db = new ApplicationDbContext())
                {
                    db.Hardware.Add(model);
                    db.SaveChanges();
                }
            }
            return hardware;
        }

        public void DeleteHardware(int id)
        {
            Hardware model;
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                model = db.Hardware.FirstOrDefault(x => x.HardwareID == id);
                model.DateDeleted = DateTime.Now;
                db.SaveChanges();
            }
        }
    }
}