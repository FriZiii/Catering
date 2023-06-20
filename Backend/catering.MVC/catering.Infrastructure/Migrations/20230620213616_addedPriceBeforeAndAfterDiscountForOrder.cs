using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace catering.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addedPriceBeforeAndAfterDiscountForOrder : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TotalPrice",
                table: "Orders",
                newName: "TotalPriceBeforeDiscount");

            migrationBuilder.AddColumn<decimal>(
                name: "TotalPriceAfterDiscount",
                table: "Orders",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TotalPriceAfterDiscount",
                table: "Orders");

            migrationBuilder.RenameColumn(
                name: "TotalPriceBeforeDiscount",
                table: "Orders",
                newName: "TotalPrice");
        }
    }
}
