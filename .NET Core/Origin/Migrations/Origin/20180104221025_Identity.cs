using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Origin.Migrations.Origin
{
    public partial class Identity : Migration
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
                    OriginId = table.Column<Guid>(nullable: false),
                    Type = table.Column<string>(nullable: true)
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
                    Name = table.Column<string>(nullable: true),
                    OriginId = table.Column<Guid>(nullable: false),
                    RelatedOriginId = table.Column<Guid>(nullable: false),
                    Type = table.Column<string>(nullable: true)
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
                    OriginId = table.Column<Guid>(nullable: false),
                    RelatedOriginId = table.Column<Guid>(nullable: false),
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
                    Name = table.Column<string>(nullable: true),
                    OriginId = table.Column<Guid>(nullable: false),
                    RelatedOriginId = table.Column<Guid>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OR_Properties", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OR_RoleTables",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AllowCreate = table.Column<bool>(nullable: false),
                    AllowDelete = table.Column<bool>(nullable: false),
                    AllowRead = table.Column<bool>(nullable: false),
                    AllowUpdate = table.Column<bool>(nullable: false),
                    RoleId = table.Column<Guid>(nullable: false),
                    TableName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OR_RoleTables", x => x.Id);
                });
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
                name: "OR_RoleTables");
        }
    }
}
