using System.Collections.Generic;
using System.Linq;

namespace OnlineQuizClasses.QuizManagement
{
    public class QuizHandler
    {
        private QuizContext _context = new QuizContext();
        public List<Quiz> GetAllQuizzes()
        {
            using (_context)
            {
                return (from v in _context.Quizzes select v).ToList();
            }
        }


    }
}
