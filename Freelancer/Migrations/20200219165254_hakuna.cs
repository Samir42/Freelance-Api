using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Freelancer.Migrations
{
    public partial class hakuna : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SkillsUsers");

            migrationBuilder.AlterColumn<DateTime>(
                name: "OpenedAt",
                table: "Jobs",
                nullable: false,
                defaultValue: new DateTime(2020, 2, 19, 20, 52, 54, 481, DateTimeKind.Local).AddTicks(3045),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 2, 18, 3, 58, 11, 332, DateTimeKind.Local).AddTicks(7784));

            migrationBuilder.AlterColumn<DateTime>(
                name: "RegisteredAt",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: new DateTime(2020, 2, 19, 20, 52, 54, 486, DateTimeKind.Local).AddTicks(9507),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 2, 18, 3, 58, 11, 345, DateTimeKind.Local).AddTicks(1841));

            migrationBuilder.CreateTable(
                name: "SkillUsers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FreelancerId = table.Column<int>(nullable: false),
                    SkillId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SkillUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SkillUsers_Freelancers_FreelancerId",
                        column: x => x.FreelancerId,
                        principalTable: "Freelancers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SkillUsers_Skills_SkillId",
                        column: x => x.SkillId,
                        principalTable: "Skills",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SkillUsers_FreelancerId",
                table: "SkillUsers",
                column: "FreelancerId");

            migrationBuilder.CreateIndex(
                name: "IX_SkillUsers_SkillId",
                table: "SkillUsers",
                column: "SkillId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SkillUsers");

            migrationBuilder.AlterColumn<DateTime>(
                name: "OpenedAt",
                table: "Jobs",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 2, 18, 3, 58, 11, 332, DateTimeKind.Local).AddTicks(7784),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 2, 19, 20, 52, 54, 481, DateTimeKind.Local).AddTicks(3045));

            migrationBuilder.AlterColumn<DateTime>(
                name: "RegisteredAt",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 2, 18, 3, 58, 11, 345, DateTimeKind.Local).AddTicks(1841),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 2, 19, 20, 52, 54, 486, DateTimeKind.Local).AddTicks(9507));

            migrationBuilder.CreateTable(
                name: "SkillsUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FreelancerId = table.Column<int>(type: "int", nullable: false),
                    SkillId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SkillsUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SkillsUsers_Freelancers_FreelancerId",
                        column: x => x.FreelancerId,
                        principalTable: "Freelancers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SkillsUsers_Skills_SkillId",
                        column: x => x.SkillId,
                        principalTable: "Skills",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SkillsUsers_FreelancerId",
                table: "SkillsUsers",
                column: "FreelancerId");

            migrationBuilder.CreateIndex(
                name: "IX_SkillsUsers_SkillId",
                table: "SkillsUsers",
                column: "SkillId");
        }
    }
}
