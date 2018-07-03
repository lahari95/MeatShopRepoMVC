namespace MeatShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ConsignmentTableCreated : DbMigration
    {
        public override void Up()
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
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.MeatTypes", t => t.MeatTypeId, cascadeDelete: true)
                .ForeignKey("dbo.Vendors", t => t.VendorId, cascadeDelete: true)
                .Index(t => t.VendorId)
                .Index(t => t.MeatTypeId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Consignments", "VendorId", "dbo.Vendors");
            DropForeignKey("dbo.Consignments", "MeatTypeId", "dbo.MeatTypes");
            DropIndex("dbo.Consignments", new[] { "MeatTypeId" });
            DropIndex("dbo.Consignments", new[] { "VendorId" });
            DropTable("dbo.Consignments");
        }
    }
}
