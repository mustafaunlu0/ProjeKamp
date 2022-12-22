using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjeKamp.Migrations
{
    /// <inheritdoc />
    public partial class finalLoop : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PostUri",
                table: "Posts",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PostUri",
                table: "Posts");
        }
    }
}
