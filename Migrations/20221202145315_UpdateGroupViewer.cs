using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace projetalexmargo.Migrations
{
    /// <inheritdoc />
    public partial class UpdateGroupViewer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GroupViewers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    IdEventId = table.Column<int>(type: "INTEGER", nullable: false),
                    IdGroupId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupViewers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GroupViewers_Events_IdEventId",
                        column: x => x.IdEventId,
                        principalTable: "Events",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GroupViewers_Groups_IdGroupId",
                        column: x => x.IdGroupId,
                        principalTable: "Groups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GroupViewers_IdEventId",
                table: "GroupViewers",
                column: "IdEventId");

            migrationBuilder.CreateIndex(
                name: "IX_GroupViewers_IdGroupId",
                table: "GroupViewers",
                column: "IdGroupId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GroupViewers");
        }
    }
}
