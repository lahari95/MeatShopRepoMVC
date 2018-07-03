namespace MeatShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulatingRatesTable : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Rates (MeatTypeId,BoneCost,BonelessCost) VALUES (1,2.5,3.1)");
        }
        
        public override void Down()
        {
        }
    }
}
