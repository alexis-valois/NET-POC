namespace NET_POC.Migrations.EBContext
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.FinancialAccounts",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 4000),
                        BaseEntity_DateCreatedUtc = c.DateTime(nullable: false),
                        BaseEntity_DateDeletedUtc = c.DateTime(),
                        Type = c.Int(nullable: false),
                        AccountName = c.String(nullable: false, maxLength: 4000),
                        InitAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Currency = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Id)
                .Index(t => t.AccountName);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.FinancialAccounts", new[] { "AccountName" });
            DropIndex("dbo.FinancialAccounts", new[] { "Id" });
            DropTable("dbo.FinancialAccounts");
        }
    }
}
