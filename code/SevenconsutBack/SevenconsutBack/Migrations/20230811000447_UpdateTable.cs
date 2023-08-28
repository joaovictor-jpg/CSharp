using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SevenconsutBack.Migrations
{
    public partial class UpdateTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "Clients");

            migrationBuilder.AddColumn<DateTime>(
                name: "DataAtualizacao",
                table: "Clients",
                type: "datetime(6)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DataAtualizacao",
                table: "Clients");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Clients",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");
        }
    }
}
