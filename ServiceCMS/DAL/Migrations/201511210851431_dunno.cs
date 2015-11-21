namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dunno : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.StatisticsInformations", "ControllerName", c => c.String());
            AddColumn("dbo.StatisticsInformations", "ActionName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.StatisticsInformations", "ActionName");
            DropColumn("dbo.StatisticsInformations", "ControllerName");
        }
    }
}
