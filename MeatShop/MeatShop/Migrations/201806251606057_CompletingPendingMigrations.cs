namespace MeatShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CompletingPendingMigrations : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Inventories", "MeatTypeId", "dbo.MeatTypes");
            DropIndex("dbo.Inventories", new[] { "MeatTypeId" });
            DropTable("dbo.Inventories");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Inventories",
                c => new
                    {
                        ItemId = c.Int(nullable: false, identity: true),
                        MeatTypeId = c.Int(nullable: false),
                        Quantity = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.ItemId);
            
            CreateIndex("dbo.Inventories", "MeatTypeId");
            AddForeignKey("dbo.Inventories", "MeatTypeId", "dbo.MeatTypes", "Id", cascadeDelete: true);
        }
    }
}
