using System;
using System.Web.Mvc;
using System.Web.Security;
using eUseControl.Domain.Entities.User;
using eUseControl.Domain.Entities.Recipe;
using eUseControl.BusinessLogic;
using eUseControl.BusinessLogic.Interfaces;

namespace MRSTWeb.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly IRecipeService _recipeService;
        private readonly ICategoryService _categoryService;

        public AdminController()
        {
            var bl = new BusinessLogic();
            _recipeService = bl.GetRecipeService();
            _categoryService = bl.GetCategoryService();
        }

        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }

        // GET: Admin/ManageRecipes
        public ActionResult ManageRecipes()
        {
            var recipes = _recipeService.GetAllRecipes().ToList();
            return View(recipes);
        }

        // GET: Admin/ManageCategories
        public ActionResult ManageCategories()
        {
            var categories = _categoryService.GetAllCategories().ToList();
            return View(categories);
        }

        // GET: Admin/ManageUsers
        public ActionResult ManageUsers()
        {
            // Get users from your user management system
            return View();
        }

        // GET: Admin/EditRecipe/5
        public ActionResult EditRecipe(int id)
        {
            var recipe = _recipeService.GetRecipeById(id);
            if (recipe == null)
            {
                return HttpNotFound();
            }
            return View(recipe);
        }

        // POST: Admin/EditRecipe/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditRecipe(Recipe recipe)
        {
            if (ModelState.IsValid)
            {
                _recipeService.UpdateRecipe(recipe);
                return RedirectToAction("ManageRecipes");
            }
            return View(recipe);
        }

        // GET: Admin/DeleteRecipe/5
        public ActionResult DeleteRecipe(int id)
        {
            var recipe = _recipeService.GetRecipeById(id);
            if (recipe == null)
            {
                return HttpNotFound();
            }
            return View(recipe);
        }

        // POST: Admin/DeleteRecipe/5
        [HttpPost, ActionName("DeleteRecipe")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteRecipeConfirmed(int id)
        {
            _recipeService.DeleteRecipe(id);
            return RedirectToAction("ManageRecipes");
        }
    }
} 