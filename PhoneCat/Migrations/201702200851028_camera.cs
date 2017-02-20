namespace PhoneCat.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class camera : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CameraFeatures",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PhoneCameraFeatures",
                c => new
                    {
                        PhoneId = c.Int(nullable: false),
                        FeaturesId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.PhoneId, t.FeaturesId })
                .ForeignKey("dbo.Phones", t => t.PhoneId, cascadeDelete: true)
                .ForeignKey("dbo.CameraFeatures", t => t.FeaturesId, cascadeDelete: true)
                .Index(t => t.PhoneId)
                .Index(t => t.FeaturesId);
            
            AddColumn("dbo.Phones", "Camera_Primary", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PhoneCameraFeatures", "FeaturesId", "dbo.CameraFeatures");
            DropForeignKey("dbo.PhoneCameraFeatures", "PhoneId", "dbo.Phones");
            DropIndex("dbo.PhoneCameraFeatures", new[] { "FeaturesId" });
            DropIndex("dbo.PhoneCameraFeatures", new[] { "PhoneId" });
            DropColumn("dbo.Phones", "Camera_Primary");
            DropTable("dbo.PhoneCameraFeatures");
            DropTable("dbo.CameraFeatures");
        }
    }
}
