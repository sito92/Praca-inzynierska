namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dunno : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.NewsletterReceivers", "Name");
            DropColumn("dbo.NewsletterReceivers", "Surname");
        }
        
        public override void Down()
        {
            AddColumn("dbo.NewsletterReceivers", "Surname", c => c.String());
            AddColumn("dbo.NewsletterReceivers", "Name", c => c.String());
        }
    }
}
