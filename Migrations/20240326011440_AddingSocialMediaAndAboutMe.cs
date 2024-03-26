using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API_Museu_da_computacao.Migrations
{
    /// <inheritdoc />
    public partial class AddingSocialMediaAndAboutMe : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SobreMim",
                table: "Usuarios",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "User_github_link",
                table: "Usuarios",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "User_insta_link",
                table: "Usuarios",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "User_twitter_link",
                table: "Usuarios",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SobreMim",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "User_github_link",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "User_insta_link",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "User_twitter_link",
                table: "Usuarios");
        }
    }
}
