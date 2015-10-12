namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ServiceEntities : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.RegistratedServices",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StartDate = c.DateTime(nullable: false),
                        ServiceTypeId = c.Int(nullable: false),
                        ServiceProviderId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ServiceProviders", t => t.ServiceProviderId, cascadeDelete: true)
                .ForeignKey("dbo.ServiceTypes", t => t.ServiceTypeId, cascadeDelete: true)
                .Index(t => t.ServiceTypeId)
                .Index(t => t.ServiceProviderId);
            
            CreateTable(
                "dbo.ServiceProviders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ServiceTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        DurationInSeconds = c.Int(nullable: false),
                        ServiceProvider_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ServiceProviders", t => t.ServiceProvider_Id)
                .Index(t => t.ServiceProvider_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.RegistratedServices", "ServiceTypeId", "dbo.ServiceTypes");
            DropForeignKey("dbo.RegistratedServices", "ServiceProviderId", "dbo.ServiceProviders");
            DropForeignKey("dbo.ServiceTypes", "ServiceProvider_Id", "dbo.ServiceProviders");
            DropIndex("dbo.ServiceTypes", new[] { "ServiceProvider_Id" });
            DropIndex("dbo.RegistratedServices", new[] { "ServiceProviderId" });
            DropIndex("dbo.RegistratedServices", new[] { "ServiceTypeId" });
            DropTable("dbo.ServiceTypes");
            DropTable("dbo.ServiceProviders");
            DropTable("dbo.RegistratedServices");
        }
    }
}
