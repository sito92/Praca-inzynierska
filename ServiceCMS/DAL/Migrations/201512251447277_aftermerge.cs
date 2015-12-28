namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class aftermerge : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PopUps",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Content = c.String(),
                        Active = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Files", "Size", c => c.Long(nullable: false));
            AddColumn("dbo.Settings", "InputType", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Settings", "InputType");
            DropColumn("dbo.Files", "Size");
            DropTable("dbo.PopUps");
        }
    }
}
