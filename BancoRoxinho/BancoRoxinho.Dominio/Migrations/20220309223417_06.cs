using Microsoft.EntityFrameworkCore.Migrations;

namespace BancoRoxinho.Dominio.Migrations
{
    public partial class _06 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Nome",
                table: "tbl_pessoaFisica",
                newName: "nome");

            migrationBuilder.RenameColumn(
                name: "Idade",
                table: "tbl_pessoaFisica",
                newName: "idade");

            migrationBuilder.RenameColumn(
                name: "NomeDaMae",
                table: "tbl_pessoaFisica",
                newName: "nome_da_mae");

            migrationBuilder.AlterColumn<string>(
                name: "nome",
                table: "tbl_pessoaFisica",
                type: "nvarchar(45)",
                maxLength: 45,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "nome",
                table: "tbl_pessoaFisica",
                newName: "Nome");

            migrationBuilder.RenameColumn(
                name: "idade",
                table: "tbl_pessoaFisica",
                newName: "Idade");

            migrationBuilder.RenameColumn(
                name: "nome_da_mae",
                table: "tbl_pessoaFisica",
                newName: "NomeDaMae");

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "tbl_pessoaFisica",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(45)",
                oldMaxLength: 45,
                oldNullable: true);
        }
    }
}
