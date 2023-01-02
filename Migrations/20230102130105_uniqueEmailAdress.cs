using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace projetalexmargo.Migrations
{
    /// <inheritdoc />
    public partial class uniqueEmailAdress : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Students_EmailAdress",
                table: "Students",
                column: "EmailAdress",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Students_EmailAdress",
                table: "Students");
        }
    }
}
