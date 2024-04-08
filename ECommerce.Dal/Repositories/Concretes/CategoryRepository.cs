using ECommerce.DAL.ContextClasses;
using ECommerce.DAL.Repositories.Abstracts;
using ECommerce.ENTITIES.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.DAL.Repositories.Concretes
{
    public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(Context db) : base(db)
        {
        }
        public void SpecialCategoryCreation(Category category, List<Product> products)
        {
            Save();
        }
    }
}
