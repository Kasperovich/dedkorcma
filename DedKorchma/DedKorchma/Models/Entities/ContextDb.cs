using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity.EntityFramework;

namespace DedKorchma.Models.Entities
{
    public class ContextDb : IdentityDbContext<User>
    {
        public ContextDb()
           : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ContextDb Create()
        {
            return new ContextDb();
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            modelBuilder.Entity<User>().ToTable("T_Users");
            modelBuilder.Entity<IdentityRole>().ToTable("T_Roles");
            modelBuilder.Entity<IdentityUserRole>().ToTable("T_UserRoles");
            modelBuilder.Entity<IdentityUserLogin>().ToTable("T_UserLogins");
            modelBuilder.Entity<IdentityUserClaim>().ToTable("T_UserClaims");
            modelBuilder.Entity<Album>().ToTable("T_Albums");
            modelBuilder.Entity<AlbumPhoto>().ToTable("T_AlbumPhotos");
            modelBuilder.Entity<Category>().ToTable("T_Categories");
            modelBuilder.Entity<News>().ToTable("T_News");
            modelBuilder.Entity<Photo>().ToTable("T_Photos");
            modelBuilder.Entity<Product>().ToTable("T_Products");
        }
        public DbSet<Album> Albums { get; set; }
        public DbSet<AlbumPhoto> AlbumPhotos { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<News> News { get; set; }
        public DbSet<Photo> Photos { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}