using ECommerce.ENTITIES.CoreInterfaces;
using ECommerce.ENTITIES.Enums;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.ENTITIES.Models
{
    public class Category : BaseEntity
    {
        public string CategoryName { get; set; }
        public string Description { get; set; }

        // Relational Properties

        //public virtual Collection<ProductCategory> ProductCategories { get; set; }

    }
}
