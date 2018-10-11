using OnlineQuizClasses;
using OnlineQuizClasses.QuizManagement;
using Rotativa;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
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
            QuizContext db = new QuizContext();
            List<Quiz> p = (from c in db.Quizzes


                            where c.Id == id
                            select c).ToList();
            db.Entry(User).State = EntityState.Unchanged;
            db.Entry(p).State = EntityState.Deleted;
            db.SaveChanges();
            return Json("Delete", JsonRequestBehavior.AllowGet);
        }
    }
}
