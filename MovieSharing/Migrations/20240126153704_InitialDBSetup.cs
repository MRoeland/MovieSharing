using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MovieSharing.Migrations
{
    /// <inheritdoc />
    public partial class InitialDBSetup : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Deleted = table.Column<bool>(type: "bit", nullable: false),
                    Voornaam = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Achternaam = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Films",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Regisseur = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Acteurs = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Genre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Prijs = table.Column<float>(type: "real", nullable: false),
                    Deleted = table.Column<bool>(type: "bit", nullable: false),
                    Aantal = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Films", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reservatie",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LidId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FilmId = table.Column<int>(type: "int", nullable: false),
                    Deleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservatie", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reservatie_AspNetUsers_LidId",
                        column: x => x.LidId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reservatie_Films_FilmId",
                        column: x => x.FilmId,
                        principalTable: "Films",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "9ddff8a4-9607-4383-8b06-0c88a0803861", null, "admin", "admin" },
                    { "cb844563-7b72-4378-a625-5778e28aebb5", null, "user", "user" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Achternaam", "ConcurrencyStamp", "Deleted", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "Voornaam" },
                values: new object[,]
                {
                    { "11f8f1f1-3277-4f87-9080-f034d96bcfa3", 0, "Test2", "4bb064a5-33b5-436b-8b5a-3d9f83cab6d3", false, "user2@test.com", true, false, null, "USER2@TEST.COM", "USER2@TEST.COM", "AQAAAAIAAYagAAAAELkSe+dIsrux4gdeW216QEBN0EpRCd50mcYef97BqTZoAvhSRME1Y4H41lMXsReKfA==", null, false, "f0c239a1-3a1e-4239-b01a-9d7957c2cdf7", false, "user2@test.com", "User2" },
                    { "55ac23b8-1097-4cc0-98f7-33a4c4818df8", 0, "Test3", "bbb15a4d-2cf8-4d77-b34d-7dd4d0e5838b", false, "user3@test.com", true, false, null, "USER3@TEST.COM", "USER3@TEST.COM", "AQAAAAIAAYagAAAAEIgbxftgt6P5p8mecTkQJIO6URaB/1P2hrBUP51bTwiRbCmg+QjsUSyEUY9UZAY4wA==", null, false, "5a669129-6a5d-49be-a66f-764a4dc91ea6", false, "user3@test.com", "User3" },
                    { "776acc73-0cbb-46c6-8384-eb3acc416b1a", 0, "Test4", "179a7f88-d973-4148-b5f1-c80298e3bbf2", false, "user4@test.com", true, false, null, "USER4@TEST.COM", "USER4@TEST.COM", "AQAAAAIAAYagAAAAENRyQA4MncwoQNyUUFjLYkuR2GKQAeIWjXsgp+Kw4Qm3BXyceRuQLNyI5sZ9x/8gQw==", null, false, "40370986-981b-4fb0-be9c-cb7fcb7c39da", false, "user4@test.com", "User4" },
                    { "8d625998-9ca2-4817-9595-169281e013e1", 0, "Roeland", "ffbc2da4-e58e-4c0d-8c0c-ff81a5e38b43", false, "admin@test.com", true, false, null, "ADMIN@TEST.COM", "ADMIN@TEST.COM", "AQAAAAIAAYagAAAAEOBKRuQ2AH8oKjYZjQP8AtUTrTu+zYKUkZuqY1DA0fFt17K8EinWfZVQFpjREsL/dw==", null, true, "a212472b-15ed-4b71-9276-4e704d45703d", false, "admin@test.com", "Matthias" },
                    { "a2775054-fe49-4b9a-ba78-c29b32fef735", 0, "Roeland", "551b7114-14e6-4715-a8f6-6774755e146b", false, "user1@test.com", true, false, null, "USER1@TEST.COM", "USER1@TEST.COM", "AQAAAAIAAYagAAAAEB7nqVdOHVDeNR4VzJ86An/oxmkcY1i2RSBXWDNgh9NLpd7dyje46eX5UHPqwMwVkw==", null, false, "c6d9f715-0e7f-42bc-bc62-94685b40627f", false, "user1@test.com", "Robin" }
                });

            migrationBuilder.InsertData(
                table: "Films",
                columns: new[] { "Id", "Aantal", "Acteurs", "Deleted", "Genre", "Prijs", "Regisseur", "Title" },
                values: new object[,]
                {
                    { 1, 1, "Tom Cruise, Tim Robbins, Kelly McGillis", false, "Action", 19.99f, "Tony Scott", "Top Gun" },
                    { 2, 1, "Tom Cruise, Jennifer Connelly, Miles Teller", false, "Action", 19.99f, "Joseph Kosinski", "Maverick" },
                    { 3, 1, "Jason Statham, Melissa McCArthy, Rose Byrne, Jude Law", false, "Action", 19.99f, "Paul Feig", "Spy" },
                    { 4, 1, "Jay Baruchel, Gerard Butler, Christopher Mintz-Plasse, Craig Ferguson", false, "Animation", 19.99f, "Dean DeBlois, Chris Sanders", "How to train your dragon" },
                    { 5, 1, "Kelly Macdonald, Billy Connolly, Emma Thompson, Craig Ferguson", false, "Animation", 19.99f, "Mark Andrews, Brenda Chapman, Steve Purcell", "Brave" },
                    { 6, 1, "Vin Diesel, Paul Walker, Michelle Rodriguez", false, "Action", 19.99f, "Justin Lin", "Fast & Furious" },
                    { 7, 1, "Margot Robbie, Ryan Gosling, Issa Rae", false, "Fantasy", 19.99f, "Greta Gerwig", "Barbie" },
                    { 8, 1, "Patrick Swayze, Demi Moore, Whoopi Goldberg", false, "Drama", 19.99f, "Jerry Zucker", "Ghost" },
                    { 9, 1, "Mark Wahlberg, Mila Kunis, Seth MacFarlane", false, "Comedy", 19.99f, "Seth MacFarlane", "Ted" },
                    { 10, 1, "Ryan Reynolds, Morena Baccarin, T.J. Miller", false, "Comedy", 19.99f, "Tim Miller", "Deadpool" },
                    { 11, 1, "Leonardo DiCaprio, Jonah Hill, Margot Robbie", false, "Crime", 19.99f, "Martin Scorsese", "The wolf of Wallstreet" },
                    { 12, 1, "Julia Roberts, Richard Gere, Joan Cusack", false, "Romance", 19.99f, "Garry Marshall", "Runaway Bride" },
                    { 13, 1, "Patrick Swayze, Keanu Reeves, Gary Busey", false, "Crime", 19.99f, "Kathryn Bigelow", "Point Break" },
                    { 14, 1, "Keanu Reeves, Laurence Fishburne, Carrie-Anne Moss", false, "Sci-Fi", 19.99f, "Lana Wachowski, Lilly Wachowski", "The Matrix" },
                    { 15, 1, "Jason Momoa, Patrick Wilson, Yahya Abdul-Mateen II", false, "Fantasy", 19.99f, "James Wan", "Aquaman and the Lost Kingdom" },
                    { 16, 1, "Matthew McConaughey, Anne Hathaway, Jessica Chastain", false, "Sci-Fi", 19.99f, "Christopher Nolan", "Interstellar" },
                    { 17, 1, "Leonardo DiCaprio, Joseph Gordon-Levitt, Elliot Page", false, "Sci-Fi", 19.99f, "Christopher Nolan", "Inception" },
                    { 18, 1, "Mark Hamill, Harrison Ford, Carrie Fisher", false, "Adventure", 19.99f, "George Lucas", "Star Wars" },
                    { 19, 1, "Keanu Reeves, Michael Nyqvist, Alfie Allen", false, "Crime", 19.99f, "Chad Stahelski, David Leitch", "John Wick" },
                    { 20, 1, "Dennis Quaid, Jake Gyllenhaal, Emmy Rossum", false, "Sci-Fi", 19.99f, "Roland Emmerich", "The Day After Tomorrow" },
                    { 21, 1, "Jamie Foxx, Christoph Waltz, Leonardo DiCaprio", false, "Western", 19.99f, "Quentin Tarantino", "Django Unchained" },
                    { 22, 1, "Kevin Costner, Mary McDonnel, Graham Greene", false, "Western", 19.99f, "Kevin Costner", "Dances with Wolves" },
                    { 23, 1, "Tom Cruise, Jon Voight, Emmanuelle Béart", false, "Action", 19.99f, "Brian De Palma", "Mission Impossible" },
                    { 24, 1, "Keanu Reeves, Jennifer Connelly, Kathy Bates", false, "Sci-Fi", 19.99f, "Scott Derrickson", "The Day the Earth Stood still" },
                    { 25, 1, "Patrick Stewart, Hugh Jackman, Ian McKellen", false, "Sci-Fi", 19.99f, "Bryan Singer", "X-Men" },
                    { 26, 1, "Hugh Grant, Julia Roberts, Richard McCabe", false, "Romance", 19.99f, "Roger Michell", "Notting Hill" },
                    { 27, 1, "Morgan Freeman, Brad Pitt, Kevin Spacey", false, "Mystery", 19.99f, "David Fincher", "Se7en" },
                    { 28, 1, "Jason Biggs, Chris Klein, Thomas Ian Nicholas", false, "Comedy", 19.99f, "Paul Weitz, Chris Weitz", "American Pie" },
                    { 29, 1, "Liam Neeson, Ralph Fiennes, Ben Kingsley", false, "History", 19.99f, "Steven Spielberg", "Schindler's List" },
                    { 30, 1, "Tom Cruise, Rosamund Pike, Richard Jenkins", false, "Action", 19.99f, "Christopher McQuarrie", "Jack Reacher" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "cb844563-7b72-4378-a625-5778e28aebb5", "11f8f1f1-3277-4f87-9080-f034d96bcfa3" },
                    { "cb844563-7b72-4378-a625-5778e28aebb5", "55ac23b8-1097-4cc0-98f7-33a4c4818df8" },
                    { "cb844563-7b72-4378-a625-5778e28aebb5", "776acc73-0cbb-46c6-8384-eb3acc416b1a" },
                    { "9ddff8a4-9607-4383-8b06-0c88a0803861", "8d625998-9ca2-4817-9595-169281e013e1" },
                    { "cb844563-7b72-4378-a625-5778e28aebb5", "a2775054-fe49-4b9a-ba78-c29b32fef735" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Reservatie_FilmId",
                table: "Reservatie",
                column: "FilmId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservatie_LidId",
                table: "Reservatie",
                column: "LidId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Reservatie");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Films");
        }
    }
}
