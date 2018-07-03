namespace MeatShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulatingMeatTypesAndDependentTables : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO MeatTypes (Name) VALUES ('Chicken')");
            Sql("INSERT INTO MeatTypes (Name) VALUES ('Beef')");
            Sql("INSERT INTO MeatTypes (Name) VALUES ('Fish')");
        }
        
        public override void Down()
        {
        }
    }
}
