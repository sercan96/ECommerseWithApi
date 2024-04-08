using ECommerce.ENTITIES.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.DAL.Repositories.Abstracts
{
    public interface ICategoryRepository : IRepository<Category>
    {
        // Special Methods
        void SpecialCategoryCreation(Category category, List<Product> products);
    }
}
