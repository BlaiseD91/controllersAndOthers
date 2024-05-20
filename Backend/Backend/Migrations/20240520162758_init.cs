using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Backend.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ingatlanok",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Leiras = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HirdetesDatuma = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Tehermentes = table.Column<bool>(type: "bit", nullable: false),
                    Ar = table.Column<long>(type: "bigint", nullable: false),
                    KepUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KategoriaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ingatlanok", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "kategoriak",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nev = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_kategoriak", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ingatlanok");

            migrationBuilder.DropTable(
                name: "kategoriak");
        }
    }
}
