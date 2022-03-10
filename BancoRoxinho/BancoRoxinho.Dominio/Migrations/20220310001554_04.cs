using Microsoft.EntityFrameworkCore.Migrations;

namespace BancoRoxinho.Dominio.Migrations
{
    public partial class _04 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CPNJ",
                table: "PessoasJuridicas");

            migrationBuilder.AddColumn<string>(
                name: "CNPJ",
                table: "PessoasJuridicas",
                type: "nvarchar(15)",
                maxLength: 15,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Endereço",
                table: "PessoasJuridicas",
                type: "nvarchar(45)",
                maxLength: 45,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "RazaoSocial",
                table: "PessoasJuridicas",
                type: "nvarchar(45)",
                maxLength: 45,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CNPJ",
                table: "PessoasJuridicas");

            migrationBuilder.DropColumn(
                name: "Endereço",
                table: "PessoasJuridicas");

            migrationBuilder.DropColumn(
                name: "RazaoSocial",
                table: "PessoasJuridicas");

            migrationBuilder.AddColumn<string>(
                name: "CPNJ",
                table: "PessoasJuridicas",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
