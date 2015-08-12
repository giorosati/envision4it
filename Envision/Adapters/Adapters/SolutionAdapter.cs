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
    public class SolutionAdapter : ISolutionAdapter
    {
        public List<AdminSolutionVM> GetSolutions()
        {
            List<AdminSolutionVM> model;
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                model = db.Solutions.Where(x => x.DateDeleted == null).OrderBy(x => x.SolutionID).Select(x => new AdminSolutionVM()
                {
                    SolutionID = x.SolutionID,
                    SolutionName = x.SolutionName,
                    ProjectID = x.ProjectID,
                    StartDate = x.StartDate,
                    TargetCompletionDate = x.TargetCompletionDate,
                    Urgency = x.Urgency,

                    SolutionNotes = x.SolutionNotes.Select(sn => new AdminSolutionNoteVM()
                    {
                        SolutionNoteID = sn.SolutionNoteID,
                        SolutionID = sn.SolutionID,
                        DateEntered = sn.DateEntered,
                        Note = sn.Note
                    }).ToList(),

                    TicketIDVM = x.Tickets.Where(t => t.DateDeleted == null).Select(t => new AdminTicketVM()
                    {
                        TicketID = t.TicketID,
                        UserID = t.UserID,
                        DateOpened = t.DateOpened,
                        DateClosed = t.DateClosed,
                        Status = t.Status,
                        Urgency = t.Urgency,
                        TicketType = t.TicketType
                    }).ToList(),

                    AdminHardwareVM = x.Solution_Hardware.Select(h => new AdminHardwareVM()
                    {
                        Category = h.Hardware.Category,
                        HardwareName = h.Hardware.HardwareName,
                    }).ToList(),
                }).ToList();
            }
            return model;
        }

        public AdminSolutionVM GetSolution(int id)
        {
            AdminSolutionVM model;
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                model = db.Solutions.Where(x => x.SolutionID == id).Select(x => new AdminSolutionVM()
                   {
                       SolutionID = x.SolutionID,
                       SolutionName = x.SolutionName,
                       ProjectID = x.ProjectID,
                       StartDate = x.StartDate,
                       TargetCompletionDate = x.TargetCompletionDate,
                       Urgency = x.Urgency,

                       SolutionNotes = x.SolutionNotes.Select(sn => new AdminSolutionNoteVM()
                       {
                           SolutionNoteID = sn.SolutionNoteID,
                           SolutionID = sn.SolutionID,
                           DateEntered = sn.DateEntered,
                           Note = sn.Note
                       }).ToList(),

                       TicketIDVM = x.Tickets.Select(t => new AdminTicketVM()
                       {
                           TicketID = t.TicketID,
                           UserID = t.UserID,
                           Description = t.Description,
                           DateOpened = t.DateOpened,
                           DateClosed = t.DateClosed,
                           Status = t.Status,
                           Urgency = t.Urgency,
                           TicketType = t.TicketType
                       }).ToList(),
                       // x is solution id h is solutionHardwareID
                       //matching these up where the solutionID matches on the solutionHardware.solutionID
                       //x.id == h.solutionid
                       AdminHardwareVM = x.Solution_Hardware.Where(h => x.SolutionID == h.SolutionID).Select(h => new AdminHardwareVM()
                       {
                           HardwareID = h.HardwareID,
                           HardwareName = h.Hardware.HardwareName,
                           Category = h.Hardware.Category,
                           DateDeleted = h.Hardware.DateDeleted,
                           Notes = h.Hardware.Notes,
                           Faq = h.Hardware.Faq.Select(f => new AdminFaqVM()
                           {
                               FaqID = f.FaqID,
                               HardwareID = f.HardwareID,
                               Answer = f.Answer,
                               Question = f.Question,
                               Topic = f.Topic
                           }).ToList(),
                       }).ToList(),
                   }).FirstOrDefault();
            }
            return model;
        }

        public AdminSolutionVM GetEditSolution(int id)
        {
            AdminSolutionVM solution;
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                solution = db.Solutions.Where(x => x.SolutionID == id).Select(x => new AdminSolutionVM()
                {
                    SolutionName = x.SolutionName,
                    Urgency = x.Urgency,
                    StartDate = x.StartDate,
                    TargetCompletionDate = x.TargetCompletionDate,
                }).FirstOrDefault();
            };
            return solution;
        }

        public void EditSolution(AdminSolutionVM solution, int id)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                if (solution != null)
                {
                    Solution model;
                    model = db.Solutions.FirstOrDefault(x => x.SolutionID == id);
                    model.SolutionName = solution.SolutionName;
                    model.TargetCompletionDate = solution.TargetCompletionDate;
                    model.Urgency = solution.Urgency;
                    model.StartDate = solution.StartDate;
                    db.SaveChanges();
                };
            };
        }

        public AdminSolutionVM AddSolution(AdminSolutionVM solution, int id)
        {
            Solution model = new Solution()
            {
                ProjectID = id,
                DateDeleted = null,
                SolutionID = solution.SolutionID,
                SolutionName = solution.SolutionName,
                StartDate = solution.StartDate,
                TargetCompletionDate = solution.TargetCompletionDate,
                Urgency = solution.Urgency
            };
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                db.Solutions.Add(model);
                db.SaveChanges();
            }
            return solution;
        }

        public AdminSolutionVM AddSolution(int id, AdminSolutionVM solution)
        {
            Project project;
            Solution newSolution = new Solution()
            {
                SolutionName = solution.SolutionName,
                StartDate = solution.StartDate,
                Urgency = solution.Urgency,
                TargetCompletionDate = solution.TargetCompletionDate
            };
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                project = db.Projects.FirstOrDefault(x => x.ProjectID == id);
                project.Solutions.Add(newSolution);
                db.SaveChanges();
            }
            return solution;
        }

        public void DeleteSolution(int id)
        {
            Solution model;
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                model = db.Solutions.FirstOrDefault(x => x.SolutionID == id);
                model.DateDeleted = DateTime.Now;
                db.SaveChanges();
            }
        }

        public AdminHardwareVM AddHardware(AdminHardwareVM hw)
        {
            Hardware model = new Hardware()
            {
                HardwareID = hw.HardwareID,
                Category = hw.Category,
                DateDeleted = null,
                HardwareName = hw.HardwareName,
                Notes = hw.Notes,
                Faq = hw.Faq.Select(f => new FAQ()
                {
                    Answer = f.Answer,
                    FaqID = f.FaqID,
                    DateDeleted = null,
                    HardwareID = hw.HardwareID,
                    Question = f.Question,
                    Topic = f.Topic
                }).ToList(),
            };
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                db.Hardware.Add(model);
                db.SaveChanges();
            }
            return hw;
        }

        public void DeleteHardware(HardwareSolutionVM ids)
        {
            Solution_Hardware model;

            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                model = db.Solution_Hardware.FirstOrDefault(x => x.HardwareID == ids.HardwareID && x.SolutionID == ids.SolutionID);
                model.DateDeleted = DateTime.Now;
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

        public AdminHardwareVM GetEditHardware(int id)
        {
            AdminHardwareVM hardware;
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                hardware = db.Hardware.Where(x => x.HardwareID == id).Select(x => new AdminHardwareVM()
                {
                    HardwareID = x.HardwareID,
                    Category = x.Category,

                    HardwareName = x.HardwareName,
                    Notes = x.Notes,
                }).FirstOrDefault();
            };
            return hardware;
        }

        public void EditHardware(AdminHardwareVM hardware, int id)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                Hardware model;
                model = db.Hardware.FirstOrDefault(x => x.HardwareID == id);
                model.HardwareID = hardware.HardwareID;
                model.HardwareName = hardware.HardwareName;
                model.Notes = hardware.Notes;
                model.DateDeleted = null;
                db.SaveChanges();
            }
        }

        public AdminFaqVM GetEditFaq(int id)
        {
            AdminFaqVM faq;
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                faq = db.FAQS.Where(f => f.FaqID == id).Select(f => new AdminFaqVM()
                {
                    FaqID = f.FaqID,
                    Answer = f.Answer,
                    DateDeleted = null,
                    Question = f.Question,
                    HardwareID = f.HardwareID,
                    Topic = f.Topic
                }).FirstOrDefault();
            };
            return faq;
        }

        public void EditFAQ(AdminFaqVM faq, int id)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                FAQ model;
                model = db.FAQS.FirstOrDefault(x => x.FaqID == id);
                model.Answer = faq.Answer;
                model.DateDeleted = null;
                model.Question = faq.Question;
                model.Topic = faq.Topic;
                model.HardwareID = faq.HardwareID;
                db.SaveChanges();
            }
        }

        public List<AdminHardwareVM> GetHardware()
        {
            List<AdminHardwareVM> model;

            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                model = db.Hardware.Where(x => x.DateDeleted == null).Select(x => new AdminHardwareVM()
                 {
                     Category = x.Category,
                     HardwareID = x.HardwareID,
                     Faq = x.Faq.Select(f => new AdminFaqVM()
                     {
                         Answer = f.Answer,
                         FaqID = f.FaqID,
                         Question = f.Question,
                         Topic = f.Topic
                     }).ToList(),
                     HardwareName = x.HardwareName,
                     Notes = x.Notes
                 }).ToList();
            }
            return model;
        }

        public void AddHardwareSolu(HardwareSolutionVM ids)
        {
            Solution_Hardware model = new Solution_Hardware()
            {
                HardwareID = ids.HardwareID,
                SolutionID = ids.SolutionID
            };
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                db.Solution_Hardware.Add(model);
                db.SaveChanges();
            };
        }

        public void DeleteHardware(int id)
        {
            throw new NotImplementedException();
        }
    }
}