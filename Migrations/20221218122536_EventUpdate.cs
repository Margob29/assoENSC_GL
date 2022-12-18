using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace projetalexmargo.Migrations
{
    /// <inheritdoc />
    public partial class EventUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Events_Groups_GroupeIdId",
                table: "Events");

            migrationBuilder.RenameColumn(
                name: "GroupeIdId",
                table: "Events",
                newName: "GroupId");

            migrationBuilder.RenameIndex(
                name: "IX_Events_GroupeIdId",
                table: "Events",
                newName: "IX_Events_GroupId");

            migrationBuilder.AddForeignKey(
                name: "FK_Events_Groups_GroupId",
                table: "Events",
                column: "GroupId",
                principalTable: "Groups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Events_Groups_GroupId",
                table: "Events");

            migrationBuilder.RenameColumn(
                name: "GroupId",
                table: "Events",
                newName: "GroupeIdId");

            migrationBuilder.RenameIndex(
                name: "IX_Events_GroupId",
                table: "Events",
                newName: "IX_Events_GroupeIdId");

            migrationBuilder.AddForeignKey(
                name: "FK_Events_Groups_GroupeIdId",
                table: "Events",
                column: "GroupeIdId",
                principalTable: "Groups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
