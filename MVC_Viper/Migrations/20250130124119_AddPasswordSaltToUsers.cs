using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVC_Viper.Migrations
{
    /// <inheritdoc />
    public partial class AddPasswordSaltToUsers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "calls",
                columns: table => new
                {
                    Call_ID = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__calls__19E6F4EB2F82E63F", x => x.Call_ID);
                });

            migrationBuilder.CreateTable(
                name: "programs",
                columns: table => new
                {
                    Program_Name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Benefits = table.Column<string>(type: "text", nullable: true),
                    Charge = table.Column<decimal>(type: "decimal(8,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__programs__1DF87844D749C4E7", x => x.Program_Name);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    User_Id = table.Column<int>(type: "int", nullable: false),
                    First_Name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Last_Name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Username = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Property = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    PasswordHash = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    PasswordSalt = table.Column<byte[]>(type: "varbinary(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__users__206D917065CDFAD4", x => x.User_Id);
                });

            migrationBuilder.CreateTable(
                name: "phones",
                columns: table => new
                {
                    PhoneNumber = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Program_Name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__phones__85FB4E391C49890F", x => x.PhoneNumber);
                    table.ForeignKey(
                        name: "FK__phones__Program___440B1D61",
                        column: x => x.Program_Name,
                        principalTable: "programs",
                        principalColumn: "Program_Name");
                });

            migrationBuilder.CreateTable(
                name: "admin",
                columns: table => new
                {
                    Admin_Id = table.Column<int>(type: "int", nullable: false),
                    User_Id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__admin__4A3006F74B196BEF", x => x.Admin_Id);
                    table.ForeignKey(
                        name: "FK__admin__User_Id__3F466844",
                        column: x => x.User_Id,
                        principalTable: "users",
                        principalColumn: "User_Id");
                });

            migrationBuilder.CreateTable(
                name: "clients",
                columns: table => new
                {
                    Client_Id = table.Column<int>(type: "int", nullable: false),
                    AFM = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    PhoneNumber = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    User_Id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__clients__75A5D8F8F69852E9", x => x.Client_Id);
                    table.ForeignKey(
                        name: "FK__clients__User_Id__3C69FB99",
                        column: x => x.User_Id,
                        principalTable: "users",
                        principalColumn: "User_Id");
                });

            migrationBuilder.CreateTable(
                name: "sellers",
                columns: table => new
                {
                    Seller_Id = table.Column<int>(type: "int", nullable: false),
                    User_Id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__sellers__009FC2A9AA606066", x => x.Seller_Id);
                    table.ForeignKey(
                        name: "FK__sellers__User_Id__398D8EEE",
                        column: x => x.User_Id,
                        principalTable: "users",
                        principalColumn: "User_Id");
                });

            migrationBuilder.CreateTable(
                name: "bills",
                columns: table => new
                {
                    Bill_ID = table.Column<int>(type: "int", nullable: false),
                    PhoneNumber = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Costs = table.Column<decimal>(type: "decimal(7,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__bills__CF6E7D4378E44C25", x => x.Bill_ID);
                    table.ForeignKey(
                        name: "FK__bills__PhoneNumb__46E78A0C",
                        column: x => x.PhoneNumber,
                        principalTable: "phones",
                        principalColumn: "PhoneNumber");
                });

            migrationBuilder.CreateTable(
                name: "billcalls",
                columns: table => new
                {
                    Bill_ID = table.Column<int>(type: "int", nullable: false),
                    Call_ID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__billcall__6EF0120D4829D6D4", x => new { x.Bill_ID, x.Call_ID });
                    table.ForeignKey(
                        name: "FK__billcalls__Bill___4BAC3F29",
                        column: x => x.Bill_ID,
                        principalTable: "bills",
                        principalColumn: "Bill_ID");
                    table.ForeignKey(
                        name: "FK__billcalls__Call___4CA06362",
                        column: x => x.Call_ID,
                        principalTable: "calls",
                        principalColumn: "Call_ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_admin_User_Id",
                table: "admin",
                column: "User_Id");

            migrationBuilder.CreateIndex(
                name: "IX_billcalls_Call_ID",
                table: "billcalls",
                column: "Call_ID");

            migrationBuilder.CreateIndex(
                name: "IX_bills_PhoneNumber",
                table: "bills",
                column: "PhoneNumber");

            migrationBuilder.CreateIndex(
                name: "IX_clients_User_Id",
                table: "clients",
                column: "User_Id");

            migrationBuilder.CreateIndex(
                name: "IX_phones_Program_Name",
                table: "phones",
                column: "Program_Name");

            migrationBuilder.CreateIndex(
                name: "IX_sellers_User_Id",
                table: "sellers",
                column: "User_Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "admin");

            migrationBuilder.DropTable(
                name: "billcalls");

            migrationBuilder.DropTable(
                name: "clients");

            migrationBuilder.DropTable(
                name: "sellers");

            migrationBuilder.DropTable(
                name: "bills");

            migrationBuilder.DropTable(
                name: "calls");

            migrationBuilder.DropTable(
                name: "users");

            migrationBuilder.DropTable(
                name: "phones");

            migrationBuilder.DropTable(
                name: "programs");
        }
    }
}
