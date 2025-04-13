﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RentalAPP.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class third : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DaysRented",
                table: "Rentals");

            migrationBuilder.AddColumn<DateTime>(
                name: "EndDate",
                table: "Rentals",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EndDate",
                table: "Rentals");

            migrationBuilder.AddColumn<int>(
                name: "DaysRented",
                table: "Rentals",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }
    }
}
