namespace Estel.Services.Api.Controllers.Identity
{
    using System.Security.Claims;
    using System.Threading.Tasks;

    using EstelApi.CrossCutting.Identity.IdentityModels;
    using EstelApi.CrossCutting.Identity.IdentityServices;
    using EstelApi.CrossCutting.Identity.IdentityViewModels.AccountViewModels;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;

    /// <inheritdoc />
    [Authorize]
    [ApiVersion("1.0")]
    [Route("identity/Account")]
    public class AccountController : ApiController
    {
        /// <summary>
        /// The user manager.
        /// </summary>
        private readonly ApplicationUserManager userManager;

        /// <summary>
        /// The sign in manager.
        /// </summary>
        private readonly ApplicationSignInManager signInManager;

        /// <summary>
        /// The logger.
        /// </summary>
        private readonly ILogger logger;

        /// <inheritdoc />
        public AccountController(
            ApplicationUserManager userManager,
            ApplicationSignInManager signInManager,
            ILoggerFactory loggerFactory)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.logger = loggerFactory.CreateLogger<AccountController>();
        }

        /// <summary>
        /// The login.
        /// </summary>
        /// <param name="model">
        /// The model.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        [HttpPost]
        [AllowAnonymous]
        [Route("account")]
        public async Task<IActionResult> Login([FromBody] LoginViewModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.ResponseBad("Validation error");
            }

            await this.signInManager.SignOutAsync();
            var result = await this.signInManager.PasswordSignInAsync(model.Email, model.Password, false, true);

            if (!result.Succeeded)
            {
                return this.ResponseBad("Login failure");
            }

            this.logger.LogInformation(1, "User logged in.");
            return this.Response();
        }

        /// <summary>
        /// The register.
        /// </summary>
        /// <param name="model">
        /// The model.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        [HttpPost]
        [AllowAnonymous]
        [Route("account/register")]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.ResponseBad("Validation error");
            }

            var user = new ApplicationUser { UserName = model.Email, Email = model.Email };
            var userInDb = await this.userManager.FindByNameAsync(model.Email);
            if (userInDb != null)
            {
                return this.ResponseBad("User already have in databse");
            }

            var result = await this.userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                // User claim for write customers data

                await this.userManager.AddToRoleAsync(user, "user");
                await this.userManager.AddClaimAsync(user, new Claim("Customers", "Read"));

                await this.signInManager.SignInAsync(user, false);
                this.logger.LogInformation(3, "User created a new account with password.");
                return this.Response(new
                {
                    result = true,
                    Name = user.UserName
                });
            }

            return this.ResponseBad("Create new User Failure");
        }


        [HttpPost("LogOff")]
        public async Task<IActionResult> LogOff()
        {
            // remove coocies
            await this.signInManager.SignOutAsync();
            this.logger.LogError(4, "User logged out.");
            return this.Response(new
            {
                result = true,
                message = "User logged out."
            });
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("account/ResetPassword")]
        public async Task<IActionResult> ResetPassword(ResetPasswordViewModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.ResponseBad("model error");
            }

            var user = await this.userManager.FindByEmailAsync(model.Email);
            if (user == null)
            {
                return this.ResponseBad("user null");
            }

            var result = await this.userManager.ResetPasswordAsync(user, model.Code, model.Password);
            if (result.Succeeded)
            {
                return this.Response(new
                {
                    result = true,
                    message = "Password was reseted"
                });
            }
            return this.ResponseBad("reset password Failure");
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("account/ForgotPassword")]
        public async Task<IActionResult> ForgotPassword(ForgotPasswordViewModel model)
        {
            if (this.ModelState.IsValid)
            {
                var user = await this.userManager.FindByEmailAsync(model.Email);

                // For more information on how to enable account confirmation and password reset please visit https://go.microsoft.com/fwlink/?LinkID=532713
                // Send an email with this link
                var code = await this.userManager.GeneratePasswordResetTokenAsync(user);
                return this.Response(new { result = true, resetToken = code });
            }
            return this.ResponseBad("ForgotPassword Failure");
        }
    }
}
