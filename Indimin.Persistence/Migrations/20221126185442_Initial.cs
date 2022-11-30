using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Indimin.Persistence.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Citizens",
                columns: table => new
                {
                    citizen_id = table.Column<Guid>(type: "UniqueIdentifier", nullable: false),
                    citizen_name = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    citizen_lastname = table.Column<string>(type: "nvarchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Citizens", x => x.citizen_id);
                });

            migrationBuilder.CreateTable(
                name: "Tasks",
                columns: table => new
                {
                    task_id = table.Column<Guid>(type: "UniqueIdentifier", nullable: false),
                    name = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    description = table.Column<string>(type: "nvarchar(255)", nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime", nullable: false),
                    is_completed = table.Column<bool>(type: "bit", nullable: false),
                    citizen_id = table.Column<Guid>(type: "UniqueIdentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tasks", x => x.task_id);
                    table.ForeignKey(
                        name: "FK_Tasks_Citizens_citizen_id",
                        column: x => x.citizen_id,
                        principalTable: "Citizens",
                        principalColumn: "citizen_id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_citizen_id",
                table: "Tasks",
                column: "citizen_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tasks");

            migrationBuilder.DropTable(
                name: "Citizens");
        }
    }
}
