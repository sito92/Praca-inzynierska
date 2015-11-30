namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RelationsServiceTypesAndMenuButtons : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.MenuButtons", name: "Parent_Id", newName: "ParentId");
            RenameIndex(table: "dbo.MenuButtons", name: "IX_Parent_Id", newName: "IX_ParentId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.MenuButtons", name: "IX_ParentId", newName: "IX_Parent_Id");
            RenameColumn(table: "dbo.MenuButtons", name: "ParentId", newName: "Parent_Id");
        }
    }
}
