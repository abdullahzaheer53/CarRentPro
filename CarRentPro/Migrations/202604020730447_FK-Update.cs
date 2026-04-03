namespace CarRentPro.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class FKUpdate : DbMigration
    {
        public override void Up()
        {
            // 1. Drop existing constraints (only once each)
            DropForeignKey("dbo.Bookings", "CarId", "dbo.Cars");
            DropForeignKey("dbo.Bookings", "UserId", "dbo.Users");

            // 2. Drop indexes
            DropIndex("dbo.Bookings", new[] { "CarId" });
            DropIndex("dbo.Bookings", new[] { "UserId" });
            DropIndex("dbo.Bookings", "IX_Bookings_CarId_StartTime_EndTime");

            // 3. Drop primary keys
            DropPrimaryKey("dbo.Bookings");
            DropPrimaryKey("dbo.Cars");
            DropPrimaryKey("dbo.Users");

            // 4. Alter columns (int → long)
            AlterColumn("dbo.Bookings", "Id", c => c.Long(nullable: false, identity: true));
            AlterColumn("dbo.Bookings", "CarId", c => c.Long(nullable: false));
            AlterColumn("dbo.Bookings", "UserId", c => c.Long(nullable: false));
            AlterColumn("dbo.Cars", "Id", c => c.Long(nullable: false, identity: true));
            AlterColumn("dbo.Users", "Id", c => c.Long(nullable: false, identity: true));

            // 5. Add primary keys back
            AddPrimaryKey("dbo.Bookings", "Id");
            AddPrimaryKey("dbo.Cars", "Id");
            AddPrimaryKey("dbo.Users", "Id");

            // 6. Create indexes
            CreateIndex("dbo.Bookings", "CarId");
            CreateIndex("dbo.Bookings", "UserId");
            CreateIndex("dbo.Histories", "BookingId");
            CreateIndex("dbo.Payments", "BookingId");
            CreateIndex("dbo.Bookings", new[] { "CarId", "StartTime", "EndTime" },
                name: "IX_Bookings_CarId_StartTime_EndTime");

            // 7. Add foreign keys (only once each)
            AddForeignKey("dbo.Histories", "BookingId", "dbo.Bookings", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Payments", "BookingId", "dbo.Bookings", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Bookings", "CarId", "dbo.Cars", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Bookings", "UserId", "dbo.Users", "Id", cascadeDelete: true);
        }

        public override void Down()
        {
            // 1. Drop foreign keys
            DropForeignKey("dbo.Bookings", "UserId", "dbo.Users");
            DropForeignKey("dbo.Bookings", "CarId", "dbo.Cars");
            DropForeignKey("dbo.Payments", "BookingId", "dbo.Bookings");
            DropForeignKey("dbo.Histories", "BookingId", "dbo.Bookings");

            // 2. Drop indexes
            DropIndex("dbo.Bookings", "IX_Bookings_CarId_StartTime_EndTime");
            DropIndex("dbo.Payments", new[] { "BookingId" });
            DropIndex("dbo.Histories", new[] { "BookingId" });
            DropIndex("dbo.Bookings", new[] { "UserId" });
            DropIndex("dbo.Bookings", new[] { "CarId" });

            // 3. Drop primary keys
            DropPrimaryKey("dbo.Users");
            DropPrimaryKey("dbo.Cars");
            DropPrimaryKey("dbo.Bookings");

            // 4. Revert columns (long → int)
            AlterColumn("dbo.Users", "Id", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Cars", "Id", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Bookings", "UserId", c => c.Int(nullable: false));
            AlterColumn("dbo.Bookings", "CarId", c => c.Int(nullable: false));
            AlterColumn("dbo.Bookings", "Id", c => c.Int(nullable: false, identity: true));

            // 5. Add primary keys back
            AddPrimaryKey("dbo.Users", "Id");
            AddPrimaryKey("dbo.Cars", "Id");
            AddPrimaryKey("dbo.Bookings", "Id");

            // 6. Recreate indexes
            CreateIndex("dbo.Bookings", "UserId");
            CreateIndex("dbo.Bookings", "CarId");
            CreateIndex("dbo.Bookings", new[] { "CarId", "StartTime", "EndTime" },
                name: "IX_Bookings_CarId_StartTime_EndTime");

            // 7. Recreate foreign keys
            AddForeignKey("dbo.Bookings", "UserId", "dbo.Users", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Bookings", "CarId", "dbo.Cars", "Id", cascadeDelete: true);
        }
    }
}