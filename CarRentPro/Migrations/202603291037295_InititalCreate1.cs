namespace CarRentPro.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InititalCreate1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Bookings", "Status", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Bookings", "Status");
        }
    }
}
