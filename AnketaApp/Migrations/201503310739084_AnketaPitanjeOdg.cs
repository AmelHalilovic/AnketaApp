namespace AnketaApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AnketaPitanjeOdg : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Anketa",
                c => new
                    {
                        ankt_brj = c.Long(nullable: false, identity: true),
                        ankt_naslov = c.String(nullable: false, maxLength: 50),
                        ankt_brjpit = c.Long(nullable: false),
                        ankt_brjotvaranja = c.Long(nullable: false),
                        ankt_datumotv = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        ankt_datposljotv = c.DateTime(precision: 7, storeType: "datetime2"),
                    })
                .PrimaryKey(t => t.ankt_brj);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Anketa");
        }
    }
}
