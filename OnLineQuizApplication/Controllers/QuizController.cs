using OnlineQuizClasses;
using OnlineQuizClasses.QuizManagement;
using OnlineQuizClasses.UserManagement;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Web.Mvc;

namespace OnLineQuizApplication.Controllers
{
    public class QuizController : Controller
    {
        // GET: QuizController
        public ActionResult Index()
        {
            List<Quiz> quizzes = new QuizHandler().GetAllQuizzes();
            return View(quizzes);
        }

        [HttpGet]
        public ActionResult QuizInfo()
        {
            return View();
        }

        [HttpPost]
        public ActionResult QuizInfo(Quiz quiz)
        {
            int qCount = quiz.TotalQuestion;
            if (!ModelState.IsValid)
            {
                return View();
            }
            if (quiz == null)
            {
                return View();
            }
            try
            {
                User u = new User();
                u = (User)Session[WebUtils.Current_User];
                u.Quiz.Add(quiz);
                //quiz.Question= new Question { Id = data["Question.Id"]};

                QuizContext db = new QuizContext();
                using (db)
                {
                    db.Entry(u).State = EntityState.Unchanged;
                    //db.Entry(u.Quiz).State = EntityState.Added;
                    db.Quizzes.AddRange(u.Quiz);
                    db.SaveChanges();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
            return RedirectToAction("AddQuestions", "Quiz", new { questionsCount = qCount, name = quiz.QuizTitle });
        }

        [HttpGet]
        public ActionResult AddQuestions(int questionsCount, string name)
        {
            ViewBag.qCount = questionsCount;
            TempData["max"] = new QuizHandler().GetQuizId(name).Id;
            if (questionsCount != 0)
            {
                return View();
            }

            return RedirectToAction("Index", "QuizHistory");

        }
        [HttpPost]
        public ActionResult AddQuestions(Question question, int questionsCount)
        {

            if (question == null)
            {
                return View();
            }
            QuizContext db = new QuizContext();
            Quiz quiz = new QuizHandler().GetQuizById((int)TempData["max"]);
            using (db)
            {
                question.Quiz = quiz;
                db.Questions.Add(question);
                db.Entry(quiz).State = EntityState.Unchanged;
                db.SaveChanges();
            }

            ViewBag.qCount = questionsCount - 1;
            return RedirectToAction("AddQuestions", new { questionsCount = (int)ViewBag.qCount, name = quiz.QuizTitle });

        }

        public ActionResult ConductQuiz(int id)
        {
            List<Question> questions = new QuizHandler().GetAllQuestion(id);
            return View(questions);
        }

        public ActionResult QuizInstructions(int id)
        {
            ViewBag.quizid = id;

            return View();
        }

    }
}
//public int QuestionCount(int id)
//{
//    QuizContext db = new QuizContext();
//    using (db)
//    {
//        return (from c in db.Questions where c.Quiz.Id == id select c).Count();
//    }
//}
