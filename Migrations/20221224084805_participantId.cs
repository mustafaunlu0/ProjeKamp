using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjeKamp.Migrations
{
    /// <inheritdoc />
    public partial class participantId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PostDetail_Users_ParticipantIdUserId",
                table: "PostDetail");

            migrationBuilder.DropIndex(
                name: "IX_PostDetail_ParticipantIdUserId",
                table: "PostDetail");

            migrationBuilder.RenameColumn(
                name: "ParticipantIdUserId",
                table: "PostDetail",
                newName: "ParticipantId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ParticipantId",
                table: "PostDetail",
                newName: "ParticipantIdUserId");

            migrationBuilder.CreateIndex(
                name: "IX_PostDetail_ParticipantIdUserId",
                table: "PostDetail",
                column: "ParticipantIdUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_PostDetail_Users_ParticipantIdUserId",
                table: "PostDetail",
                column: "ParticipantIdUserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
