namespace DedKorchma.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class album : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.T_Albums", "UrlPath", c => c.String(nullable: false, maxLength: 100));
            AddColumn("dbo.T_Albums", "Title", c => c.String());
            AddColumn("dbo.T_Albums", "Description", c => c.String());
            AddColumn("dbo.T_Albums", "Keywords", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.T_Albums", "Keywords");
            DropColumn("dbo.T_Albums", "Description");
            DropColumn("dbo.T_Albums", "Title");
            DropColumn("dbo.T_Albums", "UrlPath");
        }
    }
}
