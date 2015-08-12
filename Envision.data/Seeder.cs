using Envision.data;
using Envision.Data.Model;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Envision.data
{
    public static class Seeder
    {
        private static string Admin;
        private static string User;
        private static string Tech;
        private static string Root;
        private static string User2;
        private static string User3;

        public static void Seed(ApplicationDbContext db,
            bool roles = true,
            bool users = true,
            bool userdata = true,
            bool project = true,
            bool hardware = true,
            bool ticket = true,
            bool faq = true,
            bool customercontact = true,
            bool solution = true,
            bool document = true,
            bool ticketnote = true,
            bool solutionnote = true,
            bool projectnote = true,
            bool customernote = true,
            bool sol_hard = true)
        {
            if (roles) seedroles(db);
            if (users) seedusers(db);
            User = db.Users.FirstOrDefault(x => x.UserName == "user@test.com").Id;
            Tech = db.Users.FirstOrDefault(x => x.UserName == "tech@test.com").Id;
            Admin = db.Users.FirstOrDefault(x => x.UserName == "admin@test.com").Id;
            Root = db.Users.FirstOrDefault(x => x.UserName == "root@test.com").Id;
            User2 = db.Users.FirstOrDefault(x => x.UserName == "user2@test.com").Id;
            User3 = db.Users.FirstOrDefault(x => x.UserName == "user3@test.com").Id;
            seedUserRoles(User, Tech, Admin, Root, User2, User3, db);
            if (project) seedprojects(db);
            if (hardware) seedhardware(db);
            if (ticket) seedtickets(db);
            if (faq) seedfaq(db);
            if (customernote) seedCustomerNote(db);
            if (solution) seedsolutions(db);
            if (document) seeddocument(db);
            if (ticketnote) seedTicketNotes(db);
            if (solutionnote) seedSolutionNote(db);
            if (projectnote) seedProjectNotes(db);
            if (customercontact) seedcustomercontact(db);
            if (sol_hard) seedSolutionHardware(db);
        }

        private static void seedroles(ApplicationDbContext db)
        {
            var store = new RoleStore<IdentityRole>(db);
            var manager = new RoleManager<IdentityRole>(store);
            {
                if (!manager.RoleExists(Roles.ADMIN))
                {
                    manager.Create(new IdentityRole() { Name = Roles.ADMIN });
                }
                if (!manager.RoleExists(Roles.CUSTOMER))
                {
                    manager.Create(new IdentityRole() { Name = Roles.CUSTOMER });
                }
                if (!manager.RoleExists(Roles.ROOT))
                {
                    manager.Create(new IdentityRole() { Name = Roles.ROOT });
                }
                if (!manager.RoleExists(Roles.TECH))
                {
                    manager.Create(new IdentityRole() { Name = Roles.TECH });
                }
            }
        }

        private static void seedusers(ApplicationDbContext db)
        {
            var manager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));

            if (!db.Users.Any(x => x.UserName == "user@test.com"))
            {
                ApplicationUser user = new ApplicationUser()
                {
                    Email = "user@test.com",
                    UserName = "user@test.com",
                    Name = "Customer #1",
                    Company = "XZY Company",
                    Address1 = "Address Line 1",
                    Address2 = "Address Line 2",
                    City = "San Francisco",
                    State = "CA",
                    Zip = 94104,
                    Phone = 1234567890,
                    Fax = 1234567890
                };
                manager.Create(user, "123123");
            }

            if (!db.Users.Any(x => x.UserName == "tech@test.com"))
            {
                ApplicationUser user = new ApplicationUser()
                {
                    Email = "tech@test.com",
                    UserName = "tech@test.com",
                    Name = "Tech user",
                    Company = "XZY Company",
                    Address1 = "Address Line 1",
                    Address2 = "Address Line 2",
                    City = "San Francisco",
                    State = "CA",
                    Zip = 94104,
                    Phone = 1234567890,
                    Fax = 1234567890
                };
                manager.Create(user, "123123");
            }
            if (!db.Users.Any(x => x.UserName == "admin@test.com"))
            {
                ApplicationUser user = new ApplicationUser()
                {
                    Email = "admin@test.com",
                    UserName = "admin@test.com",
                    Name = "Admin user",
                    Company = "XZY Company",
                    Address1 = "Address Line 1",
                    Address2 = "Address Line 2",
                    City = "San Francisco",
                    State = "CA",
                    Zip = 94104,
                    Phone = 1234567890,
                    Fax = 1234567890
                };
                manager.Create(user, "123123");
            }
            if (!db.Users.Any(x => x.UserName == "root@test.com"))
            {
                ApplicationUser user = new ApplicationUser()
                {
                    Email = "root@test.com",
                    UserName = "root@test.com",
                    Name = "Root user",
                    Company = "XZY Company",
                    Address1 = "Address Line 1",
                    Address2 = "Address Line 2",
                    City = "San Francisco",
                    State = "CA",
                    Zip = 94104,
                    Phone = 1234567890,
                    Fax = 1234567890
                };
                manager.Create(user, "123123");
            }

            if (!db.Users.Any(x => x.UserName == "user2@test.com"))
            {
                ApplicationUser user = new ApplicationUser()
                {
                    Email = "user2@test.com",
                    UserName = "user2@test.com",
                    Name = "Customer #2",
                    Company = "XZY Company",
                    Address1 = "Address Line 1",
                    Address2 = "Address Line 2",
                    City = "San Francisco",
                    State = "CA",
                    Zip = 94104,
                    Phone = 1234567890,
                    Fax = 1234567890
                };
                manager.Create(user, "123123");
            }
            if (!db.Users.Any(x => x.UserName == "user3@test.com"))
            {
                ApplicationUser user = new ApplicationUser()
                {
                    Email = "user3@test.com",
                    UserName = "user3@test.com",
                    Name = "Customer #3",
                    Company = "XZY Company",
                    Address1 = "Address Line 1",
                    Address2 = "Address Line 2",
                    City = "San Francisco",
                    State = "CA",
                    Zip = 94104,
                    Phone = 1234567890,
                    Fax = 1234567890
                };
                manager.Create(user, "123123");
            }
            db.SaveChanges();
        }

        private static void seedUserRoles(string User, string Tech, string Admin, string Root, string User2, string User3, ApplicationDbContext db)
        {
            var manager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
            manager.AddToRole(User, Roles.CUSTOMER);
            manager.AddToRoles(Tech, Roles.TECH, Roles.CUSTOMER);
            manager.AddToRoles(Admin, Roles.ADMIN, Roles.TECH, Roles.CUSTOMER);
            manager.AddToRoles(Root, Roles.ROOT, Roles.ADMIN, Roles.TECH, Roles.CUSTOMER);
            manager.AddToRole(User2, Roles.CUSTOMER);
            manager.AddToRole(User3, Roles.CUSTOMER);
        }

        private static void seedprojects(ApplicationDbContext db)
        {
            db.Projects.AddOrUpdate(
                p => p.ProjectID,
            new Project { ProjectID = 1, UserID = User2, StartDate = Convert.ToDateTime("07/24/2015"), ProjectName = "Quoc's House", TargetDate = Convert.ToDateTime("12/31/2027"), Address1 = "address line 1", Address2 = "addres line 2", City = "Test City", State = "CA", Zip = "12345", LocationNotes = "Sample notes about this location..." },
            new Project { ProjectID = 2, UserID = User2, StartDate = Convert.ToDateTime("07/24/2015"), ProjectName = "The White House", TargetDate = Convert.ToDateTime("03/20/2017"), Address1 = "address line 1", Address2 = "addres line 2", City = "Test City", State = "CA", Zip = "12345", LocationNotes = "Sample notes about this location..." },
            new Project { ProjectID = 3, UserID = User2, StartDate = Convert.ToDateTime("08/30/2015"), ProjectName = "Pentagon Home Lobby", TargetDate = Convert.ToDateTime("01/01/2016"), Address1 = "address line 1", Address2 = "addres line 2", City = "Test City", State = "CA", Zip = "12345", LocationNotes = "Sample notes about this location..." },
            new Project { ProjectID = 7, UserID = User, StartDate = Convert.ToDateTime("07/01/2015"), ProjectName = "Luxury San Francisco Hotel", TargetDate = Convert.ToDateTime("01/31/2016"), Address1 = "address line 1", Address2 = "addres line 2", City = "Test City", State = "CA", Zip = "12345", LocationNotes = "Sample notes about this location..." },
            new Project { ProjectID = 8, UserID = User, StartDate = Convert.ToDateTime("08/01/2015"), ProjectName = "Gio's Home Theater", TargetDate = Convert.ToDateTime("08/31/2016"), Address1 = "address line 1", Address2 = "addres line 2", City = "Test City", State = "CA", Zip = "12345", LocationNotes = "Sample notes about this location..." },
            new Project { ProjectID = 9, UserID = User, StartDate = Convert.ToDateTime("09/10/2015"), ProjectName = "XYZ, Inc. Headquarters Building", TargetDate = Convert.ToDateTime("12/31/2015"), Address1 = "address line 1", Address2 = "addres line 2", City = "Test City", State = "CA", Zip = "12345", LocationNotes = "Sample notes about this location..." },
            new Project { ProjectID = 4, UserID = User, ProjectName = "Full upgrade", CompletionDate = Convert.ToDateTime("09/30/2015"), StartDate = Convert.ToDateTime("07/5/2015"), TargetDate = Convert.ToDateTime("08/19/2015"), Address1 = "address line 1", Address2 = "addres line 2", City = "Test City", State = "CA", Zip = "12345", LocationNotes = "Sample notes about this location..." },
            new Project { ProjectID = 5, UserID = User3, ProjectName = "Instalation of Wifi", CompletionDate = Convert.ToDateTime("10/30/2016"), StartDate = Convert.ToDateTime("09/30/2016"), TargetDate = Convert.ToDateTime("10/19/2016"), Address1 = "address line 1", Address2 = "addres line 2", City = "Test City", State = "CA", Zip = "12345", LocationNotes = "Sample notes about this location..." },
            new Project { ProjectID = 6, UserID = User3, ProjectName = "Smart Home", CompletionDate = Convert.ToDateTime("01/01/2016"), StartDate = Convert.ToDateTime("12/05/2015"), TargetDate = Convert.ToDateTime("01/01/2016"), Address1 = "address line 1", Address2 = "addres line 2", City = "Test City", State = "CA", Zip = "12345", LocationNotes = "Sample notes about this location..." }
            );
        }

        private static void seedsolutions(ApplicationDbContext db)
        {
            db.Solutions.AddOrUpdate(
                s => s.SolutionID,
            new Solution { SolutionID = 1, ProjectID = 1, Urgency = "Medium", TargetCompletionDate = Convert.ToDateTime("12/31/2027"), StartDate = Convert.ToDateTime("07/24/2015"), SolutionName = "Wifi" },
            new Solution { SolutionID = 2, ProjectID = 2, Urgency = "Mediium", TargetCompletionDate = Convert.ToDateTime("03/20/2017"), StartDate = Convert.ToDateTime("07/24/2015"), SolutionName = "pool table" },
            new Solution { SolutionID = 3, ProjectID = 3, Urgency = "High", TargetCompletionDate = Convert.ToDateTime("01/01/2016"), StartDate = Convert.ToDateTime("08/27/2015"), SolutionName = "security system" },

            new Solution { SolutionID = 4, StartDate = Convert.ToDateTime("07/01/2015"), ProjectID = 9, TargetCompletionDate = Convert.ToDateTime("07/15/2016"), Urgency = "High", SolutionName = "Primary Test Solution" },

            new Solution { SolutionID = 5, ProjectID = 4, Urgency = "Priority", TargetCompletionDate = Convert.ToDateTime("09/25/2015"), StartDate = Convert.ToDateTime("09/21/2015"), SolutionName = "Solar Panels" },
            new Solution { SolutionID = 6, ProjectID = 5, Urgency = "Priority", TargetCompletionDate = Convert.ToDateTime("10/25/2016"), StartDate = Convert.ToDateTime("09/21/2015"), SolutionName = "Solution 5" },
            new Solution { SolutionID = 7, ProjectID = 6, Urgency = "High", TargetCompletionDate = Convert.ToDateTime("12/25/2015"), StartDate = Convert.ToDateTime("09/21/2015"), SolutionName = "Entertainment System" },
            new Solution { SolutionID = 8, StartDate = Convert.ToDateTime("07/01/2015"), ProjectID = 9, TargetCompletionDate = Convert.ToDateTime("07/15/2016"), Urgency = "High", SolutionName = "3d" },
            new Solution { SolutionID = 9, StartDate = Convert.ToDateTime("07/01/2015"), ProjectID = 7, TargetCompletionDate = Convert.ToDateTime("07/15/2016"), Urgency = "Medium", SolutionName = "Solution 6" },
            new Solution { SolutionID = 10, StartDate = Convert.ToDateTime("07/01/2015"), ProjectID = 8, TargetCompletionDate = Convert.ToDateTime("07/15/2016"), Urgency = "Medium", SolutionName = "Solution 7" }
            );
        }

        private static void seedhardware(ApplicationDbContext db)
        {
            db.Hardware.AddOrUpdate(
                p => p.HardwareID,
                new Hardware { HardwareID = 1, HardwareName = "ping-pong table", Notes = "This is text about this hardware item.", Category = "Video" },
                new Hardware { HardwareID = 2, HardwareName = "Cisco Router x123", Notes = "This is text about this hardware item.", Category = "Video" },
                new Hardware { HardwareID = 3, HardwareName = "solar panels", Notes = "This is text about this hardware item.", Category = "Video" },
                new Hardware { HardwareID = 4, HardwareName = "Wifi cables", Notes = "This is text about this hardware item.", Category = "Video" },
                new Hardware { HardwareID = 5, HardwareName = "Wires for speakers", Notes = "This is text about this hardware item.", Category = "Video" },
                new Hardware { HardwareID = 6, HardwareName = "hardware for video ", Notes = "This is text about this hardware item.", Category = "Video" },
                new Hardware { HardwareID = 7, HardwareName = "Samsung 70in OLED TV", Notes = "This TV has 5 HDMI inputs.", Category = "Video" },
                new Hardware { HardwareID = 8, HardwareName = "Cisco Wi-Fi Router /a/b/g/n", Notes = "5 ethernet ports", Category = "Internet" },
                new Hardware { HardwareID = 9, HardwareName = "Conference room Speakerphone", Notes = "RJ-45 or wireless", Category = "Telecommunications" },
                new Hardware { HardwareID = 10, HardwareName = "Cisco 24 port patch bay", Notes = "RJ-45 jacks", Category = "Telecommunications" }
                );
        }

        private static void seedfaq(ApplicationDbContext db)
        {
            db.FAQS.AddOrUpdate(
                f => f.FaqID,
                new FAQ { FaqID = 1, HardwareID = 1, Answer = "Answer text goes here.....", Question = "Question text goes here.....?", Topic = "Topic text goes here....." },
                new FAQ { FaqID = 2, HardwareID = 2, Answer = "Answer text goes here.....", Question = "Question text goes here.....?", Topic = "Topic text goes here....." },
                new FAQ { FaqID = 3, HardwareID = 3, Answer = "Answer text goes here.....", Question = "Question text goes here.....?", Topic = "Topic text goes here....." },
                new FAQ { FaqID = 4, HardwareID = 4, Answer = "Answer text goes here.....", Question = "Question text goes here.....?", Topic = "Topic text goes here....." },
                new FAQ { FaqID = 5, HardwareID = 5, Answer = "Answer text goes here.....", Question = "Question text goes here.....?", Topic = "Topic text goes here....." },
                new FAQ { FaqID = 6, HardwareID = 6, Answer = "Answer text goes here.....", Question = "Question text goes here.....?", Topic = "Topic text goes here....." },
                new FAQ { FaqID = 7, HardwareID = 7, Answer = "Answer text goes here.....", Question = "Question text goes here.....?", Topic = "Topic text goes here....." },
                new FAQ { FaqID = 8, HardwareID = 8, Answer = "Answer text goes here.....", Question = "Question text goes here.....?", Topic = "Topic text goes here....." },
                new FAQ { FaqID = 9, HardwareID = 9, Answer = "Answer text goes here.....", Question = "Question text goes here.....?", Topic = "Topic text goes here....." },
                new FAQ { FaqID = 10, HardwareID = 10, Answer = "Answer text goes here.....", Question = "Question text goes here.....?", Topic = "Topic text goes here....." }
                );
        }

        private static void seeddocument(ApplicationDbContext db)
        {
            db.Documents.AddOrUpdate(
                d => d.DocumentID,
                new Document { DocumentID = 1, HardwareID = 1, Name = "XYZ Router Manual", Description = "Router Manual", Filepath = "http://www.atmel.com/images/doc4316.pdf", Url = "http://ciarang.com/gallery/albums/general/technical/amigahwref.jpg" },
                new Document { DocumentID = 2, HardwareID = 1, Name = "Samsung XD-5612 Manual", Description = "TV Manual", Filepath = "http://www.atmel.com/images/doc4316.pdf", Url = "http://ciarang.com/gallery/albums/general/technical/amigahwref.jpg" },
                new Document { DocumentID = 3, HardwareID = 2, Name = "HP 24s Manual", Description = "24 Port Switch Manual", Filepath = "http://www.atmel.com/images/doc4316.pdf", Url = "http://ciarang.com/gallery/albums/general/technical/amigahwref.jpg" },
                new Document { DocumentID = 4, HardwareID = 2, Name = "Equipment 435 Manual", Description = "Equipment 345 User Guide", Filepath = "http://www.atmel.com/images/doc4316.pdf", Url = "http://ciarang.com/gallery/albums/general/technical/amigahwref.jpg" },
                new Document { DocumentID = 5, HardwareID = 3, Name = "Sony Microphone Manual", Description = "Sony Mic Manual", Filepath = "http://www.atmel.com/images/doc4316.pdf", Url = "http://ciarang.com/gallery/albums/general/technical/amigahwref.jpg" },
                new Document { DocumentID = 6, HardwareID = 3, Name = "ACME Surveilance DVR Manual", Description = "DVR Manual", Filepath = "http://www.atmel.com/images/doc4316.pdf", Url = "http://ciarang.com/gallery/albums/general/technical/amigahwref.jpg" }
                );
        }

        private static void seedcustomercontact(ApplicationDbContext db)
        {
            db.CustomerContacts.AddOrUpdate(
                c => c.CustomerContactID,
                new CustomerContact { CustomerContactID = 1, UserID = "1", Title = "Manager", Email = "name@company.com", Department = "Management", Name = "John Smith", MobileNumber = 1234567890, WorkNumber = 1234567890, FaxNumber = 1234567890, Skype = "SkypeNameGoesHere" },
                new CustomerContact { CustomerContactID = 2, UserID = "1", Title = "Owner", Email = "name@company.com", Department = "Ownership", Name = "Mr. Big", MobileNumber = 1234567890, WorkNumber = 1234567890, FaxNumber = 1234567890, Skype = "SkypeNameGoesHere" },
                new CustomerContact { CustomerContactID = 3, UserID = "1", Title = "Executive Assistant", Email = "name@company.com", Department = "Management", Name = "Mr. Helper", MobileNumber = 1234567890, WorkNumber = 1234567890, FaxNumber = 1234567890, Skype = "SkypeNameGoesHere" },
                new CustomerContact { CustomerContactID = 4, UserID = "1", Title = "Staff Person", Email = "name@company.com", Department = "Operations", Name = "Employee #10", MobileNumber = 1234567890, WorkNumber = 1234567890, FaxNumber = 1234567890, Skype = "SkypeNameGoesHere" },
                new CustomerContact { CustomerContactID = 5, UserID = "1", Title = "Staff Person", Email = "name@company.com", Department = "Operations", Name = "Employee #11", MobileNumber = 1234567890, WorkNumber = 1234567890, FaxNumber = 1234567890, Skype = "SkypeNameGoesHere" },
                new CustomerContact { CustomerContactID = 6, UserID = "1", Title = "Staff Person", Email = "name@company.com", Department = "Operations", Name = "Employee #12", MobileNumber = 1234567890, WorkNumber = 1234567890, FaxNumber = 1234567890, Skype = "SkypeNameGoesHere" }
                );
        }

        private static void seedtickets(ApplicationDbContext db)
        {
            db.Tickets.AddOrUpdate(
                t => t.TicketID,
                new Ticket { TicketID = 1, Description = "Description goes here...", SolutionID = 1, DateOpened = Convert.ToDateTime("03/04/2015"), Status = "In Progress", Urgency = "High", TicketType = "New Install" },
                new Ticket { TicketID = 2, Description = "Description goes here...", SolutionID = 1, DateOpened = Convert.ToDateTime("03/08/2014"), Status = "In Progress", Urgency = "High", TicketType = "New Install" },
                new Ticket { TicketID = 3, Description = "Description goes here...", SolutionID = 1, DateOpened = Convert.ToDateTime("03/08/2014"), Status = "In Progress", Urgency = "High", TicketType = "New Install" },
                new Ticket { TicketID = 4, Description = "Description goes here...", SolutionID = 2, DateOpened = Convert.ToDateTime("03/08/2014"), Status = "In Progress", Urgency = "High", TicketType = "New Install" },
                new Ticket { TicketID = 5, Description = "Description goes here...", SolutionID = 2, DateOpened = Convert.ToDateTime("03/08/2014"), Status = "In Progress", Urgency = "High", TicketType = "New Install" },
                new Ticket { TicketID = 6, Description = "Description goes here...", SolutionID = 2, DateOpened = Convert.ToDateTime("03/08/2014"), Status = "In Progress", Urgency = "High", TicketType = "New Install" },
                new Ticket { TicketID = 7, Description = "Description goes here...", SolutionID = 3, DateOpened = Convert.ToDateTime("03/08/2014"), Status = "In Progress", Urgency = "High", TicketType = "New Install" },
                new Ticket { TicketID = 8, Description = "Description goes here...", SolutionID = 3, DateOpened = Convert.ToDateTime("03/08/2014"), Status = "In Progress", Urgency = "High", TicketType = "New Install" },
                new Ticket { TicketID = 9, Description = "Description goes here...", SolutionID = 3, DateOpened = Convert.ToDateTime("03/08/2014"), Status = "In Progress", Urgency = "High", TicketType = "New Install" },
                new Ticket { TicketID = 10, Description = "Description goes here...", SolutionID = 4, DateOpened = Convert.ToDateTime("03/08/2014"), Status = "In Progress", Urgency = "High", TicketType = "New Install" },
                new Ticket { TicketID = 11, Description = "Description goes here...", SolutionID = 4, DateOpened = Convert.ToDateTime("03/08/2014"), Status = "In Progress", Urgency = "High", TicketType = "New Install" },
                new Ticket { TicketID = 12, Description = "Description goes here...", SolutionID = 4, DateOpened = Convert.ToDateTime("03/08/2014"), Status = "In Progress", Urgency = "High", TicketType = "New Install" },
                new Ticket { TicketID = 13, Description = "Description goes here...", SolutionID = 5, DateOpened = Convert.ToDateTime("03/08/2014"), Status = "In Progress", Urgency = "High", TicketType = "New Install" },
                new Ticket { TicketID = 14, Description = "Description goes here...", SolutionID = 5, DateOpened = Convert.ToDateTime("03/08/2014"), Status = "In Progress", Urgency = "High", TicketType = "New Install" },
                new Ticket { TicketID = 15, Description = "Description goes here...", SolutionID = 5, DateOpened = Convert.ToDateTime("03/08/2014"), Status = "In Progress", Urgency = "High", TicketType = "New Install" },
                new Ticket { TicketID = 16, Description = "Description goes here...", SolutionID = 6, DateOpened = Convert.ToDateTime("03/08/2014"), Status = "In Progress", Urgency = "High", TicketType = "New Install" },
                new Ticket { TicketID = 17, Description = "Description goes here...", SolutionID = 6, DateOpened = Convert.ToDateTime("03/08/2014"), Status = "In Progress", Urgency = "High", TicketType = "New Install" },
                new Ticket { TicketID = 18, Description = "Description goes here...", SolutionID = 6, DateOpened = Convert.ToDateTime("03/08/2014"), Status = "In Progress", Urgency = "High", TicketType = "New Install" },
                new Ticket { TicketID = 19, Description = "Description goes here...", SolutionID = 7, DateOpened = Convert.ToDateTime("03/08/2014"), Status = "In Progress", Urgency = "High", TicketType = "New Install" },
                new Ticket { TicketID = 20, Description = "Description goes here...", SolutionID = 7, DateOpened = Convert.ToDateTime("03/08/2014"), Status = "In Progress", Urgency = "High", TicketType = "New Install" },
                new Ticket { TicketID = 21, Description = "Description goes here...", SolutionID = 7, DateOpened = Convert.ToDateTime("03/08/2014"), Status = "In Progress", Urgency = "High", TicketType = "New Install" },
                new Ticket { TicketID = 22, Description = "Description goes here...", SolutionID = 8, DateOpened = Convert.ToDateTime("03/08/2014"), Status = "In Progress", Urgency = "High", TicketType = "New Install" },
                new Ticket { TicketID = 23, Description = "Description goes here...", SolutionID = 8, DateOpened = Convert.ToDateTime("03/08/2014"), Status = "In Progress", Urgency = "High", TicketType = "New Install" },
                new Ticket { TicketID = 24, Description = "Description goes here...", SolutionID = 8, DateOpened = Convert.ToDateTime("03/08/2014"), Status = "In Progress", Urgency = "High", TicketType = "New Install" },
                new Ticket { TicketID = 25, Description = "Description goes here...", SolutionID = 9, DateOpened = Convert.ToDateTime("03/08/2014"), Status = "In Progress", Urgency = "High", TicketType = "New Install" },
                new Ticket { TicketID = 26, Description = "Description goes here...", SolutionID = 9, DateOpened = Convert.ToDateTime("03/08/2014"), Status = "In Progress", Urgency = "High", TicketType = "New Install" },
                new Ticket { TicketID = 27, Description = "Description goes here...", SolutionID = 9, DateOpened = Convert.ToDateTime("03/08/2014"), Status = "In Progress", Urgency = "High", TicketType = "New Install" },
                new Ticket { TicketID = 28, Description = "Description goes here...", SolutionID = 10, DateOpened = Convert.ToDateTime("03/08/2014"), Status = "In Progress", Urgency = "High", TicketType = "New Install" },
                new Ticket { TicketID = 29, Description = "Description goes here...", SolutionID = 10, DateOpened = Convert.ToDateTime("03/08/2014"), Status = "In Progress", Urgency = "High", TicketType = "New Install" },
                new Ticket { TicketID = 30, Description = "Description goes here...", SolutionID = 10, DateOpened = Convert.ToDateTime("03/09/2016"), Status = "In Progress", Urgency = "High", TicketType = "New Install" }
                    );
        }

        private static void seedTicketNotes(ApplicationDbContext db)
        {
            db.TicketNotes.AddOrUpdate(
                v => v.TicketNoteID,
                new TicketNote { TicketNoteID = 1, UserID = "4", TicketID = 1, DateEntered = Convert.ToDateTime("04/05/2014"), Note = "This is the text for a ticket" },
                new TicketNote { TicketNoteID = 2, UserID = "4", TicketID = 1, DateEntered = Convert.ToDateTime("05/07/2014"), Note = "This is the text for a ticket" },
                new TicketNote { TicketNoteID = 3, UserID = "4", TicketID = 1, DateEntered = Convert.ToDateTime("05/07/2014"), Note = "This is the text for a ticket" },
                new TicketNote { TicketNoteID = 4, UserID = "4", TicketID = 2, DateEntered = Convert.ToDateTime("05/07/2014"), Note = "This is the text for a ticket" },
                new TicketNote { TicketNoteID = 5, UserID = "4", TicketID = 2, DateEntered = Convert.ToDateTime("05/07/2014"), Note = "This is the text for a ticket" },
                new TicketNote { TicketNoteID = 6, UserID = "5", TicketID = 2, DateEntered = Convert.ToDateTime("05/07/2014"), Note = "This is the text for a ticket" },
                new TicketNote { TicketNoteID = 7, UserID = "5", TicketID = 3, DateEntered = Convert.ToDateTime("05/07/2014"), Note = "This is the text for a ticket" },
                new TicketNote { TicketNoteID = 8, UserID = "5", TicketID = 3, DateEntered = Convert.ToDateTime("05/07/2014"), Note = "This is the text for a ticket" },
                new TicketNote { TicketNoteID = 9, UserID = "5", TicketID = 3, DateEntered = Convert.ToDateTime("05/07/2014"), Note = "This is the text for a ticket" },
                new TicketNote { TicketNoteID = 10, UserID = "5", TicketID = 4, DateEntered = Convert.ToDateTime("05/07/2014"), Note = "This is the text for a ticket" },
                new TicketNote { TicketNoteID = 11, UserID = "6", TicketID = 4, DateEntered = Convert.ToDateTime("05/07/2014"), Note = "This is the text for a ticket" },
                new TicketNote { TicketNoteID = 12, UserID = "6", TicketID = 4, DateEntered = Convert.ToDateTime("05/07/2014"), Note = "This is the text for a ticket" },
                new TicketNote { TicketNoteID = 13, UserID = "6", TicketID = 5, DateEntered = Convert.ToDateTime("05/07/2014"), Note = "This is the text for a ticket" },
                new TicketNote { TicketNoteID = 14, UserID = "6", TicketID = 5, DateEntered = Convert.ToDateTime("05/07/2014"), Note = "This is the text for a ticket" },
                new TicketNote { TicketNoteID = 15, UserID = "6", TicketID = 5, DateEntered = Convert.ToDateTime("04/05/2014"), Note = "This is the text for a ticket" }

                );
        }

        private static void seedSolutionNote(ApplicationDbContext db)
        {
            db.SolutionNotes.AddOrUpdate(
                x => x.SolutionNoteID,
                new SolutionNote { SolutionNoteID = 1, SolutionID = 4, DateEntered = Convert.ToDateTime("04/05/2014"), Note = "Text for this solution note goes here..." },
                new SolutionNote { SolutionNoteID = 2, SolutionID = 4, DateEntered = Convert.ToDateTime("05/05/2014"), Note = "Text for this solution note goes here..." },
                new SolutionNote { SolutionNoteID = 3, SolutionID = 4, DateEntered = Convert.ToDateTime("06/05/2014"), Note = "Text for this solution note goes here..." },
                new SolutionNote { SolutionNoteID = 4, SolutionID = 5, DateEntered = Convert.ToDateTime("04/05/2014"), Note = "Text for this solution note goes here..." },
                new SolutionNote { SolutionNoteID = 5, SolutionID = 6, DateEntered = Convert.ToDateTime("04/05/2014"), Note = "Text for this solution note goes here..." }
                );
        }

        private static void seedProjectNotes(ApplicationDbContext db)
        {
            db.ProjectNotes.AddOrUpdate(
                n => n.ProjectNoteID,
                new ProjectNote { ProjectNoteID = 1, ProjectID = 1, UserID = "3", DateEntered = Convert.ToDateTime("04/05/2014"), Note = "text for this project note goes here..." },
                new ProjectNote { ProjectNoteID = 2, ProjectID = 1, UserID = "3", DateEntered = Convert.ToDateTime("04/05/2014"), Note = "text for this project note goes here..." },
                new ProjectNote { ProjectNoteID = 3, ProjectID = 2, UserID = "3", DateEntered = Convert.ToDateTime("04/14/2014"), Note = "text for this project note goes here..." },
                new ProjectNote { ProjectNoteID = 4, ProjectID = 2, UserID = "3", DateEntered = Convert.ToDateTime("04/14/2014"), Note = "text for this project note goes here..." },
                new ProjectNote { ProjectNoteID = 5, ProjectID = 3, UserID = "3", DateEntered = Convert.ToDateTime("04/14/2014"), Note = "text for this project note goes here..." },
                new ProjectNote { ProjectNoteID = 6, ProjectID = 3, UserID = "3", DateEntered = Convert.ToDateTime("04/14/2014"), Note = "text for this project note goes here..." },
                new ProjectNote { ProjectNoteID = 7, ProjectID = 4, UserID = "3", DateEntered = Convert.ToDateTime("04/14/2014"), Note = "text for this project note goes here..." },
                new ProjectNote { ProjectNoteID = 8, ProjectID = 4, UserID = "3", DateEntered = Convert.ToDateTime("04/14/2014"), Note = "text for this project note goes here..." },
                new ProjectNote { ProjectNoteID = 9, ProjectID = 5, UserID = "3", DateEntered = Convert.ToDateTime("04/14/2014"), Note = "text for this project note goes here..." },
                new ProjectNote { ProjectNoteID = 9, ProjectID = 5, UserID = "3", DateEntered = Convert.ToDateTime("04/14/2014"), Note = "text for this project note goes here..." }
                );
        }

        private static void seedCustomerNote(ApplicationDbContext db)
        {
            db.CustomerNotes.AddOrUpdate(
                x => x.CustomerNoteID,
                new CustomerNote { CustomerNoteID = 1, UserID = Admin, DateEntered = Convert.ToDateTime("05/05/2014"), Note = "This is a note  about a customer" },
                new CustomerNote { CustomerNoteID = 2, UserID = Admin, DateEntered = Convert.ToDateTime("05/05/2014"), Note = "This is a note  about a customer" },
                new CustomerNote { CustomerNoteID = 3, UserID = Admin, DateEntered = Convert.ToDateTime("07/05/2014"), Note = "This is a note  about a customer" },
                new CustomerNote { CustomerNoteID = 4, UserID = User, DateEntered = Convert.ToDateTime("04/05/2014"), Note = "This is a note  about a customer" },
                new CustomerNote { CustomerNoteID = 5, UserID = User, DateEntered = Convert.ToDateTime("04/05/2014"), Note = "This is a note  about a customer" },
                new CustomerNote { CustomerNoteID = 6, UserID = User, DateEntered = Convert.ToDateTime("04/05/2014"), Note = "This is a note  about a customer" },
                new CustomerNote { CustomerNoteID = 7, UserID = User2, DateEntered = Convert.ToDateTime("04/05/2014"), Note = "This is a note  about a customer" },
                new CustomerNote { CustomerNoteID = 8, UserID = User2, DateEntered = Convert.ToDateTime("04/05/2014"), Note = "This is a note  about a customer" },
                new CustomerNote { CustomerNoteID = 9, UserID = User2, DateEntered = Convert.ToDateTime("04/05/2014"), Note = "This is a note  about a customer" },
                new CustomerNote { CustomerNoteID = 10, UserID = User2, DateEntered = Convert.ToDateTime("04/05/2014"), Note = "This is a note  about a customer" },
                new CustomerNote { CustomerNoteID = 11, UserID = User3, DateEntered = Convert.ToDateTime("04/05/2014"), Note = "This is a note  about a customer" },
                new CustomerNote { CustomerNoteID = 12, UserID = User3, DateEntered = Convert.ToDateTime("04/05/2014"), Note = "This is a note  about a customer" },
                new CustomerNote { CustomerNoteID = 13, UserID = User3, DateEntered = Convert.ToDateTime("04/05/2014"), Note = "This is a note  about a customer" },
                new CustomerNote { CustomerNoteID = 14, UserID = User3, DateEntered = Convert.ToDateTime("04/05/2014"), Note = "This is a note  about a customer" },
                new CustomerNote { CustomerNoteID = 15, UserID = User3, DateEntered = Convert.ToDateTime("04/05/2014"), Note = "This is a note  about a customer" }
                );
        }

        private static void seedSolutionHardware(ApplicationDbContext db)
        {
            db.Solution_Hardware.AddOrUpdate(x => x.ID,
                new Solution_Hardware { ID = 1, HardwareID = 1, SolutionID = 1, },
                new Solution_Hardware { ID = 1, HardwareID = 2, SolutionID = 2, },
                new Solution_Hardware { ID = 1, HardwareID = 3, SolutionID = 3, },
                new Solution_Hardware { ID = 1, HardwareID = 4, SolutionID = 4, },
                new Solution_Hardware { ID = 1, HardwareID = 5, SolutionID = 5, },
                new Solution_Hardware { ID = 1, HardwareID = 6, SolutionID = 6, },
                new Solution_Hardware { ID = 1, HardwareID = 7, SolutionID = 7, },
                new Solution_Hardware { ID = 1, HardwareID = 8, SolutionID = 8, },
                new Solution_Hardware { ID = 1, HardwareID = 9, SolutionID = 9, },
                new Solution_Hardware { ID = 1, HardwareID = 10, SolutionID = 10, }

                );
        }
    }
}