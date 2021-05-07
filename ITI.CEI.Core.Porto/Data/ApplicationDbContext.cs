using System;
using System.Collections.Generic;
using System.Text;
using ITI.CEI.Core.Porto.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ITI.CEI.Core.Porto.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }


        public virtual DbSet<Category> Categories { get; set; }

        public virtual DbSet<Product> Products { get; set; }

        public virtual DbSet<PaymentType> PaymentTypes { get; set; }

        public virtual DbSet<Tag> Tags { get; set; }

        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<CategoryRequest> CategoryRequests { get; set; }
        public virtual DbSet<Image> Images { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            // Relation Product Tag
            modelBuilder.Entity<ProductTag>().HasKey(pt => new { pt.ProductId, pt.TagId });

            modelBuilder.Entity<ProductTag>()
                .HasOne(pt => pt.product).WithMany(pt => pt.ProductTags).HasForeignKey(pt => pt.ProductId);

            modelBuilder.Entity<ProductTag>()
                .HasOne(pt => pt.Tag).WithMany(pt => pt.ProductTags).HasForeignKey(pt => pt.TagId);


            // Relation Product PaymentType
            modelBuilder.Entity<ProductPaymentType>().HasKey(pt => new { pt.ProductId, pt.PaymentTypeId });

            modelBuilder.Entity<ProductPaymentType>()
                .HasOne(pt => pt.product).WithMany(pt => pt.ProductPaymentTypes).HasForeignKey(pt => pt.ProductId);

            modelBuilder.Entity<ProductPaymentType>()
                .HasOne(pt => pt.PaymentType).WithMany(pt => pt.ProductPaymentTypes).HasForeignKey(pt => pt.PaymentTypeId);


            // Relation Product Order
            modelBuilder.Entity<ProductsOrder>().HasKey(pt => new { pt.ProductId, pt.OrderId });

            modelBuilder.Entity<ProductsOrder>()
                .HasOne(pt => pt.product).WithMany(pt => pt.ProductsOrders).HasForeignKey(pt => pt.ProductId);

            modelBuilder.Entity<ProductsOrder>()
                .HasOne(pt => pt.Order).WithMany(pt => pt.ProductsOrders).HasForeignKey(pt => pt.OrderId);
        }
    }
}
