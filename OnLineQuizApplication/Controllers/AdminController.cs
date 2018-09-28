using OnlineQuizClasses.QuizManagement;
using Rotativa;
using System.Collections.Generic;
using System.Web.Mvc;

namespace OnLineQuizApplication.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AllQuizes()
        {
            List<Quiz> quizzes = new QuizHandler().GetAllQuizzes();
            return View(quizzes);
        }

        public ActionResult PrintAll()
        {
            var print = new ActionAsPdf("AllQuizes");
            return print;
        }

        public ActionResult DeleteQuiz(int id)
        {
            new QuizHandler().DeleteUserQuiz(id);
            return Json("Delete", JsonRequestBehavior.AllowGet);
        }
    }
}
