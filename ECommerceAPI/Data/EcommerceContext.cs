using System.Reflection.Metadata;
using ECommerceAPI.Entities;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;

namespace ECommerceAPI.Data
{
    public class EcommerceContext : DbContext
    {
       
        public EcommerceContext(DbContextOptions<EcommerceContext> options) : base(options)
        {
        }

        public DbSet<Users> Users { get; set; }
        public DbSet<Reviews> Reviews { get; set; }
        public DbSet<Roles> Roles { get; set; }

        public DbSet<Products> Products { get; set; }

        public DbSet<ReviewComments> ReviewComments { get; set; }
        public DbSet<Likes> Likes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            //Users Relationships
            modelBuilder.Entity<Users>()
                .HasOne(u => u.Role)
                .WithMany(r => r.Users)
                .HasForeignKey(u => u.RoleId);
            modelBuilder.Entity<Users>()
                .HasMany(u => u.Reviews)
                .WithOne(r => r.Users)
                .HasForeignKey(r => r.UserId);
            modelBuilder.Entity<Users>()
                .HasMany(u => u.ReviewComments)
                .WithOne(r => r.Users)
                .HasForeignKey(r => r.UserId);


            //Reviews Relationships
            modelBuilder.Entity<Reviews>()
                .HasOne(r => r.Users)
                .WithMany(u => u.Reviews)
                .HasForeignKey(r => r.UserId);
            modelBuilder.Entity<Reviews>()
                .HasOne(r => r.Products)
                .WithMany(p => p.Reviews)
                .HasForeignKey(r => r.ProductId);
            modelBuilder.Entity<Reviews>()
                .HasMany(r => r.ReviewComments)
                .WithOne(rc => rc.Reviews)
                .HasForeignKey(rc => rc.ReviewId);

            //Products Relationships
            modelBuilder.Entity<Products>()
                .HasMany(p => p.Reviews)
                .WithOne(r => r.Products)
                .HasForeignKey(r => r.ProductId);

            //ReviewComments Relationships
            modelBuilder.Entity<ReviewComments>()
                .HasOne(rc => rc.Users)
                .WithMany(u => u.ReviewComments)
                .HasForeignKey(rc => rc.UserId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<ReviewComments>()
                .HasOne(rc => rc.Reviews)
                .WithMany(r => r.ReviewComments)
                .HasForeignKey(rc => rc.ReviewId)
                .OnDelete(DeleteBehavior.Restrict);

            //Roles Relationships
            modelBuilder.Entity<Roles>()
                .HasMany(r => r.Users)
                .WithOne(u => u.Role)
                .HasForeignKey(u => u.RoleId);

            //Likes Relationships
            modelBuilder.Entity<Likes>()
                .HasOne(l => l.User)
                .WithMany(u => u.Likes)
                .HasForeignKey(l => l.UserId);
            modelBuilder.Entity<Likes>()
                .HasOne(l => l.Product)
                .WithMany(r => r.Likes)
                .HasForeignKey(l => l.ProductId);


        }
    }
}


