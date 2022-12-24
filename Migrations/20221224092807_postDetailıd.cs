using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ProjeKamp.Migrations
{
    /// <inheritdoc />
    public partial class postDetailıd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_PostDetail",
                table: "PostDetail");

            migrationBuilder.AlterColumn<int>(
                name: "postId",
                table: "PostDetail",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn);

            migrationBuilder.AddColumn<int>(
                name: "detailId",
                table: "PostDetail",
                type: "integer",
                nullable: false,
                defaultValue: 0)
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_PostDetail",
                table: "PostDetail",
                column: "detailId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_PostDetail",
                table: "PostDetail");

            migrationBuilder.DropColumn(
                name: "detailId",
                table: "PostDetail");

            migrationBuilder.AlterColumn<int>(
                name: "postId",
                table: "PostDetail",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_PostDetail",
                table: "PostDetail",
                column: "postId");
        }
    }
}
