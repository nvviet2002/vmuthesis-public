using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BE_thesis.Migrations
{
    /// <inheritdoc />
    public partial class AddInvoiceMethodAndBill : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "bill",
                table: "Invoice",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "method",
                table: "Invoice",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Brand",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2024, 5, 19, 4, 26, 23, 624, DateTimeKind.Utc).AddTicks(300), new DateTime(2024, 5, 19, 4, 26, 23, 624, DateTimeKind.Utc).AddTicks(301) });

            migrationBuilder.UpdateData(
                table: "Brand",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2024, 5, 19, 4, 26, 23, 624, DateTimeKind.Utc).AddTicks(303), new DateTime(2024, 5, 19, 4, 26, 23, 624, DateTimeKind.Utc).AddTicks(303) });

            migrationBuilder.UpdateData(
                table: "Brand",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2024, 5, 19, 4, 26, 23, 624, DateTimeKind.Utc).AddTicks(304), new DateTime(2024, 5, 19, 4, 26, 23, 624, DateTimeKind.Utc).AddTicks(305) });

            migrationBuilder.UpdateData(
                table: "Brand",
                keyColumn: "ID",
                keyValue: 4,
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2024, 5, 19, 4, 26, 23, 624, DateTimeKind.Utc).AddTicks(306), new DateTime(2024, 5, 19, 4, 26, 23, 624, DateTimeKind.Utc).AddTicks(306) });

            migrationBuilder.UpdateData(
                table: "Brand",
                keyColumn: "ID",
                keyValue: 5,
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2024, 5, 19, 4, 26, 23, 624, DateTimeKind.Utc).AddTicks(307), new DateTime(2024, 5, 19, 4, 26, 23, 624, DateTimeKind.Utc).AddTicks(308) });

            migrationBuilder.UpdateData(
                table: "Brand",
                keyColumn: "ID",
                keyValue: 6,
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2024, 5, 19, 4, 26, 23, 624, DateTimeKind.Utc).AddTicks(309), new DateTime(2024, 5, 19, 4, 26, 23, 624, DateTimeKind.Utc).AddTicks(309) });

            migrationBuilder.UpdateData(
                table: "Brand",
                keyColumn: "ID",
                keyValue: 7,
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2024, 5, 19, 4, 26, 23, 624, DateTimeKind.Utc).AddTicks(310), new DateTime(2024, 5, 19, 4, 26, 23, 624, DateTimeKind.Utc).AddTicks(310) });

            migrationBuilder.UpdateData(
                table: "Brand",
                keyColumn: "ID",
                keyValue: 8,
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2024, 5, 19, 4, 26, 23, 624, DateTimeKind.Utc).AddTicks(311), new DateTime(2024, 5, 19, 4, 26, 23, 624, DateTimeKind.Utc).AddTicks(312) });

            migrationBuilder.UpdateData(
                table: "Brand",
                keyColumn: "ID",
                keyValue: 9,
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2024, 5, 19, 4, 26, 23, 624, DateTimeKind.Utc).AddTicks(313), new DateTime(2024, 5, 19, 4, 26, 23, 624, DateTimeKind.Utc).AddTicks(313) });

            migrationBuilder.UpdateData(
                table: "Brand",
                keyColumn: "ID",
                keyValue: 10,
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2024, 5, 19, 4, 26, 23, 624, DateTimeKind.Utc).AddTicks(314), new DateTime(2024, 5, 19, 4, 26, 23, 624, DateTimeKind.Utc).AddTicks(315) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2024, 5, 19, 4, 26, 23, 624, DateTimeKind.Utc).AddTicks(483), new DateTime(2024, 5, 19, 4, 26, 23, 624, DateTimeKind.Utc).AddTicks(483) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2024, 5, 19, 4, 26, 23, 624, DateTimeKind.Utc).AddTicks(484), new DateTime(2024, 5, 19, 4, 26, 23, 624, DateTimeKind.Utc).AddTicks(485) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2024, 5, 19, 4, 26, 23, 624, DateTimeKind.Utc).AddTicks(486), new DateTime(2024, 5, 19, 4, 26, 23, 624, DateTimeKind.Utc).AddTicks(486) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "ID",
                keyValue: 4,
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2024, 5, 19, 4, 26, 23, 624, DateTimeKind.Utc).AddTicks(487), new DateTime(2024, 5, 19, 4, 26, 23, 624, DateTimeKind.Utc).AddTicks(487) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "ID",
                keyValue: 5,
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2024, 5, 19, 4, 26, 23, 624, DateTimeKind.Utc).AddTicks(488), new DateTime(2024, 5, 19, 4, 26, 23, 624, DateTimeKind.Utc).AddTicks(489) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "ID",
                keyValue: 6,
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2024, 5, 19, 4, 26, 23, 624, DateTimeKind.Utc).AddTicks(490), new DateTime(2024, 5, 19, 4, 26, 23, 624, DateTimeKind.Utc).AddTicks(490) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "ID",
                keyValue: 7,
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2024, 5, 19, 4, 26, 23, 624, DateTimeKind.Utc).AddTicks(491), new DateTime(2024, 5, 19, 4, 26, 23, 624, DateTimeKind.Utc).AddTicks(492) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "ID",
                keyValue: 8,
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2024, 5, 19, 4, 26, 23, 624, DateTimeKind.Utc).AddTicks(493), new DateTime(2024, 5, 19, 4, 26, 23, 624, DateTimeKind.Utc).AddTicks(493) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "ID",
                keyValue: 9,
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2024, 5, 19, 4, 26, 23, 624, DateTimeKind.Utc).AddTicks(494), new DateTime(2024, 5, 19, 4, 26, 23, 624, DateTimeKind.Utc).AddTicks(494) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "ID",
                keyValue: 10,
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2024, 5, 19, 4, 26, 23, 624, DateTimeKind.Utc).AddTicks(495), new DateTime(2024, 5, 19, 4, 26, 23, 624, DateTimeKind.Utc).AddTicks(496) });

            migrationBuilder.UpdateData(
                table: "Unit",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2024, 5, 19, 4, 26, 23, 624, DateTimeKind.Utc).AddTicks(541), new DateTime(2024, 5, 19, 4, 26, 23, 624, DateTimeKind.Utc).AddTicks(542) });

            migrationBuilder.UpdateData(
                table: "Unit",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2024, 5, 19, 4, 26, 23, 624, DateTimeKind.Utc).AddTicks(543), new DateTime(2024, 5, 19, 4, 26, 23, 624, DateTimeKind.Utc).AddTicks(544) });

            migrationBuilder.UpdateData(
                table: "Unit",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2024, 5, 19, 4, 26, 23, 624, DateTimeKind.Utc).AddTicks(544), new DateTime(2024, 5, 19, 4, 26, 23, 624, DateTimeKind.Utc).AddTicks(545) });

            migrationBuilder.UpdateData(
                table: "Unit",
                keyColumn: "ID",
                keyValue: 4,
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2024, 5, 19, 4, 26, 23, 624, DateTimeKind.Utc).AddTicks(546), new DateTime(2024, 5, 19, 4, 26, 23, 624, DateTimeKind.Utc).AddTicks(546) });

            migrationBuilder.UpdateData(
                table: "Unit",
                keyColumn: "ID",
                keyValue: 5,
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2024, 5, 19, 4, 26, 23, 624, DateTimeKind.Utc).AddTicks(547), new DateTime(2024, 5, 19, 4, 26, 23, 624, DateTimeKind.Utc).AddTicks(548) });

            migrationBuilder.UpdateData(
                table: "Unit",
                keyColumn: "ID",
                keyValue: 6,
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2024, 5, 19, 4, 26, 23, 624, DateTimeKind.Utc).AddTicks(549), new DateTime(2024, 5, 19, 4, 26, 23, 624, DateTimeKind.Utc).AddTicks(549) });

            migrationBuilder.UpdateData(
                table: "Unit",
                keyColumn: "ID",
                keyValue: 7,
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2024, 5, 19, 4, 26, 23, 624, DateTimeKind.Utc).AddTicks(550), new DateTime(2024, 5, 19, 4, 26, 23, 624, DateTimeKind.Utc).AddTicks(550) });

            migrationBuilder.UpdateData(
                table: "Unit",
                keyColumn: "ID",
                keyValue: 8,
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2024, 5, 19, 4, 26, 23, 624, DateTimeKind.Utc).AddTicks(551), new DateTime(2024, 5, 19, 4, 26, 23, 624, DateTimeKind.Utc).AddTicks(552) });

            migrationBuilder.UpdateData(
                table: "Unit",
                keyColumn: "ID",
                keyValue: 9,
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2024, 5, 19, 4, 26, 23, 624, DateTimeKind.Utc).AddTicks(553), new DateTime(2024, 5, 19, 4, 26, 23, 624, DateTimeKind.Utc).AddTicks(553) });

            migrationBuilder.UpdateData(
                table: "Unit",
                keyColumn: "ID",
                keyValue: 10,
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2024, 5, 19, 4, 26, 23, 624, DateTimeKind.Utc).AddTicks(554), new DateTime(2024, 5, 19, 4, 26, 23, 624, DateTimeKind.Utc).AddTicks(554) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "bill",
                table: "Invoice");

            migrationBuilder.DropColumn(
                name: "method",
                table: "Invoice");

            migrationBuilder.UpdateData(
                table: "Brand",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2024, 5, 10, 11, 28, 4, 61, DateTimeKind.Utc).AddTicks(2363), new DateTime(2024, 5, 10, 11, 28, 4, 61, DateTimeKind.Utc).AddTicks(2365) });

            migrationBuilder.UpdateData(
                table: "Brand",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2024, 5, 10, 11, 28, 4, 61, DateTimeKind.Utc).AddTicks(2369), new DateTime(2024, 5, 10, 11, 28, 4, 61, DateTimeKind.Utc).AddTicks(2369) });

            migrationBuilder.UpdateData(
                table: "Brand",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2024, 5, 10, 11, 28, 4, 61, DateTimeKind.Utc).AddTicks(2372), new DateTime(2024, 5, 10, 11, 28, 4, 61, DateTimeKind.Utc).AddTicks(2372) });

            migrationBuilder.UpdateData(
                table: "Brand",
                keyColumn: "ID",
                keyValue: 4,
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2024, 5, 10, 11, 28, 4, 61, DateTimeKind.Utc).AddTicks(2374), new DateTime(2024, 5, 10, 11, 28, 4, 61, DateTimeKind.Utc).AddTicks(2375) });

            migrationBuilder.UpdateData(
                table: "Brand",
                keyColumn: "ID",
                keyValue: 5,
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2024, 5, 10, 11, 28, 4, 61, DateTimeKind.Utc).AddTicks(2377), new DateTime(2024, 5, 10, 11, 28, 4, 61, DateTimeKind.Utc).AddTicks(2377) });

            migrationBuilder.UpdateData(
                table: "Brand",
                keyColumn: "ID",
                keyValue: 6,
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2024, 5, 10, 11, 28, 4, 61, DateTimeKind.Utc).AddTicks(2379), new DateTime(2024, 5, 10, 11, 28, 4, 61, DateTimeKind.Utc).AddTicks(2379) });

            migrationBuilder.UpdateData(
                table: "Brand",
                keyColumn: "ID",
                keyValue: 7,
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2024, 5, 10, 11, 28, 4, 61, DateTimeKind.Utc).AddTicks(2381), new DateTime(2024, 5, 10, 11, 28, 4, 61, DateTimeKind.Utc).AddTicks(2382) });

            migrationBuilder.UpdateData(
                table: "Brand",
                keyColumn: "ID",
                keyValue: 8,
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2024, 5, 10, 11, 28, 4, 61, DateTimeKind.Utc).AddTicks(2384), new DateTime(2024, 5, 10, 11, 28, 4, 61, DateTimeKind.Utc).AddTicks(2385) });

            migrationBuilder.UpdateData(
                table: "Brand",
                keyColumn: "ID",
                keyValue: 9,
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2024, 5, 10, 11, 28, 4, 61, DateTimeKind.Utc).AddTicks(2387), new DateTime(2024, 5, 10, 11, 28, 4, 61, DateTimeKind.Utc).AddTicks(2387) });

            migrationBuilder.UpdateData(
                table: "Brand",
                keyColumn: "ID",
                keyValue: 10,
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2024, 5, 10, 11, 28, 4, 61, DateTimeKind.Utc).AddTicks(2389), new DateTime(2024, 5, 10, 11, 28, 4, 61, DateTimeKind.Utc).AddTicks(2390) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2024, 5, 10, 11, 28, 4, 61, DateTimeKind.Utc).AddTicks(2698), new DateTime(2024, 5, 10, 11, 28, 4, 61, DateTimeKind.Utc).AddTicks(2699) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2024, 5, 10, 11, 28, 4, 61, DateTimeKind.Utc).AddTicks(2701), new DateTime(2024, 5, 10, 11, 28, 4, 61, DateTimeKind.Utc).AddTicks(2702) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2024, 5, 10, 11, 28, 4, 61, DateTimeKind.Utc).AddTicks(2704), new DateTime(2024, 5, 10, 11, 28, 4, 61, DateTimeKind.Utc).AddTicks(2704) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "ID",
                keyValue: 4,
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2024, 5, 10, 11, 28, 4, 61, DateTimeKind.Utc).AddTicks(2706), new DateTime(2024, 5, 10, 11, 28, 4, 61, DateTimeKind.Utc).AddTicks(2707) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "ID",
                keyValue: 5,
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2024, 5, 10, 11, 28, 4, 61, DateTimeKind.Utc).AddTicks(2708), new DateTime(2024, 5, 10, 11, 28, 4, 61, DateTimeKind.Utc).AddTicks(2709) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "ID",
                keyValue: 6,
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2024, 5, 10, 11, 28, 4, 61, DateTimeKind.Utc).AddTicks(2710), new DateTime(2024, 5, 10, 11, 28, 4, 61, DateTimeKind.Utc).AddTicks(2711) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "ID",
                keyValue: 7,
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2024, 5, 10, 11, 28, 4, 61, DateTimeKind.Utc).AddTicks(2712), new DateTime(2024, 5, 10, 11, 28, 4, 61, DateTimeKind.Utc).AddTicks(2713) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "ID",
                keyValue: 8,
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2024, 5, 10, 11, 28, 4, 61, DateTimeKind.Utc).AddTicks(2715), new DateTime(2024, 5, 10, 11, 28, 4, 61, DateTimeKind.Utc).AddTicks(2715) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "ID",
                keyValue: 9,
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2024, 5, 10, 11, 28, 4, 61, DateTimeKind.Utc).AddTicks(2717), new DateTime(2024, 5, 10, 11, 28, 4, 61, DateTimeKind.Utc).AddTicks(2717) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "ID",
                keyValue: 10,
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2024, 5, 10, 11, 28, 4, 61, DateTimeKind.Utc).AddTicks(2719), new DateTime(2024, 5, 10, 11, 28, 4, 61, DateTimeKind.Utc).AddTicks(2720) });

            migrationBuilder.UpdateData(
                table: "Unit",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2024, 5, 10, 11, 28, 4, 61, DateTimeKind.Utc).AddTicks(2787), new DateTime(2024, 5, 10, 11, 28, 4, 61, DateTimeKind.Utc).AddTicks(2788) });

            migrationBuilder.UpdateData(
                table: "Unit",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2024, 5, 10, 11, 28, 4, 61, DateTimeKind.Utc).AddTicks(2791), new DateTime(2024, 5, 10, 11, 28, 4, 61, DateTimeKind.Utc).AddTicks(2791) });

            migrationBuilder.UpdateData(
                table: "Unit",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2024, 5, 10, 11, 28, 4, 61, DateTimeKind.Utc).AddTicks(2792), new DateTime(2024, 5, 10, 11, 28, 4, 61, DateTimeKind.Utc).AddTicks(2793) });

            migrationBuilder.UpdateData(
                table: "Unit",
                keyColumn: "ID",
                keyValue: 4,
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2024, 5, 10, 11, 28, 4, 61, DateTimeKind.Utc).AddTicks(2794), new DateTime(2024, 5, 10, 11, 28, 4, 61, DateTimeKind.Utc).AddTicks(2795) });

            migrationBuilder.UpdateData(
                table: "Unit",
                keyColumn: "ID",
                keyValue: 5,
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2024, 5, 10, 11, 28, 4, 61, DateTimeKind.Utc).AddTicks(2796), new DateTime(2024, 5, 10, 11, 28, 4, 61, DateTimeKind.Utc).AddTicks(2797) });

            migrationBuilder.UpdateData(
                table: "Unit",
                keyColumn: "ID",
                keyValue: 6,
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2024, 5, 10, 11, 28, 4, 61, DateTimeKind.Utc).AddTicks(2798), new DateTime(2024, 5, 10, 11, 28, 4, 61, DateTimeKind.Utc).AddTicks(2799) });

            migrationBuilder.UpdateData(
                table: "Unit",
                keyColumn: "ID",
                keyValue: 7,
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2024, 5, 10, 11, 28, 4, 61, DateTimeKind.Utc).AddTicks(2800), new DateTime(2024, 5, 10, 11, 28, 4, 61, DateTimeKind.Utc).AddTicks(2801) });

            migrationBuilder.UpdateData(
                table: "Unit",
                keyColumn: "ID",
                keyValue: 8,
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2024, 5, 10, 11, 28, 4, 61, DateTimeKind.Utc).AddTicks(2802), new DateTime(2024, 5, 10, 11, 28, 4, 61, DateTimeKind.Utc).AddTicks(2803) });

            migrationBuilder.UpdateData(
                table: "Unit",
                keyColumn: "ID",
                keyValue: 9,
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2024, 5, 10, 11, 28, 4, 61, DateTimeKind.Utc).AddTicks(2804), new DateTime(2024, 5, 10, 11, 28, 4, 61, DateTimeKind.Utc).AddTicks(2804) });

            migrationBuilder.UpdateData(
                table: "Unit",
                keyColumn: "ID",
                keyValue: 10,
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2024, 5, 10, 11, 28, 4, 61, DateTimeKind.Utc).AddTicks(2806), new DateTime(2024, 5, 10, 11, 28, 4, 61, DateTimeKind.Utc).AddTicks(2806) });
        }
    }
}
