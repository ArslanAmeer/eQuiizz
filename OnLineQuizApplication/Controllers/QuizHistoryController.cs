using OnlineQuizClasses;
using OnlineQuizClasses.QuizManagement;
using OnlineQuizClasses.UserManagement;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
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
            QuizContext db = new QuizContext();
            List<Quiz> p = (from c in db.Quizzes
                            where c.Id == id
                            select c).ToList();
            db.Entry(p).State = EntityState.Deleted;
            db.SaveChanges();
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
