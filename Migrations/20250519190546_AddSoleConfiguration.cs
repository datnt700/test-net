using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    /// <inheritdoc />
    public partial class AddSoleConfiguration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SoleConfigurations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ConfigurationName = table.Column<string>(type: "TEXT", nullable: false),
                    SoleType = table.Column<string>(type: "TEXT", nullable: false),
                    Template = table.Column<string>(type: "TEXT", nullable: false),
                    ShoeSizeRange = table.Column<string>(type: "TEXT", nullable: false),
                    ClientCode = table.Column<string>(type: "TEXT", nullable: false),
                    EngravingText = table.Column<string>(type: "TEXT", nullable: false),
                    ContactEmail = table.Column<string>(type: "TEXT", nullable: false),
                    SendLinkToClient = table.Column<bool>(type: "INTEGER", nullable: false),
                    AllowPrototypeRequest = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SoleConfigurations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SoleLayers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    LayerType = table.Column<string>(type: "TEXT", nullable: false),
                    ElementName = table.Column<string>(type: "TEXT", nullable: false),
                    ElementCode = table.Column<string>(type: "TEXT", nullable: false),
                    MaterialName = table.Column<string>(type: "TEXT", nullable: false),
                    MaterialCode = table.Column<string>(type: "TEXT", nullable: false),
                    Density = table.Column<string>(type: "TEXT", nullable: false),
                    Thickness = table.Column<string>(type: "TEXT", nullable: false),
                    FinishType = table.Column<string>(type: "TEXT", nullable: false),
                    Comment = table.Column<string>(type: "TEXT", nullable: false),
                    SoleConfigurationId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SoleLayers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SoleLayers_SoleConfigurations_SoleConfigurationId",
                        column: x => x.SoleConfigurationId,
                        principalTable: "SoleConfigurations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SoleLayers_SoleConfigurationId",
                table: "SoleLayers",
                column: "SoleConfigurationId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SoleLayers");

            migrationBuilder.DropTable(
                name: "SoleConfigurations");
        }
    }
}
