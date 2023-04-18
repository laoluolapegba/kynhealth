using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Kynhealth.UI.Web.Migrations
{
    public partial class addaccessfieldlist : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_kyn_logins_AspNetUsers_UserId",
                schema: "public",
                table: "kyn_logins");

            migrationBuilder.DropForeignKey(
                name: "FK_kyn_user_claims_AspNetUsers_UserId",
                schema: "public",
                table: "kyn_user_claims");

            migrationBuilder.DropForeignKey(
                name: "FK_kyn_user_roles_AspNetUsers_UserId",
                schema: "public",
                table: "kyn_user_roles");

            migrationBuilder.DropForeignKey(
                name: "FK_kyn_users_AspNetUsers_Id",
                schema: "public",
                table: "kyn_users");

            migrationBuilder.DropForeignKey(
                name: "FK_kyn_usertokens_AspNetUsers_UserId",
                schema: "public",
                table: "kyn_usertokens");

            migrationBuilder.DropTable(
                name: "AspNetUsers",
                schema: "public");

            migrationBuilder.AlterColumn<byte[]>(
                name: "ProfilePicture",
                schema: "public",
                table: "kyn_users",
                type: "longblob",
                nullable: true,
                oldClrType: typeof(byte[]),
                oldType: "longblob");

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                schema: "public",
                table: "kyn_users",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                schema: "public",
                table: "kyn_users",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<int>(
                name: "CompanyId",
                schema: "public",
                table: "kyn_users",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "AccessFailedCount",
                schema: "public",
                table: "kyn_users",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ConcurrencyStamp",
                schema: "public",
                table: "kyn_users",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                schema: "public",
                table: "kyn_users",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                schema: "public",
                table: "kyn_users",
                type: "varchar(256)",
                maxLength: 256,
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<bool>(
                name: "EmailConfirmed",
                schema: "public",
                table: "kyn_users",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "LockoutEnabled",
                schema: "public",
                table: "kyn_users",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "LockoutEnd",
                schema: "public",
                table: "kyn_users",
                type: "datetime(6)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NormalizedEmail",
                schema: "public",
                table: "kyn_users",
                type: "varchar(256)",
                maxLength: 256,
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "NormalizedUserName",
                schema: "public",
                table: "kyn_users",
                type: "varchar(256)",
                maxLength: 256,
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "PasswordHash",
                schema: "public",
                table: "kyn_users",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                schema: "public",
                table: "kyn_users",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<bool>(
                name: "PhoneNumberConfirmed",
                schema: "public",
                table: "kyn_users",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "SecurityStamp",
                schema: "public",
                table: "kyn_users",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<bool>(
                name: "TwoFactorEnabled",
                schema: "public",
                table: "kyn_users",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "UserName",
                schema: "public",
                table: "kyn_users",
                type: "varchar(256)",
                maxLength: 256,
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                schema: "public",
                table: "kyn_users",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                schema: "public",
                table: "kyn_users",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_kyn_logins_kyn_users_UserId",
                schema: "public",
                table: "kyn_logins",
                column: "UserId",
                principalSchema: "public",
                principalTable: "kyn_users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_kyn_user_claims_kyn_users_UserId",
                schema: "public",
                table: "kyn_user_claims",
                column: "UserId",
                principalSchema: "public",
                principalTable: "kyn_users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_kyn_user_roles_kyn_users_UserId",
                schema: "public",
                table: "kyn_user_roles",
                column: "UserId",
                principalSchema: "public",
                principalTable: "kyn_users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_kyn_usertokens_kyn_users_UserId",
                schema: "public",
                table: "kyn_usertokens",
                column: "UserId",
                principalSchema: "public",
                principalTable: "kyn_users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_kyn_logins_kyn_users_UserId",
                schema: "public",
                table: "kyn_logins");

            migrationBuilder.DropForeignKey(
                name: "FK_kyn_user_claims_kyn_users_UserId",
                schema: "public",
                table: "kyn_user_claims");

            migrationBuilder.DropForeignKey(
                name: "FK_kyn_user_roles_kyn_users_UserId",
                schema: "public",
                table: "kyn_user_roles");

            migrationBuilder.DropForeignKey(
                name: "FK_kyn_usertokens_kyn_users_UserId",
                schema: "public",
                table: "kyn_usertokens");

            migrationBuilder.DropIndex(
                name: "EmailIndex",
                schema: "public",
                table: "kyn_users");

            migrationBuilder.DropIndex(
                name: "UserNameIndex",
                schema: "public",
                table: "kyn_users");

            migrationBuilder.DropColumn(
                name: "AccessFailedCount",
                schema: "public",
                table: "kyn_users");

            migrationBuilder.DropColumn(
                name: "ConcurrencyStamp",
                schema: "public",
                table: "kyn_users");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                schema: "public",
                table: "kyn_users");

            migrationBuilder.DropColumn(
                name: "Email",
                schema: "public",
                table: "kyn_users");

            migrationBuilder.DropColumn(
                name: "EmailConfirmed",
                schema: "public",
                table: "kyn_users");

            migrationBuilder.DropColumn(
                name: "LockoutEnabled",
                schema: "public",
                table: "kyn_users");

            migrationBuilder.DropColumn(
                name: "LockoutEnd",
                schema: "public",
                table: "kyn_users");

            migrationBuilder.DropColumn(
                name: "NormalizedEmail",
                schema: "public",
                table: "kyn_users");

            migrationBuilder.DropColumn(
                name: "NormalizedUserName",
                schema: "public",
                table: "kyn_users");

            migrationBuilder.DropColumn(
                name: "PasswordHash",
                schema: "public",
                table: "kyn_users");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                schema: "public",
                table: "kyn_users");

            migrationBuilder.DropColumn(
                name: "PhoneNumberConfirmed",
                schema: "public",
                table: "kyn_users");

            migrationBuilder.DropColumn(
                name: "SecurityStamp",
                schema: "public",
                table: "kyn_users");

            migrationBuilder.DropColumn(
                name: "TwoFactorEnabled",
                schema: "public",
                table: "kyn_users");

            migrationBuilder.DropColumn(
                name: "UserName",
                schema: "public",
                table: "kyn_users");

            migrationBuilder.AlterColumn<byte[]>(
                name: "ProfilePicture",
                schema: "public",
                table: "kyn_users",
                type: "longblob",
                nullable: false,
                defaultValue: new byte[0],
                oldClrType: typeof(byte[]),
                oldType: "longblob",
                oldNullable: true);

            migrationBuilder.UpdateData(
                schema: "public",
                table: "kyn_users",
                keyColumn: "LastName",
                keyValue: null,
                column: "LastName",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                schema: "public",
                table: "kyn_users",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                schema: "public",
                table: "kyn_users",
                keyColumn: "FirstName",
                keyValue: null,
                column: "FirstName",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                schema: "public",
                table: "kyn_users",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<int>(
                name: "CompanyId",
                schema: "public",
                table: "kyn_users",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                schema: "public",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(95)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false),
                    ConcurrencyStamp = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Email = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    EmailConfirmed = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    LockoutEnabled = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetime(6)", nullable: true),
                    NormalizedEmail = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NormalizedUserName = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PasswordHash = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PhoneNumber = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PhoneNumberConfirmed = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    SecurityStamp = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    TwoFactorEnabled = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    UserName = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                schema: "public",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                schema: "public",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_kyn_logins_AspNetUsers_UserId",
                schema: "public",
                table: "kyn_logins",
                column: "UserId",
                principalSchema: "public",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_kyn_user_claims_AspNetUsers_UserId",
                schema: "public",
                table: "kyn_user_claims",
                column: "UserId",
                principalSchema: "public",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_kyn_user_roles_AspNetUsers_UserId",
                schema: "public",
                table: "kyn_user_roles",
                column: "UserId",
                principalSchema: "public",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_kyn_users_AspNetUsers_Id",
                schema: "public",
                table: "kyn_users",
                column: "Id",
                principalSchema: "public",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_kyn_usertokens_AspNetUsers_UserId",
                schema: "public",
                table: "kyn_usertokens",
                column: "UserId",
                principalSchema: "public",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
