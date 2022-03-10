using Microsoft.EntityFrameworkCore.Migrations;

namespace BancoRoxinho.Dominio.Migrations
{
    public partial class _05 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PessoasFisicas_ContasCorrentes_ContaCorrenteId",
                table: "PessoasFisicas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PessoasFisicas",
                table: "PessoasFisicas");

            migrationBuilder.RenameTable(
                name: "PessoasFisicas",
                newName: "tbl_pessoaFisica");

            migrationBuilder.RenameIndex(
                name: "IX_PessoasFisicas_ContaCorrenteId",
                table: "tbl_pessoaFisica",
                newName: "IX_tbl_pessoaFisica_ContaCorrenteId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tbl_pessoaFisica",
                table: "tbl_pessoaFisica",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_tbl_pessoaFisica_ContasCorrentes_ContaCorrenteId",
                table: "tbl_pessoaFisica",
                column: "ContaCorrenteId",
                principalTable: "ContasCorrentes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tbl_pessoaFisica_ContasCorrentes_ContaCorrenteId",
                table: "tbl_pessoaFisica");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tbl_pessoaFisica",
                table: "tbl_pessoaFisica");

            migrationBuilder.RenameTable(
                name: "tbl_pessoaFisica",
                newName: "PessoasFisicas");

            migrationBuilder.RenameIndex(
                name: "IX_tbl_pessoaFisica_ContaCorrenteId",
                table: "PessoasFisicas",
                newName: "IX_PessoasFisicas_ContaCorrenteId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PessoasFisicas",
                table: "PessoasFisicas",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PessoasFisicas_ContasCorrentes_ContaCorrenteId",
                table: "PessoasFisicas",
                column: "ContaCorrenteId",
                principalTable: "ContasCorrentes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
