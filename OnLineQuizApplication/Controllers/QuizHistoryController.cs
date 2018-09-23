using OnlineQuizClasses.QuizManagement;
using OnlineQuizClasses.UserManagement;
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

        public ActionResult QuizCreatedBy(User user)
        {
            Quiz quiz = new QuizHandler().GetQuizByUser(user);
            return View(quiz);
        }

        public ActionResult Layout()
        {
            return View();
        }
    }
}
