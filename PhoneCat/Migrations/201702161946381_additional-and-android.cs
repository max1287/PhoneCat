namespace PhoneCat.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class additionalandandroid : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AndroidOs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Version = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Androids",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Ui = c.String(),
                        Os_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AndroidOs", t => t.Os_Id)
                .Index(t => t.Os_Id);
            
            AddColumn("dbo.Phones", "AdditionalFeatures", c => c.String());
            AddColumn("dbo.Phones", "Android_Id", c => c.Int());
            CreateIndex("dbo.Phones", "Android_Id");
            AddForeignKey("dbo.Phones", "Android_Id", "dbo.Androids", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Phones", "Android_Id", "dbo.Androids");
            DropForeignKey("dbo.Androids", "Os_Id", "dbo.AndroidOs");
            DropIndex("dbo.Phones", new[] { "Android_Id" });
            DropIndex("dbo.Androids", new[] { "Os_Id" });
            DropColumn("dbo.Phones", "Android_Id");
            DropColumn("dbo.Phones", "AdditionalFeatures");
            DropTable("dbo.Androids");
            DropTable("dbo.AndroidOs");
        }
    }
}
