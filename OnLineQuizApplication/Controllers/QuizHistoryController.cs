using OnlineQuizClasses.QuizManagement;
using OnlineQuizClasses.UserManagement;
using System.Collections.Generic;
using System.Web.Mvc;

namespace OnLineQuizApplication.Controllers
{
    public class QuizHistoryController : Controller
    {
        // GET: QuizHistory
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult QuizCreatedBy(int id)
        {
            List<User> userbyquiz = new QuizHandler().GetQuizByUser(id);
            return View(userbyquiz);
        }

        public ActionResult DeleteUserQuiz(int id)
        {
            new QuizHandler().DeleteQuizbyUser(id);
            return Json("Delete", JsonRequestBehavior.AllowGet);
        }
        public ActionResult Result(int id)
        {
            ViewBag.cquizId = id;
            return View();
        }
        public ActionResult Layout()
        {
            return View();
        }
    }
}
