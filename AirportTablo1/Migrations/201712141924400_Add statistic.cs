namespace AirportTablo1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Addstatistic : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.StatisticNameAirlineCounts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NameAirline = c.String(),
                        CountAirline = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.StatisticTerminalCounts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TerminalInfo = c.String(),
                        CountTerminal = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.StatisticTerminalCounts");
            DropTable("dbo.StatisticNameAirlineCounts");
        }
    }
}
