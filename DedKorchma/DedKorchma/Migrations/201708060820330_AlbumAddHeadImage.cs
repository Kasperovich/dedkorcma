namespace DedKorchma.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AlbumAddHeadImage : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.T_Albums", "HeadImage", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.T_Albums", "HeadImage");
        }
    }
}
