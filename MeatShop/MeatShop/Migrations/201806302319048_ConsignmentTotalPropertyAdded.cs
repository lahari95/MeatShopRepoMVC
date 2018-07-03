namespace MeatShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ConsignmentTotalPropertyAdded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Consignments", "AmountGiven", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Consignments", "AmountGiven");
        }
    }
}
