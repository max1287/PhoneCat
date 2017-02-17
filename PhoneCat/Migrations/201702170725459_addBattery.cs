namespace PhoneCat.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addBattery : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BatteryTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BatteryTypeName = c.String(),
                        Type = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Batteries",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StandbyTime = c.Int(nullable: false),
                        TalkTime = c.Int(nullable: false),
                        Capacity = c.Int(nullable: false),
                        Type_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.BatteryTypes", t => t.Type_Id)
                .Index(t => t.Type_Id);
            
            AddColumn("dbo.Phones", "Battery_Id", c => c.Int());
            CreateIndex("dbo.Phones", "Battery_Id");
            AddForeignKey("dbo.Phones", "Battery_Id", "dbo.Batteries", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Phones", "Battery_Id", "dbo.Batteries");
            DropForeignKey("dbo.Batteries", "Type_Id", "dbo.BatteryTypes");
            DropIndex("dbo.Phones", new[] { "Battery_Id" });
            DropIndex("dbo.Batteries", new[] { "Type_Id" });
            DropColumn("dbo.Phones", "Battery_Id");
            DropTable("dbo.Batteries");
            DropTable("dbo.BatteryTypes");
        }
    }
}
