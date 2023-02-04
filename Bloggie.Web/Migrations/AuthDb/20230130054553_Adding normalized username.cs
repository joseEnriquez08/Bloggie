using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bloggie.Web.Migrations.AuthDb
{
    /// <inheritdoc />
    public partial class Addingnormalizedusername : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d95aacb4-816f-44dc-a659-dc72ffa4bfe7",
                columns: new[] { "ConcurrencyStamp", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[] { "9e20ea40-d6c3-4d2b-8dd2-e141ada71232", "SUPERADMIN@BLOGGIE.COM", "SUPERADMIN@BLOGGIE.COM", "AQAAAAEAACcQAAAAEETALS6j/bZfM7YZarLpmx8MV/5tV+Aelfg8xKtWjdKQbOaQWEvahGyZRbvZsu3nBg==", "adfcaa82-9934-4a59-a4bb-46be7f0e72a2", "superadmin@bloggie.com" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d95aacb4-816f-44dc-a659-dc72ffa4bfe7",
                columns: new[] { "ConcurrencyStamp", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[] { "75ce9861-161e-4351-8ce4-68fea3aff474", null, null, "AQAAAAEAACcQAAAAEHz0lzZeVMdF3PxkDwzBkzuzeDXsPVVkdfvQxsPAPnPkm++jrQrb0WqZJtOs8p8sMg==", "0f1ce8a1-74bd-4475-b951-110a6007a58f", "supeadmin@bloggie.com" });
        }
    }
}
