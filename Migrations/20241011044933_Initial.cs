﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FrannielAriasR_Ap1_P1.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Deudores",
                columns: table => new
                {
                    DeudorId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nombres = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Deudores", x => x.DeudorId);
                });

            migrationBuilder.CreateTable(
                name: "Cobro",
                columns: table => new
                {
                    CobroId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Fecha = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Monto = table.Column<decimal>(type: "TEXT", nullable: false),
                    DeudorId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cobro", x => x.CobroId);
                    table.ForeignKey(
                        name: "FK_Cobro_Deudores_DeudorId",
                        column: x => x.DeudorId,
                        principalTable: "Deudores",
                        principalColumn: "DeudorId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CobroDetalle",
                columns: table => new
                {
                    DetalleId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CobroId = table.Column<int>(type: "INTEGER", nullable: false),
                    PrestamoId = table.Column<int>(type: "INTEGER", nullable: false),
                    ValorCobrado = table.Column<decimal>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CobroDetalle", x => x.DetalleId);
                    table.ForeignKey(
                        name: "FK_CobroDetalle_Cobro_CobroId",
                        column: x => x.CobroId,
                        principalTable: "Cobro",
                        principalColumn: "CobroId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Prestamos",
                columns: table => new
                {
                    PrestamoId = table.Column<int>(type: "INTEGER", nullable: false),
                    Concepto = table.Column<string>(type: "TEXT", nullable: false),
                    Monto = table.Column<decimal>(type: "TEXT", nullable: false),
                    Balance = table.Column<decimal>(type: "TEXT", nullable: false),
                    CobroId = table.Column<int>(type: "INTEGER", nullable: false),
                    DeudorId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prestamos", x => x.PrestamoId);
                    table.ForeignKey(
                        name: "FK_Prestamos_CobroDetalle_PrestamoId",
                        column: x => x.PrestamoId,
                        principalTable: "CobroDetalle",
                        principalColumn: "DetalleId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Prestamos_Cobro_CobroId",
                        column: x => x.CobroId,
                        principalTable: "Cobro",
                        principalColumn: "CobroId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Prestamos_Deudores_DeudorId",
                        column: x => x.DeudorId,
                        principalTable: "Deudores",
                        principalColumn: "DeudorId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Deudores",
                columns: new[] { "DeudorId", "Nombres" },
                values: new object[,]
                {
                    { 1, "Alma" },
                    { 2, "Jane" },
                    { 3, "DjMarte" },
                    { 4, "Franniel" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cobro_DeudorId",
                table: "Cobro",
                column: "DeudorId");

            migrationBuilder.CreateIndex(
                name: "IX_CobroDetalle_CobroId",
                table: "CobroDetalle",
                column: "CobroId");

            migrationBuilder.CreateIndex(
                name: "IX_Prestamos_CobroId",
                table: "Prestamos",
                column: "CobroId");

            migrationBuilder.CreateIndex(
                name: "IX_Prestamos_DeudorId",
                table: "Prestamos",
                column: "DeudorId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Prestamos");

            migrationBuilder.DropTable(
                name: "CobroDetalle");

            migrationBuilder.DropTable(
                name: "Cobro");

            migrationBuilder.DropTable(
                name: "Deudores");
        }
    }
}
