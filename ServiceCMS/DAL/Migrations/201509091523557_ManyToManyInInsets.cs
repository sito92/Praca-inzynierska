namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ManyToManyInInsets : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.InsetArguments", "Inset_Id", "dbo.Insets");
            DropIndex("dbo.InsetArguments", new[] { "Inset_Id" });
            CreateTable(
                "dbo.InsetInsetArguments",
                c => new
                    {
                        Inset_Id = c.Int(nullable: false),
                        InsetArgument_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Inset_Id, t.InsetArgument_Id })
                .ForeignKey("dbo.Insets", t => t.Inset_Id, cascadeDelete: true)
                .ForeignKey("dbo.InsetArguments", t => t.InsetArgument_Id, cascadeDelete: true)
                .Index(t => t.Inset_Id)
                .Index(t => t.InsetArgument_Id);
            
            DropColumn("dbo.InsetArguments", "Inset_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.InsetArguments", "Inset_Id", c => c.Int());
            DropForeignKey("dbo.InsetInsetArguments", "InsetArgument_Id", "dbo.InsetArguments");
            DropForeignKey("dbo.InsetInsetArguments", "Inset_Id", "dbo.Insets");
            DropIndex("dbo.InsetInsetArguments", new[] { "InsetArgument_Id" });
            DropIndex("dbo.InsetInsetArguments", new[] { "Inset_Id" });
            DropTable("dbo.InsetInsetArguments");
            CreateIndex("dbo.InsetArguments", "Inset_Id");
            AddForeignKey("dbo.InsetArguments", "Inset_Id", "dbo.Insets", "Id");
        }
    }
}
