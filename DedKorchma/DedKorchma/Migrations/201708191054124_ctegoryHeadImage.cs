namespace DedKorchma.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ctegoryHeadImage : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.T_Categories", "HeadImage", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.T_Categories", "HeadImage");
        }
    }
}
