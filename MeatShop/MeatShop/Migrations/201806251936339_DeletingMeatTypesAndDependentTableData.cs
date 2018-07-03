namespace MeatShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeletingMeatTypesAndDependentTableData : DbMigration
    {
        public override void Up()
        {
            Sql("DELETE FROM MeatTypes WHERE ID = 12 ");
            Sql("DELETE FROM MeatTypes WHERE ID = 13 ");
            Sql("DELETE FROM MeatTypes WHERE ID = 14 ");
        }
        
        public override void Down()
        {
        }
    }
}
