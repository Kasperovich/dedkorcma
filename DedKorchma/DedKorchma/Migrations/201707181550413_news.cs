namespace DedKorchma.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class news : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.T_News", "Name", c => c.String());
            AlterColumn("dbo.T_News", "ShortDescription", c => c.String());
            AlterColumn("dbo.T_News", "Body", c => c.String());
            AlterColumn("dbo.T_News", "HeadImage", c => c.String());
            AlterColumn("dbo.T_News", "UrlPath", c => c.String());
            AlterColumn("dbo.T_News", "Title", c => c.String());
            AlterColumn("dbo.T_News", "H1", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.T_News", "H1", c => c.String(nullable: false));
            AlterColumn("dbo.T_News", "Title", c => c.String(nullable: false));
            AlterColumn("dbo.T_News", "UrlPath", c => c.String(nullable: false));
            AlterColumn("dbo.T_News", "HeadImage", c => c.String(nullable: false));
            AlterColumn("dbo.T_News", "Body", c => c.String(nullable: false));
            AlterColumn("dbo.T_News", "ShortDescription", c => c.String(nullable: false));
            AlterColumn("dbo.T_News", "Name", c => c.String(nullable: false));
        }
    }
}
