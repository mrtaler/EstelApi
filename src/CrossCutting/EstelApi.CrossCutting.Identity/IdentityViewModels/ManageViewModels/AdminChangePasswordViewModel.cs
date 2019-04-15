namespace EstelApi.CrossCutting.Identity.IdentityViewModels.ManageViewModels
{
    using System.ComponentModel.DataAnnotations;

    public class AdminChangePasswordViewModel
    {
        public string Id { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [DataType(DataType.Password)]
        [Display(Name = "Confirm new password")]
        [Compare("NewPassword", ErrorMessage = "The new password and confirmation password do not match.")]
        public string NewPassword { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Current password")]
        public string OldPassword { get; set; }
    }
}