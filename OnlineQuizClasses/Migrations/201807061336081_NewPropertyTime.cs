namespace OnlineQuizClasses.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewPropertyTime : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Quizs", "TotalTime", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Quizs", "TotalTime");
        }
    }
}
