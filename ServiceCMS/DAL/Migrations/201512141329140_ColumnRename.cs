namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ColumnRename : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ServicePhases", "DelayInMinutes", c => c.Int(nullable: false));
            AddColumn("dbo.ServicePhases", "DurationInMinutes", c => c.Int(nullable: false));
            DropColumn("dbo.ServicePhases", "DelayInSeconds");
            DropColumn("dbo.ServicePhases", "DurationInSeconds");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ServicePhases", "DurationInSeconds", c => c.Int(nullable: false));
            AddColumn("dbo.ServicePhases", "DelayInSeconds", c => c.Int(nullable: false));
            DropColumn("dbo.ServicePhases", "DurationInMinutes");
            DropColumn("dbo.ServicePhases", "DelayInMinutes");
        }
    }
}
