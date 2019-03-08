namespace Estel.Services.Api.ViewModels
{
    using Microsoft.AspNetCore.Http;

    /// <summary>
    /// The view model wrapper.
    /// </summary>
    /// <typeparam name="TEntity">Wrapped Entity
    /// </typeparam>
    public class ViewModelWrapper<TEntity>
    {
        /// <summary>
        /// Gets or sets the file.
        /// </summary>
        public IFormFile File { get; set; }

        /// <summary>
        /// Gets or sets the view model.
        /// </summary>
        public TEntity ViewModel { get; set; }
    }
}
