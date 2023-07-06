using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shaxsiy_Kabinet.Migrations
{
    /// <inheritdoc />
    public partial class migration2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_notes_UserEntities_userEntityId",
                table: "notes");

            migrationBuilder.DropIndex(
                name: "IX_notes_userEntityId",
                table: "notes");

            migrationBuilder.DropColumn(
                name: "userEntityId",
                table: "notes");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "userEntityId",
                table: "notes",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_notes_userEntityId",
                table: "notes",
                column: "userEntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_notes_UserEntities_userEntityId",
                table: "notes",
                column: "userEntityId",
                principalTable: "UserEntities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
