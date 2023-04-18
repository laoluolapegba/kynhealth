using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Kynhealth.UI.Web.Migrations
{
    public partial class organizations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AddressLine1",
                schema: "public",
                table: "kyn_users",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<int>(
                name: "AgeGroup",
                schema: "public",
                table: "kyn_users",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Gender",
                schema: "public",
                table: "kyn_users",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<int>(
                name: "OrganizationCompanyId",
                schema: "public",
                table: "kyn_users",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PreferredChannel",
                schema: "public",
                table: "kyn_users",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "tb_country",
                schema: "public",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    iso_code = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    country_name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_country", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "tb_lga",
                schema: "public",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    lga_name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_lga", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "tb_states",
                schema: "public",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    state_name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_states", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "tb_orgs",
                schema: "public",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    company_name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AddressLine1 = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AddressLine2 = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    City = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Telephone = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    LocalGovtId = table.Column<int>(type: "int", nullable: false),
                    StateId = table.Column<int>(type: "int", nullable: false),
                    CountryId = table.Column<int>(type: "int", nullable: false),
                    LicenseNo = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    lgasLgaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_orgs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tb_orgs_tb_country_CountryId",
                        column: x => x.CountryId,
                        principalSchema: "public",
                        principalTable: "tb_country",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tb_orgs_tb_lga_lgasLgaId",
                        column: x => x.lgasLgaId,
                        principalSchema: "public",
                        principalTable: "tb_lga",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tb_orgs_tb_states_StateId",
                        column: x => x.StateId,
                        principalSchema: "public",
                        principalTable: "tb_states",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_kyn_users_OrganizationCompanyId",
                schema: "public",
                table: "kyn_users",
                column: "OrganizationCompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_tb_orgs_CountryId",
                schema: "public",
                table: "tb_orgs",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_tb_orgs_lgasLgaId",
                schema: "public",
                table: "tb_orgs",
                column: "lgasLgaId");

            migrationBuilder.CreateIndex(
                name: "IX_tb_orgs_StateId",
                schema: "public",
                table: "tb_orgs",
                column: "StateId");

            migrationBuilder.AddForeignKey(
                name: "FK_kyn_users_tb_orgs_OrganizationCompanyId",
                schema: "public",
                table: "kyn_users",
                column: "OrganizationCompanyId",
                principalSchema: "public",
                principalTable: "tb_orgs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_kyn_users_tb_orgs_OrganizationCompanyId",
                schema: "public",
                table: "kyn_users");

            migrationBuilder.DropTable(
                name: "tb_orgs",
                schema: "public");

            migrationBuilder.DropTable(
                name: "tb_country",
                schema: "public");

            migrationBuilder.DropTable(
                name: "tb_lga",
                schema: "public");

            migrationBuilder.DropTable(
                name: "tb_states",
                schema: "public");

            migrationBuilder.DropIndex(
                name: "IX_kyn_users_OrganizationCompanyId",
                schema: "public",
                table: "kyn_users");

            migrationBuilder.DropColumn(
                name: "AddressLine1",
                schema: "public",
                table: "kyn_users");

            migrationBuilder.DropColumn(
                name: "AgeGroup",
                schema: "public",
                table: "kyn_users");

            migrationBuilder.DropColumn(
                name: "Gender",
                schema: "public",
                table: "kyn_users");

            migrationBuilder.DropColumn(
                name: "OrganizationCompanyId",
                schema: "public",
                table: "kyn_users");

            migrationBuilder.DropColumn(
                name: "PreferredChannel",
                schema: "public",
                table: "kyn_users");
        }
    }
}
