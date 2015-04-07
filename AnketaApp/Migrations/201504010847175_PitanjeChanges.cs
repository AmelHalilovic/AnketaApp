namespace AnketaApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PitanjeChanges : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Pitanje", "odg1", c => c.String(nullable: false, maxLength: 250));
            AddColumn("dbo.Pitanje", "odg1_glas", c => c.Long(nullable: false));
            AddColumn("dbo.Pitanje", "odg2", c => c.String(nullable: false, maxLength: 250));
            AddColumn("dbo.Pitanje", "odg2_glas", c => c.Long(nullable: false));
            AddColumn("dbo.Pitanje", "odg3", c => c.String(nullable: false, maxLength: 250));
            AddColumn("dbo.Pitanje", "odg3_glas", c => c.Long(nullable: false));
            AddColumn("dbo.Pitanje", "odg4", c => c.String(nullable: false, maxLength: 250));
            AddColumn("dbo.Pitanje", "odg4_glas", c => c.Long(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Pitanje", "odg4_glas");
            DropColumn("dbo.Pitanje", "odg4");
            DropColumn("dbo.Pitanje", "odg3_glas");
            DropColumn("dbo.Pitanje", "odg3");
            DropColumn("dbo.Pitanje", "odg2_glas");
            DropColumn("dbo.Pitanje", "odg2");
            DropColumn("dbo.Pitanje", "odg1_glas");
            DropColumn("dbo.Pitanje", "odg1");
        }
    }
}
