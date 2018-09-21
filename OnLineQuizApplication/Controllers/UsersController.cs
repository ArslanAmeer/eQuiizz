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
            HttpCookie myCookie = Request.Cookies["logsec"];
            if (myCookie != null)
            {
                User user = new UserHandler().GetUser(myCookie.Values["logid"], myCookie.Values["psd"]);
                if (user != null)
                {
                    myCookie.Expires = DateTime.Now.AddDays(7);
                    Session.Add(WebUtils.Current_User, user);
                }
            }
            ViewBag.Controller = Request.QueryString["ctl"];
            ViewBag.Action = Request.QueryString["act"];
            return View();
        }
        [HttpPost]
        public ActionResult Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            User u = new UserHandler().GetUser(model.Email, model.Password);
            if (u != null)
            {
                if (model.Rememberme)
                {
                    HttpCookie cookie = new HttpCookie("logsec")
                    { Expires = DateTime.Now.AddDays(7) };
                    cookie.Values.Add("logid", u.Email);
                    cookie.Values.Add("psd", u.Password);
                    Response.SetCookie(cookie);
                }
                Session.Add(WebUtils.Current_User, u);
                string ctl = Request.QueryString["c"];
                string act = Request.QueryString["a"];
                if (!string.IsNullOrEmpty(ctl) && string.IsNullOrEmpty(act))
                {
                    return RedirectToAction(ctl, act);
                }

                if (u.IsInRole(WebUtils.Admin))
                {
                    return RedirectToAction("Index", "Admin");
                }
                return RedirectToAction("Index", "Quiz");
            }
            else
            {
                ViewBag.Error = "Your LoginId and Password are Wrong..Please try Again!";
            }
            return View();
        }

        [HttpGet]
        public ActionResult Signup()
        {
            ViewBag.GenderList = ModelHelper.ToSelectItemList(new UserHandler().GetGender());
            return View();
        }

        [HttpPost]
        public ActionResult Signup(FormCollection fdata, User u)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    u.Gender = new Gender { Id = Convert.ToInt32(fdata["gender.Name"]) };
                    u.Role = new Role() { Id = 2 };
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
                    new UserHandler().AddUser(u);
                    return RedirectToAction("Login");
                }
                catch (Exception e)
                {
                    return RedirectToAction("ErrorLog", "Users" + e);
                }
            }

            return View();

        }

        public ActionResult ErrorLog()
        {
            return View();
        }

        public ActionResult Logout()
        {
            Session.Abandon();
            HttpCookie hc = Request.Cookies["logsec"];
            if (hc != null)
            {
                hc.Expires = DateTime.Now;
                Response.SetCookie(hc);
            }
            return RedirectToAction("Login");
        }

        public ActionResult UserAccount(int id)
        {
            User user = new UserHandler().GetUserById(id);
            return View(user);
        }
    }
}
