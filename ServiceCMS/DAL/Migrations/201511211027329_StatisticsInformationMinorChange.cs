namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class StatisticsInformationMinorChange : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.StatisticsInformations", "VisitsAmount");
            DropColumn("dbo.StatisticsInformations", "Country");
        }
        
        public override void Down()
        {
            AddColumn("dbo.StatisticsInformations", "Country", c => c.String());
            AddColumn("dbo.StatisticsInformations", "VisitsAmount", c => c.Int(nullable: false));
        }
    }
}
