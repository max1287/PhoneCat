namespace PhoneCat.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class availability : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Availabilities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PhoneAvailability",
                c => new
                    {
                        PhoneId = c.Int(nullable: false),
                        AvailabilityId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.PhoneId, t.AvailabilityId })
                .ForeignKey("dbo.Phones", t => t.PhoneId, cascadeDelete: true)
                .ForeignKey("dbo.Availabilities", t => t.AvailabilityId, cascadeDelete: true)
                .Index(t => t.PhoneId)
                .Index(t => t.AvailabilityId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PhoneAvailability", "AvailabilityId", "dbo.Availabilities");
            DropForeignKey("dbo.PhoneAvailability", "PhoneId", "dbo.Phones");
            DropIndex("dbo.PhoneAvailability", new[] { "AvailabilityId" });
            DropIndex("dbo.PhoneAvailability", new[] { "PhoneId" });
            DropTable("dbo.PhoneAvailability");
            DropTable("dbo.Availabilities");
        }
    }
}
