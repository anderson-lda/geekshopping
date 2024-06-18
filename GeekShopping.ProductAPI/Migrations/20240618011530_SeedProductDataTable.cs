using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GeekShopping.ProductAPI.Migrations
{
    public partial class SeedProductDataTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "product",
                columns: new[] { "id", "category_name", "description", "image_url", "name", "price" },
                values: new object[,]
                {
                    { 3L, "Category", "Integer tempus vulputate felis, id eleifend urna vestibulum sit amet. Pellentesque ligula libero, tincidunt in rutrum a, condimentum eget velit. Vestibulum semper mattis iaculis. Fusce molestie nibh eget ipsum porta, vitae iaculis magna efficitur. Nullam quis mi sit amet erat fermentum tincidunt vel id dolor. Nulla sit amet lacinia ipsum.", "https://github.com/anderson-lda/geekshopping/blob/main/ShoppingImages/3_vader.jpg?raw=true", "Name 3", 69.9m },
                    { 4L, "Category", "Integer tempus vulputate felis, id eleifend urna vestibulum sit amet. Pellentesque ligula libero, tincidunt in rutrum a, condimentum eget velit. Vestibulum semper mattis iaculis. Fusce molestie nibh eget ipsum porta, vitae iaculis magna efficitur. Nullam quis mi sit amet erat fermentum tincidunt vel id dolor. Nulla sit amet lacinia ipsum.", "https://github.com/anderson-lda/geekshopping/blob/main/ShoppingImages/11_mars.jpg?raw=true", "Name 4", 69.9m },
                    { 5L, "Category", "Integer tempus vulputate felis, id eleifend urna vestibulum sit amet. Pellentesque ligula libero, tincidunt in rutrum a, condimentum eget velit. Vestibulum semper mattis iaculis. Fusce molestie nibh eget ipsum porta, vitae iaculis magna efficitur. Nullam quis mi sit amet erat fermentum tincidunt vel id dolor. Nulla sit amet lacinia ipsum.", "https://github.com/anderson-lda/geekshopping/blob/main/ShoppingImages/10_milennium_falcon.jpg?raw=true", "Name 5", 69.9m },
                    { 6L, "Category", "Integer tempus vulputate felis, id eleifend urna vestibulum sit amet. Pellentesque ligula libero, tincidunt in rutrum a, condimentum eget velit. Vestibulum semper mattis iaculis. Fusce molestie nibh eget ipsum porta, vitae iaculis magna efficitur. Nullam quis mi sit amet erat fermentum tincidunt vel id dolor. Nulla sit amet lacinia ipsum.", "https://github.com/anderson-lda/geekshopping/blob/main/ShoppingImages/11_mars.jpg?raw=true", "Name 6", 69.9m }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "product",
                keyColumn: "id",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "product",
                keyColumn: "id",
                keyValue: 4L);

            migrationBuilder.DeleteData(
                table: "product",
                keyColumn: "id",
                keyValue: 5L);

            migrationBuilder.DeleteData(
                table: "product",
                keyColumn: "id",
                keyValue: 6L);
        }
    }
}
