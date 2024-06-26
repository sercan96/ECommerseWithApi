﻿using ECommerce.CONF.Configurations;
using ECommerce.ENTITIES.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.DAL.ContextClasses
{
    public class Context : DbContext
    {
        /*
         * Bu metotta, MyContext sınıfı, ConfigureServices metodu içerisinde AddDbContextPool metodu kullanılarak servisler koleksiyonuna eklenir. Böylece, MyContext türündeki nesneler, Controller'ların constructor'larına otomatik olarak enjekte edilir ve kullanılabilir hale gelir.
        */
        public Context(DbContextOptions<Context> options) : base(options)
        {
           
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

    }
}
