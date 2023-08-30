using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlogApp_webapi.Migrations
{
    /// <inheritdoc />
    public partial class NewStuff : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                table: "Posts",
                newName: "ModifiedAt");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ModifiedAt",
                table: "Posts",
                newName: "UpdatedAt");
        }
    }
}
