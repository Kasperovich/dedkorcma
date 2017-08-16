namespace DedKorchma.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class deletePhoto : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.T_AlbumPhotos", "PhotoId", "dbo.T_Photos");
            DropIndex("dbo.T_AlbumPhotos", new[] { "PhotoId" });
            AddColumn("dbo.T_AlbumPhotos", "Path", c => c.String());
            DropColumn("dbo.T_AlbumPhotos", "PhotoId");
            DropTable("dbo.T_Photos");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.T_Photos",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Path = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.T_AlbumPhotos", "PhotoId", c => c.Int(nullable: false));
            DropColumn("dbo.T_AlbumPhotos", "Path");
            CreateIndex("dbo.T_AlbumPhotos", "PhotoId");
            AddForeignKey("dbo.T_AlbumPhotos", "PhotoId", "dbo.T_Photos", "Id");
        }
    }
}
