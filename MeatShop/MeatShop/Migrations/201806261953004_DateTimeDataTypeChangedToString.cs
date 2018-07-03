namespace MeatShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DateTimeDataTypeChangedToString : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Transactions", "DateTime", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Transactions", "DateTime", c => c.DateTime(nullable: false));
        }
    }
}
