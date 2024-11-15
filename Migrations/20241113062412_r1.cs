using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace E_commerce.Migrations
{
    /// <inheritdoc />
    public partial class r1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_Customers_customersCustomer_Id",
                table: "Reviews");

            migrationBuilder.DropIndex(
                name: "IX_Reviews_customersCustomer_Id",
                table: "Reviews");

            migrationBuilder.DropColumn(
                name: "customersCustomer_Id",
                table: "Reviews");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "customersCustomer_Id",
                table: "Reviews",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_customersCustomer_Id",
                table: "Reviews",
                column: "customersCustomer_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_Customers_customersCustomer_Id",
                table: "Reviews",
                column: "customersCustomer_Id",
                principalTable: "Customers",
                principalColumn: "Customer_Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
