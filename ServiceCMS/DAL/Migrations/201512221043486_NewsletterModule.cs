namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewsletterModule : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.NewsletterReceivers", "Name", c => c.String());
            AddColumn("dbo.NewsletterReceivers", "Surname", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.NewsletterReceivers", "Surname");
            DropColumn("dbo.NewsletterReceivers", "Name");
        }
    }
}
