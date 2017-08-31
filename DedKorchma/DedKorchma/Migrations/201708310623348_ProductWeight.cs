namespace DedKorchma.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ProductWeight : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.T_Products", "Weight", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.T_Products", "Weight");
        }
    }
}
