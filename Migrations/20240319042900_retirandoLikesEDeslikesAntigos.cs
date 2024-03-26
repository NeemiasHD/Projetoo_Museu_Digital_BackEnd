using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API_Museu_da_computacao.Migrations
{
    /// <inheritdoc />
    public partial class retirandoLikesEDeslikesAntigos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NotaItemDesLike",
                table: "ItensAcervo");

            migrationBuilder.DropColumn(
                name: "NotaItemLike",
                table: "ItensAcervo");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "NotaItemDesLike",
                table: "ItensAcervo",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "NotaItemLike",
                table: "ItensAcervo",
                type: "int",
                nullable: true);
        }
    }
}
