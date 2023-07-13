using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LibraryManagement.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddedNavigationalPropertyAdress : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AdressId",
                table: "Librarians",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Librarians_AdressId",
                table: "Librarians",
                column: "AdressId");

            migrationBuilder.AddForeignKey(
                name: "FK_Librarians_Adresses_AdressId",
                table: "Librarians",
                column: "AdressId",
                principalTable: "Adresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Librarians_Adresses_AdressId",
                table: "Librarians");

            migrationBuilder.DropIndex(
                name: "IX_Librarians_AdressId",
                table: "Librarians");

            migrationBuilder.DropColumn(
                name: "AdressId",
                table: "Librarians");
        }
    }
}
