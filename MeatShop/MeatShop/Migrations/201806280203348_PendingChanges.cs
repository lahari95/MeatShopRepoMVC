namespace MeatShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PendingChanges : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Consignments", "MeatTypeId", "dbo.MeatTypes");
            DropForeignKey("dbo.Consignments", "VendorId", "dbo.Vendors");
            DropIndex("dbo.Consignments", new[] { "VendorId" });
            DropIndex("dbo.Consignments", new[] { "MeatTypeId" });
            DropTable("dbo.Consignments");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Consignments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        VendorId = c.Int(nullable: false),
                        MeatTypeId = c.Int(nullable: false),
                        Quantity = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateIndex("dbo.Consignments", "MeatTypeId");
            CreateIndex("dbo.Consignments", "VendorId");
            AddForeignKey("dbo.Consignments", "VendorId", "dbo.Vendors", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Consignments", "MeatTypeId", "dbo.MeatTypes", "Id", cascadeDelete: true);
        }
    }
}
