﻿using Microsoft.EntityFrameworkCore;
using System;
using WebStore.DomainNew.Entities;

namespace WebStore.DAL
{
    public class WebStoreContext : DbContext
    {
        public WebStoreContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Brand> Brands { get; set; }
    }
}
