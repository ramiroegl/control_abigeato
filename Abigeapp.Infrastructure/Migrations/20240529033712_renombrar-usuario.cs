using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Abigeapp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class renombrarusuario : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Usuario_Fincas_FincaId",
                table: "Usuario");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Usuario",
                table: "Usuario");

            migrationBuilder.RenameTable(
                name: "Usuario",
                newName: "Usuarios");

            migrationBuilder.RenameIndex(
                name: "IX_Usuario_FincaId",
                table: "Usuarios",
                newName: "IX_Usuarios_FincaId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Usuarios",
                table: "Usuarios",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Usuarios_Fincas_FincaId",
                table: "Usuarios",
                column: "FincaId",
                principalTable: "Fincas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Usuarios_Fincas_FincaId",
                table: "Usuarios");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Usuarios",
                table: "Usuarios");

            migrationBuilder.RenameTable(
                name: "Usuarios",
                newName: "Usuario");

            migrationBuilder.RenameIndex(
                name: "IX_Usuarios_FincaId",
                table: "Usuario",
                newName: "IX_Usuario_FincaId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Usuario",
                table: "Usuario",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Usuario_Fincas_FincaId",
                table: "Usuario",
                column: "FincaId",
                principalTable: "Fincas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
