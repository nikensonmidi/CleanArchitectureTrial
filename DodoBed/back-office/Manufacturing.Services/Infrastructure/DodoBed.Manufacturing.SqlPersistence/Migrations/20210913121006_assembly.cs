using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DodoBed.Manufacturing.SqlPersistence.Migrations
{
    public partial class assembly : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Notes",
                table: "Products");

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastModifiedDate",
                table: "Tools",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2021, 9, 13, 8, 10, 5, 847, DateTimeKind.Local).AddTicks(5932),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2021, 9, 10, 17, 59, 20, 774, DateTimeKind.Local).AddTicks(4778));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Tools",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 13, 8, 10, 5, 847, DateTimeKind.Local).AddTicks(4918),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 9, 10, 17, 59, 20, 774, DateTimeKind.Local).AddTicks(3602));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastModifiedDate",
                table: "Products",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2021, 9, 13, 8, 10, 5, 839, DateTimeKind.Local).AddTicks(1387),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2021, 9, 10, 17, 59, 20, 765, DateTimeKind.Local).AddTicks(3734));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Products",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 13, 8, 10, 5, 824, DateTimeKind.Local).AddTicks(7962),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 9, 10, 17, 59, 20, 752, DateTimeKind.Local).AddTicks(7627));

            migrationBuilder.AddColumn<long>(
                name: "ProductItemId",
                table: "Notes",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "ManufacturedProductAssemblyId1",
                table: "ManufacturedProductAssemblies",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Notes_ProductItemId",
                table: "Notes",
                column: "ProductItemId");

            migrationBuilder.CreateIndex(
                name: "IX_ManufacturedProductAssemblies_ManufacturedProductAssemblyId1",
                table: "ManufacturedProductAssemblies",
                column: "ManufacturedProductAssemblyId1");

            migrationBuilder.AddForeignKey(
                name: "FK_ManufacturedProductAssemblies_ManufacturedProductAssemblies_ManufacturedProductAssemblyId1",
                table: "ManufacturedProductAssemblies",
                column: "ManufacturedProductAssemblyId1",
                principalTable: "ManufacturedProductAssemblies",
                principalColumn: "ManufacturedProductAssemblyId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Notes_Products_ProductItemId",
                table: "Notes",
                column: "ProductItemId",
                principalTable: "Products",
                principalColumn: "ItemId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ManufacturedProductAssemblies_ManufacturedProductAssemblies_ManufacturedProductAssemblyId1",
                table: "ManufacturedProductAssemblies");

            migrationBuilder.DropForeignKey(
                name: "FK_Notes_Products_ProductItemId",
                table: "Notes");

            migrationBuilder.DropIndex(
                name: "IX_Notes_ProductItemId",
                table: "Notes");

            migrationBuilder.DropIndex(
                name: "IX_ManufacturedProductAssemblies_ManufacturedProductAssemblyId1",
                table: "ManufacturedProductAssemblies");

            migrationBuilder.DropColumn(
                name: "ProductItemId",
                table: "Notes");

            migrationBuilder.DropColumn(
                name: "ManufacturedProductAssemblyId1",
                table: "ManufacturedProductAssemblies");

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastModifiedDate",
                table: "Tools",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2021, 9, 10, 17, 59, 20, 774, DateTimeKind.Local).AddTicks(4778),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2021, 9, 13, 8, 10, 5, 847, DateTimeKind.Local).AddTicks(5932));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Tools",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 10, 17, 59, 20, 774, DateTimeKind.Local).AddTicks(3602),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 9, 13, 8, 10, 5, 847, DateTimeKind.Local).AddTicks(4918));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastModifiedDate",
                table: "Products",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2021, 9, 10, 17, 59, 20, 765, DateTimeKind.Local).AddTicks(3734),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2021, 9, 13, 8, 10, 5, 839, DateTimeKind.Local).AddTicks(1387));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Products",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 10, 17, 59, 20, 752, DateTimeKind.Local).AddTicks(7627),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 9, 13, 8, 10, 5, 824, DateTimeKind.Local).AddTicks(7962));

            migrationBuilder.AddColumn<string>(
                name: "Notes",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
