using Ecommerce.Domain.Entities;

namespace Ecommerce.WebUI
{
    public class CategoryListViewModel
    {
        public CategoryListViewModel()
        {
        }

        public List<Category> Categories { get; set; }
        public int CurrentCategory {  get; set; }
    }
}