using System;
using System.Web.Mvc;
using System.Web.Security;
using eUseControl.Domain.Entities.User;
using MRSTWeb.Models;

namespace MRSTWeb.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private ReteteContext db = new ReteteContext();

        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }

        // GET: Admin/ManageRecipes
        public ActionResult ManageRecipes()
        {
            var recipes = db.Recipes.Include(r => r.Category).ToList();
            return View(recipes);
        }

        // GET: Admin/ManageCategories
        public ActionResult ManageCategories()
        {
            var categories = db.Categories.ToList();
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
            var recipe = db.Recipes.Find(id);
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
                db.Entry(recipe).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("ManageRecipes");
            }
            return View(recipe);
        }

        // GET: Admin/DeleteRecipe/5
        public ActionResult DeleteRecipe(int id)
        {
            var recipe = db.Recipes.Find(id);
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
            var recipe = db.Recipes.Find(id);
            db.Recipes.Remove(recipe);
            db.SaveChanges();
            return RedirectToAction("ManageRecipes");
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