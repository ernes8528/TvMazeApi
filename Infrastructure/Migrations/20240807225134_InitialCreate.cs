using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Country",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Code = table.Column<string>(type: "TEXT", nullable: false),
                    Timezone = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Country", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DvdCountry",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    name = table.Column<string>(type: "TEXT", nullable: false),
                    code = table.Column<string>(type: "TEXT", nullable: false),
                    timezone = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DvdCountry", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Externals",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Tvrage = table.Column<int>(type: "INTEGER", nullable: true),
                    Thetvdb = table.Column<int>(type: "INTEGER", nullable: true),
                    Imdb = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Externals", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Image",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Medium = table.Column<string>(type: "TEXT", nullable: false),
                    Original = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Image", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PreviousEpisode",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Href = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PreviousEpisode", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Rating",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Average = table.Column<double>(type: "REAL", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rating", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Schedule",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Time = table.Column<string>(type: "TEXT", nullable: false),
                    Days = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Schedule", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Self",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Href = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Self", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Networks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    CountryId = table.Column<int>(type: "INTEGER", nullable: true),
                    OfficialSite = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Networks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Networks_Country_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Country",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "WebChannels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false),
                    name = table.Column<string>(type: "TEXT", nullable: false),
                    countryId = table.Column<int>(type: "INTEGER", nullable: true),
                    officialSite = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WebChannels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WebChannels_Country_countryId",
                        column: x => x.countryId,
                        principalTable: "Country",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Links",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    SelfId = table.Column<int>(type: "INTEGER", nullable: false),
                    PreviousEpisodeId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Links", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Links_PreviousEpisode_PreviousEpisodeId",
                        column: x => x.PreviousEpisodeId,
                        principalTable: "PreviousEpisode",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Links_Self_SelfId",
                        column: x => x.SelfId,
                        principalTable: "Self",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Shows",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false),
                    Url = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Type = table.Column<string>(type: "TEXT", nullable: false),
                    Language = table.Column<string>(type: "TEXT", nullable: false),
                    Genres = table.Column<string>(type: "TEXT", nullable: false),
                    Status = table.Column<string>(type: "TEXT", nullable: false),
                    Runtime = table.Column<int>(type: "INTEGER", nullable: true),
                    AverageRuntime = table.Column<int>(type: "INTEGER", nullable: true),
                    Premiered = table.Column<DateTime>(type: "TEXT", nullable: true),
                    Ended = table.Column<DateTime>(type: "TEXT", nullable: true),
                    OfficialSite = table.Column<string>(type: "TEXT", nullable: true),
                    ScheduleId = table.Column<int>(type: "INTEGER", nullable: true),
                    RatingId = table.Column<int>(type: "INTEGER", nullable: true),
                    Weight = table.Column<int>(type: "INTEGER", nullable: true),
                    NetworkId = table.Column<int>(type: "INTEGER", nullable: true),
                    WebChannelId = table.Column<int>(type: "INTEGER", nullable: true),
                    DvdCountryId = table.Column<int>(type: "INTEGER", nullable: true),
                    ExternalsId = table.Column<int>(type: "INTEGER", nullable: true),
                    ImageId = table.Column<int>(type: "INTEGER", nullable: true),
                    Summary = table.Column<string>(type: "TEXT", nullable: false),
                    Updated = table.Column<long>(type: "INTEGER", nullable: false),
                    LinksId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shows", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Shows_DvdCountry_DvdCountryId",
                        column: x => x.DvdCountryId,
                        principalTable: "DvdCountry",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Shows_Externals_ExternalsId",
                        column: x => x.ExternalsId,
                        principalTable: "Externals",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Shows_Image_ImageId",
                        column: x => x.ImageId,
                        principalTable: "Image",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Shows_Links_LinksId",
                        column: x => x.LinksId,
                        principalTable: "Links",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Shows_Networks_NetworkId",
                        column: x => x.NetworkId,
                        principalTable: "Networks",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Shows_Rating_RatingId",
                        column: x => x.RatingId,
                        principalTable: "Rating",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Shows_Schedule_ScheduleId",
                        column: x => x.ScheduleId,
                        principalTable: "Schedule",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Shows_WebChannels_WebChannelId",
                        column: x => x.WebChannelId,
                        principalTable: "WebChannels",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Links_PreviousEpisodeId",
                table: "Links",
                column: "PreviousEpisodeId");

            migrationBuilder.CreateIndex(
                name: "IX_Links_SelfId",
                table: "Links",
                column: "SelfId");

            migrationBuilder.CreateIndex(
                name: "IX_Networks_CountryId",
                table: "Networks",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Shows_DvdCountryId",
                table: "Shows",
                column: "DvdCountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Shows_ExternalsId",
                table: "Shows",
                column: "ExternalsId");

            migrationBuilder.CreateIndex(
                name: "IX_Shows_ImageId",
                table: "Shows",
                column: "ImageId");

            migrationBuilder.CreateIndex(
                name: "IX_Shows_LinksId",
                table: "Shows",
                column: "LinksId");

            migrationBuilder.CreateIndex(
                name: "IX_Shows_NetworkId",
                table: "Shows",
                column: "NetworkId");

            migrationBuilder.CreateIndex(
                name: "IX_Shows_RatingId",
                table: "Shows",
                column: "RatingId");

            migrationBuilder.CreateIndex(
                name: "IX_Shows_ScheduleId",
                table: "Shows",
                column: "ScheduleId");

            migrationBuilder.CreateIndex(
                name: "IX_Shows_WebChannelId",
                table: "Shows",
                column: "WebChannelId");

            migrationBuilder.CreateIndex(
                name: "IX_WebChannels_countryId",
                table: "WebChannels",
                column: "countryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Shows");

            migrationBuilder.DropTable(
                name: "DvdCountry");

            migrationBuilder.DropTable(
                name: "Externals");

            migrationBuilder.DropTable(
                name: "Image");

            migrationBuilder.DropTable(
                name: "Links");

            migrationBuilder.DropTable(
                name: "Networks");

            migrationBuilder.DropTable(
                name: "Rating");

            migrationBuilder.DropTable(
                name: "Schedule");

            migrationBuilder.DropTable(
                name: "WebChannels");

            migrationBuilder.DropTable(
                name: "PreviousEpisode");

            migrationBuilder.DropTable(
                name: "Self");

            migrationBuilder.DropTable(
                name: "Country");
        }
    }
}
