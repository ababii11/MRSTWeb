<<<<<<< HEAD
﻿using System;
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

=======
﻿using System.Web.Mvc;
using System.Web.Security;
using eUseControl.Domain.Entities.User;
using MRSTWeb.Models;

namespace MRSTWeb.Controllers
{
    public class LoginController : Controller
    {
>>>>>>> c1665d64de476b3ecb81eabcb36102bbe5e52cdb
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
<<<<<<< HEAD
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
=======
                var user = AccountController.GetUserByCredentials(model.Credential, model.Password);
                
                if (user != null)
                {
                    // Create authentication ticket with user role
                    var authTicket = new FormsAuthenticationTicket(
                        1,                              // version
                        user.Username,                  // user name
                        DateTime.Now,                   // issue time
                        DateTime.Now.AddMinutes(30),    // expiry time
                        false,                          // do not remember
                        user.Role                       // user role
                    );

                    // Encrypt the ticket
                    string encryptedTicket = FormsAuthentication.Encrypt(authTicket);

                    // Create the cookie
                    var authCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);
                    Response.Cookies.Add(authCookie);

                    return RedirectToAction("Index", "Home");
                }
                
                ModelState.AddModelError("", "Invalid username/email or password");
            }

            return View(model);
>>>>>>> c1665d64de476b3ecb81eabcb36102bbe5e52cdb
        }

        [Authorize]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }
    }
}
