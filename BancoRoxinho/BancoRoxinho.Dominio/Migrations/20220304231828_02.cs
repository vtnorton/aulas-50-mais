using Microsoft.EntityFrameworkCore.Migrations;

namespace BancoRoxinho.Dominio.Migrations
{
    public partial class _02 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CPNJ",
                table: "PessoasJuridicas",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CPNJ",
                table: "PessoasJuridicas");
        }
    }
}
