namespace PhoneCat.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class change_storage_type1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Phones", "Storage_Flash", c => c.Int(nullable: false));
            AddColumn("dbo.Phones", "Storage_Ram", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Phones", "Storage_Ram");
            DropColumn("dbo.Phones", "Storage_Flash");
        }
    }
}
