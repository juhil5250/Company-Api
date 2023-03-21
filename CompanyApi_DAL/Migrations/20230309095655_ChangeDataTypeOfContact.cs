using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CompanyApi.Migrations
{
    /// <inheritdoc />
    public partial class ChangeDataTypeOfContact : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ContactNo",
                table: "Employee",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "ContactNo",
                table: "Employee",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }
    }
}
