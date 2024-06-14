using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LoremIpsum.Data.Migrations
{
    /// <inheritdoc />
    public partial class AlterColumnCidade : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Cidade",
                table: "Endereco",
                newName: "Localidade");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Localidade",
                table: "Endereco",
                newName: "Cidade");
        }
    }
}
