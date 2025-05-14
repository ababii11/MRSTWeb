using System.Linq;
using System.Web.Mvc;
using MRSTWeb.Models;
using System.Data.Entity;

namespace MRSTWeb.Controllers
{
    public class HomeController : Controller
    {
        private ReteteContext db = new ReteteContext();

        // GET: Home
        public ActionResult Index()
        {
            var featuredRecipes = db.Recipes.Include(r => r.Category).Take(3).ToList();
            return View(featuredRecipes);
        }

        // GET: About
        public ActionResult About()
        {
            return View();
        }

        // GET: Recipes
        public ActionResult Recipes()
        {
            var recipes = db.Recipes.Include(r => r.Category).ToList();
            return View(recipes);
        }

        // GET: Recipe Details
        public ActionResult RecipeDetails(int id)
        {
            var recipe = db.Recipes.Include(r => r.Category)
                                 .FirstOrDefault(r => r.RecipeId == id);
            if (recipe == null)
            {
                return HttpNotFound();
            }
            return View(recipe);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}