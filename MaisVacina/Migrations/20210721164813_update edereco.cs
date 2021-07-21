using Microsoft.EntityFrameworkCore.Migrations;

namespace MaisVacina.Migrations
{
    public partial class updateedereco : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Endereço",
                table: "Cadastro",
                newName: "Endereco");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Endereco",
                table: "Cadastro",
                newName: "Endereço");
        }
    }
}
