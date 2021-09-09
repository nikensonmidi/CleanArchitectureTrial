using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DodoBed.Manufacturing.SqlPersistence.Migrations
{
    public partial class migration1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "LastModifiedDate",
                table: "Tools",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2021, 9, 9, 13, 8, 25, 613, DateTimeKind.Local).AddTicks(3368),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2021, 9, 3, 12, 47, 21, 870, DateTimeKind.Local).AddTicks(5018));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Tools",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 9, 13, 8, 25, 613, DateTimeKind.Local).AddTicks(1634),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 9, 3, 12, 47, 21, 870, DateTimeKind.Local).AddTicks(4467));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastModifiedDate",
                table: "Products",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2021, 9, 9, 13, 8, 25, 603, DateTimeKind.Local).AddTicks(9603),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2021, 9, 3, 12, 47, 21, 868, DateTimeKind.Local).AddTicks(5766));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Products",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 9, 13, 8, 25, 587, DateTimeKind.Local).AddTicks(2229),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 9, 3, 12, 47, 21, 859, DateTimeKind.Local).AddTicks(1294));

            migrationBuilder.AddColumn<int>(
                name: "DimensionId",
                table: "Products",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "InHouseName",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Notes",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Dimensions",
                columns: table => new
                {
                    DimensionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Length = table.Column<double>(type: "float", nullable: false),
                    Width = table.Column<double>(type: "float", nullable: false),
                    Height = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dimensions", x => x.DimensionId);
                });

            migrationBuilder.CreateTable(
                name: "ProductLocations",
                columns: table => new
                {
                    ProductLocationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductItemId = table.Column<long>(type: "bigint", nullable: true),
                    BuildingNumber = table.Column<int>(type: "int", nullable: false),
                    SectionNumber = table.Column<int>(type: "int", nullable: false),
                    AisleNumber = table.Column<int>(type: "int", nullable: false),
                    ShelfNumber = table.Column<int>(type: "int", nullable: false),
                    Barcode = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductLocations", x => x.ProductLocationId);
                    table.ForeignKey(
                        name: "FK_ProductLocations_Products_ProductItemId",
                        column: x => x.ProductItemId,
                        principalTable: "Products",
                        principalColumn: "ItemId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_DimensionId",
                table: "Products",
                column: "DimensionId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductLocations_ProductItemId",
                table: "ProductLocations",
                column: "ProductItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Dimensions_DimensionId",
                table: "Products",
                column: "DimensionId",
                principalTable: "Dimensions",
                principalColumn: "DimensionId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Dimensions_DimensionId",
                table: "Products");

            migrationBuilder.DropTable(
                name: "Dimensions");

            migrationBuilder.DropTable(
                name: "ProductLocations");

            migrationBuilder.DropIndex(
                name: "IX_Products_DimensionId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "DimensionId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "InHouseName",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Notes",
                table: "Products");

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastModifiedDate",
                table: "Tools",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2021, 9, 3, 12, 47, 21, 870, DateTimeKind.Local).AddTicks(5018),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2021, 9, 9, 13, 8, 25, 613, DateTimeKind.Local).AddTicks(3368));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Tools",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 3, 12, 47, 21, 870, DateTimeKind.Local).AddTicks(4467),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 9, 9, 13, 8, 25, 613, DateTimeKind.Local).AddTicks(1634));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastModifiedDate",
                table: "Products",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2021, 9, 3, 12, 47, 21, 868, DateTimeKind.Local).AddTicks(5766),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2021, 9, 9, 13, 8, 25, 603, DateTimeKind.Local).AddTicks(9603));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Products",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 3, 12, 47, 21, 859, DateTimeKind.Local).AddTicks(1294),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 9, 9, 13, 8, 25, 587, DateTimeKind.Local).AddTicks(2229));
        }
    }
}
