using System.Linq;
using System.Data.Entity;
using eUseControl.BusinessLogic.Interfaces;
using eUseControl.Domain.Entities.Recipe;

namespace eUseControl.BusinessLogic.Core
{
    public class RecipeService : IRecipeService
    {
        private readonly ReteteContext _db;

        public RecipeService()
        {
            _db = new ReteteContext();
        }

        public IQueryable<Recipe> GetFeaturedRecipes(int count = 3)
        {
            return _db.Recipes.Include(r => r.Category).Take(count);
        }

        public IQueryable<Recipe> GetAllRecipes()
        {
            return _db.Recipes.Include(r => r.Category);
        }

        public Recipe GetRecipeById(int id)
        {
            return _db.Recipes.Include(r => r.Category)
                             .FirstOrDefault(r => r.RecipeId == id);
        }

        public IQueryable<Recipe> GetRecipesByCategory(int categoryId)
        {
            return _db.Recipes.Include(r => r.Category)
                             .Where(r => r.CategoryId == categoryId);
        }

        public void AddRecipe(Recipe recipe)
        {
            _db.Recipes.Add(recipe);
            _db.SaveChanges();
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
    }
} 