namespace DedKorchma.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class bigNews : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.T_News", "Name", c => c.String(nullable: false));
            AddColumn("dbo.T_News", "ShortDescription", c => c.String(nullable: false));
            AddColumn("dbo.T_News", "HeadImage", c => c.String(nullable: false));
            AddColumn("dbo.T_News", "IsDeleted", c => c.Boolean(nullable: false));
            AddColumn("dbo.T_News", "UrlPath", c => c.String(nullable: false));
            AddColumn("dbo.T_News", "Description", c => c.String());
            AddColumn("dbo.T_News", "H1", c => c.String(nullable: false));
            AlterColumn("dbo.T_News", "Body", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.T_News", "Body", c => c.String());
            DropColumn("dbo.T_News", "H1");
            DropColumn("dbo.T_News", "Description");
            DropColumn("dbo.T_News", "UrlPath");
            DropColumn("dbo.T_News", "IsDeleted");
            DropColumn("dbo.T_News", "HeadImage");
            DropColumn("dbo.T_News", "ShortDescription");
            DropColumn("dbo.T_News", "Name");
        }
    }
}
