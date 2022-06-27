using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProductShoppingWebsite.Server.Infrastructure.Persistence.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Sellers",
                columns: table => new
                {
                    SellerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UniqueSellerIdentificator = table.Column<int>(type: "int", nullable: false),
                    SellerNickname = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    BankAccountNumber = table.Column<string>(type: "nvarchar(18)", maxLength: 18, nullable: false),
                    IsAuthorized = table.Column<bool>(type: "bit", nullable: false),
                    IsArchived = table.Column<bool>(type: "bit", nullable: false),
                    IsBanned = table.Column<bool>(type: "bit", nullable: false),
                    ServiceUserId = table.Column<int>(type: "int", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    BirthDate = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sellers", x => x.SellerId);
                });

            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    AccountId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccountOwnerId = table.Column<int>(type: "int", nullable: false),
                    account_type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AuthorizationDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    AuthorizationMethod = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    UniqueAccountIdentificator = table.Column<int>(type: "int", nullable: false),
                    Login = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.AccountId);
                    table.ForeignKey(
                        name: "FK_Accounts_Sellers_AccountOwnerId",
                        column: x => x.AccountOwnerId,
                        principalTable: "Sellers",
                        principalColumn: "SellerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BannedSellers",
                columns: table => new
                {
                    BannedSellerEntityId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DecisionAdmin = table.Column<int>(type: "int", nullable: false),
                    DateOfBan = table.Column<DateTime>(type: "datetime", nullable: false),
                    BanReasonDescription = table.Column<string>(type: "nvarchar(1500)", maxLength: 1500, nullable: false),
                    ArchivizationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BannedSellerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BannedSellers", x => x.BannedSellerEntityId);
                    table.ForeignKey(
                        name: "FK_BannedSellers_Sellers_BannedSellerId",
                        column: x => x.BannedSellerId,
                        principalTable: "Sellers",
                        principalColumn: "SellerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UniqueProductIdentificator = table.Column<int>(type: "int", nullable: false),
                    ProductName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    ProductDescription = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(19,4)", nullable: false),
                    Quatity = table.Column<int>(type: "int", nullable: false),
                    QuantityType = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    ServicePerformer = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    ServiceType = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    ServicePerformerContactInfo = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    ProductTypesInString = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    SellerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductId);
                    table.ForeignKey(
                        name: "FK_Products_Sellers_SellerId",
                        column: x => x.SellerId,
                        principalTable: "Sellers",
                        principalColumn: "SellerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Admins",
                columns: table => new
                {
                    AdminId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UniqueAdminIdentificator = table.Column<int>(type: "int", nullable: false),
                    AdminName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    AdminAccountAccountId = table.Column<int>(type: "int", nullable: true),
                    ServiceUserId = table.Column<int>(type: "int", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    BirthDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    AccountId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admins", x => x.AdminId);
                    table.ForeignKey(
                        name: "FK_Admins_Accounts_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Accounts",
                        principalColumn: "AccountId");
                    table.ForeignKey(
                        name: "FK_Admins_Accounts_AdminAccountAccountId",
                        column: x => x.AdminAccountAccountId,
                        principalTable: "Accounts",
                        principalColumn: "AccountId");
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    CustomerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UniqueCustomerIdentificator = table.Column<int>(type: "int", nullable: false),
                    CustomerNickname = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(319)", maxLength: 319, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    BankAccountNumber = table.Column<string>(type: "nvarchar(18)", maxLength: 18, nullable: true),
                    IsAuthorized = table.Column<bool>(type: "bit", nullable: false),
                    ServiceUserId = table.Column<int>(type: "int", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    BirthDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    AccountId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.CustomerId);
                    table.ForeignKey(
                        name: "FK_Customers_Accounts_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Accounts",
                        principalColumn: "AccountId");
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    OrderId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UniqueOrderIdentificator = table.Column<int>(type: "int", nullable: false),
                    PaymentMethod = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    ShippingAddress = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    BuyerPhoneNumber = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    OrderDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    OrderStatus = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    BuyerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.OrderId);
                    table.ForeignKey(
                        name: "FK_Orders_Customers_BuyerId",
                        column: x => x.BuyerId,
                        principalTable: "Customers",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Orders_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductRatings",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    RatingScore = table.Column<double>(type: "float", nullable: false),
                    RatingDescription = table.Column<string>(type: "nvarchar(1500)", maxLength: 1500, nullable: false),
                    RatedById = table.Column<int>(type: "int", nullable: false),
                    RatingDate = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductRatings", x => x.ProductId);
                    table.ForeignKey(
                        name: "FK_ProductRatings_Customers_RatedById",
                        column: x => x.RatedById,
                        principalTable: "Customers",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductRatings_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reports",
                columns: table => new
                {
                    ReportId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UniqueReportIdentificator = table.Column<int>(type: "int", nullable: false),
                    ReportDescription = table.Column<string>(type: "nvarchar(1500)", maxLength: 1500, nullable: false),
                    ReportDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    IssuerId = table.Column<int>(type: "int", nullable: false),
                    ReportedSellerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reports", x => x.ReportId);
                    table.ForeignKey(
                        name: "FK_Reports_Customers_IssuerId",
                        column: x => x.IssuerId,
                        principalTable: "Customers",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reports_Sellers_ReportedSellerId",
                        column: x => x.ReportedSellerId,
                        principalTable: "Sellers",
                        principalColumn: "SellerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_AccountOwnerId",
                table: "Accounts",
                column: "AccountOwnerId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_UniqueAccountIdentificator",
                table: "Accounts",
                column: "UniqueAccountIdentificator",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Admins_AccountId",
                table: "Admins",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_Admins_AdminAccountAccountId",
                table: "Admins",
                column: "AdminAccountAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_Admins_UniqueAdminIdentificator",
                table: "Admins",
                column: "UniqueAdminIdentificator",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_BannedSellers_BannedSellerId",
                table: "BannedSellers",
                column: "BannedSellerId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Customers_AccountId",
                table: "Customers",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_UniqueCustomerIdentificator",
                table: "Customers",
                column: "UniqueCustomerIdentificator",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Orders_BuyerId",
                table: "Orders",
                column: "BuyerId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_ProductId",
                table: "Orders",
                column: "ProductId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Orders_UniqueOrderIdentificator",
                table: "Orders",
                column: "UniqueOrderIdentificator",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProductRatings_RatedById",
                table: "ProductRatings",
                column: "RatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Products_SellerId",
                table: "Products",
                column: "SellerId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_UniqueProductIdentificator",
                table: "Products",
                column: "UniqueProductIdentificator",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Reports_IssuerId",
                table: "Reports",
                column: "IssuerId");

            migrationBuilder.CreateIndex(
                name: "IX_Reports_ReportedSellerId",
                table: "Reports",
                column: "ReportedSellerId");

            migrationBuilder.CreateIndex(
                name: "IX_Reports_UniqueReportIdentificator",
                table: "Reports",
                column: "UniqueReportIdentificator",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Sellers_UniqueSellerIdentificator",
                table: "Sellers",
                column: "UniqueSellerIdentificator",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Admins");

            migrationBuilder.DropTable(
                name: "BannedSellers");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "ProductRatings");

            migrationBuilder.DropTable(
                name: "Reports");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Accounts");

            migrationBuilder.DropTable(
                name: "Sellers");
        }
    }
}
