namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedColumnsToSettings : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Settings", "EmailPassword", c => c.String());
            AddColumn("dbo.Settings", "Salt", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Settings", "Salt");
            DropColumn("dbo.Settings", "EmailPassword");
        }
    }
}
