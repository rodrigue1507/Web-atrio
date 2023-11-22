using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Web_atrio.Migrations
{
    /// <inheritdoc />
    public partial class changeEmploiPropertiesWording : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PosteOcupe",
                table: "Emploies",
                newName: "PosteOccupe");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PosteOccupe",
                table: "Emploies",
                newName: "PosteOcupe");
        }
    }
}
