namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ServiceRelations : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ServiceTypes", "ServiceProvider_Id", "dbo.ServiceProviders");
            DropIndex("dbo.ServiceTypes", new[] { "ServiceProvider_Id" });
            CreateTable(
                "dbo.ServiceProviderServiceTypes",
                c => new
                    {
                        ServiceProvider_Id = c.Int(nullable: false),
                        ServiceType_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ServiceProvider_Id, t.ServiceType_Id })
                .ForeignKey("dbo.ServiceProviders", t => t.ServiceProvider_Id, cascadeDelete: true)
                .ForeignKey("dbo.ServiceTypes", t => t.ServiceType_Id, cascadeDelete: true)
                .Index(t => t.ServiceProvider_Id)
                .Index(t => t.ServiceType_Id);
            
            DropColumn("dbo.ServiceTypes", "ServiceProvider_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ServiceTypes", "ServiceProvider_Id", c => c.Int());
            DropForeignKey("dbo.ServiceProviderServiceTypes", "ServiceType_Id", "dbo.ServiceTypes");
            DropForeignKey("dbo.ServiceProviderServiceTypes", "ServiceProvider_Id", "dbo.ServiceProviders");
            DropIndex("dbo.ServiceProviderServiceTypes", new[] { "ServiceType_Id" });
            DropIndex("dbo.ServiceProviderServiceTypes", new[] { "ServiceProvider_Id" });
            DropTable("dbo.ServiceProviderServiceTypes");
            CreateIndex("dbo.ServiceTypes", "ServiceProvider_Id");
            AddForeignKey("dbo.ServiceTypes", "ServiceProvider_Id", "dbo.ServiceProviders", "Id");
        }
    }
}
