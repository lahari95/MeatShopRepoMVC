namespace MeatShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemovedTransactionDbSet : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.Transactions");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Transactions",
                c => new
                    {
                        TransactionId = c.String(nullable: false, maxLength: 128),
                        MeatTypeName = c.String(),
                        BoneOption = c.Boolean(nullable: false),
                        Quantity = c.Double(nullable: false),
                        Total = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.TransactionId);
            
        }
    }
}
