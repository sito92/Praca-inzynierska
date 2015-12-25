namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedTypeToSetting : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Settings", "InputType", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Settings", "InputType");
        }
    }
}
