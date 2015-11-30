namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MenuButton : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MenuButtons",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Content = c.String(),
                        Parent_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.MenuButtons", t => t.Parent_Id)
                .Index(t => t.Parent_Id);
            
            AddColumn("dbo.Pages", "Content", c => c.String());
            AddColumn("dbo.Pages", "CreationTimeStamp", c => c.DateTime(nullable: false));
            AddColumn("dbo.Pages", "LastModifiedTimeStamp", c => c.DateTime(nullable: false));
            AddColumn("dbo.Pages", "ParentPage_Id", c => c.Int());
            CreateIndex("dbo.Pages", "ParentPage_Id");
            AddForeignKey("dbo.Pages", "ParentPage_Id", "dbo.Pages", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Pages", "ParentPage_Id", "dbo.Pages");
            DropForeignKey("dbo.MenuButtons", "Parent_Id", "dbo.MenuButtons");
            DropIndex("dbo.Pages", new[] { "ParentPage_Id" });
            DropIndex("dbo.MenuButtons", new[] { "Parent_Id" });
            DropColumn("dbo.Pages", "ParentPage_Id");
            DropColumn("dbo.Pages", "LastModifiedTimeStamp");
            DropColumn("dbo.Pages", "CreationTimeStamp");
            DropColumn("dbo.Pages", "Content");
            DropTable("dbo.MenuButtons");
        }
    }
}
