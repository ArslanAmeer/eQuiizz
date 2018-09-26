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

        public ActionResult Result()
        {
            return View();
        }
        public ActionResult Layout()
        {
            return View();
        }
    }
}
