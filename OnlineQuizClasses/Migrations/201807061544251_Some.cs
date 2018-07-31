namespace OnlineQuizClasses.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Some : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Questions", "Questions", c => c.String(nullable: false));
            AlterColumn("dbo.Questions", "Option1", c => c.String(nullable: false));
            AlterColumn("dbo.Questions", "Option2", c => c.String(nullable: false));
            AlterColumn("dbo.Questions", "CorrectAnswer", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Questions", "CorrectAnswer", c => c.String());
            AlterColumn("dbo.Questions", "Option2", c => c.String());
            AlterColumn("dbo.Questions", "Option1", c => c.String());
            AlterColumn("dbo.Questions", "Questions", c => c.String());
        }
    }
}
