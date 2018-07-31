namespace OnlineQuizClasses.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class TotalTime : DbMigration
    {
        public override void Up()
        {
            //AlterColumn("dbo.Quizs", "QuizTitle", c => c.String(nullable: false));
            //AlterColumn("dbo.Quizs", "Description", c => c.String(nullable: false));
            DropColumn("dbo.Quizs", "TotalTime");
        }

        public override void Down()
        {
            AddColumn("dbo.Quizs", "TotalTime", c => c.String());
            AlterColumn("dbo.Quizs", "Description", c => c.String());
            AlterColumn("dbo.Quizs", "QuizTitle", c => c.String());
        }
    }
}
