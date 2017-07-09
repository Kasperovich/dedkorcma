namespace DedKorchma.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.T_AlbumPhotos",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AlbumId = c.Int(),
                        PhotoId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.T_Albums", t => t.AlbumId)
                .ForeignKey("dbo.T_Photos", t => t.PhotoId)
                .Index(t => t.AlbumId)
                .Index(t => t.PhotoId);
            
            CreateTable(
                "dbo.T_Albums",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NameOfAlbum = c.String(nullable: false),
                        DateCreated = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.T_Photos",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Path = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.T_Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NameOfCategory = c.String(nullable: false),
                        NameOfCategoryLat = c.String(),
                        Title = c.String(),
                        Description = c.String(),
                        H1 = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.T_Products",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NameOfProduct = c.String(nullable: false),
                        Description = c.String(),
                        HeadImage = c.String(),
                        Price = c.Double(nullable: false),
                        Discount = c.Int(),
                        IsVisible = c.Boolean(nullable: false),
                        CategoryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.T_Categories", t => t.CategoryId)
                .Index(t => t.CategoryId);
            
            CreateTable(
                "dbo.T_News",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false),
                        Body = c.String(),
                        DateCreated = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.T_Roles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.T_UserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.T_Roles", t => t.RoleId)
                .ForeignKey("dbo.T_Users", t => t.UserId)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.T_Users",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        IsDeleted = c.Boolean(nullable: false),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.T_UserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.T_Users", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.T_UserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.T_Users", t => t.UserId)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.T_UserRoles", "UserId", "dbo.T_Users");
            DropForeignKey("dbo.T_UserLogins", "UserId", "dbo.T_Users");
            DropForeignKey("dbo.T_UserClaims", "UserId", "dbo.T_Users");
            DropForeignKey("dbo.T_UserRoles", "RoleId", "dbo.T_Roles");
            DropForeignKey("dbo.T_Products", "CategoryId", "dbo.T_Categories");
            DropForeignKey("dbo.T_AlbumPhotos", "PhotoId", "dbo.T_Photos");
            DropForeignKey("dbo.T_AlbumPhotos", "AlbumId", "dbo.T_Albums");
            DropIndex("dbo.T_UserLogins", new[] { "UserId" });
            DropIndex("dbo.T_UserClaims", new[] { "UserId" });
            DropIndex("dbo.T_Users", "UserNameIndex");
            DropIndex("dbo.T_UserRoles", new[] { "RoleId" });
            DropIndex("dbo.T_UserRoles", new[] { "UserId" });
            DropIndex("dbo.T_Roles", "RoleNameIndex");
            DropIndex("dbo.T_Products", new[] { "CategoryId" });
            DropIndex("dbo.T_AlbumPhotos", new[] { "PhotoId" });
            DropIndex("dbo.T_AlbumPhotos", new[] { "AlbumId" });
            DropTable("dbo.T_UserLogins");
            DropTable("dbo.T_UserClaims");
            DropTable("dbo.T_Users");
            DropTable("dbo.T_UserRoles");
            DropTable("dbo.T_Roles");
            DropTable("dbo.T_News");
            DropTable("dbo.T_Products");
            DropTable("dbo.T_Categories");
            DropTable("dbo.T_Photos");
            DropTable("dbo.T_Albums");
            DropTable("dbo.T_AlbumPhotos");
        }
    }
}
