using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PokemonAPI.Migrations
{
    /// <inheritdoc />
    public partial class PokemonImage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageURL",
                table: "Pokemons",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Pokemons",
                keyColumn: "Id",
                keyValue: new Guid("3fa85f64-5717-4562-b3fc-2c963f66afa6"),
                column: "ImageURL",
                value: "https://img.pokemondb.net/artwork/reshiram.jpg");

            migrationBuilder.UpdateData(
                table: "Pokemons",
                keyColumn: "Id",
                keyValue: new Guid("45b9a683-22d5-4e97-8f2b-9dfc1b2c362e"),
                column: "ImageURL",
                value: "https://img.pokemondb.net/artwork/froslass.jpg");

            migrationBuilder.UpdateData(
                table: "Pokemons",
                keyColumn: "Id",
                keyValue: new Guid("537a6d14-272f-4b4d-8bb5-1f53b7d9a74e"),
                column: "ImageURL",
                value: "https://img.pokemondb.net/artwork/espeon.jpg");

            migrationBuilder.UpdateData(
                table: "Pokemons",
                keyColumn: "Id",
                keyValue: new Guid("92c13c86-63f8-41ab-a3f3-8c1d44ff4050"),
                column: "ImageURL",
                value: "https://img.pokemondb.net/artwork/umbreon.jpg");

            migrationBuilder.UpdateData(
                table: "Pokemons",
                keyColumn: "Id",
                keyValue: new Guid("f59a62fb-9e3e-4837-8a14-0d9063b27b7d"),
                column: "ImageURL",
                value: "https://img.pokemondb.net/artwork/tyranitar.jpg");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageURL",
                table: "Pokemons");
        }
    }
}
