using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SMS.Migrations
{
    /// <inheritdoc />
    public partial class AddMstLocationandTblSoftwareLog : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AppMstLocations",
                columns: table => new
                {
                    LocationCode = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    LocationName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LocationType = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppMstLocations", x => x.LocationCode);
                });

            migrationBuilder.CreateTable(
                name: "AppTblSoftwareLog",
                columns: table => new
                {
                    SoftwareCode = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    VersionCode = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    FactoryCode = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    LineICode = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    ProcessCode = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    LogType = table.Column<int>(type: "int", nullable: true),
                    LogContent = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    LogDateTime = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppTblSoftwareLog", x => new { x.SoftwareCode, x.VersionCode });
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppMstLocations");

            migrationBuilder.DropTable(
                name: "AppTblSoftwareLog");
        }
    }
}
