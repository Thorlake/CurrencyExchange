namespace CurrencyExchange.DAL.EntityFramework.SqlServer.Migrations
{
    using System;
    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Currencies",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Code = table.Column<string>(nullable: false),
                    Rate = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Currencies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserWallets",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    UserId = table.Column<Guid>(nullable: false),
                    CurrencyId = table.Column<Guid>(nullable: false),
                    Balance = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserWallets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserWallets_Currencies_CurrencyId",
                        column: x => x.CurrencyId,
                        principalTable: "Currencies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserWallets_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Currencies",
                columns: new[] { "Id", "Code", "Rate" },
#pragma warning disable SA1118 // Parameter should not span multiple lines
                values: new object[,]
                {
                    { new Guid("c484f6bc-468e-4a0b-817c-ff477bd23163"), "RUB", 0m },
                    { new Guid("ef74e200-991d-4650-ab29-89372936184b"), "KRW", 0m }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("e5656688-c359-4ed9-86a7-fe78d967c616"), "User A" },
                    { new Guid("8d21a257-6623-45ee-aa20-3e02865bfb20"), "User B" }
                });
#pragma warning restore SA1118 // Parameter should not span multiple lines

            migrationBuilder.InsertData(
                table: "UserWallets",
                columns: new[] { "Id", "Balance", "CurrencyId", "UserId" },
                values: new object[] { new Guid("9f89b9da-acc3-4a88-9960-214b37a574fe"), 0m, new Guid("c484f6bc-468e-4a0b-817c-ff477bd23163"), new Guid("e5656688-c359-4ed9-86a7-fe78d967c616") });

            migrationBuilder.InsertData(
                table: "UserWallets",
                columns: new[] { "Id", "Balance", "CurrencyId", "UserId" },
                values: new object[] { new Guid("ab0e3d97-dcda-494a-b79e-802f6363d552"), 0m, new Guid("ef74e200-991d-4650-ab29-89372936184b"), new Guid("8d21a257-6623-45ee-aa20-3e02865bfb20") });

            migrationBuilder.CreateIndex(
                name: "IX_UserWallets_CurrencyId",
                table: "UserWallets",
                column: "CurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_UserWallets_UserId",
                table: "UserWallets",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserWallets");

            migrationBuilder.DropTable(
                name: "Currencies");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
