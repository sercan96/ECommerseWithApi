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
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        public ProductRepository(Context db) : base(db)
        {
        }
    }
}
