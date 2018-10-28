using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ClosetApi.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    ParentId = table.Column<int>(nullable: false),
                    ParentCategoryCategoryId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryId);
                    table.ForeignKey(
                        name: "FK_Categories_Categories_ParentCategoryCategoryId",
                        column: x => x.ParentCategoryCategoryId,
                        principalTable: "Categories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Materials",
                columns: table => new
                {
                    MaterialId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Materials", x => x.MaterialId);
                });

            migrationBuilder.CreateTable(
                name: "Measurements",
                columns: table => new
                {
                    MeasurementId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    HeightMin = table.Column<double>(nullable: false),
                    HeightMax = table.Column<double>(nullable: false),
                    HeightCont = table.Column<bool>(nullable: false),
                    WidthMin = table.Column<double>(nullable: false),
                    WidthMax = table.Column<double>(nullable: false),
                    WidthCont = table.Column<bool>(nullable: false),
                    DepthMin = table.Column<double>(nullable: false),
                    DepthMax = table.Column<double>(nullable: false),
                    DepthCont = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Measurements", x => x.MeasurementId);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    CategoryId1 = table.Column<int>(nullable: true),
                    ParentProductProductId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductId);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId1",
                        column: x => x.CategoryId1,
                        principalTable: "Categories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Products_Products_ParentProductProductId",
                        column: x => x.ParentProductProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Finishes",
                columns: table => new
                {
                    FinishId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    ParentMaterialMaterialId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Finishes", x => x.FinishId);
                    table.ForeignKey(
                        name: "FK_Finishes_Materials_ParentMaterialMaterialId",
                        column: x => x.ParentMaterialMaterialId,
                        principalTable: "Materials",
                        principalColumn: "MaterialId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProductMaterial",
                columns: table => new
                {
                    ProductId = table.Column<int>(nullable: false),
                    MaterialId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductMaterial", x => new { x.ProductId, x.MaterialId });
                    table.ForeignKey(
                        name: "FK_ProductMaterial_Materials_MaterialId",
                        column: x => x.MaterialId,
                        principalTable: "Materials",
                        principalColumn: "MaterialId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductMaterial_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductMeasurement",
                columns: table => new
                {
                    ProductId = table.Column<int>(nullable: false),
                    MeasurementId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductMeasurement", x => new { x.ProductId, x.MeasurementId });
                    table.ForeignKey(
                        name: "FK_ProductMeasurement_Measurements_MeasurementId",
                        column: x => x.MeasurementId,
                        principalTable: "Measurements",
                        principalColumn: "MeasurementId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductMeasurement_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Categories_ParentCategoryCategoryId",
                table: "Categories",
                column: "ParentCategoryCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Finishes_ParentMaterialMaterialId",
                table: "Finishes",
                column: "ParentMaterialMaterialId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductMaterial_MaterialId",
                table: "ProductMaterial",
                column: "MaterialId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductMeasurement_MeasurementId",
                table: "ProductMeasurement",
                column: "MeasurementId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId1",
                table: "Products",
                column: "CategoryId1");

            migrationBuilder.CreateIndex(
                name: "IX_Products_ParentProductProductId",
                table: "Products",
                column: "ParentProductProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Finishes");

            migrationBuilder.DropTable(
                name: "ProductMaterial");

            migrationBuilder.DropTable(
                name: "ProductMeasurement");

            migrationBuilder.DropTable(
                name: "Materials");

            migrationBuilder.DropTable(
                name: "Measurements");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
