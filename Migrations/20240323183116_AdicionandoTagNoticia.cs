using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API_Museu_da_computacao.Migrations
{
    /// <inheritdoc />
    public partial class AdicionandoTagNoticia : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "tagNoticia",
                table: "Noticias",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "tagNoticia",
                table: "Noticias");
        }
    }
}
