using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Backend.Migrations
{
    public partial class v2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Nev",
                table: "kategoriak",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.InsertData(
                table: "kategoriak",
                columns: new[] { "Id", "Nev" },
                values: new object[,]
                {
                    { 1, "Ház" },
                    { 2, "Lakás" },
                    { 3, "Építési telek" },
                    { 4, "Garázs" },
                    { 5, "Mezőgazdasági terület" },
                    { 6, "Ipari ingatlan" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_kategoriak_Nev",
                table: "kategoriak",
                column: "Nev",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_kategoriak_Nev",
                table: "kategoriak");

            migrationBuilder.DeleteData(
                table: "kategoriak",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "kategoriak",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "kategoriak",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "kategoriak",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "kategoriak",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "kategoriak",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.AlterColumn<string>(
                name: "Nev",
                table: "kategoriak",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");
        }
    }
}
