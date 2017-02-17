namespace PhoneCat.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addBattery3 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Phones", "Battery_Id", "dbo.Batteries");
            DropIndex("dbo.Phones", new[] { "Battery_Id" });
            AddColumn("dbo.Phones", "Battery_StandbyTime", c => c.Int(nullable: false));
            AddColumn("dbo.Phones", "Battery_TalkTime", c => c.Int(nullable: false));
            AddColumn("dbo.Phones", "Battery_Capacity", c => c.Int(nullable: false));
            DropColumn("dbo.Phones", "Battery_Id");
            DropTable("dbo.Batteries");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Batteries",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StandbyTime = c.Int(nullable: false),
                        TalkTime = c.Int(nullable: false),
                        Capacity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Phones", "Battery_Id", c => c.Int());
            DropColumn("dbo.Phones", "Battery_Capacity");
            DropColumn("dbo.Phones", "Battery_TalkTime");
            DropColumn("dbo.Phones", "Battery_StandbyTime");
            CreateIndex("dbo.Phones", "Battery_Id");
            AddForeignKey("dbo.Phones", "Battery_Id", "dbo.Batteries", "Id");
        }
    }
}
