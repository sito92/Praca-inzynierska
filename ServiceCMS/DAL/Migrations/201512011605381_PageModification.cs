namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PageModification : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Pages", name: "ParentPage_Id", newName: "RestorePageId");
            RenameIndex(table: "dbo.Pages", name: "IX_ParentPage_Id", newName: "IX_RestorePageId");
            AlterColumn("dbo.Pages", "CreationTimeStamp", c => c.DateTime());
            AlterColumn("dbo.Pages", "LastModifiedTimeStamp", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Pages", "LastModifiedTimeStamp", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Pages", "CreationTimeStamp", c => c.DateTime(nullable: false));
            RenameIndex(table: "dbo.Pages", name: "IX_RestorePageId", newName: "IX_ParentPage_Id");
            RenameColumn(table: "dbo.Pages", name: "RestorePageId", newName: "ParentPage_Id");
        }
    }
}
