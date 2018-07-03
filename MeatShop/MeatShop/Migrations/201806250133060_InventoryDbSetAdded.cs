namespace MeatShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InventoryDbSetAdded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Inventories",
                c => new
                    {
                        ItemId = c.Int(nullable: false, identity: true),
                        MeatTypeId = c.Int(nullable: false),
                        Quantity = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.ItemId)
                .ForeignKey("dbo.MeatTypes", t => t.MeatTypeId, cascadeDelete: true)
                .Index(t => t.MeatTypeId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Inventories", "MeatTypeId", "dbo.MeatTypes");
            DropIndex("dbo.Inventories", new[] { "MeatTypeId" });
            DropTable("dbo.Inventories");
        }
    }
}
