using Microsoft.EntityFrameworkCore;

namespace GeekShopping.ProductAPI.Model.Context
{
    public class MySQLContext: DbContext
    {
        public MySQLContext() {}
        public MySQLContext(DbContextOptions<MySQLContext> options) : base(options) {}

        public DbSet<Product> Products { get; set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = 3,
                Name = "Name 3",
                Price = new decimal(69.9),
                Description = "Integer tempus vulputate felis, id eleifend urna vestibulum sit amet. Pellentesque ligula libero, tincidunt in rutrum a, condimentum eget velit. Vestibulum semper mattis iaculis. Fusce molestie nibh eget ipsum porta, vitae iaculis magna efficitur. Nullam quis mi sit amet erat fermentum tincidunt vel id dolor. Nulla sit amet lacinia ipsum.",
                ImageURL = "https://github.com/anderson-lda/geekshopping/blob/main/ShoppingImages/3_vader.jpg?raw=true",
                CategoryName = "Category",
            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = 4,
                Name = "Name 4",
                Price = new decimal(69.9),
                Description = "Integer tempus vulputate felis, id eleifend urna vestibulum sit amet. Pellentesque ligula libero, tincidunt in rutrum a, condimentum eget velit. Vestibulum semper mattis iaculis. Fusce molestie nibh eget ipsum porta, vitae iaculis magna efficitur. Nullam quis mi sit amet erat fermentum tincidunt vel id dolor. Nulla sit amet lacinia ipsum.",
                ImageURL = "https://github.com/anderson-lda/geekshopping/blob/main/ShoppingImages/11_mars.jpg?raw=true",
                CategoryName = "Category",
            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = 5,
                Name = "Name 5",
                Price = new decimal(69.9),
                Description = "Integer tempus vulputate felis, id eleifend urna vestibulum sit amet. Pellentesque ligula libero, tincidunt in rutrum a, condimentum eget velit. Vestibulum semper mattis iaculis. Fusce molestie nibh eget ipsum porta, vitae iaculis magna efficitur. Nullam quis mi sit amet erat fermentum tincidunt vel id dolor. Nulla sit amet lacinia ipsum.",
                ImageURL = "https://github.com/anderson-lda/geekshopping/blob/main/ShoppingImages/10_milennium_falcon.jpg?raw=true",
                CategoryName = "Category",
            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = 6,
                Name = "Name 6",
                Price = new decimal(69.9),
                Description = "Integer tempus vulputate felis, id eleifend urna vestibulum sit amet. Pellentesque ligula libero, tincidunt in rutrum a, condimentum eget velit. Vestibulum semper mattis iaculis. Fusce molestie nibh eget ipsum porta, vitae iaculis magna efficitur. Nullam quis mi sit amet erat fermentum tincidunt vel id dolor. Nulla sit amet lacinia ipsum.",
                ImageURL = "https://github.com/anderson-lda/geekshopping/blob/main/ShoppingImages/11_mars.jpg?raw=true",
                CategoryName = "Category",
            });
        }
    }
}
