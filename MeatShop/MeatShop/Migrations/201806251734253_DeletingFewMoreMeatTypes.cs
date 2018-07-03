namespace MeatShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeletingFewMoreMeatTypes : DbMigration
    {
        public override void Up()
        {
            Sql("DELETE FROM MeatTypes WHERE ID = 6 ");
            Sql("DELETE FROM MeatTypes WHERE ID = 5 ");
            Sql("DELETE FROM MeatTypes WHERE ID = 8 ");
            Sql("DELETE FROM MeatTypes WHERE ID = 9 ");
        }
        
        public override void Down()
        {
        }
    }
}
