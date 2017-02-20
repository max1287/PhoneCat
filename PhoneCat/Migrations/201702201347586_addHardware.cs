namespace PhoneCat.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addHardware : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Processors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Usbs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Version = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Phones", "Hardware_Accelerometer", c => c.Boolean(nullable: false));
            AddColumn("dbo.Phones", "Hardware_FmRadio", c => c.Boolean(nullable: false));
            AddColumn("dbo.Phones", "Hardware_PhysicalKeyboard", c => c.Boolean(nullable: false));
            AddColumn("dbo.Phones", "Hardware_AudioJack", c => c.Double(nullable: false));
            AddColumn("dbo.Phones", "Processor_Id", c => c.Int());
            AddColumn("dbo.Phones", "Usb_Id", c => c.Int());
            CreateIndex("dbo.Phones", "Processor_Id");
            CreateIndex("dbo.Phones", "Usb_Id");
            AddForeignKey("dbo.Phones", "Processor_Id", "dbo.Processors", "Id");
            AddForeignKey("dbo.Phones", "Usb_Id", "dbo.Usbs", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Phones", "Usb_Id", "dbo.Usbs");
            DropForeignKey("dbo.Phones", "Processor_Id", "dbo.Processors");
            DropIndex("dbo.Phones", new[] { "Usb_Id" });
            DropIndex("dbo.Phones", new[] { "Processor_Id" });
            DropColumn("dbo.Phones", "Usb_Id");
            DropColumn("dbo.Phones", "Processor_Id");
            DropColumn("dbo.Phones", "Hardware_AudioJack");
            DropColumn("dbo.Phones", "Hardware_PhysicalKeyboard");
            DropColumn("dbo.Phones", "Hardware_FmRadio");
            DropColumn("dbo.Phones", "Hardware_Accelerometer");
            DropTable("dbo.Usbs");
            DropTable("dbo.Processors");
        }
    }
}
