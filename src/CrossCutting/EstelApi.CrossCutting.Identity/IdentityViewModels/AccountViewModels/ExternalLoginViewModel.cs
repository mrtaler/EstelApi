using System.ComponentModel.DataAnnotations;

namespace EstelApi.CrossCutting.Identity.IdentityViewModels.AccountViewModels
{
    public class ExternalLoginViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
