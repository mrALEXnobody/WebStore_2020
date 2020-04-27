using Microsoft.EntityFrameworkCore.Migrations;

namespace WebStore.DAL.Migrations
{
    public partial class AddedProductManufacturer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Brands_BrandId",
                table: "Products");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Brands",
                table: "Brands");

            migrationBuilder.RenameTable(
                name: "Brands",
                newName: "ProductBrands");

            migrationBuilder.AddColumn<string>(
                name: "Manufacturer",
                table: "Products",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductBrands",
                table: "ProductBrands",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_ProductBrands_BrandId",
                table: "Products",
                column: "BrandId",
                principalTable: "ProductBrands",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_ProductBrands_BrandId",
                table: "Products");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductBrands",
                table: "ProductBrands");

            migrationBuilder.DropColumn(
                name: "Manufacturer",
                table: "Products");

            migrationBuilder.RenameTable(
                name: "ProductBrands",
                newName: "Brands");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Brands",
                table: "Brands",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Brands_BrandId",
                table: "Products",
                column: "BrandId",
                principalTable: "Brands",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
