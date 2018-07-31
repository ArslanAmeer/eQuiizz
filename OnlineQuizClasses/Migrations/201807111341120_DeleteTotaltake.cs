namespace OnlineQuizClasses.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeleteTotaltake : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Quizs", "TotalTake");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Quizs", "TotalTake", c => c.Int(nullable: false));
        }
    }
}
