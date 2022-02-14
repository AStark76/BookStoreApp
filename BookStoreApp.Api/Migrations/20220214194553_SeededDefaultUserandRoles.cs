using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookStoreApp.Api.Migrations
{
    public partial class SeededDefaultUserandRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "91f5348a-772e-4e21-be2a-3217e4257193", "77d4c2e9-55e1-47d6-927a-053013152235", "Administrator", "ADMINISTRATOR" },
                    { "d0c2b008-5990-4ac0-8a2d-ae7deb4634dd", "cd46980e-d138-44a1-b23b-730cfb97f2a4", "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "34c86f35-08e4-4c8b-85fb-9d30f3eea4c6", 0, "2f628872-b7d4-43cb-9c4d-509d9a963a8d", "admin@bookstore.com", false, "System", "Admin", false, null, "ADMIN@BOOKSTORE.COM", "ADMIN@BOOKSTORE.COM", "AQAAAAEAACcQAAAAEDcOQBBhffBpgT5qNROPYmnah5hSceI9Iik+YZEWZ39Cm4g/pbi0+XP5iGzk8hOwmA==", null, false, "724e67ea-1443-4e9e-bb23-d6fc35612765", false, "admin@bookstore.com" },
                    { "8e5bf55f-4a47-4b9c-bf10-83dbb7472b7f", 0, "b99e87c1-ddf9-4820-a3fd-921ceeaa6ee4", "user@bookstore.com", false, "System", "User", false, null, "USER@BOOKSTORE.COM", "USER@BOOKSTORE.COM", "AQAAAAEAACcQAAAAEF1fZFz5Ilatc6ceXPrIJ+HReK9Ha/59+XEHFXEDIX2TaOVlS7nk2fqO8BWmzve/Bg==", null, false, "763d7b5c-48a1-4b23-8f40-cfaa8f27e458", false, "user@bookstore.com" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "91f5348a-772e-4e21-be2a-3217e4257193", "34c86f35-08e4-4c8b-85fb-9d30f3eea4c6" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "d0c2b008-5990-4ac0-8a2d-ae7deb4634dd", "8e5bf55f-4a47-4b9c-bf10-83dbb7472b7f" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "91f5348a-772e-4e21-be2a-3217e4257193", "34c86f35-08e4-4c8b-85fb-9d30f3eea4c6" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "d0c2b008-5990-4ac0-8a2d-ae7deb4634dd", "8e5bf55f-4a47-4b9c-bf10-83dbb7472b7f" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "91f5348a-772e-4e21-be2a-3217e4257193");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d0c2b008-5990-4ac0-8a2d-ae7deb4634dd");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "34c86f35-08e4-4c8b-85fb-9d30f3eea4c6");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e5bf55f-4a47-4b9c-bf10-83dbb7472b7f");
        }
    }
}
