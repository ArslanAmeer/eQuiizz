using OnLineQuizApplication.Models;
using OnlineQuizClasses.UserManagement;
using System;
using System.Web;
using System.Web.Mvc;

namespace OnLineQuizApplication.Controllers
{
    public class UsersController : Controller
    {
        // GET: Users
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(LoginViewModel model)
        {
            return View();
        }

        [HttpGet]
        public ActionResult Signup()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Signup(FormCollection fdata, User u)
        {

            long numb = DateTime.Now.Ticks;
            int count = 0;
            foreach (string fname in Request.Files)
            {
                HttpPostedFileBase file = Request.Files[fname];
                if (!string.IsNullOrEmpty(file?.FileName))
                {
                    string url = "/Content/UserImages/" + numb + "_" + ++count + file.FileName.Substring(file.FileName.LastIndexOf(".", StringComparison.Ordinal));
                    string path = Request.MapPath(url);
                    file.SaveAs(path);
                    u.ImageUrl = url;
                }
                else
                {
                    string url = "/Content/UserImages/noimage.jpg";
                    u.ImageUrl = url;
                }

            }

            return View();
        }
    }
}
