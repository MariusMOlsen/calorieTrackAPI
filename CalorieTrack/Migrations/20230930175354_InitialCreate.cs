using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CalorieTrack.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "diaries",
                columns: table => new
                {
                    Guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Weight = table.Column<double>(type: "float", nullable: false),
                    NutritionGuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_diaries", x => x.Guid);
                });

            migrationBuilder.CreateTable(
                name: "DiaryItems",
                columns: table => new
                {
                    Guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DiaryGuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ItemType = table.Column<int>(type: "int", nullable: false),
                    ItemGuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiaryItems", x => x.Guid);
                });

            migrationBuilder.CreateTable(
                name: "Foods",
                columns: table => new
                {
                    Guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NutritionGuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AmountOfUnit = table.Column<int>(type: "int", nullable: false),
                    barcode = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Foods", x => x.Guid);
                });

            migrationBuilder.CreateTable(
                name: "meals",
                columns: table => new
                {
                    Guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NutritionGuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserGuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_meals", x => x.Guid);
                });

            migrationBuilder.CreateTable(
                name: "mealsItem",
                columns: table => new
                {
                    Guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MealGuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MealItemType = table.Column<int>(type: "int", nullable: false),
                    ItemGuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mealsItem", x => x.Guid);
                });

            migrationBuilder.CreateTable(
                name: "Nutritions",
                columns: table => new
                {
                    Guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Protein = table.Column<int>(type: "int", nullable: false),
                    Carbohydrates = table.Column<int>(type: "int", nullable: false),
                    Fat = table.Column<int>(type: "int", nullable: false),
                    Calories = table.Column<int>(type: "int", nullable: false),
                    UnitDefinitionGuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nutritions", x => x.Guid);
                });

            migrationBuilder.CreateTable(
                name: "RecepieItems",
                columns: table => new
                {
                    Guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RecepieGuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FoodGuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecepieItems", x => x.Guid);
                });

            migrationBuilder.CreateTable(
                name: "Recepies",
                columns: table => new
                {
                    Guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NutritionGuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserGuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recepies", x => x.Guid);
                });

            migrationBuilder.CreateTable(
                name: "UnitDefinition",
                columns: table => new
                {
                    Guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    defaultAmount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UnitDefinition", x => x.Guid);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "diaries");

            migrationBuilder.DropTable(
                name: "DiaryItems");

            migrationBuilder.DropTable(
                name: "Foods");

            migrationBuilder.DropTable(
                name: "meals");

            migrationBuilder.DropTable(
                name: "mealsItem");

            migrationBuilder.DropTable(
                name: "Nutritions");

            migrationBuilder.DropTable(
                name: "RecepieItems");

            migrationBuilder.DropTable(
                name: "Recepies");

            migrationBuilder.DropTable(
                name: "UnitDefinition");
        }
    }
}
