using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MovieSharing.Migrations
{
    /// <inheritdoc />
    public partial class extendLid : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.AddColumn<string>(
                name: "Achternaam",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Voornaam",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1fd4582d-672e-46d2-b9da-fd9177eb8635", null, "user", "user" },
                    { "51feea52-4b72-40a9-a908-8f661b4e095e", null, "admin", "admin" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Achternaam", "ConcurrencyStamp", "Deleted", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "Voornaam" },
                values: new object[,]
                {
                    { "56548bf4-f4c3-4676-ab19-0456c050a767", 0, null, "5cccca43-8d05-47cf-98a7-be8a346e4896", false, "admin@test.com", true, false, null, "ADMIN@TEST.COM", "ADMIN@TEST.COM", "AQAAAAIAAYagAAAAENDiSn1z1iLj4n6sxoqAtG2jYt4NLuoRdtMOc6HoF28HuzFYxrNypCQd/D7RJ3C03A==", null, true, "3414ade4-4045-4d4b-82f7-7fa70034ded9", false, "admin@test.com", null },
                    { "6ca7ffdd-0d3d-4305-b92c-40e9223e320d", 0, null, "6f87605b-228b-4b64-a568-d85a0acb4ac7", false, "user1@test.com", true, false, null, "USER1@TEST.COM", "USER1@TEST.COM", "AQAAAAIAAYagAAAAEMhsmYvQPrmjBGYe+Lu0LZELgPZ/bMb2t7ls+efsyULd6JhMJ6/Ts3bEbv5JROvU7A==", null, false, "e23b8cd8-8ad6-437c-ad95-166735235517", false, "user1@test.com", null },
                    { "8e256a19-7e2b-4d7e-8da8-fd41fc245fb7", 0, null, "ede7b904-5e93-4f17-8ca9-83f6a5b6453d", false, "user2@test.com", true, false, null, "USER2@TEST.COM", "USER2@TEST.COM", "AQAAAAIAAYagAAAAEL1cRKm5Ib2u5xmcl1DC6zlMcUPTh7QN8WzkfYzQTtdSmb81Irwa9FUTiSzWmleaew==", null, false, "e3f07a7f-eb59-4fe4-90ad-78829ace6787", false, "user2@test.com", null }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "51feea52-4b72-40a9-a908-8f661b4e095e", "56548bf4-f4c3-4676-ab19-0456c050a767" },
                    { "1fd4582d-672e-46d2-b9da-fd9177eb8635", "6ca7ffdd-0d3d-4305-b92c-40e9223e320d" },
                    { "1fd4582d-672e-46d2-b9da-fd9177eb8635", "8e256a19-7e2b-4d7e-8da8-fd41fc245fb7" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "51feea52-4b72-40a9-a908-8f661b4e095e", "56548bf4-f4c3-4676-ab19-0456c050a767" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "1fd4582d-672e-46d2-b9da-fd9177eb8635", "6ca7ffdd-0d3d-4305-b92c-40e9223e320d" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "1fd4582d-672e-46d2-b9da-fd9177eb8635", "8e256a19-7e2b-4d7e-8da8-fd41fc245fb7" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1fd4582d-672e-46d2-b9da-fd9177eb8635");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "51feea52-4b72-40a9-a908-8f661b4e095e");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "56548bf4-f4c3-4676-ab19-0456c050a767");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6ca7ffdd-0d3d-4305-b92c-40e9223e320d");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e256a19-7e2b-4d7e-8da8-fd41fc245fb7");

            migrationBuilder.DropColumn(
                name: "Achternaam",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Voornaam",
                table: "AspNetUsers");

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
        }
    }
}
