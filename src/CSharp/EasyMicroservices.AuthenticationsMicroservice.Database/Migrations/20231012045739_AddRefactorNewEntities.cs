using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EasyMicroservices.AuthenticationsMicroservice.Migrations
{
    /// <inheritdoc />
    public partial class AddRefactorNewEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "UniqueIdentity",
                table: "Users",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true,
                oldCollation: "SQL_Latin1_General_CP1_CS_AS");

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ParentId = table.Column<long>(type: "bigint", nullable: true),
                    CreationDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModificationDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UniqueIdentity = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Roles_Roles_ParentId",
                        column: x => x.ParentId,
                        principalTable: "Roles",
                        principalColumn: "Id");
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
                    UniqueIdentity = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    MicroserviceName = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    ServiceName = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    MethodName = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServicePermissions", x => x.Id);
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
                    UniqueIdentity = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserRoles_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRoles_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                    UniqueIdentity = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleServicePermissions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoleServicePermissions_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RoleServicePermissions_ServicePermissions_ServicePermissionId",
                        column: x => x.ServicePermissionId,
                        principalTable: "ServicePermissions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_Id",
                table: "Users",
                column: "Id",
                unique: true);

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
                name: "IX_Roles_ParentId",
                table: "Roles",
                column: "ParentId");

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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RoleServicePermissions");

            migrationBuilder.DropTable(
                name: "UserRoles");

            migrationBuilder.DropTable(
                name: "ServicePermissions");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropIndex(
                name: "IX_Users_Id",
                table: "Users");

            migrationBuilder.AlterColumn<string>(
                name: "UniqueIdentity",
                table: "Users",
                type: "nvarchar(450)",
                nullable: true,
                collation: "SQL_Latin1_General_CP1_CS_AS",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);
        }
    }
}
