using Microsoft.AspNetCore.Http;

namespace Estel.Services.Api.ViewModels
{
    public class ViewModelWrapper<TEntity>
    {

        public IFormFile File { get; set; }

        public TEntity ViewModel { get; set; }
    }
}
