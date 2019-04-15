namespace Estel.Services.Api.Configurations
{
    using System;
    using System.Collections.Generic;
    using System.Security.Claims;
    using System.Threading.Tasks;

    using Autofac;

    using AutoMapper;

    using EstelApi.CrossCutting.Identity.IdentityModels;
    using EstelApi.CrossCutting.Identity.IdentityServices;

    using Microsoft.AspNetCore.Identity;
    using Microsoft.Extensions.DependencyInjection;

    /// <summary>
    /// The auto mapper setup.
    /// </summary>
    public static class IdentityInit
    {
        /// <summary>
        /// The add auto mapper setup.
        /// </summary>
        /// <param name="services">
        /// The services.
        /// </param>
        /// <exception cref="ArgumentNullException">if services is null
        /// </exception>
        public static async Task IdentityDataInit(IContainer container)
        {
            if (container is null)
            {
                throw new ArgumentNullException(nameof(container));
            }

            var userManager =
                container.Resolve<ApplicationUserManager>();
            var roleManager =
                container.Resolve<ApplicationRoleManager>();

            string adminEmail = "Admin@me.com";
            string password = "Admin";

            if (await roleManager.FindByNameAsync("admin") == null)
            {
                await roleManager.CreateAsync(new ApplicationRole("admin"));
            }

            if (await roleManager.FindByNameAsync("user") == null)
            {
                await roleManager.CreateAsync(new ApplicationRole("user"));
            }

            if (await userManager.FindByNameAsync(adminEmail) == null)
            {
                ApplicationUser admin = new ApplicationUser { Email = adminEmail, UserName = adminEmail, EmailConfirmed = true };
                IdentityResult result = await userManager.CreateAsync(admin, password);
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(admin, "admin");
                }
            }

            var users = new List<ApplicationUser>
                            {
                                new ApplicationUser
                                    {
                                        Email = "User1@me.com",
                                        UserName = "User1",
                                        EmailConfirmed = true,
                                        PhoneNumber = "5-53-53-56"
                                    },
                                new ApplicationUser
                                    {
                                        Email = "User2@me.com",
                                        UserName = "User2",
                                        EmailConfirmed = true,
                                        PhoneNumber = "5-53-53-56"
                                    },
                                new ApplicationUser
                                    {
                                        Email = "User3@me.com",
                                        UserName = "User3",
                                        EmailConfirmed = true,
                                        PhoneNumber = "5-53-53-56"
                                    }
                            };
            foreach (var item in users)
            {
                IdentityResult result1 = await userManager.CreateAsync(item, item.Email);
                if (result1.Succeeded)
                {
                    await userManager.AddToRoleAsync(item, "user");
                }
            }
        }
    }
}
