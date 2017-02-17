namespace PhoneCat.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fixAndroid : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Androids", "Os_Id", "dbo.AndroidOs");
            DropForeignKey("dbo.Phones", "Android_Id", "dbo.Androids");
            DropIndex("dbo.Androids", new[] { "Os_Id" });
            DropIndex("dbo.Phones", new[] { "Android_Id" });
            CreateTable(
                "dbo.AndroidUis",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Phones", "AndroidOs_Id", c => c.Int());
            AddColumn("dbo.Phones", "AndroidUi_Id", c => c.Int());
            CreateIndex("dbo.Phones", "AndroidOs_Id");
            CreateIndex("dbo.Phones", "AndroidUi_Id");
            AddForeignKey("dbo.Phones", "AndroidOs_Id", "dbo.AndroidOs", "Id");
            AddForeignKey("dbo.Phones", "AndroidUi_Id", "dbo.AndroidUis", "Id");
            DropColumn("dbo.Phones", "Android_Id");
            DropTable("dbo.Androids");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Androids",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Ui = c.String(),
                        Os_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Phones", "Android_Id", c => c.Int());
            DropForeignKey("dbo.Phones", "AndroidUi_Id", "dbo.AndroidUis");
            DropForeignKey("dbo.Phones", "AndroidOs_Id", "dbo.AndroidOs");
            DropIndex("dbo.Phones", new[] { "AndroidUi_Id" });
            DropIndex("dbo.Phones", new[] { "AndroidOs_Id" });
            DropColumn("dbo.Phones", "AndroidUi_Id");
            DropColumn("dbo.Phones", "AndroidOs_Id");
            DropTable("dbo.AndroidUis");
            CreateIndex("dbo.Phones", "Android_Id");
            CreateIndex("dbo.Androids", "Os_Id");
            AddForeignKey("dbo.Phones", "Android_Id", "dbo.Androids", "Id");
            AddForeignKey("dbo.Androids", "Os_Id", "dbo.AndroidOs", "Id");
        }
    }
}
