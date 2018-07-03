namespace MeatShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InHouseInventoryDbSetCreated : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.InHouseInventories",
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
            DropForeignKey("dbo.InHouseInventories", "MeatTypeId", "dbo.MeatTypes");
            DropIndex("dbo.InHouseInventories", new[] { "MeatTypeId" });
            DropTable("dbo.InHouseInventories");
        }
    }
}
