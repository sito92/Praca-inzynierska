namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeletedAuthorFromNews : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.News", "AuthorId", "dbo.Users");
            DropIndex("dbo.News", new[] { "AuthorId" });
            DropColumn("dbo.News", "AuthorId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.News", "AuthorId", c => c.Int(nullable: false));
            CreateIndex("dbo.News", "AuthorId");
            AddForeignKey("dbo.News", "AuthorId", "dbo.Users", "Id", cascadeDelete: true);
        }
    }
}
