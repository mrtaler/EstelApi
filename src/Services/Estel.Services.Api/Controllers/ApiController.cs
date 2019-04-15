namespace Estel.Services.Api.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    /// <inheritdoc />
    [ApiController]
    [Produces("application/json")]
    public abstract class ApiController : ControllerBase
    {
        /// <summary>
        /// The response.
        /// </summary>
        /// <param name="result">
        /// The result.
        /// </param>
        /// <returns>
        /// The <see cref="IActionResult"/>.
        /// </returns>
        protected new IActionResult Response(object result = null)
        {
            return this.Ok(new
            {
                success = true,
                data = result
            });
        }

        /// <summary>
        /// The response.
        /// </summary>
        /// <param name="result">
        /// The result.
        /// </param>
        /// <returns>
        /// The <see cref="IActionResult"/>.
        /// </returns>
        protected new IActionResult ResponseBad(string message)
        {
            return this.BadRequest(new
            {
                success = false,
                errors = message
            });
        }
    }
}
