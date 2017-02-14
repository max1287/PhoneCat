namespace PhoneCat.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addImages : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Images",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ImageUrl = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PhoneImage",
                c => new
                    {
                        PhoneID = c.Int(nullable: false),
                        ImageID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.PhoneID, t.ImageID })
                .ForeignKey("dbo.Images", t => t.PhoneID, cascadeDelete: true)
                .ForeignKey("dbo.Phones", t => t.ImageID, cascadeDelete: true)
                .Index(t => t.PhoneID)
                .Index(t => t.ImageID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PhoneImage", "ImageID", "dbo.Phones");
            DropForeignKey("dbo.PhoneImage", "PhoneID", "dbo.Images");
            DropIndex("dbo.PhoneImage", new[] { "ImageID" });
            DropIndex("dbo.PhoneImage", new[] { "PhoneID" });
            DropTable("dbo.PhoneImage");
            DropTable("dbo.Images");
        }
    }
}
