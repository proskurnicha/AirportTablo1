namespace AirportTablo1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTimeDalay : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Flights", "TimeDelay", c => c.Time(nullable: false, precision: 7));
            DropColumn("dbo.Flights", "DateTimeDelay");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Flights", "DateTimeDelay", c => c.DateTime(nullable: false));
            DropColumn("dbo.Flights", "TimeDelay");
        }
    }
}
