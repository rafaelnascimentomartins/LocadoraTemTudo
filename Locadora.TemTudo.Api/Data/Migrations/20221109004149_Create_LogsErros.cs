using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Locadora.TemTudo.Api.Data.Migrations
{
    public partial class Create_LogsErros : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LogsErros",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StackTrace = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Mensagem = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    InnerException = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    DataHoraRegistro = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LogsErros", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LogsErros");
        }
    }
}
