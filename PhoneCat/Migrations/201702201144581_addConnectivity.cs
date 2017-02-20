namespace PhoneCat.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addConnectivity : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Blueteeth",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Version = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Wifis",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PhoneWifi",
                c => new
                    {
                        PhoneId = c.Int(nullable: false),
                        WifiId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.PhoneId, t.WifiId })
                .ForeignKey("dbo.Phones", t => t.PhoneId, cascadeDelete: true)
                .ForeignKey("dbo.Wifis", t => t.WifiId, cascadeDelete: true)
                .Index(t => t.PhoneId)
                .Index(t => t.WifiId);
            
            AddColumn("dbo.Phones", "Connectivity_Gps", c => c.Boolean(nullable: false));
            AddColumn("dbo.Phones", "Connectivity_Infrared", c => c.Boolean(nullable: false));
            AddColumn("dbo.Phones", "Connectivity_Cell", c => c.String());
            AddColumn("dbo.Phones", "Bluetooth_Id", c => c.Int());
            CreateIndex("dbo.Phones", "Bluetooth_Id");
            AddForeignKey("dbo.Phones", "Bluetooth_Id", "dbo.Blueteeth", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PhoneWifi", "WifiId", "dbo.Wifis");
            DropForeignKey("dbo.PhoneWifi", "PhoneId", "dbo.Phones");
            DropForeignKey("dbo.Phones", "Bluetooth_Id", "dbo.Blueteeth");
            DropIndex("dbo.PhoneWifi", new[] { "WifiId" });
            DropIndex("dbo.PhoneWifi", new[] { "PhoneId" });
            DropIndex("dbo.Phones", new[] { "Bluetooth_Id" });
            DropColumn("dbo.Phones", "Bluetooth_Id");
            DropColumn("dbo.Phones", "Connectivity_Cell");
            DropColumn("dbo.Phones", "Connectivity_Infrared");
            DropColumn("dbo.Phones", "Connectivity_Gps");
            DropTable("dbo.PhoneWifi");
            DropTable("dbo.Wifis");
            DropTable("dbo.Blueteeth");
        }
    }
}
