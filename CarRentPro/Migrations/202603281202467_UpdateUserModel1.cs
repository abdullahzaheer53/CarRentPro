namespace CarRentPro.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateUserModel1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "Address", c => c.String());
            DropColumn("dbo.Users", "Addresses");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "Addresses", c => c.String());
            DropColumn("dbo.Users", "Address");
        }
    }
}
