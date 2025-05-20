using System.Linq;
using eUseControl.Domain.Entities.Recipe;

namespace eUseControl.BusinessLogic.Interfaces
{
    public interface IRecipeService
    {
        IQueryable<Recipe> GetFeaturedRecipes(int count = 3);
        IQueryable<Recipe> GetAllRecipes();
        Recipe GetRecipeById(int id);
        IQueryable<Recipe> GetRecipesByCategory(int categoryId);
        void AddRecipe(Recipe recipe);
        void UpdateRecipe(Recipe recipe);
        void DeleteRecipe(int id);
    }
} 