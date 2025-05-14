using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MRSTWeb.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        // GET: About
        public ActionResult About()
        {
            return View();
        }

        // GET: Recipes
        public ActionResult Recipes()
        {
            return View();
        }

        // GET: Recipe Details
        public ActionResult RecipeDetails(int id)
        {
            // TODO: Fetch recipe details based on id
            return View();
        }
    }
}