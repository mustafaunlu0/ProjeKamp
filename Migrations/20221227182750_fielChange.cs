using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjeKamp.Migrations
{
    /// <inheritdoc />
    public partial class fielChange : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PostHarita",
                table: "Posts",
                newName: "PostMap");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PostMap",
                table: "Posts",
                newName: "PostHarita");
        }
    }
}
