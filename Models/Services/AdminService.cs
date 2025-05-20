using System.Linq;
using System.Data.Entity;
using MRSTWeb.Models;

namespace MRSTWeb.Models.Services
{
    public class AdminService
    {
        private readonly ReteteContext _db;

        public AdminService()
        {
            _db = new ReteteContext();
        }

        public IQueryable<Recipe> GetAllRecipesWithCategories()
        {
            return _db.Recipes.Include(r => r.Category);
        }

        public IQueryable<Category> GetAllCategories()
        {
            return _db.Categories;
        }

        public Recipe GetRecipeById(int id)
        {
            return _db.Recipes.Find(id);
        }

        public void UpdateRecipe(Recipe recipe)
        {
            _db.Entry(recipe).State = EntityState.Modified;
            _db.SaveChanges();
        }

        public void DeleteRecipe(int id)
        {
            var recipe = _db.Recipes.Find(id);
            if (recipe != null)
            {
                _db.Recipes.Remove(recipe);
                _db.SaveChanges();
            }
        }

        public void Dispose()
        {
            _db.Dispose();
        }
    }
} 