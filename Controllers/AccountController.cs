using System;
using System.Web.Mvc;
using System.Web.Security;
using eUseControl.BusinessLogic;
using eUseControl.BusinessLogic.Interfaces;
using eUseControl.Domain.Entities.User;

namespace eUseControl.web.Controllers
{
    public class AccountController : Controller
    {
        private readonly ISession _session;

        public AccountController()
        {
            var bl = new BussinesLogic();
            _session = bl.GetSessionBL();
        }

        // GET: Account/Register
        public ActionResult Register()
        {
            return View();
        }

        // POST: Account/Register
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(User model)
        {
            if (ModelState.IsValid)
            {
                model.Role = "User"; // Set default role
                model.CreatedAt = DateTime.Now;
                
                var registrationResult = _session.RegisterUser(model);
                
                if (registrationResult.Status)
                {
                    FormsAuthentication.SetAuthCookie(model.Username, false);
                    return RedirectToAction("Index", "Home");
                }
                
                ModelState.AddModelError("", registrationResult.StatusMsg);
            }

            return View(model);
        }
    }
} 