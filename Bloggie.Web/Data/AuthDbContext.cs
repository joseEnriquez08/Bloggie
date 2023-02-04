using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Bloggie.Web.Data
{
    public class AuthDbContext : IdentityDbContext
    {
        public AuthDbContext(DbContextOptions<AuthDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            var superAdminRoleID = "089ad120 - 6433 - 423e-9909 - 8e9589612c21";
            var adminRoleId = "82b156c2-50d4-400f-9551-e2318b4dab9d";
            var userId = "80741911-397c-42fc-b74a-3267e7af669d";

            // Seed Roles (User, Admin, Super Admin
            var roles = new List<IdentityRole>
            {
                new IdentityRole()
                {
                    Name = "SuperAdmin",
                    NormalizedName = "SuperAdmin",
                    Id = superAdminRoleID,
                    ConcurrencyStamp = superAdminRoleID
                },

                new IdentityRole()
                {
                    Name = "Admin",
                    NormalizedName = "Admin",
                    Id = adminRoleId,
                    ConcurrencyStamp = adminRoleId
                },

                new IdentityRole()
                {
                    Name = "User",
                    NormalizedName = "User",
                    Id = userId,
                    ConcurrencyStamp = userId
                }
            };

            //through this line, data will be seeded when i run migrations
            builder.Entity<IdentityRole>().HasData(roles);


            //Seed Super Admin User 
            var superAdminId = "d95aacb4-816f-44dc-a659-dc72ffa4bfe7";
            var superAdminUser = new IdentityUser()
            {
                Id = superAdminId,
                UserName = "superadmin@bloggie.com",
                Email = "superadmin@bloggie.com",
                NormalizedEmail = "superadmin@bloggie.com".ToUpper(),
                NormalizedUserName = "superadmin@bloggie.com".ToUpper()
            };

            superAdminUser.PasswordHash = new PasswordHasher<IdentityUser>()
                .HashPassword(superAdminUser, "superadmin123");

            builder.Entity<IdentityUser>().HasData(superAdminUser);

            ///Add all roles to super admin user
            var superAdminRoles = new List<IdentityUserRole<string>>()
            {
                new IdentityUserRole<string>
                {
                    RoleId = superAdminRoleID,
                    UserId = superAdminId
                },

                new IdentityUserRole<string>
                {
                    RoleId = adminRoleId,
                    UserId = superAdminId
                },
                new IdentityUserRole<string>
                {
                    RoleId = userId,
                    UserId = superAdminId
                },

            };

            builder.Entity<IdentityUserRole<string>>().HasData(superAdminRoles);

        }
    }
}
