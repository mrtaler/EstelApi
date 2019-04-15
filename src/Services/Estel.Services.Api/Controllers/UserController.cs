namespace Estel.Services.Api.Controllers
{
    using System.Threading.Tasks;

    using EstelApi.Application.Dto;
    using EstelApi.Application.Interfaces;
    using EstelApi.Application.Specifications.FindByIdSpec;
    using EstelApi.Domain.DataAccessLayer.Context.CoreEntities.CustomerAgg;

    using MediatR;

    using Microsoft.AspNetCore.Mvc;

    // [Authorize]

    /// <summary>
    /// The customer controller.
    /// </summary>
    [ApiVersion("1.0")]
    public class UserController : ApiController
    {
        private IPersonService service;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserController"/> class.
        /// </summary>
        public UserController(IPersonService service)
        {
            this.service = service;
        }

        /// <summary>
        /// Work The getAll.
        /// </summary>
        /// <returns>
        /// The <see cref="IActionResult"/>.
        /// </returns>
        /// [AllowAnonymous]
        [HttpGet("GetAllCustomer")]
        public async Task<IActionResult> Get()
        {
            var result = await this.service.GetUsers();
            return this.Response(result);
        }

        /// <summary>
        /// The get.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <returns>
        /// The <see cref="IActionResult"/>.
        /// </returns>
        /// [AllowAnonymous]
        [HttpGet("GetCustomerById")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await this.service.GetUser(new FindUserById().SetId(id));
            return this.Response(result);
        }

        /// <summary>
        /// Create New Customer (work)
        /// </summary>
        /// <param name="dto">
        /// The command.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        /// [Authorize(Policy = "CanWriteCustomerData")]
        [HttpPost("CreateNewCustomer")]
        public async Task<IActionResult> Post([FromBody] CreateNewUserDto dto)
        {
            if (!this.ModelState.IsValid)
            {
                return this.ResponseBad("Validation error");
            }

            var resp = await this.service.CreateNewUser(dto);
            return this.Response(resp);
        }

        /// <summary>
        /// Update Customer. (work)
        /// </summary>
        /// <param name="dto">
        /// The command.
        /// </param>
        /// <returns>
        /// The <see cref="IActionResult"/>.
        /// </returns>
        /// [Authorize(Policy = "CanWriteCustomerData")]
        [HttpPut("UpdateCustomer")]
        public async Task<IActionResult> Put([FromBody] UpdateUserDto dto)
        {
            if (!this.ModelState.IsValid)
            {
                return this.ResponseBad("Validation error");
            }

            var resp = await this.service.UpdateUser(dto);
            return this.Response(resp);
        }

        /// <summary>
        /// The delete.
        /// </summary>
        /// <param name="id">
        /// current id
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        /// [Authorize(Policy = "CanRemoveCustomerData")]
        [HttpDelete("DeleteCustomerById")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await this.service.DeleteUser(new RemoveEntity<User>(id));
            return this.Response(result);
        }
    }
}