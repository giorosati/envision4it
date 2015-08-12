namespace Envision.data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class first : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TicketNotes", "UserID", c => c.String());
            AlterColumn("dbo.Hardwares", "Category", c => c.String());
            DropColumn("dbo.TicketNotes", "CustomerID");
            DropColumn("dbo.TicketNotes", "TechID");
            DropColumn("dbo.TicketNotes", "AdminID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.TicketNotes", "AdminID", c => c.String());
            AddColumn("dbo.TicketNotes", "TechID", c => c.String());
            AddColumn("dbo.TicketNotes", "CustomerID", c => c.String());
            AlterColumn("dbo.Hardwares", "Category", c => c.Int(nullable: false));
            DropColumn("dbo.TicketNotes", "UserID");
        }
    }
}
