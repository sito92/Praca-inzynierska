namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewsWithRestoreProperties : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.News", "CreationTimeStamp", c => c.DateTime());
            AddColumn("dbo.News", "LastModifiedTimeStamp", c => c.DateTime());
            AddColumn("dbo.News", "RestoreNewsId", c => c.Int());
            CreateIndex("dbo.News", "RestoreNewsId");
            AddForeignKey("dbo.News", "RestoreNewsId", "dbo.News", "Id");
            DropColumn("dbo.News", "Date");
        }
        
        public override void Down()
        {
            AddColumn("dbo.News", "Date", c => c.DateTime(nullable: false));
            DropForeignKey("dbo.News", "RestoreNewsId", "dbo.News");
            DropIndex("dbo.News", new[] { "RestoreNewsId" });
            DropColumn("dbo.News", "RestoreNewsId");
            DropColumn("dbo.News", "LastModifiedTimeStamp");
            DropColumn("dbo.News", "CreationTimeStamp");
        }
    }
}
