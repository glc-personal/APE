using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APE.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsEmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsPhoneConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    DateCreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateUpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateLastLoginOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Protocols",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AuthorId = table.Column<int>(type: "int", nullable: false),
                    DateCreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Version = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MongoDbStepsId = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Protocols", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Protocols_Users_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "DateCreatedOn", "DateLastLoginOn", "DateUpdatedOn", "Email", "FirstName", "IsEmailConfirmed", "IsPhoneConfirmed", "LastName", "Phone", "Username" },
                values: new object[] { 1, new DateTime(2024, 7, 18, 20, 18, 31, 984, DateTimeKind.Local).AddTicks(5894), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "gabriel_lopez-candales@bio-rad.com", "Gabe", false, false, "Lopez-Candales", "(523)455-9789", "glc-biorad" });

            migrationBuilder.InsertData(
                table: "Protocols",
                columns: new[] { "Id", "AuthorId", "DateCreatedOn", "Description", "MongoDbStepsId", "Name", "Version" },
                values: new object[] { 1, 1, new DateTime(2024, 7, 18, 20, 18, 31, 984, DateTimeKind.Local).AddTicks(6845), "Protocol for testing system integration.", "n3jnj3n899k", "Integration Protocol", "1.0.0" });

            migrationBuilder.CreateIndex(
                name: "IX_Protocols_AuthorId",
                table: "Protocols",
                column: "AuthorId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Protocols");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
