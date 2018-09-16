using OnlineQuizClasses.QuizManagement;
using OnlineQuizClasses.UserManagement;
using System.Data.Entity;

namespace OnlineQuizClasses
{
    public class QuizContext : DbContext
    {
        public QuizContext() : base("constr")
        {
            Configuration.LazyLoadingEnabled = false;
        }

        public DbSet<Quiz> Quizzes { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Gender> Genders { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }

    }
}
