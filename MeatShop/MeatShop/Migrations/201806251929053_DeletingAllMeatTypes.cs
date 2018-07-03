namespace MeatShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeletingAllMeatTypes : DbMigration
    {
        public override void Up()
        {
            Sql("DELETE FROM MeatTypes WHERE Id = 1");
            Sql("DELETE FROM MeatTypes WHERE Id = 2");
            Sql("DELETE FROM MeatTypes WHERE Id = 3");
            Sql("DELETE FROM MeatTypes WHERE Id = 4");
            Sql("DELETE FROM MeatTypes WHERE Id = 10");
            Sql("DELETE FROM MeatTypes WHERE Id = 11");
        }
        
        public override void Down()
        {
        }
    }
}
