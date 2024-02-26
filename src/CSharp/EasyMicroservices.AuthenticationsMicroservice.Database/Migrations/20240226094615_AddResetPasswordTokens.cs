using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EasyMicroservices.AuthenticationsMicroservice.Migrations
{
    /// <inheritdoc />
    public partial class AddResetPasswordTokens : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ResetPasswordTokens",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModificationDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UniqueIdentity = table.Column<string>(type: "nvarchar(450)", nullable: true, collation: "SQL_Latin1_General_CP1_CS_AS"),
                    Token = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HasConsumed = table.Column<bool>(type: "bit", nullable: false),
                    ExpirationDateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResetPasswordTokens", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "PersonalAccessTokens",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreationDateTime",
                value: new DateTime(2024, 2, 26, 13, 16, 15, 335, DateTimeKind.Local).AddTicks(3610));

            migrationBuilder.UpdateData(
                table: "RoleParentChildren",
                keyColumns: new[] { "ChildId", "ParentId" },
                keyValues: new object[] { 2L, 1L },
                column: "CreationDateTime",
                value: new DateTime(2024, 2, 26, 13, 16, 15, 335, DateTimeKind.Local).AddTicks(3485));

            migrationBuilder.UpdateData(
                table: "RoleParentChildren",
                keyColumns: new[] { "ChildId", "ParentId" },
                keyValues: new object[] { 2L, 3L },
                column: "CreationDateTime",
                value: new DateTime(2024, 2, 26, 13, 16, 15, 335, DateTimeKind.Local).AddTicks(3485));

            migrationBuilder.UpdateData(
                table: "RoleParentChildren",
                keyColumns: new[] { "ChildId", "ParentId" },
                keyValues: new object[] { 2L, 4L },
                column: "CreationDateTime",
                value: new DateTime(2024, 2, 26, 13, 16, 15, 335, DateTimeKind.Local).AddTicks(3486));

            migrationBuilder.UpdateData(
                table: "RoleParentChildren",
                keyColumns: new[] { "ChildId", "ParentId" },
                keyValues: new object[] { 3L, 5L },
                column: "CreationDateTime",
                value: new DateTime(2024, 2, 26, 13, 16, 15, 335, DateTimeKind.Local).AddTicks(3486));

            migrationBuilder.UpdateData(
                table: "RoleParentChildren",
                keyColumns: new[] { "ChildId", "ParentId" },
                keyValues: new object[] { 3L, 6L },
                column: "CreationDateTime",
                value: new DateTime(2024, 2, 26, 13, 16, 15, 335, DateTimeKind.Local).AddTicks(3487));

            migrationBuilder.UpdateData(
                table: "RoleParentChildren",
                keyColumns: new[] { "ChildId", "ParentId" },
                keyValues: new object[] { 5L, 7L },
                column: "CreationDateTime",
                value: new DateTime(2024, 2, 26, 13, 16, 15, 335, DateTimeKind.Local).AddTicks(3487));

            migrationBuilder.UpdateData(
                table: "RoleParentChildren",
                keyColumns: new[] { "ChildId", "ParentId" },
                keyValues: new object[] { 5L, 8L },
                column: "CreationDateTime",
                value: new DateTime(2024, 2, 26, 13, 16, 15, 335, DateTimeKind.Local).AddTicks(3487));

            migrationBuilder.UpdateData(
                table: "RoleParentChildren",
                keyColumns: new[] { "ChildId", "ParentId" },
                keyValues: new object[] { 2L, 9L },
                column: "CreationDateTime",
                value: new DateTime(2024, 2, 26, 13, 16, 15, 335, DateTimeKind.Local).AddTicks(3488));

            migrationBuilder.UpdateData(
                table: "RoleParentChildren",
                keyColumns: new[] { "ChildId", "ParentId" },
                keyValues: new object[] { 5L, 9L },
                column: "CreationDateTime",
                value: new DateTime(2024, 2, 26, 13, 16, 15, 335, DateTimeKind.Local).AddTicks(3487));

            migrationBuilder.UpdateData(
                table: "RoleParentChildren",
                keyColumns: new[] { "ChildId", "ParentId" },
                keyValues: new object[] { 5L, 10L },
                column: "CreationDateTime",
                value: new DateTime(2024, 2, 26, 13, 16, 15, 335, DateTimeKind.Local).AddTicks(3488));

            migrationBuilder.UpdateData(
                table: "RoleServicePermissions",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreationDateTime",
                value: new DateTime(2024, 2, 26, 13, 16, 15, 335, DateTimeKind.Local).AddTicks(3567));

            migrationBuilder.UpdateData(
                table: "RoleServicePermissions",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreationDateTime",
                value: new DateTime(2024, 2, 26, 13, 16, 15, 335, DateTimeKind.Local).AddTicks(3567));

            migrationBuilder.UpdateData(
                table: "RoleServicePermissions",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreationDateTime",
                value: new DateTime(2024, 2, 26, 13, 16, 15, 335, DateTimeKind.Local).AddTicks(3567));

            migrationBuilder.UpdateData(
                table: "RoleServicePermissions",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreationDateTime",
                value: new DateTime(2024, 2, 26, 13, 16, 15, 335, DateTimeKind.Local).AddTicks(3568));

            migrationBuilder.UpdateData(
                table: "RoleServicePermissions",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreationDateTime",
                value: new DateTime(2024, 2, 26, 13, 16, 15, 335, DateTimeKind.Local).AddTicks(3568));

            migrationBuilder.UpdateData(
                table: "RoleServicePermissions",
                keyColumn: "Id",
                keyValue: 6L,
                column: "CreationDateTime",
                value: new DateTime(2024, 2, 26, 13, 16, 15, 335, DateTimeKind.Local).AddTicks(3568));

            migrationBuilder.UpdateData(
                table: "RoleServicePermissions",
                keyColumn: "Id",
                keyValue: 7L,
                column: "CreationDateTime",
                value: new DateTime(2024, 2, 26, 13, 16, 15, 335, DateTimeKind.Local).AddTicks(3569));

            migrationBuilder.UpdateData(
                table: "RoleServicePermissions",
                keyColumn: "Id",
                keyValue: 8L,
                column: "CreationDateTime",
                value: new DateTime(2024, 2, 26, 13, 16, 15, 335, DateTimeKind.Local).AddTicks(3569));

            migrationBuilder.UpdateData(
                table: "RoleServicePermissions",
                keyColumn: "Id",
                keyValue: 9L,
                column: "CreationDateTime",
                value: new DateTime(2024, 2, 26, 13, 16, 15, 335, DateTimeKind.Local).AddTicks(3569));

            migrationBuilder.UpdateData(
                table: "RoleServicePermissions",
                keyColumn: "Id",
                keyValue: 10L,
                column: "CreationDateTime",
                value: new DateTime(2024, 2, 26, 13, 16, 15, 335, DateTimeKind.Local).AddTicks(3569));

            migrationBuilder.UpdateData(
                table: "RoleServicePermissions",
                keyColumn: "Id",
                keyValue: 11L,
                column: "CreationDateTime",
                value: new DateTime(2024, 2, 26, 13, 16, 15, 335, DateTimeKind.Local).AddTicks(3570));

            migrationBuilder.UpdateData(
                table: "RoleServicePermissions",
                keyColumn: "Id",
                keyValue: 12L,
                column: "CreationDateTime",
                value: new DateTime(2024, 2, 26, 13, 16, 15, 335, DateTimeKind.Local).AddTicks(3570));

            migrationBuilder.UpdateData(
                table: "RoleServicePermissions",
                keyColumn: "Id",
                keyValue: 13L,
                column: "CreationDateTime",
                value: new DateTime(2024, 2, 26, 13, 16, 15, 335, DateTimeKind.Local).AddTicks(3570));

            migrationBuilder.UpdateData(
                table: "RoleServicePermissions",
                keyColumn: "Id",
                keyValue: 14L,
                column: "CreationDateTime",
                value: new DateTime(2024, 2, 26, 13, 16, 15, 335, DateTimeKind.Local).AddTicks(3571));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreationDateTime",
                value: new DateTime(2024, 2, 26, 13, 16, 15, 335, DateTimeKind.Local).AddTicks(3321));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreationDateTime",
                value: new DateTime(2024, 2, 26, 13, 16, 15, 335, DateTimeKind.Local).AddTicks(3333));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreationDateTime",
                value: new DateTime(2024, 2, 26, 13, 16, 15, 335, DateTimeKind.Local).AddTicks(3333));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreationDateTime",
                value: new DateTime(2024, 2, 26, 13, 16, 15, 335, DateTimeKind.Local).AddTicks(3334));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreationDateTime",
                value: new DateTime(2024, 2, 26, 13, 16, 15, 335, DateTimeKind.Local).AddTicks(3334));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 6L,
                column: "CreationDateTime",
                value: new DateTime(2024, 2, 26, 13, 16, 15, 335, DateTimeKind.Local).AddTicks(3334));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 7L,
                column: "CreationDateTime",
                value: new DateTime(2024, 2, 26, 13, 16, 15, 335, DateTimeKind.Local).AddTicks(3335));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 8L,
                column: "CreationDateTime",
                value: new DateTime(2024, 2, 26, 13, 16, 15, 335, DateTimeKind.Local).AddTicks(3335));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 9L,
                column: "CreationDateTime",
                value: new DateTime(2024, 2, 26, 13, 16, 15, 335, DateTimeKind.Local).AddTicks(3335));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 10L,
                column: "CreationDateTime",
                value: new DateTime(2024, 2, 26, 13, 16, 15, 335, DateTimeKind.Local).AddTicks(3336));

            migrationBuilder.UpdateData(
                table: "ServicePermissions",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreationDateTime",
                value: new DateTime(2024, 2, 26, 13, 16, 15, 335, DateTimeKind.Local).AddTicks(3514));

            migrationBuilder.UpdateData(
                table: "ServicePermissions",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreationDateTime",
                value: new DateTime(2024, 2, 26, 13, 16, 15, 335, DateTimeKind.Local).AddTicks(3514));

            migrationBuilder.UpdateData(
                table: "ServicePermissions",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreationDateTime",
                value: new DateTime(2024, 2, 26, 13, 16, 15, 335, DateTimeKind.Local).AddTicks(3514));

            migrationBuilder.UpdateData(
                table: "ServicePermissions",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreationDateTime",
                value: new DateTime(2024, 2, 26, 13, 16, 15, 335, DateTimeKind.Local).AddTicks(3515));

            migrationBuilder.UpdateData(
                table: "ServicePermissions",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreationDateTime",
                value: new DateTime(2024, 2, 26, 13, 16, 15, 335, DateTimeKind.Local).AddTicks(3515));

            migrationBuilder.UpdateData(
                table: "ServicePermissions",
                keyColumn: "Id",
                keyValue: 6L,
                column: "CreationDateTime",
                value: new DateTime(2024, 2, 26, 13, 16, 15, 335, DateTimeKind.Local).AddTicks(3515));

            migrationBuilder.UpdateData(
                table: "ServicePermissions",
                keyColumn: "Id",
                keyValue: 7L,
                column: "CreationDateTime",
                value: new DateTime(2024, 2, 26, 13, 16, 15, 335, DateTimeKind.Local).AddTicks(3516));

            migrationBuilder.UpdateData(
                table: "ServicePermissions",
                keyColumn: "Id",
                keyValue: 8L,
                column: "CreationDateTime",
                value: new DateTime(2024, 2, 26, 13, 16, 15, 335, DateTimeKind.Local).AddTicks(3516));

            migrationBuilder.UpdateData(
                table: "ServicePermissions",
                keyColumn: "Id",
                keyValue: 9L,
                column: "CreationDateTime",
                value: new DateTime(2024, 2, 26, 13, 16, 15, 335, DateTimeKind.Local).AddTicks(3516));

            migrationBuilder.UpdateData(
                table: "ServicePermissions",
                keyColumn: "Id",
                keyValue: 10L,
                column: "CreationDateTime",
                value: new DateTime(2024, 2, 26, 13, 16, 15, 335, DateTimeKind.Local).AddTicks(3517));

            migrationBuilder.UpdateData(
                table: "ServicePermissions",
                keyColumn: "Id",
                keyValue: 11L,
                column: "CreationDateTime",
                value: new DateTime(2024, 2, 26, 13, 16, 15, 335, DateTimeKind.Local).AddTicks(3517));

            migrationBuilder.UpdateData(
                table: "ServicePermissions",
                keyColumn: "Id",
                keyValue: 12L,
                column: "CreationDateTime",
                value: new DateTime(2024, 2, 26, 13, 16, 15, 335, DateTimeKind.Local).AddTicks(3517));

            migrationBuilder.UpdateData(
                table: "ServicePermissions",
                keyColumn: "Id",
                keyValue: 13L,
                column: "CreationDateTime",
                value: new DateTime(2024, 2, 26, 13, 16, 15, 335, DateTimeKind.Local).AddTicks(3518));

            migrationBuilder.UpdateData(
                table: "ServicePermissions",
                keyColumn: "Id",
                keyValue: 14L,
                column: "CreationDateTime",
                value: new DateTime(2024, 2, 26, 13, 16, 15, 335, DateTimeKind.Local).AddTicks(3518));

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreationDateTime",
                value: new DateTime(2024, 2, 26, 13, 16, 15, 335, DateTimeKind.Local).AddTicks(3599));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreationDateTime", "Password", "UniqueIdentity", "UserName" },
                values: new object[] { new DateTime(2024, 2, 26, 13, 16, 15, 335, DateTimeKind.Local).AddTicks(3588), "8094fd276b937d38e75cec61a91ec84781d1000f0ba290448e8ce931b6a5bbfd", "1-2-d-1", "MahdiyarGHD" });

            migrationBuilder.CreateIndex(
                name: "IX_ResetPasswordTokens_CreationDateTime",
                table: "ResetPasswordTokens",
                column: "CreationDateTime");

            migrationBuilder.CreateIndex(
                name: "IX_ResetPasswordTokens_DeletedDateTime",
                table: "ResetPasswordTokens",
                column: "DeletedDateTime");

            migrationBuilder.CreateIndex(
                name: "IX_ResetPasswordTokens_IsDeleted",
                table: "ResetPasswordTokens",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_ResetPasswordTokens_ModificationDateTime",
                table: "ResetPasswordTokens",
                column: "ModificationDateTime");

            migrationBuilder.CreateIndex(
                name: "IX_ResetPasswordTokens_UniqueIdentity",
                table: "ResetPasswordTokens",
                column: "UniqueIdentity");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ResetPasswordTokens");

            migrationBuilder.UpdateData(
                table: "PersonalAccessTokens",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreationDateTime",
                value: new DateTime(2024, 1, 1, 1, 15, 32, 369, DateTimeKind.Local).AddTicks(9139));

            migrationBuilder.UpdateData(
                table: "RoleParentChildren",
                keyColumns: new[] { "ChildId", "ParentId" },
                keyValues: new object[] { 2L, 1L },
                column: "CreationDateTime",
                value: new DateTime(2024, 1, 1, 1, 15, 32, 369, DateTimeKind.Local).AddTicks(8983));

            migrationBuilder.UpdateData(
                table: "RoleParentChildren",
                keyColumns: new[] { "ChildId", "ParentId" },
                keyValues: new object[] { 2L, 3L },
                column: "CreationDateTime",
                value: new DateTime(2024, 1, 1, 1, 15, 32, 369, DateTimeKind.Local).AddTicks(8984));

            migrationBuilder.UpdateData(
                table: "RoleParentChildren",
                keyColumns: new[] { "ChildId", "ParentId" },
                keyValues: new object[] { 2L, 4L },
                column: "CreationDateTime",
                value: new DateTime(2024, 1, 1, 1, 15, 32, 369, DateTimeKind.Local).AddTicks(8984));

            migrationBuilder.UpdateData(
                table: "RoleParentChildren",
                keyColumns: new[] { "ChildId", "ParentId" },
                keyValues: new object[] { 3L, 5L },
                column: "CreationDateTime",
                value: new DateTime(2024, 1, 1, 1, 15, 32, 369, DateTimeKind.Local).AddTicks(8985));

            migrationBuilder.UpdateData(
                table: "RoleParentChildren",
                keyColumns: new[] { "ChildId", "ParentId" },
                keyValues: new object[] { 3L, 6L },
                column: "CreationDateTime",
                value: new DateTime(2024, 1, 1, 1, 15, 32, 369, DateTimeKind.Local).AddTicks(8985));

            migrationBuilder.UpdateData(
                table: "RoleParentChildren",
                keyColumns: new[] { "ChildId", "ParentId" },
                keyValues: new object[] { 5L, 7L },
                column: "CreationDateTime",
                value: new DateTime(2024, 1, 1, 1, 15, 32, 369, DateTimeKind.Local).AddTicks(8985));

            migrationBuilder.UpdateData(
                table: "RoleParentChildren",
                keyColumns: new[] { "ChildId", "ParentId" },
                keyValues: new object[] { 5L, 8L },
                column: "CreationDateTime",
                value: new DateTime(2024, 1, 1, 1, 15, 32, 369, DateTimeKind.Local).AddTicks(8986));

            migrationBuilder.UpdateData(
                table: "RoleParentChildren",
                keyColumns: new[] { "ChildId", "ParentId" },
                keyValues: new object[] { 2L, 9L },
                column: "CreationDateTime",
                value: new DateTime(2024, 1, 1, 1, 15, 32, 369, DateTimeKind.Local).AddTicks(8987));

            migrationBuilder.UpdateData(
                table: "RoleParentChildren",
                keyColumns: new[] { "ChildId", "ParentId" },
                keyValues: new object[] { 5L, 9L },
                column: "CreationDateTime",
                value: new DateTime(2024, 1, 1, 1, 15, 32, 369, DateTimeKind.Local).AddTicks(8986));

            migrationBuilder.UpdateData(
                table: "RoleParentChildren",
                keyColumns: new[] { "ChildId", "ParentId" },
                keyValues: new object[] { 5L, 10L },
                column: "CreationDateTime",
                value: new DateTime(2024, 1, 1, 1, 15, 32, 369, DateTimeKind.Local).AddTicks(8986));

            migrationBuilder.UpdateData(
                table: "RoleServicePermissions",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreationDateTime",
                value: new DateTime(2024, 1, 1, 1, 15, 32, 369, DateTimeKind.Local).AddTicks(9088));

            migrationBuilder.UpdateData(
                table: "RoleServicePermissions",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreationDateTime",
                value: new DateTime(2024, 1, 1, 1, 15, 32, 369, DateTimeKind.Local).AddTicks(9088));

            migrationBuilder.UpdateData(
                table: "RoleServicePermissions",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreationDateTime",
                value: new DateTime(2024, 1, 1, 1, 15, 32, 369, DateTimeKind.Local).AddTicks(9088));

            migrationBuilder.UpdateData(
                table: "RoleServicePermissions",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreationDateTime",
                value: new DateTime(2024, 1, 1, 1, 15, 32, 369, DateTimeKind.Local).AddTicks(9089));

            migrationBuilder.UpdateData(
                table: "RoleServicePermissions",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreationDateTime",
                value: new DateTime(2024, 1, 1, 1, 15, 32, 369, DateTimeKind.Local).AddTicks(9089));

            migrationBuilder.UpdateData(
                table: "RoleServicePermissions",
                keyColumn: "Id",
                keyValue: 6L,
                column: "CreationDateTime",
                value: new DateTime(2024, 1, 1, 1, 15, 32, 369, DateTimeKind.Local).AddTicks(9090));

            migrationBuilder.UpdateData(
                table: "RoleServicePermissions",
                keyColumn: "Id",
                keyValue: 7L,
                column: "CreationDateTime",
                value: new DateTime(2024, 1, 1, 1, 15, 32, 369, DateTimeKind.Local).AddTicks(9090));

            migrationBuilder.UpdateData(
                table: "RoleServicePermissions",
                keyColumn: "Id",
                keyValue: 8L,
                column: "CreationDateTime",
                value: new DateTime(2024, 1, 1, 1, 15, 32, 369, DateTimeKind.Local).AddTicks(9090));

            migrationBuilder.UpdateData(
                table: "RoleServicePermissions",
                keyColumn: "Id",
                keyValue: 9L,
                column: "CreationDateTime",
                value: new DateTime(2024, 1, 1, 1, 15, 32, 369, DateTimeKind.Local).AddTicks(9091));

            migrationBuilder.UpdateData(
                table: "RoleServicePermissions",
                keyColumn: "Id",
                keyValue: 10L,
                column: "CreationDateTime",
                value: new DateTime(2024, 1, 1, 1, 15, 32, 369, DateTimeKind.Local).AddTicks(9091));

            migrationBuilder.UpdateData(
                table: "RoleServicePermissions",
                keyColumn: "Id",
                keyValue: 11L,
                column: "CreationDateTime",
                value: new DateTime(2024, 1, 1, 1, 15, 32, 369, DateTimeKind.Local).AddTicks(9091));

            migrationBuilder.UpdateData(
                table: "RoleServicePermissions",
                keyColumn: "Id",
                keyValue: 12L,
                column: "CreationDateTime",
                value: new DateTime(2024, 1, 1, 1, 15, 32, 369, DateTimeKind.Local).AddTicks(9092));

            migrationBuilder.UpdateData(
                table: "RoleServicePermissions",
                keyColumn: "Id",
                keyValue: 13L,
                column: "CreationDateTime",
                value: new DateTime(2024, 1, 1, 1, 15, 32, 369, DateTimeKind.Local).AddTicks(9092));

            migrationBuilder.UpdateData(
                table: "RoleServicePermissions",
                keyColumn: "Id",
                keyValue: 14L,
                column: "CreationDateTime",
                value: new DateTime(2024, 1, 1, 1, 15, 32, 369, DateTimeKind.Local).AddTicks(9092));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreationDateTime",
                value: new DateTime(2024, 1, 1, 1, 15, 32, 369, DateTimeKind.Local).AddTicks(8814));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreationDateTime",
                value: new DateTime(2024, 1, 1, 1, 15, 32, 369, DateTimeKind.Local).AddTicks(8829));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreationDateTime",
                value: new DateTime(2024, 1, 1, 1, 15, 32, 369, DateTimeKind.Local).AddTicks(8830));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreationDateTime",
                value: new DateTime(2024, 1, 1, 1, 15, 32, 369, DateTimeKind.Local).AddTicks(8830));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreationDateTime",
                value: new DateTime(2024, 1, 1, 1, 15, 32, 369, DateTimeKind.Local).AddTicks(8830));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 6L,
                column: "CreationDateTime",
                value: new DateTime(2024, 1, 1, 1, 15, 32, 369, DateTimeKind.Local).AddTicks(8831));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 7L,
                column: "CreationDateTime",
                value: new DateTime(2024, 1, 1, 1, 15, 32, 369, DateTimeKind.Local).AddTicks(8831));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 8L,
                column: "CreationDateTime",
                value: new DateTime(2024, 1, 1, 1, 15, 32, 369, DateTimeKind.Local).AddTicks(8832));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 9L,
                column: "CreationDateTime",
                value: new DateTime(2024, 1, 1, 1, 15, 32, 369, DateTimeKind.Local).AddTicks(8832));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 10L,
                column: "CreationDateTime",
                value: new DateTime(2024, 1, 1, 1, 15, 32, 369, DateTimeKind.Local).AddTicks(8832));

            migrationBuilder.UpdateData(
                table: "ServicePermissions",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreationDateTime",
                value: new DateTime(2024, 1, 1, 1, 15, 32, 369, DateTimeKind.Local).AddTicks(9054));

            migrationBuilder.UpdateData(
                table: "ServicePermissions",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreationDateTime",
                value: new DateTime(2024, 1, 1, 1, 15, 32, 369, DateTimeKind.Local).AddTicks(9054));

            migrationBuilder.UpdateData(
                table: "ServicePermissions",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreationDateTime",
                value: new DateTime(2024, 1, 1, 1, 15, 32, 369, DateTimeKind.Local).AddTicks(9055));

            migrationBuilder.UpdateData(
                table: "ServicePermissions",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreationDateTime",
                value: new DateTime(2024, 1, 1, 1, 15, 32, 369, DateTimeKind.Local).AddTicks(9055));

            migrationBuilder.UpdateData(
                table: "ServicePermissions",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreationDateTime",
                value: new DateTime(2024, 1, 1, 1, 15, 32, 369, DateTimeKind.Local).AddTicks(9055));

            migrationBuilder.UpdateData(
                table: "ServicePermissions",
                keyColumn: "Id",
                keyValue: 6L,
                column: "CreationDateTime",
                value: new DateTime(2024, 1, 1, 1, 15, 32, 369, DateTimeKind.Local).AddTicks(9056));

            migrationBuilder.UpdateData(
                table: "ServicePermissions",
                keyColumn: "Id",
                keyValue: 7L,
                column: "CreationDateTime",
                value: new DateTime(2024, 1, 1, 1, 15, 32, 369, DateTimeKind.Local).AddTicks(9056));

            migrationBuilder.UpdateData(
                table: "ServicePermissions",
                keyColumn: "Id",
                keyValue: 8L,
                column: "CreationDateTime",
                value: new DateTime(2024, 1, 1, 1, 15, 32, 369, DateTimeKind.Local).AddTicks(9057));

            migrationBuilder.UpdateData(
                table: "ServicePermissions",
                keyColumn: "Id",
                keyValue: 9L,
                column: "CreationDateTime",
                value: new DateTime(2024, 1, 1, 1, 15, 32, 369, DateTimeKind.Local).AddTicks(9057));

            migrationBuilder.UpdateData(
                table: "ServicePermissions",
                keyColumn: "Id",
                keyValue: 10L,
                column: "CreationDateTime",
                value: new DateTime(2024, 1, 1, 1, 15, 32, 369, DateTimeKind.Local).AddTicks(9057));

            migrationBuilder.UpdateData(
                table: "ServicePermissions",
                keyColumn: "Id",
                keyValue: 11L,
                column: "CreationDateTime",
                value: new DateTime(2024, 1, 1, 1, 15, 32, 369, DateTimeKind.Local).AddTicks(9058));

            migrationBuilder.UpdateData(
                table: "ServicePermissions",
                keyColumn: "Id",
                keyValue: 12L,
                column: "CreationDateTime",
                value: new DateTime(2024, 1, 1, 1, 15, 32, 369, DateTimeKind.Local).AddTicks(9058));

            migrationBuilder.UpdateData(
                table: "ServicePermissions",
                keyColumn: "Id",
                keyValue: 13L,
                column: "CreationDateTime",
                value: new DateTime(2024, 1, 1, 1, 15, 32, 369, DateTimeKind.Local).AddTicks(9058));

            migrationBuilder.UpdateData(
                table: "ServicePermissions",
                keyColumn: "Id",
                keyValue: 14L,
                column: "CreationDateTime",
                value: new DateTime(2024, 1, 1, 1, 15, 32, 369, DateTimeKind.Local).AddTicks(9059));

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreationDateTime",
                value: new DateTime(2024, 1, 1, 1, 15, 32, 369, DateTimeKind.Local).AddTicks(9126));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreationDateTime", "Password", "UniqueIdentity", "UserName" },
                values: new object[] { new DateTime(2024, 1, 1, 1, 15, 32, 369, DateTimeKind.Local).AddTicks(9112), null, "1-2", "Owner" });
        }
    }
}
