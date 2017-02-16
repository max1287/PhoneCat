namespace PhoneCat.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class change_storage_type : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Phones", "Storage_Flash");
            DropColumn("dbo.Phones", "Storage_Ram");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Phones", "Storage_Ram", c => c.String());
            AddColumn("dbo.Phones", "Storage_Flash", c => c.String());
        }
    }
}
