using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace usuario.Migrations
{
    public partial class atualizar : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_tabelaUsuarios",
                table: "tabelaUsuarios");

            migrationBuilder.RenameTable(
                name: "tabelaUsuarios",
                newName: "tb_usuario");

            migrationBuilder.RenameColumn(
                name: "dataNasc",
                table: "tb_usuario",
                newName: "nascimento");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tb_usuario",
                table: "tb_usuario",
                column: "id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_tb_usuario",
                table: "tb_usuario");

            migrationBuilder.RenameTable(
                name: "tb_usuario",
                newName: "tabelaUsuarios");

            migrationBuilder.RenameColumn(
                name: "nascimento",
                table: "tabelaUsuarios",
                newName: "dataNasc");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tabelaUsuarios",
                table: "tabelaUsuarios",
                column: "id");
        }
    }
}
