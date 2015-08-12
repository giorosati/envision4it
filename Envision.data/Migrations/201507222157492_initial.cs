namespace Envision.data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CustomerContacts",
                c => new
                    {
                        CustomerContactID = c.Int(nullable: false, identity: true),
                        UserID = c.String(),
                        Name = c.String(),
                        Department = c.String(),
                        Title = c.String(),
                        MobileNumber = c.Int(nullable: false),
                        WorkNumber = c.Int(nullable: false),
                        FaxNumber = c.Int(nullable: false),
                        Skype = c.String(),
                        Email = c.String(),
                        DateDeleted = c.DateTime(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.CustomerContactID)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.CustomerNotes",
                c => new
                    {
                        CustomerNoteID = c.Int(nullable: false, identity: true),
                        DateEntered = c.DateTime(nullable: false),
                        DateDeleted = c.DateTime(),
                        Note = c.String(),
                        UserID = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.CustomerNoteID)
                .ForeignKey("dbo.AspNetUsers", t => t.UserID)
                .Index(t => t.UserID);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                        Company = c.String(),
                        Address1 = c.String(),
                        Address2 = c.String(),
                        City = c.String(),
                        State = c.String(),
                        Zip = c.Int(nullable: false),
                        Phone = c.Int(nullable: false),
                        Fax = c.Int(nullable: false),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.ProjectNotes",
                c => new
                    {
                        ProjectNoteID = c.Int(nullable: false, identity: true),
                        ProjectID = c.Int(nullable: false),
                        Note = c.String(),
                        UserID = c.String(),
                        DateEntered = c.DateTime(nullable: false),
                        DateDeleted = c.DateTime(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.ProjectNoteID)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id)
                .ForeignKey("dbo.Projects", t => t.ProjectID, cascadeDelete: true)
                .Index(t => t.ProjectID)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.Projects",
                c => new
                    {
                        ProjectID = c.Int(nullable: false, identity: true),
                        UserID = c.String(),
                        StartDate = c.DateTime(nullable: false),
                        DateDeleted = c.DateTime(),
                        ProjectName = c.String(),
                        TargetDate = c.DateTime(),
                        CompletionDate = c.DateTime(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.ProjectID)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.Solutions",
                c => new
                    {
                        SolutionID = c.Int(nullable: false, identity: true),
                        SolutionName = c.String(),
                        ProjectID = c.Int(nullable: false),
                        StartDate = c.DateTime(nullable: false),
                        TargetCompletionDate = c.DateTime(),
                        DateDeleted = c.DateTime(),
                        Urgency = c.String(),
                    })
                .PrimaryKey(t => t.SolutionID)
                .ForeignKey("dbo.Projects", t => t.ProjectID, cascadeDelete: true)
                .Index(t => t.ProjectID);
            
            CreateTable(
                "dbo.Solution_Hardware",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        SolutionID = c.Int(nullable: false),
                        HardwareID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Hardwares", t => t.HardwareID, cascadeDelete: true)
                .ForeignKey("dbo.Solutions", t => t.SolutionID, cascadeDelete: true)
                .Index(t => t.SolutionID)
                .Index(t => t.HardwareID);
            
            CreateTable(
                "dbo.Hardwares",
                c => new
                    {
                        HardwareID = c.Int(nullable: false, identity: true),
                        HardwareName = c.String(),
                        Notes = c.String(),
                        Category = c.String(),
                        DateDeleted = c.DateTime(),
                    })
                .PrimaryKey(t => t.HardwareID);
            
            CreateTable(
                "dbo.Documents",
                c => new
                    {
                        DocumentID = c.Int(nullable: false, identity: true),
                        HardwareID = c.Int(nullable: false),
                        Name = c.String(),
                        Description = c.String(),
                        Filepath = c.String(),
                        Url = c.String(),
                        DateDeleted = c.DateTime(),
                    })
                .PrimaryKey(t => t.DocumentID)
                .ForeignKey("dbo.Hardwares", t => t.HardwareID, cascadeDelete: true)
                .Index(t => t.HardwareID);
            
            CreateTable(
                "dbo.FAQs",
                c => new
                    {
                        FaqID = c.Int(nullable: false, identity: true),
                        HardwareID = c.Int(nullable: false),
                        Topic = c.String(),
                        Question = c.String(),
                        Answer = c.String(),
                        DateDeleted = c.DateTime(),
                    })
                .PrimaryKey(t => t.FaqID)
                .ForeignKey("dbo.Hardwares", t => t.HardwareID, cascadeDelete: true)
                .Index(t => t.HardwareID);
            
            CreateTable(
                "dbo.SolutionNotes",
                c => new
                    {
                        SolutionNoteID = c.Int(nullable: false, identity: true),
                        SolutionID = c.Int(nullable: false),
                        Note = c.String(),
                        DateEntered = c.DateTime(nullable: false),
                        DateDeleted = c.DateTime(),
                        AdminID = c.String(),
                        TechID = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.SolutionNoteID)
                .ForeignKey("dbo.Solutions", t => t.SolutionID, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id)
                .Index(t => t.SolutionID)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.Tickets",
                c => new
                    {
                        TicketID = c.Int(nullable: false, identity: true),
                        SolutionID = c.Int(nullable: false),
                        UserID = c.String(maxLength: 128),
                        DateOpened = c.DateTime(nullable: false),
                        DateClosed = c.DateTime(),
                        DateDeleted = c.DateTime(),
                        Status = c.String(),
                        Urgency = c.String(),
                        TicketType = c.String(),
                    })
                .PrimaryKey(t => t.TicketID)
                .ForeignKey("dbo.Solutions", t => t.SolutionID, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserID)
                .Index(t => t.SolutionID)
                .Index(t => t.UserID);
            
            CreateTable(
                "dbo.TicketNotes",
                c => new
                    {
                        TicketNoteID = c.Int(nullable: false, identity: true),
                        TicketID = c.Int(nullable: false),
                        DateEntered = c.DateTime(nullable: false),
                        DateDeleted = c.DateTime(),
                        Note = c.String(),
                        UserID = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.TicketNoteID)
                .ForeignKey("dbo.Tickets", t => t.TicketID, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id)
                .Index(t => t.TicketID)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.TicketNotes", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.SolutionNotes", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Projects", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Tickets", "UserID", "dbo.AspNetUsers");
            DropForeignKey("dbo.TicketNotes", "TicketID", "dbo.Tickets");
            DropForeignKey("dbo.Tickets", "SolutionID", "dbo.Solutions");
            DropForeignKey("dbo.SolutionNotes", "SolutionID", "dbo.Solutions");
            DropForeignKey("dbo.Solution_Hardware", "SolutionID", "dbo.Solutions");
            DropForeignKey("dbo.Solution_Hardware", "HardwareID", "dbo.Hardwares");
            DropForeignKey("dbo.FAQs", "HardwareID", "dbo.Hardwares");
            DropForeignKey("dbo.Documents", "HardwareID", "dbo.Hardwares");
            DropForeignKey("dbo.Solutions", "ProjectID", "dbo.Projects");
            DropForeignKey("dbo.ProjectNotes", "ProjectID", "dbo.Projects");
            DropForeignKey("dbo.ProjectNotes", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.CustomerNotes", "UserID", "dbo.AspNetUsers");
            DropForeignKey("dbo.CustomerContacts", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.TicketNotes", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.TicketNotes", new[] { "TicketID" });
            DropIndex("dbo.Tickets", new[] { "UserID" });
            DropIndex("dbo.Tickets", new[] { "SolutionID" });
            DropIndex("dbo.SolutionNotes", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.SolutionNotes", new[] { "SolutionID" });
            DropIndex("dbo.FAQs", new[] { "HardwareID" });
            DropIndex("dbo.Documents", new[] { "HardwareID" });
            DropIndex("dbo.Solution_Hardware", new[] { "HardwareID" });
            DropIndex("dbo.Solution_Hardware", new[] { "SolutionID" });
            DropIndex("dbo.Solutions", new[] { "ProjectID" });
            DropIndex("dbo.Projects", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.ProjectNotes", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.ProjectNotes", new[] { "ProjectID" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.CustomerNotes", new[] { "UserID" });
            DropIndex("dbo.CustomerContacts", new[] { "ApplicationUser_Id" });
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.TicketNotes");
            DropTable("dbo.Tickets");
            DropTable("dbo.SolutionNotes");
            DropTable("dbo.FAQs");
            DropTable("dbo.Documents");
            DropTable("dbo.Hardwares");
            DropTable("dbo.Solution_Hardware");
            DropTable("dbo.Solutions");
            DropTable("dbo.Projects");
            DropTable("dbo.ProjectNotes");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.CustomerNotes");
            DropTable("dbo.CustomerContacts");
        }
    }
}
