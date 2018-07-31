using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineQuizClasses;
using OnlineQuizClasses.QuizManagement;

namespace OnLineQuizApplication.Controllers
{
    public class QuizController : Controller
    {
        // GET: QuizController
        public ActionResult Index()
        {
            return View();
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
                //quiz.Question= new Question { Id = data["Question.Id"]};

                QuizContext db = new QuizContext();
                using (db)
                {
                    db.Quizzes.Add(quiz);
                    db.SaveChanges();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
            return RedirectToAction("AddQuestions", "Quiz", new { questionsCount = qCount });
        }
        [HttpGet]
        public ActionResult AddQuestions(int questionsCount)
        {
            ViewBag.qCount = questionsCount;
            return View();
        }
        [HttpPost]
        public ActionResult AddQuestions(Question question, int questionsCount)
        {

            if (question == null)
            {
                return View();
            }
            QuizContext db = new QuizContext();
            using (db)
            {
                db.Questions.Add(question);
                db.SaveChanges();
            }

            ViewBag.qCount = questionsCount + 1;
            return RedirectToAction("AddQuestions", new { questionsCount = (int)ViewBag.qCount });
        }
    }
}