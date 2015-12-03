namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SettingsMigration : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Settings", "DomainAndPorts_Id", "dbo.DomainAndPorts");
            DropIndex("dbo.Settings", new[] { "DomainAndPorts_Id" });
            AddColumn("dbo.Settings", "Name", c => c.String());
            AddColumn("dbo.Settings", "Value", c => c.String());
            DropColumn("dbo.Settings", "EmailAddress");
            DropColumn("dbo.Settings", "EmailDomain");
            DropColumn("dbo.Settings", "DomainAndPorts_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Settings", "DomainAndPorts_Id", c => c.Int(nullable: false));
            AddColumn("dbo.Settings", "EmailDomain", c => c.String());
            AddColumn("dbo.Settings", "EmailAddress", c => c.String());
            DropColumn("dbo.Settings", "Value");
            DropColumn("dbo.Settings", "Name");
            CreateIndex("dbo.Settings", "DomainAndPorts_Id");
            AddForeignKey("dbo.Settings", "DomainAndPorts_Id", "dbo.DomainAndPorts", "Id");
        }
    }
}
