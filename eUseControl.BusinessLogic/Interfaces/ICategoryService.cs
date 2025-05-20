using System.Linq;
using eUseControl.Domain.Entities.Recipe;

namespace eUseControl.BusinessLogic.Interfaces
{
    public interface ICategoryService
    {
        IQueryable<Category> GetAllCategories();
        Category GetCategoryById(int id);
        Category GetCategoryWithRecipes(int id);
        void AddCategory(Category category);
        void UpdateCategory(Category category);
        void DeleteCategory(int id);
    }
} 