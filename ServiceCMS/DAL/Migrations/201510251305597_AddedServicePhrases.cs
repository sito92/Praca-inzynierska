namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedServicePhrases : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ServicePhrases",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        DelayInSeconds = c.Int(nullable: false),
                        DurationInSeconds = c.Int(nullable: false),
                        Order = c.Int(nullable: false),
                        ServiceTypeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ServiceTypes", t => t.ServiceTypeId, cascadeDelete: true)
                .Index(t => t.ServiceTypeId);
            
            DropColumn("dbo.ServiceTypes", "DurationInSeconds");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ServiceTypes", "DurationInSeconds", c => c.Int(nullable: false));
            DropForeignKey("dbo.ServicePhrases", "ServiceTypeId", "dbo.ServiceTypes");
            DropIndex("dbo.ServicePhrases", new[] { "ServiceTypeId" });
            DropTable("dbo.ServicePhrases");
        }
    }
}
