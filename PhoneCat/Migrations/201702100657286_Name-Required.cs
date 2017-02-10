namespace PhoneCat.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NameRequired : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Phones", "Name", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Phones", "Name", c => c.String());
        }
    }
}
