using Microsoft.EntityFrameworkCore;
using StoreWebAPI_Assingment.Models.Category;
using StoreWebAPI_Assingment.Models.Order;
using StoreWebAPI_Assingment.Models.Product;
using StoreWebAPI_Assingment.Models.User;

namespace StoreWebAPI_Assingment.Models.Data
{
    public class DataContext : DbContext
    {
        public DataContext()
        {
        }

        public DataContext(DbContextOptions options) : base(options)
        {
        }

        public virtual DbSet<UserEntity> Users { get; set; } = null!;
        public virtual DbSet<ProductEntity> Products { get; set; } = null!;
        public virtual DbSet<CategoryEntity> Categories { get; set; } = null!;
        public virtual DbSet<OrderEntity> Orders { get; set; } = null!;
        public virtual DbSet<OrderRowEntity> OrderRows { get; set; } = null!;

        //For creating a table in db without PKEY
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<OrderRowEntity>()
                .HasKey(c => new { c.OrderId, c.ArticleNumber });

        }
    }
}
