using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjeKamp.Migrations
{
    /// <inheritdoc />
    public partial class postMaps : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PostHarita",
                table: "Posts",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PostHarita",
                table: "Posts");
        }
    }
}
