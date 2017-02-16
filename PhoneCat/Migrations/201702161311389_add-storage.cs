namespace PhoneCat.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addstorage : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Phones", "Storage_Flash", c => c.String());
            AddColumn("dbo.Phones", "Storage_Ram", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Phones", "Storage_Ram");
            DropColumn("dbo.Phones", "Storage_Flash");
        }
    }
}
