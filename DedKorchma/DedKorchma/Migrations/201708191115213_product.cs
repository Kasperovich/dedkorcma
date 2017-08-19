namespace DedKorchma.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class product : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.T_Categories", "UrlPath", c => c.String());
            AddColumn("dbo.T_Products", "UrlPath", c => c.String());
            AddColumn("dbo.T_Products", "Title", c => c.String());
            AddColumn("dbo.T_Products", "H1", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.T_Products", "H1");
            DropColumn("dbo.T_Products", "Title");
            DropColumn("dbo.T_Products", "UrlPath");
            DropColumn("dbo.T_Categories", "UrlPath");
        }
    }
}
