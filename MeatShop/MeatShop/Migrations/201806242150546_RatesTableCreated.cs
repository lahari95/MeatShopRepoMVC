namespace MeatShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RatesTableCreated : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Rates",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MeatTypeId = c.Int(nullable: false),
                        BoneCost = c.Decimal(nullable: false, precision: 18, scale: 2),
                        BonelessCost = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.MeatTypes", t => t.MeatTypeId, cascadeDelete: true)
                .Index(t => t.MeatTypeId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Rates", "MeatTypeId", "dbo.MeatTypes");
            DropIndex("dbo.Rates", new[] { "MeatTypeId" });
            DropTable("dbo.Rates");
        }
    }
}
