using System.Web.Mvc;
using System.Web.Security;
using eUseControl.Domain.Entities.User;
using MRSTWeb.Models;

namespace MRSTWeb.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(UserLogin model)
        {
            if (ModelState.IsValid)
            {
                var user = AccountController.GetUserByCredentials(model.Credential, model.Password);
                
                if (user != null)
                {
                    FormsAuthentication.SetAuthCookie(user.Username, false);
                    return RedirectToAction("Index", "Home");
                }
                
                ModelState.AddModelError("", "Invalid username/email or password");
            }

            return View(model);
        }

        [Authorize]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }
    }
}
