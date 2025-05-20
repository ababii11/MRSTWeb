using eUseControl.BusinessLogic.Core;
using eUseControl.BusinessLogic.Interfaces;

namespace eUseControl.BusinessLogic
{
    public class BusinessLogic
    {
        public ISession GetSessionBL()
        {
            return new SessionBL();
        }

        public IRecipeService GetRecipeService()
        {
            return new RecipeService();
        }

        public ICategoryService GetCategoryService()
        {
            return new CategoryService();
        }
    }
} 