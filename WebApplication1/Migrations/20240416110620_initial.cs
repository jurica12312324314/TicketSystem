using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "category",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_category", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "user",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    email = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    telephone_number = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    roles = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "ticket",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    user_id = table.Column<int>(type: "int", nullable: false),
                    category_id = table.Column<int>(type: "int", nullable: false),
                    title = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime2(6)", precision: 6, nullable: false, defaultValueSql: "(sysutcdatetime())"),
                    state = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    priority = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ticket", x => x.id);
                    table.ForeignKey(
                        name: "FK_ticket_category",
                        column: x => x.category_id,
                        principalTable: "category",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_ticket_user",
                        column: x => x.user_id,
                        principalTable: "user",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "escalation_process",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ticket_id = table.Column<int>(type: "int", nullable: false),
                    trigger_reason = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_escalation_process", x => x.id);
                    table.ForeignKey(
                        name: "FK_escalation_ticket",
                        column: x => x.ticket_id,
                        principalTable: "ticket",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "user_ticket_update",
                columns: table => new
                {
                    user_id = table.Column<int>(type: "int", nullable: false),
                    ticket_id = table.Column<int>(type: "int", nullable: false),
                    updated_at = table.Column<DateTime>(type: "datetime2(6)", precision: 6, nullable: false, defaultValueSql: "(sysutcdatetime())"),
                    changed_column = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    reason = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK_update_ticket",
                        column: x => x.ticket_id,
                        principalTable: "ticket",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_update_user",
                        column: x => x.user_id,
                        principalTable: "user",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_escalation_process_ticket_id",
                table: "escalation_process",
                column: "ticket_id");

            migrationBuilder.CreateIndex(
                name: "IX_ticket_category_id",
                table: "ticket",
                column: "category_id");

            migrationBuilder.CreateIndex(
                name: "IX_ticket_user_id",
                table: "ticket",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_user_ticket_update_ticket_id",
                table: "user_ticket_update",
                column: "ticket_id");

            migrationBuilder.CreateIndex(
                name: "IX_user_ticket_update_user_id",
                table: "user_ticket_update",
                column: "user_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "escalation_process");

            migrationBuilder.DropTable(
                name: "user_ticket_update");

            migrationBuilder.DropTable(
                name: "ticket");

            migrationBuilder.DropTable(
                name: "category");

            migrationBuilder.DropTable(
                name: "user");
        }
    }
}
