namespace AirportTablo1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addpassangers : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Passangers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        SecondName = c.String(),
                        BirthDate = c.DateTime(nullable: false),
                        Passport = c.String(),
                        AspNetUsersId = c.String(maxLength: 128),
                        FlightId = c.Int(nullable: false),
                        SeatNumber = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Flights", t => t.FlightId, cascadeDelete: true)
                 .ForeignKey("dbo.AspNetUsers", t => t.AspNetUsersId, cascadeDelete: true)
                .Index(t => t.FlightId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Passangers", "FlightId", "dbo.Flights");
            DropForeignKey("dbo.Passangers", "AspNetUsersId", "dbo.AspNetUsers");
            DropIndex("dbo.Passangers", new[] { "FlightId" });
            DropTable("dbo.Passangers");
        }
    }
}
