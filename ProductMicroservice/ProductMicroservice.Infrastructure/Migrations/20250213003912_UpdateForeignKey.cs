using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProductMicroservice.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateForeignKey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CategoryVariations_ProductCategories_ProductCategoryId",
                table: "CategoryVariations");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_ProductCategories_ProductCategoryId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_VariationValues_CategoryVariations_CategoryVariationId",
                table: "VariationValues");

            migrationBuilder.DropIndex(
                name: "IX_VariationValues_CategoryVariationId",
                table: "VariationValues");

            migrationBuilder.DropIndex(
                name: "IX_Products_ProductCategoryId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_CategoryVariations_ProductCategoryId",
                table: "CategoryVariations");

            migrationBuilder.DropColumn(
                name: "CategoryVariationId",
                table: "VariationValues");

            migrationBuilder.DropColumn(
                name: "ProductCategoryId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ProductCategoryId",
                table: "CategoryVariations");

            migrationBuilder.CreateIndex(
                name: "IX_VariationValues_VariationId",
                table: "VariationValues",
                column: "VariationId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_CategoryVariations_CategoryId",
                table: "CategoryVariations",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_CategoryVariations_ProductCategories_CategoryId",
                table: "CategoryVariations",
                column: "CategoryId",
                principalTable: "ProductCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_ProductCategories_CategoryId",
                table: "Products",
                column: "CategoryId",
                principalTable: "ProductCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_VariationValues_CategoryVariations_VariationId",
                table: "VariationValues",
                column: "VariationId",
                principalTable: "CategoryVariations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CategoryVariations_ProductCategories_CategoryId",
                table: "CategoryVariations");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_ProductCategories_CategoryId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_VariationValues_CategoryVariations_VariationId",
                table: "VariationValues");

            migrationBuilder.DropIndex(
                name: "IX_VariationValues_VariationId",
                table: "VariationValues");

            migrationBuilder.DropIndex(
                name: "IX_Products_CategoryId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_CategoryVariations_CategoryId",
                table: "CategoryVariations");

            migrationBuilder.AddColumn<int>(
                name: "CategoryVariationId",
                table: "VariationValues",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ProductCategoryId",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ProductCategoryId",
                table: "CategoryVariations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_VariationValues_CategoryVariationId",
                table: "VariationValues",
                column: "CategoryVariationId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_ProductCategoryId",
                table: "Products",
                column: "ProductCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_CategoryVariations_ProductCategoryId",
                table: "CategoryVariations",
                column: "ProductCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_CategoryVariations_ProductCategories_ProductCategoryId",
                table: "CategoryVariations",
                column: "ProductCategoryId",
                principalTable: "ProductCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_ProductCategories_ProductCategoryId",
                table: "Products",
                column: "ProductCategoryId",
                principalTable: "ProductCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_VariationValues_CategoryVariations_CategoryVariationId",
                table: "VariationValues",
                column: "CategoryVariationId",
                principalTable: "CategoryVariations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
