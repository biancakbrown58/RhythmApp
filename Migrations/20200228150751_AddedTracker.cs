using Microsoft.EntityFrameworkCore.Migrations;

namespace RhythmApp.Migrations
{
    public partial class AddedTracker : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "IsSigned",
                table: "Bands",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "boolean");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "IsSigned",
                table: "Bands",
                type: "boolean",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
