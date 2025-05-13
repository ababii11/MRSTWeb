using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using eUseControl.BusinessLogic;
using eUseControl.BusinessLogic.Interfaces;
using eUseControl.Domain.Entities.User;
using static System.Collections.Specialized.BitVector32;

namespace eUseControl.web
{
    public class LoginController : Controller
    {
        private readonly ISession _session;
        public LoginController()
        {
            var bl = new BussinesLogic();
            _session = bl.GetSessionBL();
        }

        //GET lOGIN
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
                ULoginData data = new ULoginData
                {
                    Credential = login.Credential,
                    Password = login.Password,
                    LoginIp = Request.UserHostAddress,
                    LoginDateTime = DateTime.Now
                };
                var userLogin = _session.UserLogin(data);
                if (userLogin.Status)
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", userLogin.StatusMsg);
                    return View();
                }
            }
            return View();
        }
    }
}
