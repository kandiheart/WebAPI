using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PokemonAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddJsonPokemon : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Pokemons",
                columns: new[] { "Id", "Attack", "Defense", "Description", "DexNumber", "Name", "Region", "Stamina", "Type" },
                values: new object[,]
                {
                    { new Guid("3fa85f64-5717-4562-b3fc-2c963f66afa6"), 275, 211, "When Reshiram's tail flares, the heat energy moves the atmosphere and changes the world's weather.", 643, "Reshiram", "Unova", 205, "Dragon/Fire" },
                    { new Guid("45b9a683-22d5-4e97-8f2b-9dfc1b2c362e"), 171, 150, "It's said that on nights of terrible blizzards, it comes down to human settlements. If you hear it knocking at your door, do not open it!", 478, "Froslass", "Sinnoh", 172, "Ice/Ghost" },
                    { new Guid("537a6d14-272f-4b4d-8bb5-1f53b7d9a74e"), 261, 175, "Espeon is extremely loyal to any Trainer it considers to be worthy. It is said that this Pokémon developed its precognitive powers to protect its Trainer from harm.", 196, "Espeon", "Johto", 163, "Psychic" },
                    { new Guid("92c13c86-63f8-41ab-a3f3-8c1d44ff4050"), 126, 240, "Umbreon evolved as a result of exposure to the moon's waves. It hides silently in darkness and waits for its foes to make a move. The rings on its body glow when it leaps to attack.", 197, "Umbreon", "Johto", 216, "Dark" },
                    { new Guid("f59a62fb-9e3e-4837-8a14-0d9063b27b7d"), 251, 207, "Tyranitar is so overwhelmingly powerful, it can bring down a whole mountain to make its nest. This Pokémon wanders about in mountains seeking new opponents to fight.", 248, "Tyranitar", "Johto", 225, "Rock/Dark" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Pokemons",
                keyColumn: "Id",
                keyValue: new Guid("3fa85f64-5717-4562-b3fc-2c963f66afa6"));

            migrationBuilder.DeleteData(
                table: "Pokemons",
                keyColumn: "Id",
                keyValue: new Guid("45b9a683-22d5-4e97-8f2b-9dfc1b2c362e"));

            migrationBuilder.DeleteData(
                table: "Pokemons",
                keyColumn: "Id",
                keyValue: new Guid("537a6d14-272f-4b4d-8bb5-1f53b7d9a74e"));

            migrationBuilder.DeleteData(
                table: "Pokemons",
                keyColumn: "Id",
                keyValue: new Guid("92c13c86-63f8-41ab-a3f3-8c1d44ff4050"));

            migrationBuilder.DeleteData(
                table: "Pokemons",
                keyColumn: "Id",
                keyValue: new Guid("f59a62fb-9e3e-4837-8a14-0d9063b27b7d"));
        }
    }
}
