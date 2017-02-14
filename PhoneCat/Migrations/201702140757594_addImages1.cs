namespace PhoneCat.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addImages1 : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.PhoneImage", name: "PhoneID", newName: "__mig_tmp__0");
            RenameColumn(table: "dbo.PhoneImage", name: "ImageID", newName: "PhoneID");
            RenameColumn(table: "dbo.PhoneImage", name: "__mig_tmp__0", newName: "ImageID");
            RenameIndex(table: "dbo.PhoneImage", name: "IX_ImageID", newName: "__mig_tmp__0");
            RenameIndex(table: "dbo.PhoneImage", name: "IX_PhoneID", newName: "IX_ImageID");
            RenameIndex(table: "dbo.PhoneImage", name: "__mig_tmp__0", newName: "IX_PhoneID");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.PhoneImage", name: "IX_PhoneID", newName: "__mig_tmp__0");
            RenameIndex(table: "dbo.PhoneImage", name: "IX_ImageID", newName: "IX_PhoneID");
            RenameIndex(table: "dbo.PhoneImage", name: "__mig_tmp__0", newName: "IX_ImageID");
            RenameColumn(table: "dbo.PhoneImage", name: "ImageID", newName: "__mig_tmp__0");
            RenameColumn(table: "dbo.PhoneImage", name: "PhoneID", newName: "ImageID");
            RenameColumn(table: "dbo.PhoneImage", name: "__mig_tmp__0", newName: "PhoneID");
        }
    }
}
