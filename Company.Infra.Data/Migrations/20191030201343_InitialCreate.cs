using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Company.Infra.Data.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CREATED = table.Column<DateTime>(nullable: false),
                    LASTMODIFIED = table.Column<DateTime>(nullable: true),
                    NAME = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: false),
                    EMAIL = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: false),
                    BirthDate = table.Column<DateTime>(nullable: false),
                    PHONE = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Customer");
        }
    }
}
