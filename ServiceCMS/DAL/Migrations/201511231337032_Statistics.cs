namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Statistics : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.StatisticsInformations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IP = c.String(),
                        Date = c.DateTime(nullable: false),
                        ControllerName = c.String(),
                        ActionName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.StatisticsInformations");
        }
    }
}
