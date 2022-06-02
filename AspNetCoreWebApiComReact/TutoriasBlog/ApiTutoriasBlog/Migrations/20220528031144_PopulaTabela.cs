using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiTutoriasBlog.Migrations
{
    public partial class PopulaTabela : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Alunos",
                columns: new[] { "AlunoId", "Email", "Idade", "Nome" },
                values: new object[] { 1, "josefina@gmail.com", 20, "Josefina Da Silva" });

            migrationBuilder.InsertData(
                table: "Alunos",
                columns: new[] { "AlunoId", "Email", "Idade", "Nome" },
                values: new object[] { 2, "marlucio@gmail.com", 25, "Marlucio De Oliveira" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Alunos",
                keyColumn: "AlunoId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Alunos",
                keyColumn: "AlunoId",
                keyValue: 2);
        }
    }
}
