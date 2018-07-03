namespace MeatShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DateAddedToConsignmentModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Consignments", "DateTime", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Consignments", "DateTime");
        }
    }
}
