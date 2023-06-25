using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace catering.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddedGuest : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Guests",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DeliveryAdressId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Guests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Guests_UserDeliveryAdress_DeliveryAdressId",
                        column: x => x.DeliveryAdressId,
                        principalTable: "UserDeliveryAdress",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Guests_DeliveryAdressId",
                table: "Guests",
                column: "DeliveryAdressId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Guests");
        }
    }
}
