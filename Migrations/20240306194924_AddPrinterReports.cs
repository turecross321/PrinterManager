using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PrinterManagerServer.Migrations
{
    /// <inheritdoc />
    public partial class AddPrinterReports : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "Active",
                table: "Printers",
                newName: "Disabled");

            migrationBuilder.CreateTable(
                name: "PrinterReports",
                columns: table => new
                {
                    Guid = table.Column<Guid>(type: "TEXT", nullable: false),
                    PrinterGuid = table.Column<Guid>(type: "TEXT", nullable: false),
                    Severity = table.Column<int>(type: "INTEGER", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    CreationDate = table.Column<DateTimeOffset>(type: "TEXT", nullable: false),
                    Resolved = table.Column<bool>(type: "INTEGER", nullable: false),
                    ResolveDate = table.Column<DateTimeOffset>(type: "TEXT", nullable: true),
                    ResolveComment = table.Column<string>(type: "TEXT", nullable: true),
                    ResolverGuid = table.Column<Guid>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrinterReports", x => x.Guid);
                    table.ForeignKey(
                        name: "FK_PrinterReports_Printers_PrinterGuid",
                        column: x => x.PrinterGuid,
                        principalTable: "Printers",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PrinterReports_Users_ResolverGuid",
                        column: x => x.ResolverGuid,
                        principalTable: "Users",
                        principalColumn: "Guid");
                });

            migrationBuilder.CreateIndex(
                name: "IX_PrinterReports_PrinterGuid",
                table: "PrinterReports",
                column: "PrinterGuid");

            migrationBuilder.CreateIndex(
                name: "IX_PrinterReports_ResolverGuid",
                table: "PrinterReports",
                column: "ResolverGuid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PrinterReports");

            migrationBuilder.RenameColumn(
                name: "Disabled",
                table: "Printers",
                newName: "Active");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Users",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }
    }
}
