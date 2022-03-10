using Microsoft.EntityFrameworkCore.Migrations;

namespace BancoRoxinho.Dominio.Migrations
{
    public partial class mig01 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "NomeFantasia",
                table: "PessoasJuridicas",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RazaoSocial",
                table: "PessoasJuridicas",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NomeFantasia",
                table: "PessoasJuridicas");

            migrationBuilder.DropColumn(
                name: "RazaoSocial",
                table: "PessoasJuridicas");
        }
    }
}
