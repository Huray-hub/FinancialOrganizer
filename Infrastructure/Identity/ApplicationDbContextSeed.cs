using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Identity
{
    public class ApplicationDbContextSeed
    {
        public static async Task SeedAsync(UserManager<ApplicationUser> userManager, RoleManager<ApplicationRole> roleManager)
        {
            if (!roleManager.Roles.Any())
            {
                var roles = new List<ApplicationRole>
                {
                    new ApplicationRole("User"),
                    new ApplicationRole("Admin")
                };

                foreach (var role in roles)
                    await roleManager.CreateAsync(role);
            }

            if (!userManager.Users.Any())
            {
                var users = new List<ApplicationUser>
                {
                    new ApplicationUser
                    {
                        Id = "a",
                        UserName = "Panos",
                        DisplayName = "Panos Morepanos",
                        Email = "panos@gmail.com",
                        FirstName = "Panos",
                        LastName = "Morepanos",
                        DateOfBirth = new DateTime(1996,09,12),
                        Country = "Greece",
                    },
                    new ApplicationUser
                    {
                        Id = "b",
                        UserName = "Helen",
                        DisplayName = "Helen Morehelen",
                        Email = "helen@gmail.com",
                        FirstName = "Helen",
                        LastName = "Morehelen",
                        DateOfBirth = new DateTime(1994,04,2),
                        Country = "Greece"
                    },
                    new ApplicationUser
                    {
                        Id = "c",
                        UserName = "Michael",
                        DisplayName = "Michael MoreMichael",
                        Email = "michael@gmail.com",
                        FirstName = "Michael",
                        LastName = "MoreMichael",
                        DateOfBirth = new DateTime(1998, 01, 12),
                        Country = "Greece"
                    },
                    new ApplicationUser
                    {
                        Id="d",
                        UserName = "Antonia",
                        DisplayName = "Antonia MoreAntonia",
                        Email = "antonia@gmail.com",
                        FirstName = "Antonia",
                        LastName = "MoreAntonia",
                        DateOfBirth = new DateTime(1996,10,21),
                        Country = "Greece"
                    }
                };

                foreach (var user in users)
                {
                    await userManager.CreateAsync(user, "Ab123456!");
                    await userManager.AddToRoleAsync(user, "User");
                }
            }
        }
    }
}
