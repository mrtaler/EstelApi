using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Estel.Services.Api.ViewModels
{
    public class ViewModelWrapper<TEntity>
    {

        public IFormFile File { get; set; }

        public TEntity ViewModel { get; set; }
    }
}
