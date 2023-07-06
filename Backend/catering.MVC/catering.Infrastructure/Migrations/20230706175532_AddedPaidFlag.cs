using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace catering.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddedPaidFlag : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_UserDeliveryAdress_DeliveryAdressId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Guests_UserDeliveryAdress_DeliveryAdressId",
                table: "Guests");

            migrationBuilder.DropTable(
                name: "UserDeliveryAdress");

            migrationBuilder.AddColumn<bool>(
                name: "Paid",
                table: "Orders",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "DeliveryAddresses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Adress1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Adress2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PostalCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeliveryAddresses", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_DeliveryAddresses_DeliveryAdressId",
                table: "AspNetUsers",
                column: "DeliveryAdressId",
                principalTable: "DeliveryAddresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Guests_DeliveryAddresses_DeliveryAdressId",
                table: "Guests",
                column: "DeliveryAdressId",
                principalTable: "DeliveryAddresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_DeliveryAddresses_DeliveryAdressId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Guests_DeliveryAddresses_DeliveryAdressId",
                table: "Guests");

            migrationBuilder.DropTable(
                name: "DeliveryAddresses");

            migrationBuilder.DropColumn(
                name: "Paid",
                table: "Orders");

            migrationBuilder.CreateTable(
                name: "UserDeliveryAdress",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Adress1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Adress2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PostalCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserDeliveryAdress", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_UserDeliveryAdress_DeliveryAdressId",
                table: "AspNetUsers",
                column: "DeliveryAdressId",
                principalTable: "UserDeliveryAdress",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Guests_UserDeliveryAdress_DeliveryAdressId",
                table: "Guests",
                column: "DeliveryAdressId",
                principalTable: "UserDeliveryAdress",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
