using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Locadora.TemTudo.Api.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DataNascimento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CPF = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    TelefoneFixo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Celular = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ClientesEnderecos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Logradouro = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Bairro = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    CEP = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Complemento = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Numero = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    PontoReferencia = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    ClienteId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientesEnderecos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClientesEnderecos_Clientes_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Clientes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ClientesEnderecos_ClienteId",
                table: "ClientesEnderecos",
                column: "ClienteId");

            //PODEMOS EXECUTAR COMANDOS DIRETAMENTE NA MIGRATION, CONFORME EXEMPLO ABAIXO!
            //migrationBuilder.Sql(@"INSERT INTO Clientes (Nome) VALUES ('Rafael Teste')");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClientesEnderecos");

            migrationBuilder.DropTable(
                name: "Clientes");

            //PODEMOS EXECUTAR COMANDOS DIRETAMENTE NA MIGRATION, CONFORME EXEMPLO ABAIXO! ROLLBACK
            //migrationBuilder.Sql(@"DELETE FROM Clientes WHERE Nome = 'Rafael Teste'");
        }
    }
}
