namespace AirPortApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class x : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Flights",
                c => new
                    {
                        FlightId = c.Int(nullable: false, identity: true),
                        TimeArrival = c.DateTime(),
                        TimeDeparture = c.DateTime(nullable: false),
                        TimeExpected = c.DateTime(nullable: false),
                        Number = c.Int(nullable: false),
                        PortArrival = c.String(),
                        PortDeparture = c.String(),
                        Airline = c.String(),
                        Terminal = c.String(),
                        Status = c.String(),
                        Gate = c.String(),
                    })
                .PrimaryKey(t => t.FlightId);
            
            CreateTable(
                "dbo.Tickets",
                c => new
                    {
                        TicketId = c.Int(nullable: false, identity: true),
                        Number = c.Int(nullable: false),
                        Place = c.String(maxLength: 15),
                        Price = c.Double(nullable: false),
                        FlightId = c.Int(nullable: false),
                        PassId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TicketId)
                .ForeignKey("dbo.Flights", t => t.FlightId, cascadeDelete: true)
                .ForeignKey("dbo.Passengers", t => t.PassId, cascadeDelete: true)
                .Index(t => t.FlightId)
                .Index(t => t.PassId);
            
            CreateTable(
                "dbo.Passengers",
                c => new
                    {
                        Passport = c.String(maxLength: 12, unicode: false),
                        PassId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Surname = c.String(maxLength: 25),
                    })
                .PrimaryKey(t => t.PassId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tickets", "PassId", "dbo.Passengers");
            DropForeignKey("dbo.Tickets", "FlightId", "dbo.Flights");
            DropIndex("dbo.Tickets", new[] { "PassId" });
            DropIndex("dbo.Tickets", new[] { "FlightId" });
            DropTable("dbo.Passengers");
            DropTable("dbo.Tickets");
            DropTable("dbo.Flights");
        }
    }
}
