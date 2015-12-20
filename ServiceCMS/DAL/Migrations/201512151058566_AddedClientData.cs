namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedClientData : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.RegistratedServices", "ClientName", c => c.String());
            AddColumn("dbo.RegistratedServices", "ClientSurname", c => c.String());
            AddColumn("dbo.RegistratedServices", "ClientPhoneNumber", c => c.String());
            AddColumn("dbo.RegistratedServices", "ClientEmail", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.RegistratedServices", "ClientEmail");
            DropColumn("dbo.RegistratedServices", "ClientPhoneNumber");
            DropColumn("dbo.RegistratedServices", "ClientSurname");
            DropColumn("dbo.RegistratedServices", "ClientName");
        }
    }
}
