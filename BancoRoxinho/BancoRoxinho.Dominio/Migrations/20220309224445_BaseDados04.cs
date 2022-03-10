using Microsoft.EntityFrameworkCore.Migrations;

namespace BancoRoxinho.Dominio.Migrations
{
    public partial class BaseDados04 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CPNJ",
                table: "PessoasJuridicas",
                newName: "Nome");

            migrationBuilder.AddColumn<string>(
                name: "CNPJ",
                table: "PessoasJuridicas",
                type: "nvarchar(18)",
                maxLength: 18,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CNPJ",
                table: "PessoasJuridicas");

            migrationBuilder.RenameColumn(
                name: "Nome",
                table: "PessoasJuridicas",
                newName: "CPNJ");
        }
    }
}
