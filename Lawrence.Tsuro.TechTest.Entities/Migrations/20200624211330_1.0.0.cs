using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Lawrence.Tsuro.TechTest.Entities.Migrations
{
    public partial class _100 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                                         "Addresses",
                                         table => new
                                                  {
                                                      AddressId = table.Column<Guid>(nullable: false),
                                                      Name      = table.Column<string>(maxLength: 250, nullable: false),
                                                      Surname   = table.Column<string>(maxLength: 250, nullable: false),
                                                      Company   = table.Column<string>(maxLength: 250, nullable: false),
                                                      Street    = table.Column<string>(maxLength: 250, nullable: false),
                                                      City      = table.Column<string>(maxLength: 250, nullable: false),
                                                      County    = table.Column<string>(maxLength: 250, nullable: false),
                                                      Postcode  = table.Column<string>(maxLength: 250, nullable: false),
                                                      Phone     = table.Column<string>(maxLength: 250, nullable: false),
                                                      Email     = table.Column<string>(maxLength: 250, nullable: false),
                                                      Updated   = table.Column<DateTime>(nullable: false)
                                                  },
                                         constraints: table => { table.PrimaryKey("PK_Addresses", x => x.AddressId); });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                                       "Addresses");
        }
    }
}