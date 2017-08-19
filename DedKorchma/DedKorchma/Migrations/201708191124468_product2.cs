namespace DedKorchma.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class product2 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.T_Products", "Title");
            DropColumn("dbo.T_Products", "Description");
            DropColumn("dbo.T_Products", "H1");
        }
        
        public override void Down()
        {
            AddColumn("dbo.T_Products", "H1", c => c.String());
            AddColumn("dbo.T_Products", "Description", c => c.String());
            AddColumn("dbo.T_Products", "Title", c => c.String());
        }
    }
}
