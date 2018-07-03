namespace MeatShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeletingMeatTypeRecords : DbMigration
    {
        public override void Up()
        {
            Sql("DELETE FROM MeatTypes WHERE Id = 4");
            Sql("DELETE FROM MeatTypes WHERE Id = 5");
            Sql("DELETE FROM MeatTypes WHERE Id = 6");
        }
        
        public override void Down()
        {
        }
    }
}
