namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class pageFile : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PageFiles",
                c => new
                    {
                        Page_Id = c.Int(nullable: false),
                        File_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Page_Id, t.File_Id })
                .ForeignKey("dbo.Pages", t => t.Page_Id, cascadeDelete: true)
                .ForeignKey("dbo.Files", t => t.File_Id, cascadeDelete: true)
                .Index(t => t.Page_Id)
                .Index(t => t.File_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PageFiles", "File_Id", "dbo.Files");
            DropForeignKey("dbo.PageFiles", "Page_Id", "dbo.Pages");
            DropIndex("dbo.PageFiles", new[] { "File_Id" });
            DropIndex("dbo.PageFiles", new[] { "Page_Id" });
            DropTable("dbo.PageFiles");
        }
    }
}
