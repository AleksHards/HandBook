using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Handbook.Repository.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CityName = table.Column<string>(type: "nvarchar(30)", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "date", nullable: false, defaultValueSql: "GetDate()"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "(0)")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Persons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(30)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(30)", nullable: false),
                    IdNumber = table.Column<string>(type: "nvarchar(15)", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "date", nullable: false),
                    CityId = table.Column<int>(type: "int", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "date", nullable: false, defaultValueSql: "GetDate()"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "(0)")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Persons_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PersonLinks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonFromId = table.Column<int>(type: "int", nullable: false),
                    PersonToId = table.Column<int>(type: "int", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonLinks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PersonLinks_Persons_PersonFromId",
                        column: x => x.PersonFromId,
                        principalTable: "Persons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PersonLinks_Persons_PersonToId",
                        column: x => x.PersonToId,
                        principalTable: "Persons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Phones",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ContactInformation = table.Column<string>(type: "nvarchar(30)", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    PersonId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Phones", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Phones_Persons_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Persons",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cities_CityName",
                table: "Cities",
                column: "CityName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PersonLinks_PersonFromId",
                table: "PersonLinks",
                column: "PersonFromId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonLinks_PersonToId",
                table: "PersonLinks",
                column: "PersonToId");

            migrationBuilder.CreateIndex(
                name: "IX_Persons_CityId",
                table: "Persons",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Phones_PersonId",
                table: "Phones",
                column: "PersonId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PersonLinks");

            migrationBuilder.DropTable(
                name: "Phones");

            migrationBuilder.DropTable(
                name: "Persons");

            migrationBuilder.DropTable(
                name: "Cities");
        }
    }
}
