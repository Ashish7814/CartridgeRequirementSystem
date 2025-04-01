using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Efs.Migrations
{
    /// <inheritdoc />
    public partial class initialize : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "availableStock",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    printer_brand = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    printer_model = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    cartridge_partno = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    cartridge_number = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    cartridge_colour = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    stock_quantity = table.Column<int>(type: "int", nullable: true),
                    issue_quantity = table.Column<int>(type: "int", nullable: true),
                    updatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_availableStock", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "cartridgeDetail",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    printer_brand = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    printer_model = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    cartridge_colour = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    cartridge_number = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    cartridge_partNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    stock_quantity = table.Column<int>(type: "int", nullable: false),
                    createdAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    updatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cartridgeDetail", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "issuedDetails",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    user_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    department = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    cartridge_colour = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    cartridge_number = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    cartridge_partno = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    issued_quantity = table.Column<int>(type: "int", nullable: false),
                    date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_issuedDetails", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "requestCartridge",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    printer_brand = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    printer_model = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    cartridge_colour = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    cartridge_number = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    cartridge_partNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    required_quantity = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    user_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    department = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    createdAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_requestCartridge", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    user_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    department = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "availableStock");

            migrationBuilder.DropTable(
                name: "cartridgeDetail");

            migrationBuilder.DropTable(
                name: "issuedDetails");

            migrationBuilder.DropTable(
                name: "requestCartridge");

            migrationBuilder.DropTable(
                name: "users");
        }
    }
}
