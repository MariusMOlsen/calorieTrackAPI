using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CalorieTrack.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Diaries",
                columns: table => new
                {
                    Guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Weight = table.Column<double>(type: "float", nullable: false),
                    NutritionGuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    userGuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Sections = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Diaries", x => x.Guid);
                });

            migrationBuilder.CreateTable(
                name: "DiaryItems",
                columns: table => new
                {
                    Guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DiaryGuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Amount = table.Column<int>(type: "int", nullable: false),
                    InstanceDefinition = table.Column<int>(type: "int", nullable: false),
                    ItemGuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiaryItems", x => x.Guid);
                });

            migrationBuilder.CreateTable(
                name: "Meals",
                columns: table => new
                {
                    Guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NutritionGuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserGuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Meals", x => x.Guid);
                });

            migrationBuilder.CreateTable(
                name: "MealsItem",
                columns: table => new
                {
                    Guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MealGuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ItemGuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Amount = table.Column<int>(type: "int", nullable: false),
                    InstanceDefinition = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MealsItem", x => x.Guid);
                });

            migrationBuilder.CreateTable(
                name: "Nutritions",
                columns: table => new
                {
                    Guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Protein = table.Column<double>(type: "float", nullable: false),
                    Carbohydrates = table.Column<double>(type: "float", nullable: false),
                    Fat = table.Column<double>(type: "float", nullable: false),
                    Calories = table.Column<double>(type: "float", nullable: false),
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
                    FoodGuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Amount = table.Column<int>(type: "int", nullable: false)
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
                    UserGuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    InstanceDefinition = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recepies", x => x.Guid);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GoogleUserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProfileType = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Guid);
                });

            migrationBuilder.CreateTable(
                name: "CommonFoods",
                columns: table => new
                {
                    Guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    credibility = table.Column<long>(type: "bigint", nullable: false),
                    InstanceDefinition = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NutritionGuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AmountOfUnit = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Barcode = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommonFoods", x => x.Guid);
                    table.ForeignKey(
                        name: "FK_CommonFoods_Nutritions_NutritionGuid",
                        column: x => x.NutritionGuid,
                        principalTable: "Nutritions",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UnitDefinition",
                columns: table => new
                {
                    Guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    defaultAmount = table.Column<int>(type: "int", nullable: false),
                    NutritionGuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UnitDefinition", x => x.Guid);
                    table.ForeignKey(
                        name: "FK_UnitDefinition_Nutritions_NutritionGuid",
                        column: x => x.NutritionGuid,
                        principalTable: "Nutritions",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserFoods",
                columns: table => new
                {
                    Guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NutritionGuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AmountOfUnit = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Barcode = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserFoods", x => x.Guid);
                    table.ForeignKey(
                        name: "FK_UserFoods_Nutritions_NutritionGuid",
                        column: x => x.NutritionGuid,
                        principalTable: "Nutritions",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserFoods_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CommonFoods_NutritionGuid",
                table: "CommonFoods",
                column: "NutritionGuid");

            migrationBuilder.CreateIndex(
                name: "IX_UnitDefinition_NutritionGuid",
                table: "UnitDefinition",
                column: "NutritionGuid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserFoods_NutritionGuid",
                table: "UserFoods",
                column: "NutritionGuid");

            migrationBuilder.CreateIndex(
                name: "IX_UserFoods_UserId",
                table: "UserFoods",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CommonFoods");

            migrationBuilder.DropTable(
                name: "Diaries");

            migrationBuilder.DropTable(
                name: "DiaryItems");

            migrationBuilder.DropTable(
                name: "Meals");

            migrationBuilder.DropTable(
                name: "MealsItem");

            migrationBuilder.DropTable(
                name: "RecepieItems");

            migrationBuilder.DropTable(
                name: "Recepies");

            migrationBuilder.DropTable(
                name: "UnitDefinition");

            migrationBuilder.DropTable(
                name: "UserFoods");

            migrationBuilder.DropTable(
                name: "Nutritions");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
