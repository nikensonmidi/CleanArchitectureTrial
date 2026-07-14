using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DodoBed.Manufacturing.SqlPersistence.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Costs",
                columns: table => new
                {
                    CostId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UnitCost = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    FreightCost = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    AverageUnitCost = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Costs", x => x.CostId);
                });

            migrationBuilder.CreateTable(
                name: "DigitalAddressTypes",
                columns: table => new
                {
                    DigitalAddressTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DigitalAddressTypes", x => x.DigitalAddressTypeId);
                });

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
                name: "EmployeePositions",
                columns: table => new
                {
                    EmployeePositionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeePositions", x => x.EmployeePositionId);
                });

            migrationBuilder.CreateTable(
                name: "ManufacturingShopProcessorStates",
                columns: table => new
                {
                    ManufacturingShopProcessorStateId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StateBeginAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StateReason = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StateName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ManufacturingShopProcessorStates", x => x.ManufacturingShopProcessorStateId);
                });

            migrationBuilder.CreateTable(
                name: "ManufacturingShops",
                columns: table => new
                {
                    ManufacturingShopId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ManufacturingShops", x => x.ManufacturingShopId);
                });

            migrationBuilder.CreateTable(
                name: "ManufacturingShopSchedules",
                columns: table => new
                {
                    ManufacturingShopScheduleId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ScheduleTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ManufacturingShopSchedules", x => x.ManufacturingShopScheduleId);
                });

            migrationBuilder.CreateTable(
                name: "Prices",
                columns: table => new
                {
                    PriceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ListPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    UnitPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    LowestRebatePrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    BundlePrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PurchasingPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prices", x => x.PriceId);
                });

            migrationBuilder.CreateTable(
                name: "StorageLocation",
                columns: table => new
                {
                    StorageLocationID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BuildingNumber = table.Column<int>(type: "int", nullable: false),
                    SectionNumber = table.Column<int>(type: "int", nullable: false),
                    AisleNumber = table.Column<int>(type: "int", nullable: false),
                    ShelfNumber = table.Column<int>(type: "int", nullable: false),
                    Barcode = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StorageLocation", x => x.StorageLocationID);
                });

            migrationBuilder.CreateTable(
                name: "ActivityBasedCosts",
                columns: table => new
                {
                    ActivityBasedCostId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Value = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CostId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActivityBasedCosts", x => x.ActivityBasedCostId);
                    table.ForeignKey(
                        name: "FK_ActivityBasedCosts_Costs_CostId",
                        column: x => x.CostId,
                        principalTable: "Costs",
                        principalColumn: "CostId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ManufacturingShopProcessorActivities",
                columns: table => new
                {
                    ManufacturingShopProcessorActivityId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProcessorStateManufacturingShopProcessorStateId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ManufacturingShopProcessorActivities", x => x.ManufacturingShopProcessorActivityId);
                    table.ForeignKey(
                        name: "FK_ManufacturingShopProcessorActivities_ManufacturingShopProcessorStates_ProcessorStateManufacturingShopProcessorStateId",
                        column: x => x.ProcessorStateManufacturingShopProcessorStateId,
                        principalTable: "ManufacturingShopProcessorStates",
                        principalColumn: "ManufacturingShopProcessorStateId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    EmployeeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateHired = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastDateOfEmployment = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PositionEmployeePositionId = table.Column<int>(type: "int", nullable: true),
                    ManufacturingShopId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.EmployeeId);
                    table.ForeignKey(
                        name: "FK_Employees_EmployeePositions_PositionEmployeePositionId",
                        column: x => x.PositionEmployeePositionId,
                        principalTable: "EmployeePositions",
                        principalColumn: "EmployeePositionId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Employees_ManufacturingShops_ManufacturingShopId",
                        column: x => x.ManufacturingShopId,
                        principalTable: "ManufacturingShops",
                        principalColumn: "ManufacturingShopId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ManufacturingShopProcessors",
                columns: table => new
                {
                    ManufacturingShopProcessorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProcessingSequence = table.Column<int>(type: "int", nullable: false),
                    ManufacturingShopId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ManufacturingShopProcessors", x => x.ManufacturingShopProcessorId);
                    table.ForeignKey(
                        name: "FK_ManufacturingShopProcessors_ManufacturingShops_ManufacturingShopId",
                        column: x => x.ManufacturingShopId,
                        principalTable: "ManufacturingShops",
                        principalColumn: "ManufacturingShopId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ItemId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InHouseName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductCostCostId = table.Column<long>(type: "bigint", nullable: true),
                    PorductPricePriceId = table.Column<int>(type: "int", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2021, 9, 10, 17, 59, 20, 752, DateTimeKind.Local).AddTicks(7627)),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValue: new DateTime(2021, 9, 10, 17, 59, 20, 765, DateTimeKind.Local).AddTicks(3734)),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ItemId);
                    table.ForeignKey(
                        name: "FK_Products_Costs_ProductCostCostId",
                        column: x => x.ProductCostCostId,
                        principalTable: "Costs",
                        principalColumn: "CostId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Products_Prices_PorductPricePriceId",
                        column: x => x.PorductPricePriceId,
                        principalTable: "Prices",
                        principalColumn: "PriceId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ManufacturingShopScheduleLogs",
                columns: table => new
                {
                    ManufacturingShopScheduleLogId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ManufacturingShopScheduleId = table.Column<long>(type: "bigint", nullable: true),
                    ManufacturingShopProcessorActivityId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ManufacturingShopScheduleLogs", x => x.ManufacturingShopScheduleLogId);
                    table.ForeignKey(
                        name: "FK_ManufacturingShopScheduleLogs_ManufacturingShopProcessorActivities_ManufacturingShopProcessorActivityId",
                        column: x => x.ManufacturingShopProcessorActivityId,
                        principalTable: "ManufacturingShopProcessorActivities",
                        principalColumn: "ManufacturingShopProcessorActivityId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ManufacturingShopScheduleLogs_ManufacturingShopSchedules_ManufacturingShopScheduleId",
                        column: x => x.ManufacturingShopScheduleId,
                        principalTable: "ManufacturingShopSchedules",
                        principalColumn: "ManufacturingShopScheduleId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Tools",
                columns: table => new
                {
                    ItemId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ManufacturerId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ManufacturingShopProcessorId = table.Column<int>(type: "int", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2021, 9, 10, 17, 59, 20, 774, DateTimeKind.Local).AddTicks(3602)),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValue: new DateTime(2021, 9, 10, 17, 59, 20, 774, DateTimeKind.Local).AddTicks(4778)),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tools", x => x.ItemId);
                    table.ForeignKey(
                        name: "FK_Tools_ManufacturingShopProcessors_ManufacturingShopProcessorId",
                        column: x => x.ManufacturingShopProcessorId,
                        principalTable: "ManufacturingShopProcessors",
                        principalColumn: "ManufacturingShopProcessorId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ManufacturedProducts",
                columns: table => new
                {
                    ManufacturedProductId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductItemId = table.Column<long>(type: "bigint", nullable: true),
                    DimensionId = table.Column<int>(type: "int", nullable: true),
                    AverageAssembledTimeInSec = table.Column<double>(type: "float", nullable: false),
                    LowestAssembledTimeInSec = table.Column<double>(type: "float", nullable: false),
                    HighestAssembledTimeInSec = table.Column<double>(type: "float", nullable: false),
                    AverageDailyQuota = table.Column<double>(type: "float", nullable: false),
                    LowestQuota = table.Column<int>(type: "int", nullable: false),
                    HighestQuota = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ManufacturedProducts", x => x.ManufacturedProductId);
                    table.ForeignKey(
                        name: "FK_ManufacturedProducts_Dimensions_DimensionId",
                        column: x => x.DimensionId,
                        principalTable: "Dimensions",
                        principalColumn: "DimensionId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ManufacturedProducts_Products_ProductItemId",
                        column: x => x.ProductItemId,
                        principalTable: "Products",
                        principalColumn: "ItemId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ObsoleteManufacturedProducts",
                columns: table => new
                {
                    ObsoleteManufacturedProductId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductItemId = table.Column<long>(type: "bigint", nullable: true),
                    StatusChangeDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StatusChangeByEmployeeId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ObsoleteManufacturedProducts", x => x.ObsoleteManufacturedProductId);
                    table.ForeignKey(
                        name: "FK_ObsoleteManufacturedProducts_Employees_StatusChangeByEmployeeId",
                        column: x => x.StatusChangeByEmployeeId,
                        principalTable: "Employees",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ObsoleteManufacturedProducts_Products_ProductItemId",
                        column: x => x.ProductItemId,
                        principalTable: "Products",
                        principalColumn: "ItemId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProductLocations",
                columns: table => new
                {
                    ProductLocationID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LocationStorageLocationID = table.Column<int>(type: "int", nullable: true),
                    ProductItemId = table.Column<long>(type: "bigint", nullable: true),
                    SizeDimensionId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductLocations", x => x.ProductLocationID);
                    table.ForeignKey(
                        name: "FK_ProductLocations_Dimensions_SizeDimensionId",
                        column: x => x.SizeDimensionId,
                        principalTable: "Dimensions",
                        principalColumn: "DimensionId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProductLocations_Products_ProductItemId",
                        column: x => x.ProductItemId,
                        principalTable: "Products",
                        principalColumn: "ItemId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProductLocations_StorageLocation_LocationStorageLocationID",
                        column: x => x.LocationStorageLocationID,
                        principalTable: "StorageLocation",
                        principalColumn: "StorageLocationID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MachineTools",
                columns: table => new
                {
                    MachineToolId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ToolItemId = table.Column<long>(type: "bigint", nullable: true),
                    LocationStorageLocationID = table.Column<int>(type: "int", nullable: true),
                    SizeDimensionId = table.Column<int>(type: "int", nullable: true),
                    LastMaintenanceDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MaintenanceFrequencyInDays = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MachineTools", x => x.MachineToolId);
                    table.ForeignKey(
                        name: "FK_MachineTools_Dimensions_SizeDimensionId",
                        column: x => x.SizeDimensionId,
                        principalTable: "Dimensions",
                        principalColumn: "DimensionId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MachineTools_StorageLocation_LocationStorageLocationID",
                        column: x => x.LocationStorageLocationID,
                        principalTable: "StorageLocation",
                        principalColumn: "StorageLocationID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MachineTools_Tools_ToolItemId",
                        column: x => x.ToolItemId,
                        principalTable: "Tools",
                        principalColumn: "ItemId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Suppliers",
                columns: table => new
                {
                    SupplierId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductItemId = table.Column<long>(type: "bigint", nullable: true),
                    ToolItemId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Suppliers", x => x.SupplierId);
                    table.ForeignKey(
                        name: "FK_Suppliers_Products_ProductItemId",
                        column: x => x.ProductItemId,
                        principalTable: "Products",
                        principalColumn: "ItemId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Suppliers_Tools_ToolItemId",
                        column: x => x.ToolItemId,
                        principalTable: "Tools",
                        principalColumn: "ItemId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CreatedManufacturedProducts",
                columns: table => new
                {
                    ManufacturedProductCreatedId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ManufacturedProductId = table.Column<int>(type: "int", nullable: true),
                    ManufacturingShopProcessorActivityId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CreatedManufacturedProducts", x => x.ManufacturedProductCreatedId);
                    table.ForeignKey(
                        name: "FK_CreatedManufacturedProducts_ManufacturedProducts_ManufacturedProductId",
                        column: x => x.ManufacturedProductId,
                        principalTable: "ManufacturedProducts",
                        principalColumn: "ManufacturedProductId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CreatedManufacturedProducts_ManufacturingShopProcessorActivities_ManufacturingShopProcessorActivityId",
                        column: x => x.ManufacturingShopProcessorActivityId,
                        principalTable: "ManufacturingShopProcessorActivities",
                        principalColumn: "ManufacturingShopProcessorActivityId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ManufacturedProductAssemblies",
                columns: table => new
                {
                    ManufacturedProductAssemblyId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AssemblyItemId = table.Column<long>(type: "bigint", nullable: true),
                    QuantityNeeded = table.Column<double>(type: "float", nullable: false),
                    ManufacturedProductId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ManufacturedProductAssemblies", x => x.ManufacturedProductAssemblyId);
                    table.ForeignKey(
                        name: "FK_ManufacturedProductAssemblies_ManufacturedProducts_ManufacturedProductId",
                        column: x => x.ManufacturedProductId,
                        principalTable: "ManufacturedProducts",
                        principalColumn: "ManufacturedProductId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ManufacturedProductAssemblies_Products_AssemblyItemId",
                        column: x => x.AssemblyItemId,
                        principalTable: "Products",
                        principalColumn: "ItemId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ManufacturedProductInventories",
                columns: table => new
                {
                    ManufacturedProductInventoryId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductManufacturedProductId = table.Column<int>(type: "int", nullable: true),
                    QuantityUsed = table.Column<double>(type: "float", nullable: false),
                    CurrentQuantityOnHand = table.Column<double>(type: "float", nullable: false),
                    OrderPoint = table.Column<double>(type: "float", nullable: false),
                    TransactionDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ManufacturedProductInventories", x => x.ManufacturedProductInventoryId);
                    table.ForeignKey(
                        name: "FK_ManufacturedProductInventories_ManufacturedProducts_ProductManufacturedProductId",
                        column: x => x.ProductManufacturedProductId,
                        principalTable: "ManufacturedProducts",
                        principalColumn: "ManufacturedProductId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProductDesignDocuments",
                columns: table => new
                {
                    ProductDesignDocumentId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AuthorEmployeeId = table.Column<int>(type: "int", nullable: true),
                    FileLocation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ManufacturedProductId = table.Column<int>(type: "int", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ItemId = table.Column<long>(type: "bigint", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductDesignDocuments", x => x.ProductDesignDocumentId);
                    table.ForeignKey(
                        name: "FK_ProductDesignDocuments_Employees_AuthorEmployeeId",
                        column: x => x.AuthorEmployeeId,
                        principalTable: "Employees",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProductDesignDocuments_ManufacturedProducts_ManufacturedProductId",
                        column: x => x.ManufacturedProductId,
                        principalTable: "ManufacturedProducts",
                        principalColumn: "ManufacturedProductId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProductionCapacities",
                columns: table => new
                {
                    ProductionCapacityId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Month = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Year = table.Column<int>(type: "int", nullable: false),
                    AmountProduced = table.Column<double>(type: "float", nullable: false),
                    AmountProjected = table.Column<double>(type: "float", nullable: false),
                    ManufacturedProductId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductionCapacities", x => x.ProductionCapacityId);
                    table.ForeignKey(
                        name: "FK_ProductionCapacities_ManufacturedProducts_ManufacturedProductId",
                        column: x => x.ManufacturedProductId,
                        principalTable: "ManufacturedProducts",
                        principalColumn: "ManufacturedProductId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProductManufacturingShops",
                columns: table => new
                {
                    ProductManufacturingShopId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ManufacturingShopId = table.Column<int>(type: "int", nullable: true),
                    ManufacturedProductId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductManufacturingShops", x => x.ProductManufacturingShopId);
                    table.ForeignKey(
                        name: "FK_ProductManufacturingShops_ManufacturedProducts_ManufacturedProductId",
                        column: x => x.ManufacturedProductId,
                        principalTable: "ManufacturedProducts",
                        principalColumn: "ManufacturedProductId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProductManufacturingShops_ManufacturingShops_ManufacturingShopId",
                        column: x => x.ManufacturingShopId,
                        principalTable: "ManufacturingShops",
                        principalColumn: "ManufacturingShopId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Contacts",
                columns: table => new
                {
                    ContactId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MiddleName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SupplierId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contacts", x => x.ContactId);
                    table.ForeignKey(
                        name: "FK_Contacts_Suppliers_SupplierId",
                        column: x => x.SupplierId,
                        principalTable: "Suppliers",
                        principalColumn: "SupplierId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ManufacturedProductScheduled",
                columns: table => new
                {
                    ManufacturedProductScheduledId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InventoriedProductManufacturedProductInventoryId = table.Column<long>(type: "bigint", nullable: true),
                    ManufacturingShopScheduleId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ManufacturedProductScheduled", x => x.ManufacturedProductScheduledId);
                    table.ForeignKey(
                        name: "FK_ManufacturedProductScheduled_ManufacturedProductInventories_InventoriedProductManufacturedProductInventoryId",
                        column: x => x.InventoriedProductManufacturedProductInventoryId,
                        principalTable: "ManufacturedProductInventories",
                        principalColumn: "ManufacturedProductInventoryId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ManufacturedProductScheduled_ManufacturingShopSchedules_ManufacturingShopScheduleId",
                        column: x => x.ManufacturingShopScheduleId,
                        principalTable: "ManufacturingShopSchedules",
                        principalColumn: "ManufacturingShopScheduleId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Notes",
                columns: table => new
                {
                    NoteId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AuthorEmployeeId = table.Column<int>(type: "int", nullable: true),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ManufacturingShopProcessorId = table.Column<int>(type: "int", nullable: true),
                    ProductionCapacityId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notes", x => x.NoteId);
                    table.ForeignKey(
                        name: "FK_Notes_Employees_AuthorEmployeeId",
                        column: x => x.AuthorEmployeeId,
                        principalTable: "Employees",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Notes_ManufacturingShopProcessors_ManufacturingShopProcessorId",
                        column: x => x.ManufacturingShopProcessorId,
                        principalTable: "ManufacturingShopProcessors",
                        principalColumn: "ManufacturingShopProcessorId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Notes_ProductionCapacities_ProductionCapacityId",
                        column: x => x.ProductionCapacityId,
                        principalTable: "ProductionCapacities",
                        principalColumn: "ProductionCapacityId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    AddressId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Address1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContactId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.AddressId);
                    table.ForeignKey(
                        name: "FK_Addresses_Contacts_ContactId",
                        column: x => x.ContactId,
                        principalTable: "Contacts",
                        principalColumn: "ContactId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DigitalAddresses",
                columns: table => new
                {
                    DigitalAddressId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DigitalAddressTypeId = table.Column<int>(type: "int", nullable: true),
                    ContactId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DigitalAddresses", x => x.DigitalAddressId);
                    table.ForeignKey(
                        name: "FK_DigitalAddresses_Contacts_ContactId",
                        column: x => x.ContactId,
                        principalTable: "Contacts",
                        principalColumn: "ContactId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DigitalAddresses_DigitalAddressTypes_DigitalAddressTypeId",
                        column: x => x.DigitalAddressTypeId,
                        principalTable: "DigitalAddressTypes",
                        principalColumn: "DigitalAddressTypeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ActivityBasedCosts_CostId",
                table: "ActivityBasedCosts",
                column: "CostId");

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_ContactId",
                table: "Addresses",
                column: "ContactId");

            migrationBuilder.CreateIndex(
                name: "IX_Contacts_SupplierId",
                table: "Contacts",
                column: "SupplierId");

            migrationBuilder.CreateIndex(
                name: "IX_CreatedManufacturedProducts_ManufacturedProductId",
                table: "CreatedManufacturedProducts",
                column: "ManufacturedProductId");

            migrationBuilder.CreateIndex(
                name: "IX_CreatedManufacturedProducts_ManufacturingShopProcessorActivityId",
                table: "CreatedManufacturedProducts",
                column: "ManufacturingShopProcessorActivityId");

            migrationBuilder.CreateIndex(
                name: "IX_DigitalAddresses_ContactId",
                table: "DigitalAddresses",
                column: "ContactId");

            migrationBuilder.CreateIndex(
                name: "IX_DigitalAddresses_DigitalAddressTypeId",
                table: "DigitalAddresses",
                column: "DigitalAddressTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_ManufacturingShopId",
                table: "Employees",
                column: "ManufacturingShopId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_PositionEmployeePositionId",
                table: "Employees",
                column: "PositionEmployeePositionId");

            migrationBuilder.CreateIndex(
                name: "IX_MachineTools_LocationStorageLocationID",
                table: "MachineTools",
                column: "LocationStorageLocationID");

            migrationBuilder.CreateIndex(
                name: "IX_MachineTools_SizeDimensionId",
                table: "MachineTools",
                column: "SizeDimensionId");

            migrationBuilder.CreateIndex(
                name: "IX_MachineTools_ToolItemId",
                table: "MachineTools",
                column: "ToolItemId");

            migrationBuilder.CreateIndex(
                name: "IX_ManufacturedProductAssemblies_AssemblyItemId",
                table: "ManufacturedProductAssemblies",
                column: "AssemblyItemId");

            migrationBuilder.CreateIndex(
                name: "IX_ManufacturedProductAssemblies_ManufacturedProductId",
                table: "ManufacturedProductAssemblies",
                column: "ManufacturedProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ManufacturedProductInventories_ProductManufacturedProductId",
                table: "ManufacturedProductInventories",
                column: "ProductManufacturedProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ManufacturedProducts_DimensionId",
                table: "ManufacturedProducts",
                column: "DimensionId");

            migrationBuilder.CreateIndex(
                name: "IX_ManufacturedProducts_ProductItemId",
                table: "ManufacturedProducts",
                column: "ProductItemId");

            migrationBuilder.CreateIndex(
                name: "IX_ManufacturedProductScheduled_InventoriedProductManufacturedProductInventoryId",
                table: "ManufacturedProductScheduled",
                column: "InventoriedProductManufacturedProductInventoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ManufacturedProductScheduled_ManufacturingShopScheduleId",
                table: "ManufacturedProductScheduled",
                column: "ManufacturingShopScheduleId");

            migrationBuilder.CreateIndex(
                name: "IX_ManufacturingShopProcessorActivities_ProcessorStateManufacturingShopProcessorStateId",
                table: "ManufacturingShopProcessorActivities",
                column: "ProcessorStateManufacturingShopProcessorStateId");

            migrationBuilder.CreateIndex(
                name: "IX_ManufacturingShopProcessors_ManufacturingShopId",
                table: "ManufacturingShopProcessors",
                column: "ManufacturingShopId");

            migrationBuilder.CreateIndex(
                name: "IX_ManufacturingShopScheduleLogs_ManufacturingShopProcessorActivityId",
                table: "ManufacturingShopScheduleLogs",
                column: "ManufacturingShopProcessorActivityId");

            migrationBuilder.CreateIndex(
                name: "IX_ManufacturingShopScheduleLogs_ManufacturingShopScheduleId",
                table: "ManufacturingShopScheduleLogs",
                column: "ManufacturingShopScheduleId");

            migrationBuilder.CreateIndex(
                name: "IX_Notes_AuthorEmployeeId",
                table: "Notes",
                column: "AuthorEmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Notes_ManufacturingShopProcessorId",
                table: "Notes",
                column: "ManufacturingShopProcessorId");

            migrationBuilder.CreateIndex(
                name: "IX_Notes_ProductionCapacityId",
                table: "Notes",
                column: "ProductionCapacityId");

            migrationBuilder.CreateIndex(
                name: "IX_ObsoleteManufacturedProducts_ProductItemId",
                table: "ObsoleteManufacturedProducts",
                column: "ProductItemId");

            migrationBuilder.CreateIndex(
                name: "IX_ObsoleteManufacturedProducts_StatusChangeByEmployeeId",
                table: "ObsoleteManufacturedProducts",
                column: "StatusChangeByEmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductDesignDocuments_AuthorEmployeeId",
                table: "ProductDesignDocuments",
                column: "AuthorEmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductDesignDocuments_ManufacturedProductId",
                table: "ProductDesignDocuments",
                column: "ManufacturedProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductionCapacities_ManufacturedProductId",
                table: "ProductionCapacities",
                column: "ManufacturedProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductLocations_LocationStorageLocationID",
                table: "ProductLocations",
                column: "LocationStorageLocationID");

            migrationBuilder.CreateIndex(
                name: "IX_ProductLocations_ProductItemId",
                table: "ProductLocations",
                column: "ProductItemId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductLocations_SizeDimensionId",
                table: "ProductLocations",
                column: "SizeDimensionId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductManufacturingShops_ManufacturedProductId",
                table: "ProductManufacturingShops",
                column: "ManufacturedProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductManufacturingShops_ManufacturingShopId",
                table: "ProductManufacturingShops",
                column: "ManufacturingShopId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_PorductPricePriceId",
                table: "Products",
                column: "PorductPricePriceId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_ProductCostCostId",
                table: "Products",
                column: "ProductCostCostId");

            migrationBuilder.CreateIndex(
                name: "IX_Suppliers_ProductItemId",
                table: "Suppliers",
                column: "ProductItemId");

            migrationBuilder.CreateIndex(
                name: "IX_Suppliers_ToolItemId",
                table: "Suppliers",
                column: "ToolItemId");

            migrationBuilder.CreateIndex(
                name: "IX_Tools_ManufacturingShopProcessorId",
                table: "Tools",
                column: "ManufacturingShopProcessorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ActivityBasedCosts");

            migrationBuilder.DropTable(
                name: "Addresses");

            migrationBuilder.DropTable(
                name: "CreatedManufacturedProducts");

            migrationBuilder.DropTable(
                name: "DigitalAddresses");

            migrationBuilder.DropTable(
                name: "MachineTools");

            migrationBuilder.DropTable(
                name: "ManufacturedProductAssemblies");

            migrationBuilder.DropTable(
                name: "ManufacturedProductScheduled");

            migrationBuilder.DropTable(
                name: "ManufacturingShopScheduleLogs");

            migrationBuilder.DropTable(
                name: "Notes");

            migrationBuilder.DropTable(
                name: "ObsoleteManufacturedProducts");

            migrationBuilder.DropTable(
                name: "ProductDesignDocuments");

            migrationBuilder.DropTable(
                name: "ProductLocations");

            migrationBuilder.DropTable(
                name: "ProductManufacturingShops");

            migrationBuilder.DropTable(
                name: "Contacts");

            migrationBuilder.DropTable(
                name: "DigitalAddressTypes");

            migrationBuilder.DropTable(
                name: "ManufacturedProductInventories");

            migrationBuilder.DropTable(
                name: "ManufacturingShopProcessorActivities");

            migrationBuilder.DropTable(
                name: "ManufacturingShopSchedules");

            migrationBuilder.DropTable(
                name: "ProductionCapacities");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "StorageLocation");

            migrationBuilder.DropTable(
                name: "Suppliers");

            migrationBuilder.DropTable(
                name: "ManufacturingShopProcessorStates");

            migrationBuilder.DropTable(
                name: "ManufacturedProducts");

            migrationBuilder.DropTable(
                name: "EmployeePositions");

            migrationBuilder.DropTable(
                name: "Tools");

            migrationBuilder.DropTable(
                name: "Dimensions");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "ManufacturingShopProcessors");

            migrationBuilder.DropTable(
                name: "Costs");

            migrationBuilder.DropTable(
                name: "Prices");

            migrationBuilder.DropTable(
                name: "ManufacturingShops");
        }
    }
}
