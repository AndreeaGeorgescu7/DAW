using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TestDAW1.Migrations
{
    public partial class AddMigrationAddRelations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BridePackages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<float>(type: "real", nullable: false),
                    Time = table.Column<float>(type: "real", nullable: false),
                    NumberOfServices = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BridePackages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Datas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HairStylistId = table.Column<int>(type: "int", nullable: false),
                    Tel = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Datas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Datas_HairStylists_HairStylistId",
                        column: x => x.HairStylistId,
                        principalTable: "HairStylists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HairServices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<float>(type: "real", nullable: false),
                    HairStylistId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HairServices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HairServices_HairStylists_HairStylistId",
                        column: x => x.HairStylistId,
                        principalTable: "HairStylists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeBridePackages",
                columns: table => new
                {
                    HairStylistId = table.Column<int>(type: "int", nullable: false),
                    BridePackageId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeBridePackages", x => new { x.HairStylistId, x.BridePackageId });
                    table.ForeignKey(
                        name: "FK_EmployeeBridePackages_BridePackages_BridePackageId",
                        column: x => x.BridePackageId,
                        principalTable: "BridePackages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeeBridePackages_HairStylists_HairStylistId",
                        column: x => x.HairStylistId,
                        principalTable: "HairStylists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Datas_HairStylistId",
                table: "Datas",
                column: "HairStylistId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeBridePackages_BridePackageId",
                table: "EmployeeBridePackages",
                column: "BridePackageId");

            migrationBuilder.CreateIndex(
                name: "IX_HairServices_HairStylistId",
                table: "HairServices",
                column: "HairStylistId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Datas");

            migrationBuilder.DropTable(
                name: "EmployeeBridePackages");

            migrationBuilder.DropTable(
                name: "HairServices");

            migrationBuilder.DropTable(
                name: "BridePackages");
        }
    }
}
