using System.ComponentModel.DataAnnotations;

namespace EstelApi.CrossCutting.Identity.IdentityViewModels.AccountViewModels
{
    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}