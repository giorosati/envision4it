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
    public class FAQAdapter : IFAQAdapter
    {
        public List<AdminFaqVM> GetFAQs()
        {
            List<AdminFaqVM> model;
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                model = db.FAQS.Where(x => x.DateDeleted == null).OrderBy(x => x.HardwareID).OrderBy(x => x.Topic).Select(x => new AdminFaqVM()
                {
                    FaqID = x.FaqID,
                    HardwareID = x.HardwareID,
                    Hardware = db.Hardware.Where(h => h.HardwareID == x.HardwareID).Select(h => new AdminHardwareVM()
                    {
                        HardwareID = h.HardwareID,
                        HardwareName = h.HardwareName,
                        Notes = h.Notes,
                        Category = h.Category,
                        DateDeleted = h.DateDeleted
                    }).FirstOrDefault(),
                }).ToList();
            }
            return model;
        }

        public AdminFaqVM GetFAQ(int id)
        {
            AdminFaqVM model;
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                model = db.FAQS.Where(x => x.FaqID == id).Select(x => new AdminFaqVM()
                {
                    FaqID = x.FaqID,
                    HardwareID = x.HardwareID,
                    Hardware = db.Hardware.Where(h => h.HardwareID == x.HardwareID).Select(h => new AdminHardwareVM()
                    {
                        HardwareID = h.HardwareID,
                        HardwareName = h.HardwareName,
                        Notes = h.Notes,
                        Category = h.Category,
                        DateDeleted = h.DateDeleted
                    }).FirstOrDefault(),
                    Topic = x.Topic,
                    Question = x.Question,
                    Answer = x.Answer,
                    DateDeleted = x.DateDeleted
                }).FirstOrDefault();
            }
            return model;
        }

        public void EditFAQ(AdminFaqVM editedFAQ, int id)
        {
            FAQ model;
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                model = db.FAQS.FirstOrDefault(x => x.FaqID == id);
                model.HardwareID = editedFAQ.HardwareID;
                model.Topic = editedFAQ.Topic;
                model.Question = editedFAQ.Question;
                model.Answer = editedFAQ.Answer;
                model.DateDeleted = editedFAQ.DateDeleted;
                db.SaveChanges();
            };
        }

        public void newFAQ(AdminFaqVM newFAQ, int id)
        {
            FAQ model = new FAQ();
            Hardware hardwareModel;
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                hardwareModel = db.Hardware.FirstOrDefault(x => x.HardwareID == id);
                model.HardwareID = id;
                model.Topic = newFAQ.Topic;
                model.Question = newFAQ.Question;
                model.Answer = newFAQ.Answer;
                hardwareModel.Faq.Add(model);
                db.SaveChanges();
            }
        }

        public void DeleteFAQ(int id)
        {
            FAQ model;
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                model = db.FAQS.FirstOrDefault(x => x.FaqID == id);
                model.DateDeleted = DateTime.Now;
                db.SaveChanges();
            }
        }
    }
}