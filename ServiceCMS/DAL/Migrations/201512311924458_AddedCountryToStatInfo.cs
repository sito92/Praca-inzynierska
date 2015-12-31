namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedCountryToStatInfo : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.StatisticsInformations", "Country", c => c.String());
        }
        
        public override void Down()
        {          
            DropColumn("dbo.StatisticsInformations", "Country");
        }
    }
}
