namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SettingsWithoutId : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Settings");
            AlterColumn("dbo.Settings", "Name", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.Settings", "Name");
            DropColumn("dbo.Settings", "Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Settings", "Id", c => c.Int(nullable: false, identity: true));
            DropPrimaryKey("dbo.Settings");
            AlterColumn("dbo.Settings", "Name", c => c.String());
            AddPrimaryKey("dbo.Settings", "Id");
        }
    }
}
