using System.Linq;
using System.Data.Entity;

namespace MRSTWeb.Models.Services
{
    public class CategoryService
    {
        private readonly ReteteContext _db;

        public CategoryService()
        {
            _db = new ReteteContext();
        }

        public IQueryable<Category> GetAllCategories()
        {
            return _db.Categories;
        }

        public Category GetCategoryById(int id)
        {
            return _db.Categories.Find(id);
        }

        public Category GetCategoryWithRecipes(int id)
        {
            return _db.Categories
                     .Include(c => c.Recipes)
                     .FirstOrDefault(c => c.CategoryId == id);
        }

        public void AddCategory(Category category)
        {
            _db.Categories.Add(category);
            _db.SaveChanges();
        }

        public void UpdateCategory(Category category)
        {
            _db.Entry(category).State = EntityState.Modified;
            _db.SaveChanges();
        }

        public void DeleteCategory(int id)
        {
            var category = _db.Categories.Find(id);
            if (category != null)
            {
                _db.Categories.Remove(category);
                _db.SaveChanges();
            }
        }

        public void Dispose()
        {
            _db.Dispose();
        }
    }
} 