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
                        Id = c.Int(nullable: false, identity: true),
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
                        EBRole_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.EBRoles", t => t.EBRole_Id)
                .Index(t => t.EBRole_Id);
            
            CreateTable(
                "dbo.EBUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BaseEntity_DateCreatedUtc = c.DateTime(nullable: false),
                        BaseEntity_DateDeletedUtc = c.DateTime(),
                        UserId = c.Int(nullable: false),
                        ClaimType = c.String(maxLength: 4000),
                        ClaimValue = c.String(maxLength: 4000),
                        EBUser_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.EBUsers", t => t.EBUser_Id)
                .Index(t => t.EBUser_Id);
            
            CreateTable(
                "dbo.EBUserLogins",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BaseEntity_DateCreatedUtc = c.DateTime(nullable: false),
                        BaseEntity_DateDeletedUtc = c.DateTime(),
                        LoginProvider = c.String(maxLength: 4000),
                        ProviderKey = c.String(maxLength: 4000),
                        UserId = c.Int(nullable: false),
                        EBUser_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.EBUsers", t => t.EBUser_Id)
                .Index(t => t.EBUser_Id);
            
            CreateTable(
                "dbo.EBUserRoles",
                c => new
                    {
                        UserRoleId = c.Int(nullable: false, identity: true),
                        BaseEntity_DateCreatedUtc = c.DateTime(nullable: false),
                        BaseEntity_DateDeletedUtc = c.DateTime(),
                        UserId = c.Int(nullable: false),
                        RoleId = c.Int(nullable: false),
                        EBUser_Id = c.Int(),
                        EBRole_Id = c.Int(),
                    })
                .PrimaryKey(t => t.UserRoleId)
                .ForeignKey("dbo.EBUsers", t => t.EBUser_Id)
                .ForeignKey("dbo.EBRoles", t => t.EBRole_Id)
                .Index(t => t.EBUser_Id)
                .Index(t => t.EBRole_Id);
            
            CreateTable(
                "dbo.EBRoles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BaseEntity_DateCreatedUtc = c.DateTime(nullable: false),
                        BaseEntity_DateDeletedUtc = c.DateTime(),
                        Name = c.String(maxLength: 4000),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.EBUserFinancialAccounts",
                c => new
                    {
                        EBUser_Id = c.Int(nullable: false),
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
            DropForeignKey("dbo.EBUserRoles", "EBRole_Id", "dbo.EBRoles");
            DropForeignKey("dbo.EBUsers", "EBRole_Id", "dbo.EBRoles");
            DropForeignKey("dbo.EBUserRoles", "EBUser_Id", "dbo.EBUsers");
            DropForeignKey("dbo.EBUserLogins", "EBUser_Id", "dbo.EBUsers");
            DropForeignKey("dbo.EBUserFinancialAccounts", "FinancialAccount_EBFinancialAccountID", "dbo.FinancialAccounts");
            DropForeignKey("dbo.EBUserFinancialAccounts", "EBUser_Id", "dbo.EBUsers");
            DropForeignKey("dbo.EBUserClaims", "EBUser_Id", "dbo.EBUsers");
            DropIndex("dbo.EBUserFinancialAccounts", new[] { "FinancialAccount_EBFinancialAccountID" });
            DropIndex("dbo.EBUserFinancialAccounts", new[] { "EBUser_Id" });
            DropIndex("dbo.EBUserRoles", new[] { "EBRole_Id" });
            DropIndex("dbo.EBUserRoles", new[] { "EBUser_Id" });
            DropIndex("dbo.EBUserLogins", new[] { "EBUser_Id" });
            DropIndex("dbo.EBUserClaims", new[] { "EBUser_Id" });
            DropIndex("dbo.EBUsers", new[] { "EBRole_Id" });
            DropIndex("dbo.FinancialAccounts", new[] { "AccountName" });
            DropIndex("dbo.FinancialAccounts", new[] { "EBFinancialAccountID" });
            DropTable("dbo.EBUserFinancialAccounts");
            DropTable("dbo.EBRoles");
            DropTable("dbo.EBUserRoles");
            DropTable("dbo.EBUserLogins");
            DropTable("dbo.EBUserClaims");
            DropTable("dbo.EBUsers");
            DropTable("dbo.FinancialAccounts");
        }
    }
}
