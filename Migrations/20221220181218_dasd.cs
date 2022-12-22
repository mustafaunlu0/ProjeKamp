using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjeKamp.Migrations
{
    /// <inheritdoc />
    public partial class dasd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PostImage",
                table: "Posts");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PostImage",
                table: "Posts",
                type: "text",
                nullable: false,
                defaultValue: "");
        }
    }
}
