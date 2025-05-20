using System.Linq;
using System.Web.Mvc;
using eUseControl.BusinessLogic;
using eUseControl.BusinessLogic.Interfaces;
using eUseControl.Domain.Entities.Recipe;

namespace MRSTWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly IRecipeService _recipeService;

        public HomeController()
        {
            var bl = new BusinessLogic();
            _recipeService = bl.GetRecipeService();
        }

        // GET: Home
        public ActionResult Index()
        {
            var featuredRecipes = _recipeService.GetFeaturedRecipes().ToList();
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
            var recipes = _recipeService.GetAllRecipes().ToList();
            return View(recipes);
        }

        // GET: Recipe Details
        public ActionResult RecipeDetails(int id)
        {
            var recipe = _recipeService.GetRecipeById(id);
            if (recipe == null)
            {
                return HttpNotFound();
            }
            return View(recipe);
        }

        // GET: Contact
        public ActionResult Contact()
        {
            return View();
        }
    }
}