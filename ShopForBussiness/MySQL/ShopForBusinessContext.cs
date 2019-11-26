using ShopForBussiness.Domain;
using System.Data.Entity;

namespace ShopForBussiness.MySQL
{
    public class ShopForBusinessContext : DbContext
    {
        public DbSet<User> User { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<Address> Address { get; set; }

        public ShopForBusinessContext() : base("MySQLConnection")
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<User>()
                .HasMany(x => x.Orders)
                .WithRequired(x => x.User)
                .HasForeignKey(x => x.UserID)
                .WillCascadeOnDelete();

            modelBuilder.Entity<User>()
                .HasOptional(x => x.Address)
                .WithRequired(x => x.User)
                .WillCascadeOnDelete();

            modelBuilder.Entity<Address>()
                .HasKey(x => x.UserID);

            modelBuilder.Entity<Order>();

            modelBuilder.Entity<Product>();
        }
    }
}