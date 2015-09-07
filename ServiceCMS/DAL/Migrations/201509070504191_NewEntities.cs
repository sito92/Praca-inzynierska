namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewEntities : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.NewsCategories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Category = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.NewsletterReceivers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EmailAddress = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Settings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EmailAddress = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.NewsNewsCategories",
                c => new
                    {
                        News_Id = c.Int(nullable: false),
                        NewsCategory_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.News_Id, t.NewsCategory_Id })
                .ForeignKey("dbo.News", t => t.News_Id, cascadeDelete: true)
                .ForeignKey("dbo.NewsCategories", t => t.NewsCategory_Id, cascadeDelete: true)
                .Index(t => t.News_Id)
                .Index(t => t.NewsCategory_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.NewsNewsCategories", "NewsCategory_Id", "dbo.NewsCategories");
            DropForeignKey("dbo.NewsNewsCategories", "News_Id", "dbo.News");
            DropIndex("dbo.NewsNewsCategories", new[] { "NewsCategory_Id" });
            DropIndex("dbo.NewsNewsCategories", new[] { "News_Id" });
            DropTable("dbo.NewsNewsCategories");
            DropTable("dbo.Settings");
            DropTable("dbo.NewsletterReceivers");
            DropTable("dbo.NewsCategories");
        }
    }
}
