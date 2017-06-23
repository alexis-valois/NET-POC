namespace NET_POC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.EBUserFinancialAccounts", "FinancialAccount_EBFinancialAccountID", "dbo.FinancialAccounts");
            DropIndex("dbo.FinancialAccounts", new[] { "EBFinancialAccountID" });
            DropIndex("dbo.EBUserFinancialAccounts", new[] { "FinancialAccount_EBFinancialAccountID" });
            RenameColumn(table: "dbo.EBUserFinancialAccounts", name: "FinancialAccount_EBFinancialAccountID", newName: "FinancialAccount_Id");
            DropPrimaryKey("dbo.FinancialAccounts");
            DropPrimaryKey("dbo.EBUserFinancialAccounts");
            AddColumn("dbo.FinancialAccounts", "Id", c => c.String(nullable: false, maxLength: 4000));
            AlterColumn("dbo.EBUserFinancialAccounts", "FinancialAccount_Id", c => c.String(nullable: false, maxLength: 4000));
            AddPrimaryKey("dbo.FinancialAccounts", "Id");
            AddPrimaryKey("dbo.EBUserFinancialAccounts", new[] { "EBUser_Id", "FinancialAccount_Id" });
            CreateIndex("dbo.FinancialAccounts", "Id");
            CreateIndex("dbo.EBUserFinancialAccounts", "FinancialAccount_Id");
            AddForeignKey("dbo.EBUserFinancialAccounts", "FinancialAccount_Id", "dbo.FinancialAccounts", "Id", cascadeDelete: true);
            DropColumn("dbo.FinancialAccounts", "EBFinancialAccountID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.FinancialAccounts", "EBFinancialAccountID", c => c.Long(nullable: false, identity: true));
            DropForeignKey("dbo.EBUserFinancialAccounts", "FinancialAccount_Id", "dbo.FinancialAccounts");
            DropIndex("dbo.EBUserFinancialAccounts", new[] { "FinancialAccount_Id" });
            DropIndex("dbo.FinancialAccounts", new[] { "Id" });
            DropPrimaryKey("dbo.EBUserFinancialAccounts");
            DropPrimaryKey("dbo.FinancialAccounts");
            AlterColumn("dbo.EBUserFinancialAccounts", "FinancialAccount_Id", c => c.Long(nullable: false));
            DropColumn("dbo.FinancialAccounts", "Id");
            AddPrimaryKey("dbo.EBUserFinancialAccounts", new[] { "EBUser_Id", "FinancialAccount_EBFinancialAccountID" });
            AddPrimaryKey("dbo.FinancialAccounts", "EBFinancialAccountID");
            RenameColumn(table: "dbo.EBUserFinancialAccounts", name: "FinancialAccount_Id", newName: "FinancialAccount_EBFinancialAccountID");
            CreateIndex("dbo.EBUserFinancialAccounts", "FinancialAccount_EBFinancialAccountID");
            CreateIndex("dbo.FinancialAccounts", "EBFinancialAccountID");
            AddForeignKey("dbo.EBUserFinancialAccounts", "FinancialAccount_EBFinancialAccountID", "dbo.FinancialAccounts", "EBFinancialAccountID", cascadeDelete: true);
        }
    }
}
