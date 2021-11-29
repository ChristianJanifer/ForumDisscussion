using Microsoft.EntityFrameworkCore.Migrations;

namespace API_Forum.Migrations
{
    public partial class forumhayukjalan : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Views",
                table: "Tb_T_Discussion",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Views",
                table: "Tb_T_Discussion");
        }
    }
}
