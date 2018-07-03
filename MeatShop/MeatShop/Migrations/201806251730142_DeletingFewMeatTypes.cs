namespace MeatShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeletingFewMeatTypes : DbMigration
    {
        public override void Up()
        {
            Sql("DELETE FROM MeatTypes WHERE ID = 7 ");
        }
        
        public override void Down()
        {
        }
    }
}
