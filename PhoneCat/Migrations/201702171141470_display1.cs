namespace PhoneCat.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class display1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Phones", "Display_ScreenSize", c => c.Double(nullable: false));
            AddColumn("dbo.Phones", "Display_TouchScreen", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Phones", "Display_TouchScreen");
            DropColumn("dbo.Phones", "Display_ScreenSize");
        }
    }
}
