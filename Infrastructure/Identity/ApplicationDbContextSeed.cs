using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Identity
{
    public class ApplicationDbContextSeed
    {
        public static async Task SeedAsync(UserManager<ApplicationUser> userManager)
        {
            if (!userManager.Users.Any())
            {
                var users = new List<ApplicationUser>
                {
                    new ApplicationUser
                    {
                        Id = "a",
                        UserName = "Panos",
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
                }
            }
        }
    }
}
