using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UserRegistrationAPI.Migrations
{
    /// <inheritdoc />
    public partial class v1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    USER_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FRST_NAME = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    LAST_NAME = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    EMAL = table.Column<string>(type: "nvarchar(70)", nullable: false),
                    PWRD = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ROLE = table.Column<string>(type: "nvarchar(10)", nullable: true),
                    TOKN = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.USER_ID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "users");
        }
    }
}
