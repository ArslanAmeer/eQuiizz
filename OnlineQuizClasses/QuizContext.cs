using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineQuizClasses.QuizManagement;

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
    }
}
