using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TheSchizoGamblers.Migrations
{
    /// <inheritdoc />
    public partial class ProfilePic : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "PictureSource",
                table: "AspNetUsers",
                type: "longblob",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PictureSource",
                table: "AspNetUsers");
        }
    }
}
