namespace NET_POC.Migrations
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
                        EBFinancialAccountID = c.Long(nullable: false, identity: true),
                        BaseEntity_DateCreatedUtc = c.DateTime(nullable: false),
                        BaseEntity_DateDeletedUtc = c.DateTime(),
                        Type = c.Int(nullable: false),
                        AccountName = c.String(nullable: false, maxLength: 4000),
                        InitAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Currency = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.EBFinancialAccountID)
                .Index(t => t.EBFinancialAccountID)
                .Index(t => t.AccountName);
            
            CreateTable(
                "dbo.EBUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 4000),
                        BaseEntity_DateCreatedUtc = c.DateTime(nullable: false),
                        BaseEntity_DateDeletedUtc = c.DateTime(),
                        ActivationToken = c.String(maxLength: 4000),
                        CreationTimezone = c.String(maxLength: 4000),
                        FirstName = c.String(maxLength: 4000),
                        LastName = c.String(maxLength: 4000),
                        Enabled = c.Boolean(nullable: false),
                        LastLoginUtc = c.DateTime(),
                        LastLogoutUtc = c.DateTime(),
                        CredentialsExpired = c.Boolean(nullable: false),
                        AccountExpired = c.Boolean(nullable: false),
                        Email = c.String(maxLength: 4000),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(maxLength: 4000),
                        SecurityStamp = c.String(maxLength: 4000),
                        PhoneNumber = c.String(maxLength: 4000),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(maxLength: 4000),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IdentityUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        UserId = c.String(nullable: false, maxLength: 4000),
                        ClaimType = c.String(maxLength: 4000),
                        ClaimValue = c.String(maxLength: 4000),
                    })
                .PrimaryKey(t => new { t.Id, t.UserId })
                .ForeignKey("dbo.EBUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.IdentityUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 4000),
                        ProviderKey = c.String(nullable: false, maxLength: 4000),
                        UserId = c.String(nullable: false, maxLength: 4000),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.EBUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.IdentityUserRoles",
                c => new
                    {
                        RoleId = c.String(nullable: false, maxLength: 4000),
                        UserId = c.String(nullable: false, maxLength: 4000),
                    })
                .PrimaryKey(t => new { t.RoleId, t.UserId })
                .ForeignKey("dbo.EBUsers", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.IdentityRoles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.RoleId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.IdentityRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 4000),
                        Name = c.String(maxLength: 4000),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.EBUserFinancialAccounts",
                c => new
                    {
                        EBUser_Id = c.String(nullable: false, maxLength: 4000),
                        FinancialAccount_EBFinancialAccountID = c.Long(nullable: false),
                    })
                .PrimaryKey(t => new { t.EBUser_Id, t.FinancialAccount_EBFinancialAccountID })
                .ForeignKey("dbo.EBUsers", t => t.EBUser_Id, cascadeDelete: true)
                .ForeignKey("dbo.FinancialAccounts", t => t.FinancialAccount_EBFinancialAccountID, cascadeDelete: true)
                .Index(t => t.EBUser_Id)
                .Index(t => t.FinancialAccount_EBFinancialAccountID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.IdentityUserRoles", "RoleId", "dbo.IdentityRoles");
            DropForeignKey("dbo.IdentityUserRoles", "UserId", "dbo.EBUsers");
            DropForeignKey("dbo.IdentityUserLogins", "UserId", "dbo.EBUsers");
            DropForeignKey("dbo.EBUserFinancialAccounts", "FinancialAccount_EBFinancialAccountID", "dbo.FinancialAccounts");
            DropForeignKey("dbo.EBUserFinancialAccounts", "EBUser_Id", "dbo.EBUsers");
            DropForeignKey("dbo.IdentityUserClaims", "UserId", "dbo.EBUsers");
            DropIndex("dbo.EBUserFinancialAccounts", new[] { "FinancialAccount_EBFinancialAccountID" });
            DropIndex("dbo.EBUserFinancialAccounts", new[] { "EBUser_Id" });
            DropIndex("dbo.IdentityUserRoles", new[] { "UserId" });
            DropIndex("dbo.IdentityUserRoles", new[] { "RoleId" });
            DropIndex("dbo.IdentityUserLogins", new[] { "UserId" });
            DropIndex("dbo.IdentityUserClaims", new[] { "UserId" });
            DropIndex("dbo.FinancialAccounts", new[] { "AccountName" });
            DropIndex("dbo.FinancialAccounts", new[] { "EBFinancialAccountID" });
            DropTable("dbo.EBUserFinancialAccounts");
            DropTable("dbo.IdentityRoles");
            DropTable("dbo.IdentityUserRoles");
            DropTable("dbo.IdentityUserLogins");
            DropTable("dbo.IdentityUserClaims");
            DropTable("dbo.EBUsers");
            DropTable("dbo.FinancialAccounts");
        }
    }
}
