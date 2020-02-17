using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Freelancer.Migrations
{
    public partial class init2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "OpenedAt",
                table: "Jobs",
                nullable: false,
                defaultValue: new DateTime(2020, 2, 18, 3, 58, 11, 332, DateTimeKind.Local).AddTicks(7784),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 2, 16, 1, 46, 22, 225, DateTimeKind.Local).AddTicks(3800));

            migrationBuilder.AlterColumn<DateTime>(
                name: "RegisteredAt",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: new DateTime(2020, 2, 18, 3, 58, 11, 345, DateTimeKind.Local).AddTicks(1841),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 2, 16, 1, 46, 22, 230, DateTimeKind.Local).AddTicks(7606));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "OpenedAt",
                table: "Jobs",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 2, 16, 1, 46, 22, 225, DateTimeKind.Local).AddTicks(3800),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 2, 18, 3, 58, 11, 332, DateTimeKind.Local).AddTicks(7784));

            migrationBuilder.AlterColumn<DateTime>(
                name: "RegisteredAt",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 2, 16, 1, 46, 22, 230, DateTimeKind.Local).AddTicks(7606),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 2, 18, 3, 58, 11, 345, DateTimeKind.Local).AddTicks(1841));
        }
    }
}
