﻿using System.Security.Claims;
using System.Threading.Tasks;
using EstelApi.Core.Seedwork.CoreCqrs.Notifications;
using EstelApi.CrossCutting.Identity.IdentityModels;
using EstelApi.CrossCutting.Identity.IdentityViewModels.AccountViewModels;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Estel.Services.Api.Controllers
{
    [Authorize]
    [ApiVersion("1.0")]
    public class AccountController : ApiController
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly ILogger logger;

        public AccountController(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            INotificationHandler<DomainNotification> notifications,
            ILoggerFactory loggerFactory,
            IMediator mediator) : base(notifications, mediator)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.logger = loggerFactory.CreateLogger<AccountController>();
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("account")]
        public async Task<IActionResult> Login([FromBody] LoginViewModel model)
        {
            if (!this.ModelState.IsValid)
            {
                this.NotifyModelStateErrors();
                return this.Response(model);
            }

            var result = await this.signInManager.PasswordSignInAsync(model.Email, model.Password, false, true);
            if (!result.Succeeded) this.NotifyError(result.ToString(), "Login failure");

            this.logger.LogInformation(1, "User logged in.");
            return this.Response(model);
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("account/register")]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (!this.ModelState.IsValid)
            {
                this.NotifyModelStateErrors();
                return this.Response(model);
            }

            var user = new ApplicationUser { UserName = model.Email, Email = model.Email };

            var result = await this.userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                // User claim for write customers data
                await this.userManager.AddClaimAsync(user, new Claim("Customers", "Write"));

                await this.signInManager.SignInAsync(user, false);
                this.logger.LogInformation(3, "User created a new account with password.");
                return this.Response(model);
            }

            this.AddIdentityErrors(result);
            return this.Response(model);
        }
    }
}