using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjectStructure.Databases.MSSQL.Migrations
{
    public partial class TicketUpgrade : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Seat",
                table: "Tickets",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Seat",
                table: "Tickets");
        }
    }
}
