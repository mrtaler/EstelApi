namespace Estel.Services.Api.Controllers.Identity
{
    using System.Linq;
    using System.Security.Claims;
    using System.Threading.Tasks;

    using EstelApi.CrossCutting.Identity.IdentityModels;
    using EstelApi.CrossCutting.Identity.IdentityServices;
    using EstelApi.CrossCutting.Identity.IdentityViewModels.AccountViewModels;
    using EstelApi.CrossCutting.Identity.IdentityViewModels.ManageViewModels;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    [Authorize]
    [ApiVersion("1.0")]
    [Route("identity/Users")]
    public class UsersController : ApiController
    {
        private readonly ApplicationUserManager userManager;
   

        public UsersController(ApplicationUserManager userManager)
        {
            this.userManager = userManager;
         }

        [Authorize(Roles = "admin")]
        [HttpGet]
        public async Task<IActionResult> Details()
        {

            var user = this.userManager.Users.ToList();
            if (user == null)
            {
                return this.NotFound();
            }

            return this.Response(user);
        }


        [Authorize(Roles = "admin")]
        [HttpGet]
        public async Task<IActionResult> Details(string id)
        {

            var user = await this.userManager.FindByIdAsync(id);
            if (user == null)
            {
                return this.NotFound();
            }

            return this.Response(user);
        }

        [Authorize(Roles = "admin")]
        [HttpPost]
        public async Task<IActionResult> Create(CreateUserViewModel model)
        {
            if (this.ModelState.IsValid)
            {
                var user = new ApplicationUser { Email = model.Email, UserName = model.Email };
                var result = await this.userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    await this.userManager.AddToRoleAsync(user, "user");
                    await this.userManager.AddClaimAsync(user, new Claim("Customers", "Read"));
                    return this.Response(new
                                             {
                                                 result = true,
                                                 Name = user.UserName
                                             });
                }
             
            }

            return this.ResponseBad("New user not created");
        }

        [Authorize(Roles = "admin")]
        [HttpDelete]
        public async Task<IActionResult> Delete(string id)
        {
            var user = await this.userManager.FindByIdAsync(id);
            if (user != null)
            {
                IdentityResult result = await this.userManager.DeleteAsync(user);
                return this.Response("User was deleted");
            }

            return this.ResponseBad("Cant delete user");
        }

        [Authorize(Roles = "admin")]
        [HttpPost]
        public async Task<IActionResult> ChangePassword(AdminChangePasswordViewModel model)
        {
            if (this.ModelState.IsValid)
            {
                var user = await this.userManager.FindByIdAsync(model.Id);
                if (user != null)
                {
                    IdentityResult result =
                        await this.userManager.ChangePasswordAsync(user, model.OldPassword, model.NewPassword);
                    if (result.Succeeded)
                    {
                        return this.Response("password was changed");
                    }
                }
               
            }

            return this.ResponseBad("Cant change password for user");
        }
    }
}