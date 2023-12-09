using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MovieSharing.Migrations
{
    /// <inheritdoc />
    public partial class AddedReservations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "9132c292-249e-4ca1-93e0-2c05c62bf03a", "ee34f99a-beb6-4643-97ca-c178e9e0ac78" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "8f597b58-0655-4b95-bfa2-5dce870a98b9", "f077b7c9-11a9-4109-b4a2-36644a5e4d47" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "9132c292-249e-4ca1-93e0-2c05c62bf03a", "f1637008-1e0b-46db-85d4-6aa8e3c9414e" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8f597b58-0655-4b95-bfa2-5dce870a98b9");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9132c292-249e-4ca1-93e0-2c05c62bf03a");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ee34f99a-beb6-4643-97ca-c178e9e0ac78");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f077b7c9-11a9-4109-b4a2-36644a5e4d47");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f1637008-1e0b-46db-85d4-6aa8e3c9414e");

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
                    { "3eb69d21-1ed0-4eeb-a6c1-4bbd2c8c4be0", null, "admin", "admin" },
                    { "919a472d-b11a-4637-bfc8-362e9989a690", null, "user", "user" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Deleted", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "26e4b8f8-51f0-4d93-ab7e-50d12260ba5a", 0, "c935c4c8-772c-4088-9715-d9a08191cdbb", false, "user2@test.com", true, false, null, "USER2@TEST.COM", "USER2@TEST.COM", "AQAAAAIAAYagAAAAEEmPUqI7kKPXJXm2ImvCZzlcWMRHDskXKKYriEVhn0qdcxg5wKvjLf/SVdq7BYDb1w==", null, false, "1b98e7c1-8b5c-4340-a524-0a7e2a3710d2", false, "user2@test.com" },
                    { "8f2cd04c-52e5-431e-87e4-fe1cf6caffbb", 0, "cfe3b4ed-114a-4d7a-9a2c-79de40e5316b", false, "admin@test.com", true, false, null, "ADMIN@TEST.COM", "ADMIN@TEST.COM", "AQAAAAIAAYagAAAAEB80YajJLGwP8qtoo1gL0D8g+tGfemCuScb4RFSmAPIgag0l/tgrLMG8P7KkXgb0UA==", null, true, "69c2a3f4-bfb0-4cb8-bc84-8d6a0c258bb1", false, "admin@test.com" },
                    { "fd44c952-48b5-467b-b59f-86af801b9f98", 0, "c5589be7-3df7-453d-b292-e36944069bf5", false, "user1@test.com", true, false, null, "USER1@TEST.COM", "USER1@TEST.COM", "AQAAAAIAAYagAAAAEPVMiFJk6Ib1dBeQehL8mURiwJ6w33SGv6YScQqwpQTNqoKe2H0El58q74mSldQ75A==", null, false, "c8422a14-6f26-456e-9e05-9c4b1c0416ff", false, "user1@test.com" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "919a472d-b11a-4637-bfc8-362e9989a690", "26e4b8f8-51f0-4d93-ab7e-50d12260ba5a" },
                    { "3eb69d21-1ed0-4eeb-a6c1-4bbd2c8c4be0", "8f2cd04c-52e5-431e-87e4-fe1cf6caffbb" },
                    { "919a472d-b11a-4637-bfc8-362e9989a690", "fd44c952-48b5-467b-b59f-86af801b9f98" }
                });

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
                name: "Reservatie");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "919a472d-b11a-4637-bfc8-362e9989a690", "26e4b8f8-51f0-4d93-ab7e-50d12260ba5a" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "3eb69d21-1ed0-4eeb-a6c1-4bbd2c8c4be0", "8f2cd04c-52e5-431e-87e4-fe1cf6caffbb" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "919a472d-b11a-4637-bfc8-362e9989a690", "fd44c952-48b5-467b-b59f-86af801b9f98" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3eb69d21-1ed0-4eeb-a6c1-4bbd2c8c4be0");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "919a472d-b11a-4637-bfc8-362e9989a690");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "26e4b8f8-51f0-4d93-ab7e-50d12260ba5a");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8f2cd04c-52e5-431e-87e4-fe1cf6caffbb");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "fd44c952-48b5-467b-b59f-86af801b9f98");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "8f597b58-0655-4b95-bfa2-5dce870a98b9", null, "admin", "admin" },
                    { "9132c292-249e-4ca1-93e0-2c05c62bf03a", null, "user", "user" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Deleted", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "ee34f99a-beb6-4643-97ca-c178e9e0ac78", 0, "62169828-d1b4-47eb-9e7a-8c4164e1d734", false, "user1@test.com", true, false, null, "USER1@TEST.COM", "USER1@TEST.COM", "AQAAAAIAAYagAAAAEEipDhByYJDWYOVBoLTQ0LezzfIavtPDtH1HLedNWxaYDhUyw7+ru7CbSnRAVb/w8w==", null, false, "c7d363ec-50db-4c46-acc9-b24fd801ebe3", false, "user1@test.com" },
                    { "f077b7c9-11a9-4109-b4a2-36644a5e4d47", 0, "1d6c844d-389e-4587-aa6b-4b656d52eece", false, "admin@test.com", true, false, null, "ADMIN@TEST.COM", "ADMIN@TEST.COM", "AQAAAAIAAYagAAAAEE9Gh8/p+fnRoWhShFfCoXnXX593LrEpfgMEBzXMC+xdBluSjxMKMBeEN4A8BZhhfQ==", null, true, "0810d019-435c-4889-bd14-e891829cf34b", false, "admin@test.com" },
                    { "f1637008-1e0b-46db-85d4-6aa8e3c9414e", 0, "d160b6e7-7ffb-4bac-8e26-e1ad25d5c233", false, "user2@test.com", true, false, null, "USER2@TEST.COM", "USER2@TEST.COM", "AQAAAAIAAYagAAAAEB4CLFzHGtFK2S3haM08h0QWwpmS1Rl8JJMUgz8wbiqSzJE4otDxUmYxCbx65z4adA==", null, false, "74138c4b-e4ce-48b5-8a32-c84a55bf727c", false, "user2@test.com" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "9132c292-249e-4ca1-93e0-2c05c62bf03a", "ee34f99a-beb6-4643-97ca-c178e9e0ac78" },
                    { "8f597b58-0655-4b95-bfa2-5dce870a98b9", "f077b7c9-11a9-4109-b4a2-36644a5e4d47" },
                    { "9132c292-249e-4ca1-93e0-2c05c62bf03a", "f1637008-1e0b-46db-85d4-6aa8e3c9414e" }
                });
        }
    }
}
