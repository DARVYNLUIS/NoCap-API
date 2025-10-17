using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NoCap_Data.Migrations
{
    /// <inheritdoc />
    public partial class CambiandoANullableDetalleCarrito : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CarritoDetalles_Colores_ColorId",
                table: "CarritoDetalles");

            migrationBuilder.DropForeignKey(
                name: "FK_CarritoDetalles_Productos_ProductoId",
                table: "CarritoDetalles");

            migrationBuilder.DropForeignKey(
                name: "FK_CarritoDetalles_Tamaños_TamañoId",
                table: "CarritoDetalles");

            migrationBuilder.AlterColumn<int>(
                name: "TamañoId",
                table: "CarritoDetalles",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "ProductoId",
                table: "CarritoDetalles",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "ColorId",
                table: "CarritoDetalles",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_CarritoDetalles_Colores_ColorId",
                table: "CarritoDetalles",
                column: "ColorId",
                principalTable: "Colores",
                principalColumn: "ColorId");

            migrationBuilder.AddForeignKey(
                name: "FK_CarritoDetalles_Productos_ProductoId",
                table: "CarritoDetalles",
                column: "ProductoId",
                principalTable: "Productos",
                principalColumn: "ProductoId");

            migrationBuilder.AddForeignKey(
                name: "FK_CarritoDetalles_Tamaños_TamañoId",
                table: "CarritoDetalles",
                column: "TamañoId",
                principalTable: "Tamaños",
                principalColumn: "TamañoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CarritoDetalles_Colores_ColorId",
                table: "CarritoDetalles");

            migrationBuilder.DropForeignKey(
                name: "FK_CarritoDetalles_Productos_ProductoId",
                table: "CarritoDetalles");

            migrationBuilder.DropForeignKey(
                name: "FK_CarritoDetalles_Tamaños_TamañoId",
                table: "CarritoDetalles");

            migrationBuilder.AlterColumn<int>(
                name: "TamañoId",
                table: "CarritoDetalles",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ProductoId",
                table: "CarritoDetalles",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ColorId",
                table: "CarritoDetalles",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_CarritoDetalles_Colores_ColorId",
                table: "CarritoDetalles",
                column: "ColorId",
                principalTable: "Colores",
                principalColumn: "ColorId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CarritoDetalles_Productos_ProductoId",
                table: "CarritoDetalles",
                column: "ProductoId",
                principalTable: "Productos",
                principalColumn: "ProductoId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CarritoDetalles_Tamaños_TamañoId",
                table: "CarritoDetalles",
                column: "TamañoId",
                principalTable: "Tamaños",
                principalColumn: "TamañoId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
