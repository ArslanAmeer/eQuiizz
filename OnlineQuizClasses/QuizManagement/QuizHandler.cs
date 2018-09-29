using OnlineQuizClasses.UserManagement;
using System.Collections.Generic;
using System.Data.Entity;
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

        public Quiz GetQuizId(string name)
        {
            using (_context)
            {
                return (from c in _context.Quizzes where c.QuizTitle == name select c).FirstOrDefault();
            }
        }

        public Quiz GetQuizById(int i)
        {
            using (_context)
            {
                return (from c in _context.Quizzes where c.Id == i select c).FirstOrDefault();
            }
        }

        public List<Question> GetAllQuestion(int id)
        {
            using (_context)
            {
                return (from c in _context.Questions.Include(m => m.Quiz) where c.Quiz.Id == id select c).ToList();
            }
        }

        public List<User> GetQuizByUser(int id)
        {
            using (_context)
            {
                return (from c in _context.Users.Include(m => m.Quiz).Include(m => m.Role) where c.Id == id select c).ToList();
            }
        }

        public Quiz DeleteQuizbyUser(int id)
        {
            using (_context)
            {
                Quiz p = (from c in _context.Quizzes
                          where c.Id == id
                          select c).FirstOrDefault();

                _context.Entry(p).State = EntityState.Deleted;
                _context.SaveChanges();
                return p;
            }
        }

        public Quiz DeleteUserQuiz(int id)
        {
            using (_context)
            {
                return (from c in _context.Quizzes where c.Id == id select c).FirstOrDefault();
            }
        }
    }
}
