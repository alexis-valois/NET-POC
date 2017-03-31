namespace NET_POC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.EBAuthorities",
                c => new
                    {
                        EBAuthorityID = c.Long(nullable: false, identity: true),
                        BaseEntity_DateCreated = c.DateTime(nullable: false),
                        BaseEntity_DateCreatedTimezone = c.String(nullable: false, maxLength: 4000),
                        BaseEntity_DateDeleted = c.DateTime(),
                        BaseEntity_DateDeletedTimezone = c.String(maxLength: 4000),
                        BaseEntity_Deleted = c.Boolean(nullable: false),
                        Role = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.EBAuthorityID)
                .Index(t => t.EBAuthorityID);
            
            CreateTable(
                "dbo.EBUsers",
                c => new
                    {
                        EBUserID = c.Long(nullable: false, identity: true),
                        Username = c.String(nullable: false, maxLength: 4000),
                        Email = c.String(nullable: false, maxLength: 4000),
                        ActivationToken = c.String(maxLength: 4000),
                        FirstName = c.String(maxLength: 4000),
                        LastName = c.String(maxLength: 4000),
                        Password = c.String(maxLength: 4000),
                        Enabled = c.Boolean(nullable: false),
                        LastLogin = c.DateTime(),
                        LastLoginTimezone = c.String(maxLength: 4000),
                        LastLogout = c.DateTime(),
                        LastLogoutTimezone = c.String(maxLength: 4000),
                        Locked = c.Boolean(nullable: false),
                        CredentialsExpired = c.Boolean(nullable: false),
                        AccountExpired = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.EBUserID)
                .Index(t => t.EBUserID)
                .Index(t => t.Username, unique: true)
                .Index(t => t.Email);
            
            CreateTable(
                "dbo.FinancialAccounts",
                c => new
                    {
                        EBFinancialAccountID = c.Long(nullable: false, identity: true),
                        BaseEntity_DateCreated = c.DateTime(nullable: false),
                        BaseEntity_DateCreatedTimezone = c.String(nullable: false, maxLength: 4000),
                        BaseEntity_DateDeleted = c.DateTime(),
                        BaseEntity_DateDeletedTimezone = c.String(maxLength: 4000),
                        BaseEntity_Deleted = c.Boolean(nullable: false),
                        Type = c.Int(nullable: false),
                        AccountName = c.String(nullable: false, maxLength: 4000),
                        InitAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Currency = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.EBFinancialAccountID)
                .Index(t => t.EBFinancialAccountID)
                .Index(t => t.AccountName);
            
            CreateTable(
                "dbo.EBUserEBAuthorities",
                c => new
                    {
                        EBUser_EBUserID = c.Long(nullable: false),
                        EBAuthority_EBAuthorityID = c.Long(nullable: false),
                    })
                .PrimaryKey(t => new { t.EBUser_EBUserID, t.EBAuthority_EBAuthorityID })
                .ForeignKey("dbo.EBUsers", t => t.EBUser_EBUserID, cascadeDelete: true)
                .ForeignKey("dbo.EBAuthorities", t => t.EBAuthority_EBAuthorityID, cascadeDelete: true)
                .Index(t => t.EBUser_EBUserID)
                .Index(t => t.EBAuthority_EBAuthorityID);
            
            CreateTable(
                "dbo.FinancialAccountEBUsers",
                c => new
                    {
                        FinancialAccount_EBFinancialAccountID = c.Long(nullable: false),
                        EBUser_EBUserID = c.Long(nullable: false),
                    })
                .PrimaryKey(t => new { t.FinancialAccount_EBFinancialAccountID, t.EBUser_EBUserID })
                .ForeignKey("dbo.FinancialAccounts", t => t.FinancialAccount_EBFinancialAccountID, cascadeDelete: true)
                .ForeignKey("dbo.EBUsers", t => t.EBUser_EBUserID, cascadeDelete: true)
                .Index(t => t.FinancialAccount_EBFinancialAccountID)
                .Index(t => t.EBUser_EBUserID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.FinancialAccountEBUsers", "EBUser_EBUserID", "dbo.EBUsers");
            DropForeignKey("dbo.FinancialAccountEBUsers", "FinancialAccount_EBFinancialAccountID", "dbo.FinancialAccounts");
            DropForeignKey("dbo.EBUserEBAuthorities", "EBAuthority_EBAuthorityID", "dbo.EBAuthorities");
            DropForeignKey("dbo.EBUserEBAuthorities", "EBUser_EBUserID", "dbo.EBUsers");
            DropIndex("dbo.FinancialAccountEBUsers", new[] { "EBUser_EBUserID" });
            DropIndex("dbo.FinancialAccountEBUsers", new[] { "FinancialAccount_EBFinancialAccountID" });
            DropIndex("dbo.EBUserEBAuthorities", new[] { "EBAuthority_EBAuthorityID" });
            DropIndex("dbo.EBUserEBAuthorities", new[] { "EBUser_EBUserID" });
            DropIndex("dbo.FinancialAccounts", new[] { "AccountName" });
            DropIndex("dbo.FinancialAccounts", new[] { "EBFinancialAccountID" });
            DropIndex("dbo.EBUsers", new[] { "Email" });
            DropIndex("dbo.EBUsers", new[] { "Username" });
            DropIndex("dbo.EBUsers", new[] { "EBUserID" });
            DropIndex("dbo.EBAuthorities", new[] { "EBAuthorityID" });
            DropTable("dbo.FinancialAccountEBUsers");
            DropTable("dbo.EBUserEBAuthorities");
            DropTable("dbo.FinancialAccounts");
            DropTable("dbo.EBUsers");
            DropTable("dbo.EBAuthorities");
        }
    }
}
