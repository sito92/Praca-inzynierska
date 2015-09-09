namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedSettings : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DomainAndPorts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DomainName = c.String(),
                        DomainPort = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Settings", "EmailDomain", c => c.String());
            AddColumn("dbo.Settings", "DomainAndPorts_Id", c => c.Int(nullable: false));
            CreateIndex("dbo.Settings", "DomainAndPorts_Id");
            AddForeignKey("dbo.Settings", "DomainAndPorts_Id", "dbo.DomainAndPorts", "Id");
            DropColumn("dbo.Settings", "EmailPassword");
            DropColumn("dbo.Settings", "Salt");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Settings", "Salt", c => c.String());
            AddColumn("dbo.Settings", "EmailPassword", c => c.String());
            DropForeignKey("dbo.Settings", "DomainAndPorts_Id", "dbo.DomainAndPorts");
            DropIndex("dbo.Settings", new[] { "DomainAndPorts_Id" });
            DropColumn("dbo.Settings", "DomainAndPorts_Id");
            DropColumn("dbo.Settings", "EmailDomain");
            DropTable("dbo.DomainAndPorts");
        }
    }
}
