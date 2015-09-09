namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedInsetAndArguments : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.InsetArguments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        IsRequierd = c.Boolean(nullable: false),
                        ArgumentType = c.Byte(nullable: false),
                        Inset_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Insets", t => t.Inset_Id)
                .Index(t => t.Inset_Id);
            
            CreateTable(
                "dbo.Insets",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.InsetArguments", "Inset_Id", "dbo.Insets");
            DropIndex("dbo.InsetArguments", new[] { "Inset_Id" });
            DropTable("dbo.Insets");
            DropTable("dbo.InsetArguments");
        }
    }
}
