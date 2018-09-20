namespace OnlineQuizClasses.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserGender : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Users", "Loginid");
            DropColumn("dbo.Users", "Cnic");
            DropColumn("dbo.Users", "Shift");
            DropColumn("dbo.Users", "DateofBirth");
            DropColumn("dbo.Users", "MobileNo");
            DropColumn("dbo.Users", "FullAddress");
            DropColumn("dbo.Users", "City");
            DropColumn("dbo.Users", "State");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "State", c => c.String(nullable: false));
            AddColumn("dbo.Users", "City", c => c.String(nullable: false));
            AddColumn("dbo.Users", "FullAddress", c => c.String(nullable: false));
            AddColumn("dbo.Users", "MobileNo", c => c.Long(nullable: false));
            AddColumn("dbo.Users", "DateofBirth", c => c.DateTime(nullable: false));
            AddColumn("dbo.Users", "Shift", c => c.String(nullable: false));
            AddColumn("dbo.Users", "Cnic", c => c.Long(nullable: false));
            AddColumn("dbo.Users", "Loginid", c => c.String(nullable: false));
        }
    }
}
