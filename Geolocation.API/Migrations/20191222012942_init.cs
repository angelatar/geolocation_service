using System.Net;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Geolocation.API.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "public");

            migrationBuilder.CreateTable(
                name: "Blocks",
                schema: "public",
                columns: table => new
                {
                    Network = table.Column<IPAddress>(nullable: false),
                    GeonameId = table.Column<long>(nullable: true),
                    RegisteredCountryGeonameId = table.Column<long>(nullable: true),
                    RepresentedCountryGeonameId = table.Column<long>(nullable: true),
                    IsAnonymousProxy = table.Column<bool>(nullable: false),
                    IsSatelliteProvider = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Blocks", x => x.Network);
                });

            migrationBuilder.CreateTable(
                name: "Locations",
                schema: "public",
                columns: table => new
                {
                    GeonameId = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    LocalCode = table.Column<string>(nullable: true),
                    ContinentCode = table.Column<string>(nullable: true),
                    ContinentName = table.Column<string>(nullable: true),
                    CountryIsoCode = table.Column<string>(nullable: true),
                    CountryName = table.Column<string>(nullable: true),
                    IsInEuropeanUnion = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.GeonameId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Blocks",
                schema: "public");

            migrationBuilder.DropTable(
                name: "Locations",
                schema: "public");
        }
    }
}
