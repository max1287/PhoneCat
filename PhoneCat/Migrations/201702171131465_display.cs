namespace PhoneCat.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class display : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DisplayResolutions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Height = c.Int(nullable: false),
                        Width = c.Int(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Phones", "DisplayResolution_Id", c => c.Int());
            CreateIndex("dbo.Phones", "DisplayResolution_Id");
            AddForeignKey("dbo.Phones", "DisplayResolution_Id", "dbo.DisplayResolutions", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Phones", "DisplayResolution_Id", "dbo.DisplayResolutions");
            DropIndex("dbo.Phones", new[] { "DisplayResolution_Id" });
            DropColumn("dbo.Phones", "DisplayResolution_Id");
            DropTable("dbo.DisplayResolutions");
        }
    }
}
