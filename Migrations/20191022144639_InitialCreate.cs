using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace FinanzasBE.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Banks",
                columns: table => new
                {
                    BankId = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Ruc = table.Column<string>(nullable: true),
                    BusinessName = table.Column<string>(nullable: true),
                    TEASoles = table.Column<double>(nullable: false),
                    TEADolares = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Banks", x => x.BankId);
                });

            migrationBuilder.CreateTable(
                name: "Costs",
                columns: table => new
                {
                    CostId = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Reason = table.Column<string>(nullable: true),
                    CostType = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Costs", x => x.CostId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Username = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    Role = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "Pymes",
                columns: table => new
                {
                    PymeId = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Ruc = table.Column<string>(nullable: true),
                    BusinessName = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pymes", x => x.PymeId);
                    table.ForeignKey(
                        name: "FK_Pymes_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Bills",
                columns: table => new
                {
                    BillId = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    StartDate = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: false),
                    Currency = table.Column<string>(nullable: true),
                    Amount = table.Column<double>(nullable: false),
                    BillType = table.Column<int>(nullable: false),
                    DrawerRuc = table.Column<string>(nullable: true),
                    DraweeRuc = table.Column<string>(nullable: true),
                    PymeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bills", x => x.BillId);
                    table.ForeignKey(
                        name: "FK_Bills_Pymes_PymeId",
                        column: x => x.PymeId,
                        principalTable: "Pymes",
                        principalColumn: "PymeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DiscountPools",
                columns: table => new
                {
                    DiscountPoolId = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ReceivedValue = table.Column<double>(nullable: false),
                    DeliveredValue = table.Column<double>(nullable: false),
                    TCEA = table.Column<double>(nullable: false),
                    DiscountDate = table.Column<DateTime>(nullable: false),
                    PymeId = table.Column<int>(nullable: false),
                    BankId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiscountPools", x => x.DiscountPoolId);
                    table.ForeignKey(
                        name: "FK_DiscountPools_Banks_BankId",
                        column: x => x.BankId,
                        principalTable: "Banks",
                        principalColumn: "BankId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DiscountPools_Pymes_PymeId",
                        column: x => x.PymeId,
                        principalTable: "Pymes",
                        principalColumn: "PymeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Discounts",
                columns: table => new
                {
                    DiscountId = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Retention = table.Column<double>(nullable: false),
                    DiscountDays = table.Column<int>(nullable: false),
                    Tep = table.Column<double>(nullable: false),
                    DiscountRate = table.Column<double>(nullable: false),
                    InitialCost = table.Column<double>(nullable: false),
                    FinalCost = table.Column<double>(nullable: false),
                    NetValue = table.Column<double>(nullable: false),
                    ReceivedValue = table.Column<double>(nullable: false),
                    DeliveredValue = table.Column<double>(nullable: false),
                    Tcea = table.Column<double>(nullable: false),
                    BillId = table.Column<int>(nullable: false),
                    DiscountPoolId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Discounts", x => x.DiscountId);
                    table.ForeignKey(
                        name: "FK_Discounts_Bills_BillId",
                        column: x => x.BillId,
                        principalTable: "Bills",
                        principalColumn: "BillId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Discounts_DiscountPools_DiscountPoolId",
                        column: x => x.DiscountPoolId,
                        principalTable: "DiscountPools",
                        principalColumn: "DiscountPoolId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DiscountCosts",
                columns: table => new
                {
                    DiscountId = table.Column<int>(nullable: false),
                    CostId = table.Column<int>(nullable: false),
                    DiscountCostId = table.Column<int>(nullable: false),
                    Amount = table.Column<double>(nullable: false),
                    ValueType = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiscountCosts", x => new { x.DiscountId, x.CostId });
                    table.UniqueConstraint("AK_DiscountCosts_DiscountCostId", x => x.DiscountCostId);
                    table.ForeignKey(
                        name: "FK_DiscountCosts_Costs_CostId",
                        column: x => x.CostId,
                        principalTable: "Costs",
                        principalColumn: "CostId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DiscountCosts_Discounts_DiscountId",
                        column: x => x.DiscountId,
                        principalTable: "Discounts",
                        principalColumn: "DiscountId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "Password", "Role", "Username" },
                values: new object[] { 1, "20123456789", "USER", "20123456789" });

            migrationBuilder.InsertData(
                table: "Pymes",
                columns: new[] { "PymeId", "Address", "BusinessName", "Ruc", "UserId" },
                values: new object[] { 1, "no address", "PYME SAC", "20123456789", 1 });

            migrationBuilder.InsertData(
                table: "Bills",
                columns: new[] { "BillId", "Amount", "BillType", "Currency", "DraweeRuc", "DrawerRuc", "EndDate", "PymeId", "StartDate" },
                values: new object[,]
                {
                    { 1, 1000.0, 1, "SOLES", "20123456789", "20123456789", new DateTime(2019, 10, 22, 9, 46, 38, 492, DateTimeKind.Local).AddTicks(74), 1, new DateTime(2019, 10, 22, 9, 46, 38, 490, DateTimeKind.Local).AddTicks(7249) },
                    { 2, 2000.0, 2, "DOLARES", "20123456789", "20123456789", new DateTime(2019, 10, 22, 9, 46, 38, 492, DateTimeKind.Local).AddTicks(1162), 1, new DateTime(2019, 10, 22, 9, 46, 38, 492, DateTimeKind.Local).AddTicks(1141) },
                    { 3, 3000.0, 3, "SOLES", "20123456789", "20123456789", new DateTime(2019, 10, 22, 9, 46, 38, 492, DateTimeKind.Local).AddTicks(1190), 1, new DateTime(2019, 10, 22, 9, 46, 38, 492, DateTimeKind.Local).AddTicks(1188) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bills_PymeId",
                table: "Bills",
                column: "PymeId");

            migrationBuilder.CreateIndex(
                name: "IX_DiscountCosts_CostId",
                table: "DiscountCosts",
                column: "CostId");

            migrationBuilder.CreateIndex(
                name: "IX_DiscountPools_BankId",
                table: "DiscountPools",
                column: "BankId");

            migrationBuilder.CreateIndex(
                name: "IX_DiscountPools_PymeId",
                table: "DiscountPools",
                column: "PymeId");

            migrationBuilder.CreateIndex(
                name: "IX_Discounts_BillId",
                table: "Discounts",
                column: "BillId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Discounts_DiscountPoolId",
                table: "Discounts",
                column: "DiscountPoolId");

            migrationBuilder.CreateIndex(
                name: "IX_Pymes_UserId",
                table: "Pymes",
                column: "UserId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DiscountCosts");

            migrationBuilder.DropTable(
                name: "Costs");

            migrationBuilder.DropTable(
                name: "Discounts");

            migrationBuilder.DropTable(
                name: "Bills");

            migrationBuilder.DropTable(
                name: "DiscountPools");

            migrationBuilder.DropTable(
                name: "Banks");

            migrationBuilder.DropTable(
                name: "Pymes");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
