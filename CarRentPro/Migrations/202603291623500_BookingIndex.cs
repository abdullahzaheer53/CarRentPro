namespace CarRentPro.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BookingIndex : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Bookings", new[] { "CarId", "StartTime", "EndTime" }, name: "IX_Bookings_CarId_StartTime_EndTime");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Bookings", "IX_Bookings_CarId_StartTime_EndTime");

        }
    }
}
