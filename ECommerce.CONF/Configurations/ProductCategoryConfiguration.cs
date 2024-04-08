using ECommerce.ENTITIES.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.CONF.Configurations
{
    public class ProductCategoryConfiguration :BaseConfiguration<ProductCategory>
    {
        public override void Configure(EntityTypeBuilder<ProductCategory> builder)
        {
            base.Configure(builder);

            builder.Ignore(x => x.ID);
            builder.HasKey(x => new
            {
                x.ProductId,
                x.CategoryId
            });

            //builder.HasOne(pc => pc.Product)
            //    .WithMany(p => p.ProductCategories)
            //    .HasForeignKey(pc => pc.ProductId);

            //builder.HasOne(pc => pc.Category)
            //    .WithMany(c => c.ProductCategories)
            //    .HasForeignKey(pc => pc.CategoryId);

        }
    }
}
