using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Origin.Migrations
{
    public partial class Origin : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "OR_Forms",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    OriginId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OR_Forms", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OR_Inputs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FormOriginId = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    OriginId = table.Column<Guid>(nullable: false),
                    Type = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OR_Inputs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OR_ItemActions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FormOriginId = table.Column<Guid>(nullable: false),
                    ItemTypeOriginId = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    OriginId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OR_ItemActions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OR_Items",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    ItemTypeOriginId = table.Column<Guid>(nullable: false),
                    LastEditDate = table.Column<DateTime>(nullable: false),
                    OriginId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OR_Items", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OR_ItemTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    OriginId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OR_ItemTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OR_Lookups",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    OriginId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OR_Lookups", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OR_LookupValues",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    LookupOriginId = table.Column<Guid>(nullable: false),
                    OriginId = table.Column<Guid>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OR_LookupValues", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OR_Properties",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ItemTypeOriginId = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    OriginId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OR_Properties", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OR_PropertyValues",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ItemOriginId = table.Column<Guid>(nullable: false),
                    PropertyOriginId = table.Column<Guid>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OR_PropertyValues", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OR_Roles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OR_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OR_Users",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: false),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    OriginId = table.Column<Guid>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: false),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    SecurityStamp = table.Column<string>(nullable: true),
                    Surname = table.Column<string>(nullable: true),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OR_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OR_RoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true),
                    RoleId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OR_RoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OR_RoleClaims_OR_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "OR_Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OR_UserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OR_UserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OR_UserClaims_OR_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "OR_Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OR_UserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    UserId = table.Column<int>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OR_UserLogins", x => new { x.LoginProvider, x.ProviderKey, x.UserId });
                    table.UniqueConstraint("AK_OR_UserLogins_LoginProvider_ProviderKey", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_OR_UserLogins_OR_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "OR_Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OR_UserRoles",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false),
                    RoleId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OR_UserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_OR_UserRoles_OR_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "OR_Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OR_UserRoles_OR_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "OR_Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OR_UserTokens",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OR_UserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_OR_UserTokens_OR_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "OR_Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OR_RoleClaims_RoleId",
                table: "OR_RoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "OR_Roles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_OR_UserClaims_UserId",
                table: "OR_UserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_OR_UserLogins_UserId",
                table: "OR_UserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_OR_UserRoles_RoleId",
                table: "OR_UserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "OR_Users",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "OR_Users",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OR_Forms");

            migrationBuilder.DropTable(
                name: "OR_Inputs");

            migrationBuilder.DropTable(
                name: "OR_ItemActions");

            migrationBuilder.DropTable(
                name: "OR_Items");

            migrationBuilder.DropTable(
                name: "OR_ItemTypes");

            migrationBuilder.DropTable(
                name: "OR_Lookups");

            migrationBuilder.DropTable(
                name: "OR_LookupValues");

            migrationBuilder.DropTable(
                name: "OR_Properties");

            migrationBuilder.DropTable(
                name: "OR_PropertyValues");

            migrationBuilder.DropTable(
                name: "OR_RoleClaims");

            migrationBuilder.DropTable(
                name: "OR_UserClaims");

            migrationBuilder.DropTable(
                name: "OR_UserLogins");

            migrationBuilder.DropTable(
                name: "OR_UserRoles");

            migrationBuilder.DropTable(
                name: "OR_UserTokens");

            migrationBuilder.DropTable(
                name: "OR_Roles");

            migrationBuilder.DropTable(
                name: "OR_Users");
        }
    }
}
