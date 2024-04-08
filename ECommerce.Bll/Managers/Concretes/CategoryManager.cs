using ECommerce.BLL.Managers.Abstracts;
using ECommerce.DAL.Repositories.Abstracts;
using ECommerce.ENTITIES.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.BLL.Managers.Concretes
{
    public class CategoryManager : BaseManager<Category>, ICategoryManager
    {
        ICategoryRepository _cateRep;
        public CategoryManager(ICategoryRepository catRep) : base(catRep)
        {
            _cateRep = catRep;
        }  
        
        
    }
}
