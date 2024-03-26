using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API_Museu_da_computacao.Migrations
{
    /// <inheritdoc />
    public partial class adicaotipoUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TipoUsuario",
                table: "Usuarios",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "DescricaoCurtaItem",
                table: "ItensAcervo",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TipoUsuario",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "DescricaoCurtaItem",
                table: "ItensAcervo");
        }
    }
}
