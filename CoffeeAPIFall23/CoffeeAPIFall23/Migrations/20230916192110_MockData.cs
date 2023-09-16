using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CoffeeAPIFall23.Migrations
{
    /// <inheritdoc />
    public partial class MockData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Coffees",
                columns: new[] { "Id", "Characteristic", "Cost", "ImageURL", "Name", "Strength" },
                values: new object[,]
                {
                    { new Guid("0de40e1c-5727-492b-94d9-efa9eefe6080"), "Espresso", 2.45m, "https://upload.wikimedia.org/wikipedia/commons/0/0f/402px-Cappuccino_at_Sightglass_Coffee.jpg", "Espresso", "Strong" },
                    { new Guid("258d4024-3314-43e6-97f0-b49698b05c40"), "Espresso and steamed milk", 3.45m, "https://upload.wikimedia.org/wikipedia/commons/0/0f/402px-Cappuccino_at_Sightglass_Coffee.jpg", "Latte", "Medium" },
                    { new Guid("4618ad48-d836-469f-9dd4-8a2cd1239a0b"), "Espresso and steamed milk", 3.45m, "https://upload.wikimedia.org/wikipedia/commons/0/0f/402px-Cappuccino_at_Sightglass_Coffee.jpg", "Cortado", "Medium" },
                    { new Guid("4922e75c-9bd3-4192-9e7a-3705c600ea73"), "Espresso and hot water", 3.45m, "https://upload.wikimedia.org/wikipedia/commons/0/0f/402px-Cappuccino_at_Sightglass_Coffee.jpg", "Americano", "Medium" },
                    { new Guid("7072fa5a-a417-464d-b4bf-3b6aaa7e8260"), "Espresso, steamed milk, and milk foam", 3.45m, "https://upload.wikimedia.org/wikipedia/commons/0/0f/402px-Cappuccino_at_Sightglass_Coffee.jpg", "Cappuccino", "Medium" },
                    { new Guid("78814f49-ea40-49e6-9c70-e58ddd49c681"), "Espresso, steamed milk, milk foam, and chocolate", 3.45m, "https://upload.wikimedia.org/wikipedia/commons/0/0f/402px-Cappuccino_at_Sightglass_Coffee.jpg", "Mocha", "Medium" },
                    { new Guid("ff024a63-e7f1-4734-94f8-d09efd1f4be2"), "Espresso and milk foam", 3.45m, "https://upload.wikimedia.org/wikipedia/commons/0/0f/402px-Cappuccino_at_Sightglass_Coffee.jpg", "Macchiato", "Medium" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Coffees",
                keyColumn: "Id",
                keyValue: new Guid("0de40e1c-5727-492b-94d9-efa9eefe6080"));

            migrationBuilder.DeleteData(
                table: "Coffees",
                keyColumn: "Id",
                keyValue: new Guid("258d4024-3314-43e6-97f0-b49698b05c40"));

            migrationBuilder.DeleteData(
                table: "Coffees",
                keyColumn: "Id",
                keyValue: new Guid("4618ad48-d836-469f-9dd4-8a2cd1239a0b"));

            migrationBuilder.DeleteData(
                table: "Coffees",
                keyColumn: "Id",
                keyValue: new Guid("4922e75c-9bd3-4192-9e7a-3705c600ea73"));

            migrationBuilder.DeleteData(
                table: "Coffees",
                keyColumn: "Id",
                keyValue: new Guid("7072fa5a-a417-464d-b4bf-3b6aaa7e8260"));

            migrationBuilder.DeleteData(
                table: "Coffees",
                keyColumn: "Id",
                keyValue: new Guid("78814f49-ea40-49e6-9c70-e58ddd49c681"));

            migrationBuilder.DeleteData(
                table: "Coffees",
                keyColumn: "Id",
                keyValue: new Guid("ff024a63-e7f1-4734-94f8-d09efd1f4be2"));
        }
    }
}
