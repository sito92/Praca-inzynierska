namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedPageToMenuButton : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MenuButtons", "PageId", c => c.Int());
            CreateIndex("dbo.MenuButtons", "PageId");
            AddForeignKey("dbo.MenuButtons", "PageId", "dbo.Pages", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MenuButtons", "PageId", "dbo.Pages");
            DropIndex("dbo.MenuButtons", new[] { "PageId" });
            DropColumn("dbo.MenuButtons", "PageId");
        }
    }
}
