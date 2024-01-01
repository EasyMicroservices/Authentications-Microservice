using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EasyMicroservices.AuthenticationsMicroservice.Migrations
{
    /// <inheritdoc />
    public partial class Initialize : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModificationDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UniqueIdentity = table.Column<string>(type: "nvarchar(450)", nullable: true, collation: "SQL_Latin1_General_CP1_CS_AS"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ServicePermissions",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModificationDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UniqueIdentity = table.Column<string>(type: "nvarchar(450)", nullable: true, collation: "SQL_Latin1_General_CP1_CS_AS"),
                    MicroserviceName = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    ServiceName = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    MethodName = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    AccessType = table.Column<byte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServicePermissions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModificationDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UniqueIdentity = table.Column<string>(type: "nvarchar(450)", nullable: true, collation: "SQL_Latin1_General_CP1_CS_AS"),
                    UserName = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BusinessUniqueIdentity = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    IsVerified = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RegisterUserDefaultRoles",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<long>(type: "bigint", nullable: false),
                    CreationDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModificationDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UniqueIdentity = table.Column<string>(type: "nvarchar(450)", nullable: true, collation: "SQL_Latin1_General_CP1_CS_AS")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegisterUserDefaultRoles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RegisterUserDefaultRoles_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RoleParentChildren",
                columns: table => new
                {
                    ChildId = table.Column<long>(type: "bigint", nullable: false),
                    ParentId = table.Column<long>(type: "bigint", nullable: false),
                    CreationDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModificationDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UniqueIdentity = table.Column<string>(type: "nvarchar(450)", nullable: true, collation: "SQL_Latin1_General_CP1_CS_AS")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleParentChildren", x => new { x.ParentId, x.ChildId });
                    table.ForeignKey(
                        name: "FK_RoleParentChildren_Roles_ChildId",
                        column: x => x.ChildId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RoleParentChildren_Roles_ParentId",
                        column: x => x.ParentId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RoleServicePermissions",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<long>(type: "bigint", nullable: false),
                    ServicePermissionId = table.Column<long>(type: "bigint", nullable: false),
                    CreationDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModificationDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UniqueIdentity = table.Column<string>(type: "nvarchar(450)", nullable: true, collation: "SQL_Latin1_General_CP1_CS_AS")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleServicePermissions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoleServicePermissions_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RoleServicePermissions_ServicePermissions_ServicePermissionId",
                        column: x => x.ServicePermissionId,
                        principalTable: "ServicePermissions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PersonalAccessTokens",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    CreationDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModificationDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UniqueIdentity = table.Column<string>(type: "nvarchar(450)", nullable: true, collation: "SQL_Latin1_General_CP1_CS_AS"),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonalAccessTokens", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PersonalAccessTokens_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserRoles",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<long>(type: "bigint", nullable: false),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    CreationDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModificationDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UniqueIdentity = table.Column<string>(type: "nvarchar(450)", nullable: true, collation: "SQL_Latin1_General_CP1_CS_AS")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserRoles_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserRoles_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "CreationDateTime", "DeletedDateTime", "IsDeleted", "ModificationDateTime", "Name", "UniqueIdentity" },
                values: new object[,]
                {
                    { 1L, new DateTime(2024, 1, 1, 1, 15, 32, 369, DateTimeKind.Local).AddTicks(8814), null, false, null, "Owner", null },
                    { 2L, new DateTime(2024, 1, 1, 1, 15, 32, 369, DateTimeKind.Local).AddTicks(8829), null, false, null, "SystemAdmin", null },
                    { 3L, new DateTime(2024, 1, 1, 1, 15, 32, 369, DateTimeKind.Local).AddTicks(8830), null, false, null, "SuperAdmin", null },
                    { 4L, new DateTime(2024, 1, 1, 1, 15, 32, 369, DateTimeKind.Local).AddTicks(8830), null, false, null, "HardWriter", null },
                    { 5L, new DateTime(2024, 1, 1, 1, 15, 32, 369, DateTimeKind.Local).AddTicks(8830), null, false, null, "Moderator", null },
                    { 6L, new DateTime(2024, 1, 1, 1, 15, 32, 369, DateTimeKind.Local).AddTicks(8831), null, false, null, "HardReader", null },
                    { 7L, new DateTime(2024, 1, 1, 1, 15, 32, 369, DateTimeKind.Local).AddTicks(8831), null, false, null, "Operator", null },
                    { 8L, new DateTime(2024, 1, 1, 1, 15, 32, 369, DateTimeKind.Local).AddTicks(8832), null, false, null, "EndUser", null },
                    { 9L, new DateTime(2024, 1, 1, 1, 15, 32, 369, DateTimeKind.Local).AddTicks(8832), null, false, null, "SoftWriter", null },
                    { 10L, new DateTime(2024, 1, 1, 1, 15, 32, 369, DateTimeKind.Local).AddTicks(8832), null, false, null, "SoftReader", null }
                });

            migrationBuilder.InsertData(
                table: "ServicePermissions",
                columns: new[] { "Id", "AccessType", "CreationDateTime", "DeletedDateTime", "IsDeleted", "MethodName", "MicroserviceName", "ModificationDateTime", "ServiceName", "UniqueIdentity" },
                values: new object[,]
                {
                    { 1L, (byte)6, new DateTime(2024, 1, 1, 1, 15, 32, 369, DateTimeKind.Local).AddTicks(9054), null, false, null, null, null, null, null },
                    { 2L, (byte)6, new DateTime(2024, 1, 1, 1, 15, 32, 369, DateTimeKind.Local).AddTicks(9054), null, false, "GetById", null, null, null, null },
                    { 3L, (byte)6, new DateTime(2024, 1, 1, 1, 15, 32, 369, DateTimeKind.Local).AddTicks(9055), null, false, "Filter", null, null, null, null },
                    { 4L, (byte)6, new DateTime(2024, 1, 1, 1, 15, 32, 369, DateTimeKind.Local).AddTicks(9055), null, false, "GetByUniqueIdentity", null, null, null, null },
                    { 5L, (byte)6, new DateTime(2024, 1, 1, 1, 15, 32, 369, DateTimeKind.Local).AddTicks(9055), null, false, "GetAllByUniqueIdentity", null, null, null, null },
                    { 6L, (byte)6, new DateTime(2024, 1, 1, 1, 15, 32, 369, DateTimeKind.Local).AddTicks(9056), null, false, "GetAll", null, null, null, null },
                    { 7L, (byte)6, new DateTime(2024, 1, 1, 1, 15, 32, 369, DateTimeKind.Local).AddTicks(9056), null, false, "Add", null, null, null, null },
                    { 8L, (byte)6, new DateTime(2024, 1, 1, 1, 15, 32, 369, DateTimeKind.Local).AddTicks(9057), null, false, "Update", null, null, null, null },
                    { 9L, (byte)6, new DateTime(2024, 1, 1, 1, 15, 32, 369, DateTimeKind.Local).AddTicks(9057), null, false, "SoftDeleteById", null, null, null, null },
                    { 10L, (byte)6, new DateTime(2024, 1, 1, 1, 15, 32, 369, DateTimeKind.Local).AddTicks(9057), null, false, "SoftDeleteBulkByIds", null, null, null, null },
                    { 11L, (byte)6, new DateTime(2024, 1, 1, 1, 15, 32, 369, DateTimeKind.Local).AddTicks(9058), null, false, "AddBulk", null, null, null, null },
                    { 12L, (byte)6, new DateTime(2024, 1, 1, 1, 15, 32, 369, DateTimeKind.Local).AddTicks(9058), null, false, "UpdateBulk", null, null, null, null },
                    { 13L, (byte)6, new DateTime(2024, 1, 1, 1, 15, 32, 369, DateTimeKind.Local).AddTicks(9058), null, false, "HardDeleteById", null, null, null, null },
                    { 14L, (byte)6, new DateTime(2024, 1, 1, 1, 15, 32, 369, DateTimeKind.Local).AddTicks(9059), null, false, "HardDeleteBulkByIds", null, null, null, null }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "BusinessUniqueIdentity", "CreationDateTime", "DeletedDateTime", "IsDeleted", "IsVerified", "ModificationDateTime", "Password", "UniqueIdentity", "UserName" },
                values: new object[] { 1L, "1-2", new DateTime(2024, 1, 1, 1, 15, 32, 369, DateTimeKind.Local).AddTicks(9112), null, false, true, null, null, "1-2", "Owner" });

            migrationBuilder.InsertData(
                table: "PersonalAccessTokens",
                columns: new[] { "Id", "CreationDateTime", "DeletedDateTime", "IsDeleted", "ModificationDateTime", "UniqueIdentity", "UserId", "Value" },
                values: new object[] { 1L, new DateTime(2024, 1, 1, 1, 15, 32, 369, DateTimeKind.Local).AddTicks(9139), null, false, null, null, 1L, "ownerpat" });

            migrationBuilder.InsertData(
                table: "RoleParentChildren",
                columns: new[] { "ChildId", "ParentId", "CreationDateTime", "DeletedDateTime", "IsDeleted", "ModificationDateTime", "UniqueIdentity" },
                values: new object[,]
                {
                    { 2L, 1L, new DateTime(2024, 1, 1, 1, 15, 32, 369, DateTimeKind.Local).AddTicks(8983), null, false, null, null },
                    { 2L, 3L, new DateTime(2024, 1, 1, 1, 15, 32, 369, DateTimeKind.Local).AddTicks(8984), null, false, null, null },
                    { 2L, 4L, new DateTime(2024, 1, 1, 1, 15, 32, 369, DateTimeKind.Local).AddTicks(8984), null, false, null, null },
                    { 3L, 5L, new DateTime(2024, 1, 1, 1, 15, 32, 369, DateTimeKind.Local).AddTicks(8985), null, false, null, null },
                    { 3L, 6L, new DateTime(2024, 1, 1, 1, 15, 32, 369, DateTimeKind.Local).AddTicks(8985), null, false, null, null },
                    { 5L, 7L, new DateTime(2024, 1, 1, 1, 15, 32, 369, DateTimeKind.Local).AddTicks(8985), null, false, null, null },
                    { 5L, 8L, new DateTime(2024, 1, 1, 1, 15, 32, 369, DateTimeKind.Local).AddTicks(8986), null, false, null, null },
                    { 2L, 9L, new DateTime(2024, 1, 1, 1, 15, 32, 369, DateTimeKind.Local).AddTicks(8987), null, false, null, null },
                    { 5L, 9L, new DateTime(2024, 1, 1, 1, 15, 32, 369, DateTimeKind.Local).AddTicks(8986), null, false, null, null },
                    { 5L, 10L, new DateTime(2024, 1, 1, 1, 15, 32, 369, DateTimeKind.Local).AddTicks(8986), null, false, null, null }
                });

            migrationBuilder.InsertData(
                table: "RoleServicePermissions",
                columns: new[] { "Id", "CreationDateTime", "DeletedDateTime", "IsDeleted", "ModificationDateTime", "RoleId", "ServicePermissionId", "UniqueIdentity" },
                values: new object[,]
                {
                    { 1L, new DateTime(2024, 1, 1, 1, 15, 32, 369, DateTimeKind.Local).AddTicks(9088), null, false, null, 1L, 1L, null },
                    { 2L, new DateTime(2024, 1, 1, 1, 15, 32, 369, DateTimeKind.Local).AddTicks(9088), null, false, null, 10L, 2L, null },
                    { 3L, new DateTime(2024, 1, 1, 1, 15, 32, 369, DateTimeKind.Local).AddTicks(9088), null, false, null, 10L, 3L, null },
                    { 4L, new DateTime(2024, 1, 1, 1, 15, 32, 369, DateTimeKind.Local).AddTicks(9089), null, false, null, 10L, 4L, null },
                    { 5L, new DateTime(2024, 1, 1, 1, 15, 32, 369, DateTimeKind.Local).AddTicks(9089), null, false, null, 6L, 5L, null },
                    { 6L, new DateTime(2024, 1, 1, 1, 15, 32, 369, DateTimeKind.Local).AddTicks(9090), null, false, null, 6L, 6L, null },
                    { 7L, new DateTime(2024, 1, 1, 1, 15, 32, 369, DateTimeKind.Local).AddTicks(9090), null, false, null, 9L, 7L, null },
                    { 8L, new DateTime(2024, 1, 1, 1, 15, 32, 369, DateTimeKind.Local).AddTicks(9090), null, false, null, 9L, 8L, null },
                    { 9L, new DateTime(2024, 1, 1, 1, 15, 32, 369, DateTimeKind.Local).AddTicks(9091), null, false, null, 9L, 9L, null },
                    { 10L, new DateTime(2024, 1, 1, 1, 15, 32, 369, DateTimeKind.Local).AddTicks(9091), null, false, null, 9L, 10L, null },
                    { 11L, new DateTime(2024, 1, 1, 1, 15, 32, 369, DateTimeKind.Local).AddTicks(9091), null, false, null, 9L, 11L, null },
                    { 12L, new DateTime(2024, 1, 1, 1, 15, 32, 369, DateTimeKind.Local).AddTicks(9092), null, false, null, 9L, 12L, null },
                    { 13L, new DateTime(2024, 1, 1, 1, 15, 32, 369, DateTimeKind.Local).AddTicks(9092), null, false, null, 4L, 13L, null },
                    { 14L, new DateTime(2024, 1, 1, 1, 15, 32, 369, DateTimeKind.Local).AddTicks(9092), null, false, null, 4L, 14L, null }
                });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "Id", "CreationDateTime", "DeletedDateTime", "IsDeleted", "ModificationDateTime", "RoleId", "UniqueIdentity", "UserId" },
                values: new object[] { 1L, new DateTime(2024, 1, 1, 1, 15, 32, 369, DateTimeKind.Local).AddTicks(9126), null, false, null, 1L, "1-2", 1L });

            migrationBuilder.CreateIndex(
                name: "IX_PersonalAccessTokens_CreationDateTime",
                table: "PersonalAccessTokens",
                column: "CreationDateTime");

            migrationBuilder.CreateIndex(
                name: "IX_PersonalAccessTokens_DeletedDateTime",
                table: "PersonalAccessTokens",
                column: "DeletedDateTime");

            migrationBuilder.CreateIndex(
                name: "IX_PersonalAccessTokens_IsDeleted",
                table: "PersonalAccessTokens",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_PersonalAccessTokens_ModificationDateTime",
                table: "PersonalAccessTokens",
                column: "ModificationDateTime");

            migrationBuilder.CreateIndex(
                name: "IX_PersonalAccessTokens_UniqueIdentity",
                table: "PersonalAccessTokens",
                column: "UniqueIdentity");

            migrationBuilder.CreateIndex(
                name: "IX_PersonalAccessTokens_UserId",
                table: "PersonalAccessTokens",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_RegisterUserDefaultRoles_CreationDateTime",
                table: "RegisterUserDefaultRoles",
                column: "CreationDateTime");

            migrationBuilder.CreateIndex(
                name: "IX_RegisterUserDefaultRoles_DeletedDateTime",
                table: "RegisterUserDefaultRoles",
                column: "DeletedDateTime");

            migrationBuilder.CreateIndex(
                name: "IX_RegisterUserDefaultRoles_IsDeleted",
                table: "RegisterUserDefaultRoles",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_RegisterUserDefaultRoles_ModificationDateTime",
                table: "RegisterUserDefaultRoles",
                column: "ModificationDateTime");

            migrationBuilder.CreateIndex(
                name: "IX_RegisterUserDefaultRoles_RoleId",
                table: "RegisterUserDefaultRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_RegisterUserDefaultRoles_UniqueIdentity",
                table: "RegisterUserDefaultRoles",
                column: "UniqueIdentity");

            migrationBuilder.CreateIndex(
                name: "IX_RoleParentChildren_ChildId",
                table: "RoleParentChildren",
                column: "ChildId");

            migrationBuilder.CreateIndex(
                name: "IX_RoleParentChildren_CreationDateTime",
                table: "RoleParentChildren",
                column: "CreationDateTime");

            migrationBuilder.CreateIndex(
                name: "IX_RoleParentChildren_DeletedDateTime",
                table: "RoleParentChildren",
                column: "DeletedDateTime");

            migrationBuilder.CreateIndex(
                name: "IX_RoleParentChildren_IsDeleted",
                table: "RoleParentChildren",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_RoleParentChildren_ModificationDateTime",
                table: "RoleParentChildren",
                column: "ModificationDateTime");

            migrationBuilder.CreateIndex(
                name: "IX_RoleParentChildren_UniqueIdentity",
                table: "RoleParentChildren",
                column: "UniqueIdentity");

            migrationBuilder.CreateIndex(
                name: "IX_Roles_CreationDateTime",
                table: "Roles",
                column: "CreationDateTime");

            migrationBuilder.CreateIndex(
                name: "IX_Roles_DeletedDateTime",
                table: "Roles",
                column: "DeletedDateTime");

            migrationBuilder.CreateIndex(
                name: "IX_Roles_IsDeleted",
                table: "Roles",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_Roles_ModificationDateTime",
                table: "Roles",
                column: "ModificationDateTime");

            migrationBuilder.CreateIndex(
                name: "IX_Roles_UniqueIdentity",
                table: "Roles",
                column: "UniqueIdentity");

            migrationBuilder.CreateIndex(
                name: "IX_RoleServicePermissions_CreationDateTime",
                table: "RoleServicePermissions",
                column: "CreationDateTime");

            migrationBuilder.CreateIndex(
                name: "IX_RoleServicePermissions_DeletedDateTime",
                table: "RoleServicePermissions",
                column: "DeletedDateTime");

            migrationBuilder.CreateIndex(
                name: "IX_RoleServicePermissions_IsDeleted",
                table: "RoleServicePermissions",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_RoleServicePermissions_ModificationDateTime",
                table: "RoleServicePermissions",
                column: "ModificationDateTime");

            migrationBuilder.CreateIndex(
                name: "IX_RoleServicePermissions_RoleId",
                table: "RoleServicePermissions",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_RoleServicePermissions_ServicePermissionId",
                table: "RoleServicePermissions",
                column: "ServicePermissionId");

            migrationBuilder.CreateIndex(
                name: "IX_RoleServicePermissions_UniqueIdentity",
                table: "RoleServicePermissions",
                column: "UniqueIdentity");

            migrationBuilder.CreateIndex(
                name: "IX_ServicePermissions_CreationDateTime",
                table: "ServicePermissions",
                column: "CreationDateTime");

            migrationBuilder.CreateIndex(
                name: "IX_ServicePermissions_DeletedDateTime",
                table: "ServicePermissions",
                column: "DeletedDateTime");

            migrationBuilder.CreateIndex(
                name: "IX_ServicePermissions_IsDeleted",
                table: "ServicePermissions",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_ServicePermissions_MethodName",
                table: "ServicePermissions",
                column: "MethodName");

            migrationBuilder.CreateIndex(
                name: "IX_ServicePermissions_MicroserviceName",
                table: "ServicePermissions",
                column: "MicroserviceName");

            migrationBuilder.CreateIndex(
                name: "IX_ServicePermissions_MicroserviceName_ServiceName_MethodName",
                table: "ServicePermissions",
                columns: new[] { "MicroserviceName", "ServiceName", "MethodName" },
                unique: true,
                filter: "[MicroserviceName] IS NOT NULL AND [ServiceName] IS NOT NULL AND [MethodName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_ServicePermissions_ModificationDateTime",
                table: "ServicePermissions",
                column: "ModificationDateTime");

            migrationBuilder.CreateIndex(
                name: "IX_ServicePermissions_ServiceName",
                table: "ServicePermissions",
                column: "ServiceName");

            migrationBuilder.CreateIndex(
                name: "IX_ServicePermissions_UniqueIdentity",
                table: "ServicePermissions",
                column: "UniqueIdentity");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_CreationDateTime",
                table: "UserRoles",
                column: "CreationDateTime");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_DeletedDateTime",
                table: "UserRoles",
                column: "DeletedDateTime");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_IsDeleted",
                table: "UserRoles",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_ModificationDateTime",
                table: "UserRoles",
                column: "ModificationDateTime");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_RoleId",
                table: "UserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_UniqueIdentity",
                table: "UserRoles",
                column: "UniqueIdentity");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_UserId",
                table: "UserRoles",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_BusinessUniqueIdentity_UserName",
                table: "Users",
                columns: new[] { "BusinessUniqueIdentity", "UserName" },
                unique: true,
                filter: "[BusinessUniqueIdentity] IS NOT NULL AND [UserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Users_CreationDateTime",
                table: "Users",
                column: "CreationDateTime");

            migrationBuilder.CreateIndex(
                name: "IX_Users_DeletedDateTime",
                table: "Users",
                column: "DeletedDateTime");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Id",
                table: "Users",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_IsDeleted",
                table: "Users",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_Users_ModificationDateTime",
                table: "Users",
                column: "ModificationDateTime");

            migrationBuilder.CreateIndex(
                name: "IX_Users_UniqueIdentity",
                table: "Users",
                column: "UniqueIdentity");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PersonalAccessTokens");

            migrationBuilder.DropTable(
                name: "RegisterUserDefaultRoles");

            migrationBuilder.DropTable(
                name: "RoleParentChildren");

            migrationBuilder.DropTable(
                name: "RoleServicePermissions");

            migrationBuilder.DropTable(
                name: "UserRoles");

            migrationBuilder.DropTable(
                name: "ServicePermissions");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
