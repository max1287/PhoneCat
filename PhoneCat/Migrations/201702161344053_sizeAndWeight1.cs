namespace PhoneCat.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class sizeAndWeight1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Phones", "SizeAndWeight_Height", c => c.Double(nullable: false));
            AlterColumn("dbo.Phones", "SizeAndWeight_Width", c => c.Double(nullable: false));
            AlterColumn("dbo.Phones", "SizeAndWeight_Depth", c => c.Double(nullable: false));
            AlterColumn("dbo.Phones", "SizeAndWeight_Weight", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Phones", "SizeAndWeight_Weight", c => c.Int(nullable: false));
            AlterColumn("dbo.Phones", "SizeAndWeight_Depth", c => c.Int(nullable: false));
            AlterColumn("dbo.Phones", "SizeAndWeight_Width", c => c.Int(nullable: false));
            AlterColumn("dbo.Phones", "SizeAndWeight_Height", c => c.Int(nullable: false));
        }
    }
}
