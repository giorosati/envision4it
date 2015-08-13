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
    public class TicketAdapter : ITicketAdapter
    {
        public List<AdminTicketVM> GetTickets()
        {
            List<AdminTicketVM> model;
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                model = db.Tickets.Where(x => x.DateDeleted == null).OrderByDescending(x => x.DateOpened).Select(x => new AdminTicketVM()
                {
                    TicketID = x.TicketID,
                    SolutionID = x.SolutionID,
                    Solution = db.Solutions.Where(s => s.SolutionID == x.SolutionID).Select(s => new AdminSolutionVM()
                    {
                        StartDate = s.StartDate,
                        SolutionName = s.SolutionName,
                        ProjectID = s.ProjectID,
                        Project = db.Projects.Where(p => p.ProjectID == s.ProjectID).Select(p => new ProjectVM()
                        {
                            ProjectID = p.ProjectID,
                            ProjectName = p.ProjectName
                        }).FirstOrDefault(),
                    }).FirstOrDefault(),
                    Description = x.Description,
                    UserID = x.UserID,
                    User = x.User,
                    DateOpened = x.DateOpened,
                    DateClosed = x.DateClosed,
                    DateDeleted = x.DateDeleted,
                    Status = x.Status,
                    Urgency = x.Urgency,
                    TicketType = x.TicketType
                }).ToList();
            }
            return model;
        }

        public AdminTicketVM GetTicket(int id)
        {
            AdminTicketVM model;
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                model = db.Tickets.Where(x => x.TicketID == id).Select(x => new AdminTicketVM()
                {
                    SolutionID = x.SolutionID,
                    Description = x.Description,
                    UserID = x.UserID,
                    User = x.User,
                    DateOpened = x.DateOpened,
                    DateClosed = x.DateClosed,
                    DateDeleted = x.DateDeleted,
                    Status = x.Status,
                    Urgency = x.Urgency,
                    TicketType = x.TicketType
                }).FirstOrDefault();
            }
            return model;
        }

        public void EditTicket(AdminTicketVM editedTicket, int id)
        {
            Ticket model;
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                model = db.Tickets.FirstOrDefault(x => x.TicketID == id);
                model.SolutionID = editedTicket.SolutionID;
                model.Description = editedTicket.Description;
                model.UserID = editedTicket.UserID;
                model.User = editedTicket.User;
                model.DateOpened = editedTicket.DateOpened;
                model.DateClosed = editedTicket.DateClosed;
                model.DateDeleted = editedTicket.DateDeleted;
                model.Status = editedTicket.Status;
                model.Urgency = editedTicket.Urgency;
                model.TicketType = editedTicket.TicketType;
                db.SaveChanges();
            };
        }

        public void newTicket(AdminTicketVM newTicket, int id)
        {
            Ticket model = new Ticket();
            Solution solutionModel;
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                solutionModel = db.Solutions.FirstOrDefault(x => x.SolutionID == id);
                model.SolutionID = id;
                model.Description = newTicket.Description;
                model.DateOpened = newTicket.DateOpened;
                model.DateClosed = newTicket.DateClosed;
                model.Status = newTicket.Status;
                model.Urgency = newTicket.Urgency;
                model.TicketType = newTicket.TicketType;
                solutionModel.Tickets.Add(model);
                db.SaveChanges();
            }
        }

        public void DeleteTicket(int id)
        {
            Ticket model;
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                model = db.Tickets.FirstOrDefault(x => x.TicketID == id);
                model.DateDeleted = DateTime.Now;
                db.SaveChanges();
            }
        }
    }
}