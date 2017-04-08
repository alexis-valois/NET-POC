namespace NET_POC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Identity : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.EBUserEBAuthorities", "EBUser_EBUserID", "dbo.EBUsers");
            DropForeignKey("dbo.EBUserEBAuthorities", "EBAuthority_EBAuthorityID", "dbo.EBAuthorities");
            DropIndex("dbo.EBAuthorities", new[] { "EBAuthorityID" });
            DropIndex("dbo.EBUsers", new[] { "Username" });
            DropIndex("dbo.EBUsers", new[] { "Email" });
            DropIndex("dbo.EBUserEBAuthorities", new[] { "EBUser_EBUserID" });
            DropIndex("dbo.EBUserEBAuthorities", new[] { "EBAuthority_EBAuthorityID" });
            CreateTable(
                "dbo.EBRoles",
                c => new
                    {
                        EBAuthorityID = c.Long(nullable: false, identity: true),
                        BaseEntity_DateCreated = c.DateTime(nullable: false),
                        BaseEntity_DateCreatedTimezone = c.String(nullable: false, maxLength: 4000),
                        BaseEntity_DateDeleted = c.DateTime(),
                        BaseEntity_DateDeletedTimezone = c.String(maxLength: 4000),
                        BaseEntity_Deleted = c.Boolean(nullable: false),
                        Id = c.Int(nullable: false),
                        Name = c.String(maxLength: 4000),
                    })
                .PrimaryKey(t => t.EBAuthorityID)
                .Index(t => t.EBAuthorityID);
            
            CreateTable(
                "dbo.EBUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BaseEntity_DateCreated = c.DateTime(nullable: false),
                        BaseEntity_DateCreatedTimezone = c.String(nullable: false, maxLength: 4000),
                        BaseEntity_DateDeleted = c.DateTime(),
                        BaseEntity_DateDeletedTimezone = c.String(maxLength: 4000),
                        BaseEntity_Deleted = c.Boolean(nullable: false),
                        UserId = c.Int(nullable: false),
                        ClaimType = c.String(maxLength: 4000),
                        ClaimValue = c.String(maxLength: 4000),
                        EBUser_EBUserID = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.EBUsers", t => t.EBUser_EBUserID)
                .Index(t => t.EBUser_EBUserID);
            
            CreateTable(
                "dbo.EBUserLogins",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BaseEntity_DateCreated = c.DateTime(nullable: false),
                        BaseEntity_DateCreatedTimezone = c.String(nullable: false, maxLength: 4000),
                        BaseEntity_DateDeleted = c.DateTime(),
                        BaseEntity_DateDeletedTimezone = c.String(maxLength: 4000),
                        BaseEntity_Deleted = c.Boolean(nullable: false),
                        LoginProvider = c.String(maxLength: 4000),
                        ProviderKey = c.String(maxLength: 4000),
                        UserId = c.Int(nullable: false),
                        EBUser_EBUserID = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.EBUsers", t => t.EBUser_EBUserID)
                .Index(t => t.EBUser_EBUserID);
            
            CreateTable(
                "dbo.EBUserRoles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BaseEntity_DateCreated = c.DateTime(nullable: false),
                        BaseEntity_DateCreatedTimezone = c.String(nullable: false, maxLength: 4000),
                        BaseEntity_DateDeleted = c.DateTime(),
                        BaseEntity_DateDeletedTimezone = c.String(maxLength: 4000),
                        BaseEntity_Deleted = c.Boolean(nullable: false),
                        UserId = c.Int(nullable: false),
                        RoleId = c.Int(nullable: false),
                        EBUser_EBUserID = c.Long(),
                        EBRole_EBAuthorityID = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.EBUsers", t => t.EBUser_EBUserID)
                .ForeignKey("dbo.EBRoles", t => t.EBRole_EBAuthorityID)
                .Index(t => t.EBUser_EBUserID)
                .Index(t => t.EBRole_EBAuthorityID);
            
            AddColumn("dbo.EBUsers", "EmailConfirmed", c => c.Boolean(nullable: false));
            AddColumn("dbo.EBUsers", "PasswordHash", c => c.String(maxLength: 4000));
            AddColumn("dbo.EBUsers", "SecurityStamp", c => c.String(maxLength: 4000));
            AddColumn("dbo.EBUsers", "PhoneNumber", c => c.String(maxLength: 4000));
            AddColumn("dbo.EBUsers", "PhoneNumberConfirmed", c => c.Boolean(nullable: false));
            AddColumn("dbo.EBUsers", "TwoFactorEnabled", c => c.Boolean(nullable: false));
            AddColumn("dbo.EBUsers", "LockoutEndDateUtc", c => c.DateTime());
            AddColumn("dbo.EBUsers", "LockoutEnabled", c => c.Boolean(nullable: false));
            AddColumn("dbo.EBUsers", "AccessFailedCount", c => c.Int(nullable: false));
            AddColumn("dbo.EBUsers", "Id", c => c.Int(nullable: false));
            AddColumn("dbo.EBUsers", "EBRole_EBAuthorityID", c => c.Long());
            AlterColumn("dbo.EBUsers", "UserName", c => c.String(maxLength: 4000));
            AlterColumn("dbo.EBUsers", "Email", c => c.String(maxLength: 4000));
            CreateIndex("dbo.EBUsers", "EBRole_EBAuthorityID");
            AddForeignKey("dbo.EBUsers", "EBRole_EBAuthorityID", "dbo.EBRoles", "EBAuthorityID");
            DropTable("dbo.EBAuthorities");
            DropTable("dbo.EBUserEBAuthorities");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.EBUserEBAuthorities",
                c => new
                    {
                        EBUser_EBUserID = c.Long(nullable: false),
                        EBAuthority_EBAuthorityID = c.Long(nullable: false),
                    })
                .PrimaryKey(t => new { t.EBUser_EBUserID, t.EBAuthority_EBAuthorityID });
            
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
                .PrimaryKey(t => t.EBAuthorityID);
            
            DropForeignKey("dbo.EBUserRoles", "EBRole_EBAuthorityID", "dbo.EBRoles");
            DropForeignKey("dbo.EBUsers", "EBRole_EBAuthorityID", "dbo.EBRoles");
            DropForeignKey("dbo.EBUserRoles", "EBUser_EBUserID", "dbo.EBUsers");
            DropForeignKey("dbo.EBUserLogins", "EBUser_EBUserID", "dbo.EBUsers");
            DropForeignKey("dbo.EBUserClaims", "EBUser_EBUserID", "dbo.EBUsers");
            DropIndex("dbo.EBUserRoles", new[] { "EBRole_EBAuthorityID" });
            DropIndex("dbo.EBUserRoles", new[] { "EBUser_EBUserID" });
            DropIndex("dbo.EBUserLogins", new[] { "EBUser_EBUserID" });
            DropIndex("dbo.EBUserClaims", new[] { "EBUser_EBUserID" });
            DropIndex("dbo.EBUsers", new[] { "EBRole_EBAuthorityID" });
            DropIndex("dbo.EBRoles", new[] { "EBAuthorityID" });
            AlterColumn("dbo.EBUsers", "Email", c => c.String(nullable: false, maxLength: 4000));
            AlterColumn("dbo.EBUsers", "UserName", c => c.String(nullable: false, maxLength: 4000));
            DropColumn("dbo.EBUsers", "EBRole_EBAuthorityID");
            DropColumn("dbo.EBUsers", "Id");
            DropColumn("dbo.EBUsers", "AccessFailedCount");
            DropColumn("dbo.EBUsers", "LockoutEnabled");
            DropColumn("dbo.EBUsers", "LockoutEndDateUtc");
            DropColumn("dbo.EBUsers", "TwoFactorEnabled");
            DropColumn("dbo.EBUsers", "PhoneNumberConfirmed");
            DropColumn("dbo.EBUsers", "PhoneNumber");
            DropColumn("dbo.EBUsers", "SecurityStamp");
            DropColumn("dbo.EBUsers", "PasswordHash");
            DropColumn("dbo.EBUsers", "EmailConfirmed");
            DropTable("dbo.EBUserRoles");
            DropTable("dbo.EBUserLogins");
            DropTable("dbo.EBUserClaims");
            DropTable("dbo.EBRoles");
            CreateIndex("dbo.EBUserEBAuthorities", "EBAuthority_EBAuthorityID");
            CreateIndex("dbo.EBUserEBAuthorities", "EBUser_EBUserID");
            CreateIndex("dbo.EBUsers", "Email");
            CreateIndex("dbo.EBUsers", "Username", unique: true);
            CreateIndex("dbo.EBAuthorities", "EBAuthorityID");
            AddForeignKey("dbo.EBUserEBAuthorities", "EBAuthority_EBAuthorityID", "dbo.EBAuthorities", "EBAuthorityID", cascadeDelete: true);
            AddForeignKey("dbo.EBUserEBAuthorities", "EBUser_EBUserID", "dbo.EBUsers", "EBUserID", cascadeDelete: true);
        }
    }
}
