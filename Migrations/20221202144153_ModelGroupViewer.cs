using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace projetalexmargo.Migrations
{
    /// <inheritdoc />
    public partial class ModelGroupViewer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Events_Groups_GroupId",
                table: "Events");

            migrationBuilder.DropIndex(
                name: "IX_Events_GroupId",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "GroupId",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "GroupeId",
                table: "Events");

            migrationBuilder.RenameColumn(
                name: "IdStudent",
                table: "Members",
                newName: "IdStudentId");

            migrationBuilder.RenameColumn(
                name: "IdGroup",
                table: "Members",
                newName: "IdGroupId");

            migrationBuilder.RenameColumn(
                name: "Visibility",
                table: "Events",
                newName: "GroupeIdId");

            migrationBuilder.CreateIndex(
                name: "IX_Members_IdGroupId",
                table: "Members",
                column: "IdGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Members_IdStudentId",
                table: "Members",
                column: "IdStudentId");

            migrationBuilder.CreateIndex(
                name: "IX_Events_GroupeIdId",
                table: "Events",
                column: "GroupeIdId");

            migrationBuilder.AddForeignKey(
                name: "FK_Events_Groups_GroupeIdId",
                table: "Events",
                column: "GroupeIdId",
                principalTable: "Groups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Members_Groups_IdGroupId",
                table: "Members",
                column: "IdGroupId",
                principalTable: "Groups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Members_Students_IdStudentId",
                table: "Members",
                column: "IdStudentId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Events_Groups_GroupeIdId",
                table: "Events");

            migrationBuilder.DropForeignKey(
                name: "FK_Members_Groups_IdGroupId",
                table: "Members");

            migrationBuilder.DropForeignKey(
                name: "FK_Members_Students_IdStudentId",
                table: "Members");

            migrationBuilder.DropIndex(
                name: "IX_Members_IdGroupId",
                table: "Members");

            migrationBuilder.DropIndex(
                name: "IX_Members_IdStudentId",
                table: "Members");

            migrationBuilder.DropIndex(
                name: "IX_Events_GroupeIdId",
                table: "Events");

            migrationBuilder.RenameColumn(
                name: "IdStudentId",
                table: "Members",
                newName: "IdStudent");

            migrationBuilder.RenameColumn(
                name: "IdGroupId",
                table: "Members",
                newName: "IdGroup");

            migrationBuilder.RenameColumn(
                name: "GroupeIdId",
                table: "Events",
                newName: "Visibility");

            migrationBuilder.AddColumn<int>(
                name: "GroupId",
                table: "Events",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "GroupeId",
                table: "Events",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Events_GroupId",
                table: "Events",
                column: "GroupId");

            migrationBuilder.AddForeignKey(
                name: "FK_Events_Groups_GroupId",
                table: "Events",
                column: "GroupId",
                principalTable: "Groups",
                principalColumn: "Id");
        }
    }
}
