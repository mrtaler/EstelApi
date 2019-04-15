namespace Estel.Services.Api.Controllers.Identity
{
    using System.Threading.Tasks;

    using EstelApi.CrossCutting.Identity.IdentityModels;
    using EstelApi.CrossCutting.Identity.IdentityServices;
    using EstelApi.CrossCutting.Identity.IdentityViewModels.ManageViewModels;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    [Authorize]
    [ApiVersion("1.0")]
    [Route("identity/Manage")]
    public class ManageController : ApiController
    {
        private readonly ApplicationUserManager userManager;

        private readonly ApplicationSignInManager signInManager;


        public ManageController(ApplicationUserManager userManager, ApplicationSignInManager signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        [HttpPost("SetPassword")]
        public async Task<IActionResult> SetPassword(SetPasswordViewModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.ResponseBad("Cant change password for user");
            }

            var user = await this.GetCurrentUserAsync();
            if (user != null)
            {
                var result = await this.userManager.AddPasswordAsync(user, model.NewPassword);
                if (result.Succeeded)
                {
                    await this.signInManager.SignInAsync(user, isPersistent: false);
                    return this.Response(" password for user was changed");
                }
                
            }

            return this.ResponseBad("Cant change password for user");
        }

        private Task<ApplicationUser> GetCurrentUserAsync()
        {
            return this.userManager.GetUserAsync(this.HttpContext.User);
        }

        [HttpPost("ChangePassword")]

        public async Task<IActionResult> ChangePassword(ChangePasswordViewModel model)
        {
            if (this.ModelState.IsValid)
            {
                var user = await this.GetCurrentUserAsync();
                if (user != null)
                {
                    IdentityResult result =
                        await this.userManager.ChangePasswordAsync(user, model.OldPassword, model.NewPassword);
                    if (result.Succeeded)
                    {
                        return this.Response(" password for user was changed");
                    }
                  
                }
         
            }

            return this.ResponseBad("Cant change password for user");
        }
    }
}