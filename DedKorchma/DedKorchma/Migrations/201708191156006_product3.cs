namespace DedKorchma.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class product3 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.T_Categories", "UrlPath");
        }
        
        public override void Down()
        {
            AddColumn("dbo.T_Categories", "UrlPath", c => c.String());
        }
    }
}
