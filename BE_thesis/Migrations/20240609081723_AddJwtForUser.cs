using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BE_thesis.Migrations
{
    /// <inheritdoc />
    public partial class AddJwtForUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "jwt",
                table: "Users",
                type: "nvarchar(MAX)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Brand",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2024, 6, 9, 8, 17, 22, 141, DateTimeKind.Utc).AddTicks(7814), new DateTime(2024, 6, 9, 8, 17, 22, 141, DateTimeKind.Utc).AddTicks(7817) });

            migrationBuilder.UpdateData(
                table: "Brand",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2024, 6, 9, 8, 17, 22, 141, DateTimeKind.Utc).AddTicks(7819), new DateTime(2024, 6, 9, 8, 17, 22, 141, DateTimeKind.Utc).AddTicks(7819) });

            migrationBuilder.UpdateData(
                table: "Brand",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2024, 6, 9, 8, 17, 22, 141, DateTimeKind.Utc).AddTicks(7820), new DateTime(2024, 6, 9, 8, 17, 22, 141, DateTimeKind.Utc).AddTicks(7820) });

            migrationBuilder.UpdateData(
                table: "Brand",
                keyColumn: "ID",
                keyValue: 4,
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2024, 6, 9, 8, 17, 22, 141, DateTimeKind.Utc).AddTicks(7821), new DateTime(2024, 6, 9, 8, 17, 22, 141, DateTimeKind.Utc).AddTicks(7822) });

            migrationBuilder.UpdateData(
                table: "Brand",
                keyColumn: "ID",
                keyValue: 5,
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2024, 6, 9, 8, 17, 22, 141, DateTimeKind.Utc).AddTicks(7823), new DateTime(2024, 6, 9, 8, 17, 22, 141, DateTimeKind.Utc).AddTicks(7823) });

            migrationBuilder.UpdateData(
                table: "Brand",
                keyColumn: "ID",
                keyValue: 6,
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2024, 6, 9, 8, 17, 22, 141, DateTimeKind.Utc).AddTicks(7824), new DateTime(2024, 6, 9, 8, 17, 22, 141, DateTimeKind.Utc).AddTicks(7825) });

            migrationBuilder.UpdateData(
                table: "Brand",
                keyColumn: "ID",
                keyValue: 7,
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2024, 6, 9, 8, 17, 22, 141, DateTimeKind.Utc).AddTicks(7825), new DateTime(2024, 6, 9, 8, 17, 22, 141, DateTimeKind.Utc).AddTicks(7826) });

            migrationBuilder.UpdateData(
                table: "Brand",
                keyColumn: "ID",
                keyValue: 8,
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2024, 6, 9, 8, 17, 22, 141, DateTimeKind.Utc).AddTicks(7827), new DateTime(2024, 6, 9, 8, 17, 22, 141, DateTimeKind.Utc).AddTicks(7827) });

            migrationBuilder.UpdateData(
                table: "Brand",
                keyColumn: "ID",
                keyValue: 9,
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2024, 6, 9, 8, 17, 22, 141, DateTimeKind.Utc).AddTicks(7828), new DateTime(2024, 6, 9, 8, 17, 22, 141, DateTimeKind.Utc).AddTicks(7828) });

            migrationBuilder.UpdateData(
                table: "Brand",
                keyColumn: "ID",
                keyValue: 10,
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2024, 6, 9, 8, 17, 22, 141, DateTimeKind.Utc).AddTicks(7829), new DateTime(2024, 6, 9, 8, 17, 22, 141, DateTimeKind.Utc).AddTicks(7830) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2024, 6, 9, 8, 17, 22, 141, DateTimeKind.Utc).AddTicks(8016), new DateTime(2024, 6, 9, 8, 17, 22, 141, DateTimeKind.Utc).AddTicks(8016) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2024, 6, 9, 8, 17, 22, 141, DateTimeKind.Utc).AddTicks(8018), new DateTime(2024, 6, 9, 8, 17, 22, 141, DateTimeKind.Utc).AddTicks(8018) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2024, 6, 9, 8, 17, 22, 141, DateTimeKind.Utc).AddTicks(8019), new DateTime(2024, 6, 9, 8, 17, 22, 141, DateTimeKind.Utc).AddTicks(8020) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "ID",
                keyValue: 4,
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2024, 6, 9, 8, 17, 22, 141, DateTimeKind.Utc).AddTicks(8021), new DateTime(2024, 6, 9, 8, 17, 22, 141, DateTimeKind.Utc).AddTicks(8021) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "ID",
                keyValue: 5,
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2024, 6, 9, 8, 17, 22, 141, DateTimeKind.Utc).AddTicks(8022), new DateTime(2024, 6, 9, 8, 17, 22, 141, DateTimeKind.Utc).AddTicks(8022) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "ID",
                keyValue: 6,
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2024, 6, 9, 8, 17, 22, 141, DateTimeKind.Utc).AddTicks(8023), new DateTime(2024, 6, 9, 8, 17, 22, 141, DateTimeKind.Utc).AddTicks(8023) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "ID",
                keyValue: 7,
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2024, 6, 9, 8, 17, 22, 141, DateTimeKind.Utc).AddTicks(8024), new DateTime(2024, 6, 9, 8, 17, 22, 141, DateTimeKind.Utc).AddTicks(8025) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "ID",
                keyValue: 8,
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2024, 6, 9, 8, 17, 22, 141, DateTimeKind.Utc).AddTicks(8026), new DateTime(2024, 6, 9, 8, 17, 22, 141, DateTimeKind.Utc).AddTicks(8026) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "ID",
                keyValue: 9,
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2024, 6, 9, 8, 17, 22, 141, DateTimeKind.Utc).AddTicks(8027), new DateTime(2024, 6, 9, 8, 17, 22, 141, DateTimeKind.Utc).AddTicks(8027) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "ID",
                keyValue: 10,
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2024, 6, 9, 8, 17, 22, 141, DateTimeKind.Utc).AddTicks(8028), new DateTime(2024, 6, 9, 8, 17, 22, 141, DateTimeKind.Utc).AddTicks(8028) });

            migrationBuilder.UpdateData(
                table: "Unit",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2024, 6, 9, 8, 17, 22, 141, DateTimeKind.Utc).AddTicks(8069), new DateTime(2024, 6, 9, 8, 17, 22, 141, DateTimeKind.Utc).AddTicks(8070) });

            migrationBuilder.UpdateData(
                table: "Unit",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2024, 6, 9, 8, 17, 22, 141, DateTimeKind.Utc).AddTicks(8071), new DateTime(2024, 6, 9, 8, 17, 22, 141, DateTimeKind.Utc).AddTicks(8071) });

            migrationBuilder.UpdateData(
                table: "Unit",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2024, 6, 9, 8, 17, 22, 141, DateTimeKind.Utc).AddTicks(8072), new DateTime(2024, 6, 9, 8, 17, 22, 141, DateTimeKind.Utc).AddTicks(8072) });

            migrationBuilder.UpdateData(
                table: "Unit",
                keyColumn: "ID",
                keyValue: 4,
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2024, 6, 9, 8, 17, 22, 141, DateTimeKind.Utc).AddTicks(8073), new DateTime(2024, 6, 9, 8, 17, 22, 141, DateTimeKind.Utc).AddTicks(8074) });

            migrationBuilder.UpdateData(
                table: "Unit",
                keyColumn: "ID",
                keyValue: 5,
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2024, 6, 9, 8, 17, 22, 141, DateTimeKind.Utc).AddTicks(8075), new DateTime(2024, 6, 9, 8, 17, 22, 141, DateTimeKind.Utc).AddTicks(8075) });

            migrationBuilder.UpdateData(
                table: "Unit",
                keyColumn: "ID",
                keyValue: 6,
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2024, 6, 9, 8, 17, 22, 141, DateTimeKind.Utc).AddTicks(8076), new DateTime(2024, 6, 9, 8, 17, 22, 141, DateTimeKind.Utc).AddTicks(8076) });

            migrationBuilder.UpdateData(
                table: "Unit",
                keyColumn: "ID",
                keyValue: 7,
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2024, 6, 9, 8, 17, 22, 141, DateTimeKind.Utc).AddTicks(8077), new DateTime(2024, 6, 9, 8, 17, 22, 141, DateTimeKind.Utc).AddTicks(8077) });

            migrationBuilder.UpdateData(
                table: "Unit",
                keyColumn: "ID",
                keyValue: 8,
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2024, 6, 9, 8, 17, 22, 141, DateTimeKind.Utc).AddTicks(8078), new DateTime(2024, 6, 9, 8, 17, 22, 141, DateTimeKind.Utc).AddTicks(8079) });

            migrationBuilder.UpdateData(
                table: "Unit",
                keyColumn: "ID",
                keyValue: 9,
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2024, 6, 9, 8, 17, 22, 141, DateTimeKind.Utc).AddTicks(8080), new DateTime(2024, 6, 9, 8, 17, 22, 141, DateTimeKind.Utc).AddTicks(8080) });

            migrationBuilder.UpdateData(
                table: "Unit",
                keyColumn: "ID",
                keyValue: 10,
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2024, 6, 9, 8, 17, 22, 141, DateTimeKind.Utc).AddTicks(8117), new DateTime(2024, 6, 9, 8, 17, 22, 141, DateTimeKind.Utc).AddTicks(8118) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "jwt",
                table: "Users");

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
    }
}
