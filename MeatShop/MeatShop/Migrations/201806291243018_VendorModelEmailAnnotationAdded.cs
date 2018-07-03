namespace MeatShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class VendorModelEmailAnnotationAdded : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Vendors", "Email", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Vendors", "Email", c => c.String());
        }
    }
}
