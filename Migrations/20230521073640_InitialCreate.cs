using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace infeco.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Client",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nom = table.Column<string>(type: "text", nullable: true),
                    Prenom = table.Column<string>(type: "text", nullable: true),
                    NumeroTel = table.Column<string>(type: "text", nullable: true),
                    Mail = table.Column<string>(type: "text", nullable: true),
                    Solde = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Client", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Location",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nom = table.Column<string>(type: "text", nullable: true),
                    IdAppartement = table.Column<int>(type: "integer", nullable: true),
                    IdClient = table.Column<int>(type: "integer", nullable: true),
                    ClientId = table.Column<int>(type: "integer", nullable: true),
                    MontantLoyer = table.Column<float>(type: "real", nullable: false),
                    MontantDepotGarantie = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Location", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Location_Client_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Client",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Location_ClientId",
                table: "Location",
                column: "ClientId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Location");

            migrationBuilder.DropTable(
                name: "Client");
        }
    }
}
