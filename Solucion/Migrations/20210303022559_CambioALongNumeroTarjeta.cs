using Microsoft.EntityFrameworkCore.Migrations;

namespace Solucion.Migrations
{
    public partial class CambioALongNumeroTarjeta : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "Numero",
                table: "Tarjeta",
                nullable: false,
                oldClrType: typeof(int));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Numero",
                table: "Tarjeta",
                nullable: false,
                oldClrType: typeof(long));
        }
    }
}
