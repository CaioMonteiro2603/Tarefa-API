using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tarefa.Migrations
{
    /// <inheritdoc />
    public partial class Tarefas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "id",
                table: "Tarefa",
                newName: "TarefaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TarefaId",
                table: "Tarefa",
                newName: "id");
        }
    }
}
