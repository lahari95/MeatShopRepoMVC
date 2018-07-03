namespace MeatShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DateTimeDataTypeChangedToDateTime : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Transactions", "DateTime", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Transactions", "DateTime", c => c.String());
        }
    }
}
