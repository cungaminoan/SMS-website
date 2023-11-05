using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SMS.Migrations
{
    /// <inheritdoc />
    public partial class AddSoftwareEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AppMstSoftwares",
                columns: table => new
                {
                    SoftwareCode = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    SoftwareName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    SoftwareDescription = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    SoftwareStatus = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppMstSoftwares", x => x.SoftwareCode);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppMstSoftwares");
        }
    }
}
