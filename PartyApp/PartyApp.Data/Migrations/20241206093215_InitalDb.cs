using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PartyApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitalDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Invitations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EventName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    EventDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invitations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Partycipants",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Age = table.Column<byte>(type: "tinyint", nullable: true),
                    NumberOfPeople = table.Column<byte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Partycipants", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "InvitationParticipants",
                columns: table => new
                {
                    InvitationId = table.Column<int>(type: "int", nullable: false),
                    ParticipantId = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvitationParticipants", x => new { x.InvitationId, x.ParticipantId });
                    table.ForeignKey(
                        name: "FK_InvitationParticipants_Invitations_InvitationId",
                        column: x => x.InvitationId,
                        principalTable: "Invitations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InvitationParticipants_Partycipants_ParticipantId",
                        column: x => x.ParticipantId,
                        principalTable: "Partycipants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Invitations",
                columns: new[] { "Id", "EventDate", "EventName" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "TESTESTESRE PARTİSİ" },
                    { 2, new DateTime(2024, 12, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "DGKO PARTİSİ" }
                });

            migrationBuilder.InsertData(
                table: "Partycipants",
                columns: new[] { "Id", "Age", "Email", "FullName", "NumberOfPeople", "PhoneNumber" },
                values: new object[,]
                {
                    { 1, (byte)18, "a12ıdwdıj@gmail.com", "Asaf", (byte)1, "39283834" },
                    { 2, (byte)19, "aıdwdı22j@gmail.com", "Kemal", (byte)2, "3928383224" },
                    { 3, (byte)28, "a12ıdwdıj@gmail.com", "Ömer", (byte)1, "3928321834" },
                    { 4, (byte)18, "aıdw221dıj@gmail.com", "Selim", (byte)1, "392813834" },
                    { 5, (byte)18, "aıd12wdıj@gmail.com", "Hakkı", (byte)1, "319283834" },
                    { 6, (byte)18, "aıd12wdıj@gmail.com", "Büşra", (byte)1, "392838343" },
                    { 7, (byte)22, "ayse@example.com", "Ayşe", (byte)3, "39838345" },
                    { 8, (byte)30, "mehmet@example.com", "Mehmet", (byte)1, "39183837" },
                    { 9, (byte)25, "fatma@example.com", "Fatma", (byte)2, "39283839" },
                    { 10, (byte)24, "ali@example.com", "Ali", (byte)1, "39383831" }
                });

            migrationBuilder.InsertData(
                table: "InvitationParticipants",
                columns: new[] { "InvitationId", "ParticipantId", "Id" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 1, 3, 3 },
                    { 1, 5, 5 },
                    { 1, 7, 7 },
                    { 1, 9, 9 },
                    { 2, 2, 2 },
                    { 2, 4, 4 },
                    { 2, 6, 6 },
                    { 2, 8, 8 },
                    { 2, 10, 10 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_InvitationParticipants_ParticipantId",
                table: "InvitationParticipants",
                column: "ParticipantId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InvitationParticipants");

            migrationBuilder.DropTable(
                name: "Invitations");

            migrationBuilder.DropTable(
                name: "Partycipants");
        }
    }
}
