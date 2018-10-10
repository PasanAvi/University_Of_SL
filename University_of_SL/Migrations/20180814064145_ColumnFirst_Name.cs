using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace University_of_SL.Migrations
{
    public partial class ColumnFirst_Name : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Firstname",
                table: "Student",
                newName: "First_Name");

            migrationBuilder.AlterColumn<string>(
                name: "Lastname",
                table: "Student",
                maxLength: 10,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 20,
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "First_Name",
                table: "Student",
                newName: "Firstname");

            migrationBuilder.AlterColumn<string>(
                name: "Lastname",
                table: "Student",
                maxLength: 20,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 10,
                oldNullable: true);
        }
    }
}
