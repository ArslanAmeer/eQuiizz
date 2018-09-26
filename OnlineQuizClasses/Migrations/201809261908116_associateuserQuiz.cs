namespace OnlineQuizClasses.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class associateuserQuiz : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Quizs", "User_Id", c => c.Int());
            CreateIndex("dbo.Quizs", "User_Id");
            AddForeignKey("dbo.Quizs", "User_Id", "dbo.Users", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Quizs", "User_Id", "dbo.Users");
            DropIndex("dbo.Quizs", new[] { "User_Id" });
            DropColumn("dbo.Quizs", "User_Id");
        }
    }
}
