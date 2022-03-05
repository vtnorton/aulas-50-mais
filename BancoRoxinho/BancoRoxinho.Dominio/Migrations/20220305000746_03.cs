using Microsoft.EntityFrameworkCore.Migrations;

namespace BancoRoxinho.Dominio.Migrations
{
    public partial class _03 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ContaCorrenteId",
                table: "PessoasJuridicas",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Endereco",
                table: "PessoasJuridicas",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ContaCorrenteId",
                table: "PessoasFisicas",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Endereco",
                table: "PessoasFisicas",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PessoasJuridicas_ContaCorrenteId",
                table: "PessoasJuridicas",
                column: "ContaCorrenteId");

            migrationBuilder.CreateIndex(
                name: "IX_PessoasFisicas_ContaCorrenteId",
                table: "PessoasFisicas",
                column: "ContaCorrenteId");

            migrationBuilder.AddForeignKey(
                name: "FK_PessoasFisicas_ContasCorrentes_ContaCorrenteId",
                table: "PessoasFisicas",
                column: "ContaCorrenteId",
                principalTable: "ContasCorrentes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PessoasJuridicas_ContasCorrentes_ContaCorrenteId",
                table: "PessoasJuridicas",
                column: "ContaCorrenteId",
                principalTable: "ContasCorrentes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PessoasFisicas_ContasCorrentes_ContaCorrenteId",
                table: "PessoasFisicas");

            migrationBuilder.DropForeignKey(
                name: "FK_PessoasJuridicas_ContasCorrentes_ContaCorrenteId",
                table: "PessoasJuridicas");

            migrationBuilder.DropIndex(
                name: "IX_PessoasJuridicas_ContaCorrenteId",
                table: "PessoasJuridicas");

            migrationBuilder.DropIndex(
                name: "IX_PessoasFisicas_ContaCorrenteId",
                table: "PessoasFisicas");

            migrationBuilder.DropColumn(
                name: "ContaCorrenteId",
                table: "PessoasJuridicas");

            migrationBuilder.DropColumn(
                name: "Endereco",
                table: "PessoasJuridicas");

            migrationBuilder.DropColumn(
                name: "ContaCorrenteId",
                table: "PessoasFisicas");

            migrationBuilder.DropColumn(
                name: "Endereco",
                table: "PessoasFisicas");
        }
    }
}
