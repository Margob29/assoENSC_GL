using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace projetalexmargo.Migrations
{
    /// <inheritdoc />
    public partial class UpdateMembers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Member_Groups_GroupId",
                table: "Member");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Member",
                table: "Member");

            migrationBuilder.DropIndex(
                name: "IX_Member_GroupId",
                table: "Member");

            migrationBuilder.DropColumn(
                name: "GroupId",
                table: "Member");

            migrationBuilder.RenameTable(
                name: "Member",
                newName: "Members");

            migrationBuilder.AlterColumn<int>(
                name: "NbMembers",
                table: "Groups",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Members",
                table: "Members",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Members",
                table: "Members");

            migrationBuilder.RenameTable(
                name: "Members",
                newName: "Member");

            migrationBuilder.AlterColumn<int>(
                name: "NbMembers",
                table: "Groups",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "GroupId",
                table: "Member",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Member",
                table: "Member",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Member_GroupId",
                table: "Member",
                column: "GroupId");

            migrationBuilder.AddForeignKey(
                name: "FK_Member_Groups_GroupId",
                table: "Member",
                column: "GroupId",
                principalTable: "Groups",
                principalColumn: "Id");
        }
    }
}
