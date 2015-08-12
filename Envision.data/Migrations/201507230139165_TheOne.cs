namespace Envision.data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TheOne : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.CustomerNotes", new[] { "ApplicationUser_Id" });
            DropColumn("dbo.CustomerNotes", "UserID");
            RenameColumn(table: "dbo.CustomerNotes", name: "ApplicationUser_Id", newName: "UserID");
            AlterColumn("dbo.CustomerNotes", "UserID", c => c.String(maxLength: 128));
            CreateIndex("dbo.CustomerNotes", "UserID");
        }
        
        public override void Down()
        {
            DropIndex("dbo.CustomerNotes", new[] { "UserID" });
            AlterColumn("dbo.CustomerNotes", "UserID", c => c.String());
            RenameColumn(table: "dbo.CustomerNotes", name: "UserID", newName: "ApplicationUser_Id");
            AddColumn("dbo.CustomerNotes", "UserID", c => c.String());
            CreateIndex("dbo.CustomerNotes", "ApplicationUser_Id");
        }
    }
}
