using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ThreeAmigos_Corp.Data
{
    public class CustomerWebAppDb : DbContext
    {
        public DbSet<Customer> Customers { get; set; }

        public CustomerWebAppDb(DbContextOptions<CustomerWebAppDb> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            base.OnConfiguring(options);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Customer>(x =>
            {
                x.Property(n => n.Id)
                 .ValueGeneratedNever();
            });

        }
    }
}

