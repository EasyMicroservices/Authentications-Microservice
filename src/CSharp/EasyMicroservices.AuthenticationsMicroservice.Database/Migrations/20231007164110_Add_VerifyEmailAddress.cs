using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EasyMicroservices.AuthenticationsMicroservice.Migrations
{
    /// <inheritdoc />
    public partial class Add_VerifyEmailAddress : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsUsernameVerified",
                table: "Users",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsUsernameVerified",
                table: "Users");
        }
    }
}
