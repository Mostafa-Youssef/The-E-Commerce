using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities.Identity;
using Microsoft.AspNetCore.Identity;

namespace Infrastructure.Identity
{
    public class AppIdentityDbContextSeed
    {
        
        public static async Task SeedUserAsync (UserManager<AppUser> userManger)
        {
            if (!userManger.Users.Any())
            {
                var user = new AppUser 
                {
                    DisplayName = "Mostafa",
                    Email = "mostafa@test.com",
                    UserName = "mostafa@test.com",
                    Address = new Address
                    {
                        FirstName = "Mostafa",
                        LastName = "Mostafaity",
                        Street = "10 The Street",
                        City = "Helwan",
                        State = "cairo",
                        ZipCode = "90210"

                    }
                };

                await userManger.CreateAsync(user, "Pa$$w0rd");
            }
        }
    }
}