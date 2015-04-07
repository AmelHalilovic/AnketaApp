namespace AnketaApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IzmjeneTabelePitanje : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Pitanje", "brojotvaranja", c => c.Long(nullable: false));
            DropColumn("dbo.Pitanje", "odg1_brojotvaranja");
            DropColumn("dbo.Pitanje", "odg2_brojotvaranja");
            DropColumn("dbo.Pitanje", "odg3_brojotvaranja");
            DropColumn("dbo.Pitanje", "odg4_brojotvaranja");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Pitanje", "odg4_brojotvaranja", c => c.Long(nullable: false));
            AddColumn("dbo.Pitanje", "odg3_brojotvaranja", c => c.Long(nullable: false));
            AddColumn("dbo.Pitanje", "odg2_brojotvaranja", c => c.Long(nullable: false));
            AddColumn("dbo.Pitanje", "odg1_brojotvaranja", c => c.Long(nullable: false));
            DropColumn("dbo.Pitanje", "brojotvaranja");
        }
    }
}
