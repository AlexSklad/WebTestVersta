using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebTestVersta.Migrations
{
    /// <inheritdoc />
    public partial class Create : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Recipients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RecCity = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    RecAddress = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__tmp_ms_x__3214EC073A34F04B", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Senders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SenderCity = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    SenderAddress = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__tmp_ms_x__3214EC0710339CA3", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SenderID = table.Column<int>(type: "int", nullable: false),
                    RecID = table.Column<int>(type: "int", nullable: false),
                    CargoWeight = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PickupDate = table.Column<DateTime>(type: "date", nullable: false),
                    OrderNum = table.Column<string>(type: "nchar(20)", fixedLength: true, maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__tmp_ms_x__3214EC07B0749FA1", x => x.Id);
                    table.ForeignKey(
                        name: "FK__Orders__RecID__3A81B327",
                        column: x => x.RecID,
                        principalTable: "Recipients",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK__Orders__SenderID__5AEE82B9",
                        column: x => x.SenderID,
                        principalTable: "Senders",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Orders_RecID",
                table: "Orders",
                column: "RecID");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_SenderID",
                table: "Orders",
                column: "SenderID");

            migrationBuilder.CreateIndex(
                name: "UQ__Recipien__2CB74F3B5F3A8B1E",
                table: "Recipients",
                column: "RecAddress",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UQ__Senders__DF28C57E3E6D9496",
                table: "Senders",
                column: "SenderAddress",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Recipients");

            migrationBuilder.DropTable(
                name: "Senders");
        }
    }
}
