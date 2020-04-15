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
                    Rate = table.Column<decimal>(type: "decimal(19, 4)", nullable: false)
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
                    { new Guid("3d4d4786-4cc0-4f2b-ac1a-4b0158d65922"), "RUB", 0m },
                    { new Guid("521cf211-eb99-4889-b3b6-ac94c34b5e13"), "KRW", 0m }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("eedced01-3e38-4762-b9fd-91dea1daef6a"), "User A" },
                    { new Guid("d1ec617b-6266-44ff-9fce-864d057dc108"), "User B" }
                });
#pragma warning restore SA1118 // Parameter should not span multiple lines

            migrationBuilder.InsertData(
                table: "UserWallets",
                columns: new[] { "Id", "Balance", "CurrencyId", "UserId" },
                values: new object[] { new Guid("782de4d7-25e1-49ad-96b2-f9c9e9c10daa"), 0m, new Guid("3d4d4786-4cc0-4f2b-ac1a-4b0158d65922"), new Guid("eedced01-3e38-4762-b9fd-91dea1daef6a") });

            migrationBuilder.InsertData(
                table: "UserWallets",
                columns: new[] { "Id", "Balance", "CurrencyId", "UserId" },
                values: new object[] { new Guid("51649174-7433-45bd-bbe3-81d25705a5c0"), 0m, new Guid("521cf211-eb99-4889-b3b6-ac94c34b5e13"), new Guid("d1ec617b-6266-44ff-9fce-864d057dc108") });

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
