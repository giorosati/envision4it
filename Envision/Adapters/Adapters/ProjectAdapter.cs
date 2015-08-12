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
    public class ProjectAdapter : IProjectAdapter
    {
        public List<ProjectVM> getProjects()
        {
            List<ProjectVM> model;
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                model = db.Projects.OrderByDescending(x => x.StartDate).Select(x => new ProjectVM()
                {
                    ProjectName = x.ProjectName,
                    UserID = x.UserID,
                    User = db.Users.Where(u => u.Id == x.UserID).Select(u => new ApplicationUserVM()
                    {
                        Name = u.Name,
                        Company = u.Company,
                        Address1 = u.Address1,
                        Address2 = u.Address2,
                        City = u.City,
                        State = u.State,
                        Zip = u.Zip,
                        Phone = u.Phone,
                        Fax = u.Fax,
                        Email = u.Email,
                        UserName = u.UserName,
                        Id = u.Id
                    }).FirstOrDefault(),
                    StartDate = x.StartDate,
                    TargetDate = x.TargetDate,
                    ProjectID = x.ProjectID,
                    CompletionDate = x.CompletionDate,
                    Address1 = x.Address1,
                    Address2 = x.Address2,
                    City = x.City,
                    State = x.State,
                    Zip = x.Zip,
                    LocationNotes = x.LocationNotes,
                    Solutions = x.Solutions.Select(s => new AdminSolutionVM()
                    {
                        SolutionID = s.SolutionID,
                        SolutionName = s.SolutionName,
                        StartDate = s.StartDate,
                        ProjectID = s.ProjectID,
                        Urgency = s.Urgency,
                        TargetCompletionDate = s.TargetCompletionDate,
                        TicketIDVM = s.Tickets.Select(t => new AdminTicketVM()
                        {
                            TicketID = t.TicketID,
                            SolutionID = t.SolutionID,
                            UserID = t.UserID,
                            Description = t.Description,
                            DateOpened = t.DateOpened,
                            DateClosed = t.DateClosed,
                            DateDeleted = t.DateDeleted,
                            TicketNotes = t.TicketNotes.Select(n => new AdminTicketNotesVM()
                            {
                                UserID = n.UserID,
                                DateDeleted = n.DateDeleted,
                                DateEntered = n.DateEntered,
                                TicketNoteID = n.TicketNoteID,
                                Note = n.Note,
                                TicketID = n.TicketID
                            }).ToList(),
                        }).ToList(),
                    }).ToList(),
                }).ToList();
            }
            return (model);
        }

        public ProjectVM GetProject(int id)
        {
            ProjectVM model;
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                model = db.Projects.Where(x => x.ProjectID == id).Select(x => new ProjectVM()
                {
                    ProjectName = x.ProjectName,
                    ProjectID = x.ProjectID,
                    StartDate = x.StartDate,
                    CompletionDate = x.CompletionDate,
                    TargetDate = x.TargetDate,
                    Address1 = x.Address1,
                    Address2 = x.Address2,
                    City = x.City,
                    State = x.State,
                    Zip = x.Zip,
                    LocationNotes = x.LocationNotes,
                    Solutions = x.Solutions.Select(s => new AdminSolutionVM()
                    {
                        SolutionID = s.SolutionID,
                        SolutionName = s.SolutionName,
                        ProjectID = s.ProjectID,
                        Urgency = s.Urgency,
                        StartDate = s.StartDate,
                        TargetCompletionDate = s.TargetCompletionDate
                    }).ToList(),
                }).FirstOrDefault();
            }
            return model;
        }

        public ProjectVM GetEditProject(int id)
        {
            ProjectVM project;
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                project = db.Projects.Where(x => x.ProjectID == id).Select(x => new ProjectVM()
                {
                    ProjectName = x.ProjectName,
                    StartDate = x.StartDate,
                    TargetDate = x.TargetDate,
                    CompletionDate = x.CompletionDate,
                    DateDelted = x.DateDeleted,
                    Address1 = x.Address1,
                    Address2 = x.Address2,
                    City = x.City,
                    State = x.State,
                    Zip = x.Zip,
                    LocationNotes = x.LocationNotes,
                }).FirstOrDefault();
            };
            return project;
        }

        public void EditProject(ProjectVM project, int id)
        {
            if (project != null)
            {
                Project model;
                using (ApplicationDbContext db = new ApplicationDbContext())
                {
                    model = db.Projects.FirstOrDefault(x => x.ProjectID == id);
                    model.ProjectName = project.ProjectName;
                    model.StartDate = project.StartDate;
                    model.TargetDate = project.TargetDate;
                    model.CompletionDate = project.CompletionDate;
                    model.Address1 = project.Address1;
                    model.Address2 = project.Address2;
                    model.City = project.City;
                    model.State = project.State;
                    model.Zip = project.Zip;
                    model.LocationNotes = project.LocationNotes;
                    db.SaveChanges();
                };
            };
        }

        public ProjectVM AddProject(ProjectVM project)
        {
            Project model = new Project()
            {
                ProjectName = project.ProjectName,
                CompletionDate = project.CompletionDate,
                StartDate = project.StartDate,
                TargetDate = project.TargetDate,
                DateDeleted = null,
                ProjectID = project.ProjectID,
                Address1 = project.Address1,
                Address2 = project.Address2,
                City = project.City,
                State = project.State,
                Zip = project.Zip,
                LocationNotes = project.LocationNotes,
                Solutions = project.Solutions.Select(x => new Solution()
                {
                    SolutionID = x.SolutionID,
                    StartDate = x.StartDate,
                    SolutionName = x.SolutionName,
                    ProjectID = project.ProjectID,
                    DateDeleted = null,
                    TargetCompletionDate = x.TargetCompletionDate,
                    Urgency = x.Urgency,
                    SolutionNotes = x.SolutionNotes.Select(sn => new SolutionNote()
                    {
                        DateDeleted = null,
                        DateEntered = DateTime.Now,
                        SolutionID = x.SolutionID,
                        SolutionNoteID = sn.SolutionNoteID,
                        Note = sn.Note
                    }).ToList(),
                }).ToList(),
            };

            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                db.Projects.Add(model);
                db.SaveChanges();
            }
            return project;
        }

        public void DeleteProject(int id)
        {
            Project model;
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                model = db.Projects.FirstOrDefault(x => x.ProjectID == id);
                model.DateDeleted = DateTime.Now;
                db.SaveChanges();
            }
        }
    }
}