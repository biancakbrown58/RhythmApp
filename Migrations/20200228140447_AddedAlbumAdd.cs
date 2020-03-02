using Microsoft.EntityFrameworkCore.Migrations;

namespace RhythmApp.Migrations
{
    public partial class AddedAlbumAdd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "IsExplicit",
                table: "Albums",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "boolean");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "IsExplicit",
                table: "Albums",
                type: "boolean",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
