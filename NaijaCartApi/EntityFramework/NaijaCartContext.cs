﻿using Microsoft.EntityFrameworkCore;
using NaijaCartApi.Models;
using NaijaCart.Api.Models;

namespace NaijaCartApi.EntityFramework
{
    public partial class NaijaCartContext : DbContext
    {
        public NaijaCartContext(DbContextOptions<NaijaCartContext> options)
            : base(options) { }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<Order> Orders { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(typeof(NaijaCartContext).Assembly);

            base.OnModelCreating(builder);
        }

        public DbSet<NaijaCart.Api.Models.Address> Address { get; set; } = default!;
    }
}
