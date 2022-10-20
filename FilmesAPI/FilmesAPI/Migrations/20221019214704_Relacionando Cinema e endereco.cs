using Microsoft.EntityFrameworkCore.Migrations;

namespace FilmesAPI.Migrations
{
    public partial class RelacionandoCinemaeendereco : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cinemas_enderecos_enderecoId",
                table: "Cinemas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_enderecos",
                table: "enderecos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Endereco",
                table: "Endereco");

            migrationBuilder.RenameTable(
                name: "enderecos",
                newName: "Enderecos");

            migrationBuilder.RenameTable(
                name: "Endereco",
                newName: "Filmes");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Enderecos",
                table: "Enderecos",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Filmes",
                table: "Filmes",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Cinemas_Enderecos_enderecoId",
                table: "Cinemas",
                column: "enderecoId",
                principalTable: "Enderecos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cinemas_Enderecos_enderecoId",
                table: "Cinemas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Enderecos",
                table: "Enderecos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Filmes",
                table: "Filmes");

            migrationBuilder.RenameTable(
                name: "Enderecos",
                newName: "enderecos");

            migrationBuilder.RenameTable(
                name: "Filmes",
                newName: "Endereco");

            migrationBuilder.AddPrimaryKey(
                name: "PK_enderecos",
                table: "enderecos",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Endereco",
                table: "Endereco",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Cinemas_enderecos_enderecoId",
                table: "Cinemas",
                column: "enderecoId",
                principalTable: "enderecos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
