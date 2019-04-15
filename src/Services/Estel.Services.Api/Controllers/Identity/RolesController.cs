namespace Estel.Services.Api.Controllers.Identity
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using EstelApi.CrossCutting.Identity.IdentityModels;
    using EstelApi.CrossCutting.Identity.IdentityServices;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    [Route("identity/Roles")]
    [ApiVersion("1.0")]
    [Authorize(Roles = "admin")]
    public class RolesController : ApiController
    {
        private readonly ApplicationRoleManager roleManager;

        private readonly ApplicationUserManager userManager;

        public RolesController(ApplicationRoleManager roleManager, ApplicationUserManager userManager)
        {
            this.roleManager = roleManager;
            this.userManager = userManager;
        }

        [HttpPost]
        [Route("Role")]
        public async Task<IActionResult> Create(string name)
        {
            if (!string.IsNullOrEmpty(name))
            {
                IdentityResult result = await this.roleManager.CreateAsync(new ApplicationRole(name));
                if (result.Succeeded)
                {
                    return this.Response("New role was created");
                }
            }

            return this.ResponseBad("CreateRole Failure");
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(string name)
        {
            ApplicationRole role = await this.roleManager.FindByNameAsync(name);
            if (role != null)
            {
                IdentityResult result = await this.roleManager.DeleteAsync(role);
                return this.Response("role was deletetd");
            }

            return this.ResponseBad("Delelte role have erros");
        }

        [HttpPost]
        [Route("UserRoles")]
        public async Task<IActionResult> Edit(string userId, IEnumerable<string> roles)
        {
            // �������� ������������
            ApplicationUser user = await this.userManager.FindByIdAsync(userId);
            if (user != null)
            {
                var userRoles = await this.userManager.GetRolesAsync(user);
                var allRoles = this.roleManager.Roles.ToList();

                var addedRoles = roles.Except(userRoles);
                var removedRoles = userRoles.Except(roles);

                await this.userManager.AddToRolesAsync(user, addedRoles);
                await this.userManager.RemoveFromRolesAsync(user, removedRoles);
                return this.Response("User role was changed");
            }

            return this.Response("User role not changed");
        }

        [HttpGet]
        [Route("UserRoles")]
        public async Task<IActionResult> GetRoles(string userId)
        {
            ApplicationUser user = await this.userManager.FindByIdAsync(userId);
            if (user != null)
            {
                var userRoles = await this.userManager.GetRolesAsync(user);
                var allRoles = this.roleManager.Roles.ToList();

                var changeRoleModel = new
                                          {
                                              UserId = user.Id,
                                              UserEmail = user.Email,
                                              UserRoles = userRoles,
                                              AllRoles = allRoles
                                          };

                return this.Response(new
                                         {
                                             message = "model For change role",
                                             model = changeRoleModel
                                         });
            }

            return this.Response("Cant generate model for change role");
        }
    }
}