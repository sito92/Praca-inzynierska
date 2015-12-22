namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedOrderToMenuButton : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MenuButtons", "Order", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.MenuButtons", "Order");
        }
    }
}
