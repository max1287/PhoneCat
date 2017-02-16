namespace PhoneCat.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class onetomany_images : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.PhoneImage", "PhoneID", "dbo.Phones");
            DropForeignKey("dbo.PhoneImage", "ImageID", "dbo.Images");
            DropIndex("dbo.PhoneImage", new[] { "PhoneID" });
            DropIndex("dbo.PhoneImage", new[] { "ImageID" });
            AddColumn("dbo.Images", "Phone_Id", c => c.Int());
            CreateIndex("dbo.Images", "Phone_Id");
            AddForeignKey("dbo.Images", "Phone_Id", "dbo.Phones", "Id");
            DropTable("dbo.PhoneImage");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.PhoneImage",
                c => new
                    {
                        PhoneID = c.Int(nullable: false),
                        ImageID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.PhoneID, t.ImageID });
            
            DropForeignKey("dbo.Images", "Phone_Id", "dbo.Phones");
            DropIndex("dbo.Images", new[] { "Phone_Id" });
            DropColumn("dbo.Images", "Phone_Id");
            CreateIndex("dbo.PhoneImage", "ImageID");
            CreateIndex("dbo.PhoneImage", "PhoneID");
            AddForeignKey("dbo.PhoneImage", "ImageID", "dbo.Images", "Id", cascadeDelete: true);
            AddForeignKey("dbo.PhoneImage", "PhoneID", "dbo.Phones", "Id", cascadeDelete: true);
        }
    }
}
