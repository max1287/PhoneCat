namespace PhoneCat.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class sizeAndWeight : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Phones", "SizeAndWeight_Height", c => c.Int(nullable: false));
            AddColumn("dbo.Phones", "SizeAndWeight_Width", c => c.Int(nullable: false));
            AddColumn("dbo.Phones", "SizeAndWeight_Depth", c => c.Int(nullable: false));
            AddColumn("dbo.Phones", "SizeAndWeight_Weight", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Phones", "SizeAndWeight_Weight");
            DropColumn("dbo.Phones", "SizeAndWeight_Depth");
            DropColumn("dbo.Phones", "SizeAndWeight_Width");
            DropColumn("dbo.Phones", "SizeAndWeight_Height");
        }
    }
}
