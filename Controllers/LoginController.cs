using System;
using System.Web.Mvc;
using System.Web.Security;
using eUseControl.BusinessLogic;
using eUseControl.BusinessLogic.Interfaces;
using eUseControl.Domain.Entities.User;

namespace eUseControl.web.Controllers
{
    public class LoginController : Controller
    {
        private readonly ISession _session;

        public LoginController()
        {
            var bl = new BussinesLogic();
            _session = bl.GetSessionBL();
        }

        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(UserLogin login)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    ULoginData data = new ULoginData
                    {
                        Credential = login.Credential,
                        Password = login.Password,
                        LoginIp = Request.UserHostAddress,
                        LoginDateTime = DateTime.Now
                    };

                    var response = _session.UserLogin(data);
                    if (response != null && response.Status)
                    {
                        if (response.User != null)
                        {
                            FormsAuthentication.SetAuthCookie(response.User.Username, false);
                            return RedirectToAction("Index", "Home");
                        }
                    }
                    
                    ModelState.AddModelError("", response?.StatusMsg ?? "Invalid login attempt");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", "An error occurred during login. Please try again.");
                }
            }

            return View(login);
        }

        [Authorize]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }
    }
}
