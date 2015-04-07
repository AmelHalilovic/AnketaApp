namespace AnketaApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Novetabele : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Odgovor",
                c => new
                    {
                        odg_brj = c.Long(nullable: false, identity: true),
                        odg_sadr = c.String(nullable: false, maxLength: 50),
                        odg_pitbrj = c.Long(nullable: false),
                        odg_datumpost = c.DateTime(precision: 7, storeType: "datetime2"),
                        odg_brojodabira = c.Long(),
                    })
                .PrimaryKey(t => t.odg_brj);
            
            CreateTable(
                "dbo.Pitanje",
                c => new
                    {
                        pit_brj = c.Long(nullable: false, identity: true),
                        pit_sadrz = c.String(nullable: false, maxLength: 50),
                        pit_anktbrj = c.Long(nullable: false),
                        pit_datumpost = c.DateTime(precision: 7, storeType: "datetime2"),
                    })
                .PrimaryKey(t => t.pit_brj);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Pitanje");
            DropTable("dbo.Odgovor");
        }
    }
}
