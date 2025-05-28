﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LojaVeiculos.Migrations
{
    /// <inheritdoc />
    public partial class AddVendidos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Vendido",
                table: "Veiculos",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Vendido",
                table: "Veiculos");
        }
    }
}
