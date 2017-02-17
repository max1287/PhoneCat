namespace PhoneCat.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addBattery1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Batteries", "Type_Id", "dbo.BatteryTypes");
            DropIndex("dbo.Batteries", new[] { "Type_Id" });
            AddColumn("dbo.Phones", "BatteryType_Id", c => c.Int());
            CreateIndex("dbo.Phones", "BatteryType_Id");
            AddForeignKey("dbo.Phones", "BatteryType_Id", "dbo.BatteryTypes", "Id");
            DropColumn("dbo.Batteries", "Type_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Batteries", "Type_Id", c => c.Int());
            DropForeignKey("dbo.Phones", "BatteryType_Id", "dbo.BatteryTypes");
            DropIndex("dbo.Phones", new[] { "BatteryType_Id" });
            DropColumn("dbo.Phones", "BatteryType_Id");
            CreateIndex("dbo.Batteries", "Type_Id");
            AddForeignKey("dbo.Batteries", "Type_Id", "dbo.BatteryTypes", "Id");
        }
    }
}
