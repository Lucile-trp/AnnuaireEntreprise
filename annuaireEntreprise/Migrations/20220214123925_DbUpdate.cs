using Microsoft.EntityFrameworkCore.Migrations;

namespace annuaireEntreprise.Migrations
{
    public partial class DbUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Services",
                columns: table => new
                {
                    Id_service = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name_service = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Services", x => x.Id_service);
                });

            migrationBuilder.CreateTable(
                name: "Sites",
                columns: table => new
                {
                    Id_site = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name_site = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sites", x => x.Id_site);
                });

            migrationBuilder.CreateTable(
                name: "Employes",
                columns: table => new
                {
                    Id_employe = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FirstName_employe = table.Column<string>(type: "TEXT", nullable: true),
                    LastName_employe = table.Column<string>(type: "TEXT", nullable: true),
                    PhoneNumber_employe = table.Column<string>(type: "TEXT", nullable: true),
                    FixeNumber_employe = table.Column<string>(type: "TEXT", nullable: true),
                    Email_employe = table.Column<string>(type: "TEXT", nullable: true),
                    role_employe = table.Column<bool>(type: "INTEGER", nullable: false),
                    Id_service = table.Column<string>(type: "TEXT", nullable: true),
                    ServiceId_service = table.Column<int>(type: "INTEGER", nullable: true),
                    Id_site = table.Column<string>(type: "TEXT", nullable: true),
                    SiteId_site = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employes", x => x.Id_employe);
                    table.ForeignKey(
                        name: "FK_Employes_Services_ServiceId_service",
                        column: x => x.ServiceId_service,
                        principalTable: "Services",
                        principalColumn: "Id_service",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Employes_Sites_SiteId_site",
                        column: x => x.SiteId_site,
                        principalTable: "Sites",
                        principalColumn: "Id_site",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Employes_ServiceId_service",
                table: "Employes",
                column: "ServiceId_service");

            migrationBuilder.CreateIndex(
                name: "IX_Employes_SiteId_site",
                table: "Employes",
                column: "SiteId_site");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employes");

            migrationBuilder.DropTable(
                name: "Services");

            migrationBuilder.DropTable(
                name: "Sites");
        }
    }
}
