using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace E_commerce.Migrations
{
    /// <inheritdoc />
    public partial class i1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Carts",
                columns: table => new
                {
                    Cart_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Product_Id = table.Column<int>(type: "int", nullable: false),
                    Product_Price = table.Column<int>(type: "int", nullable: false),
                    Total_Amount = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carts", x => x.Cart_Id);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Customer_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Customer_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Customer_Contact = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Customer_Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Customer_Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Customer_Gender = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Customer_DOB = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Customer_Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Customer_ConfirmPassword = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Customer_State = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Customer_District = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Customer_Pincode = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: false),
                    Customer_Landmark = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Customer_IsActive = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Customer_Id);
                });

            migrationBuilder.CreateTable(
                name: "Electronics",
                columns: table => new
                {
                    Product_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Product_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Product_Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Product_Price = table.Column<int>(type: "int", nullable: false),
                    Seller_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImagePath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ratings = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Electronics", x => x.Product_Id);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Order_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ordered_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Product_Id = table.Column<int>(type: "int", nullable: false),
                    Customer_Id = table.Column<int>(type: "int", nullable: false),
                    Seller_Id = table.Column<int>(type: "int", nullable: false),
                    Ordered_Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Order_Id);
                });

            migrationBuilder.CreateTable(
                name: "Sellers",
                columns: table => new
                {
                    Seller_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Seller_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Seller_Contact = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Seller_Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Seller_Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Seller_Gender = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Seller_DOB = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Seller_Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Seller_ConfirmPassword = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Seller_State = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Seller_District = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Seller_Pincode = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: false),
                    Seller_isactive = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sellers", x => x.Seller_Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Carts");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Electronics");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Sellers");
        }
    }
}
