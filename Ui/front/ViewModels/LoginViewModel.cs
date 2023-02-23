using System.ComponentModel.DataAnnotations;
using Base.ViewModels;

namespace front.ViewModels;

public class LoginViewModel : ViewModelBase<Guid>
{
    [Required(ErrorMessage = "{0} is required.", AllowEmptyStrings = false)]
    [StringLength(20, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 5)]
    public string Username { get; set; }

    [Required(ErrorMessage = "{0} is required.", AllowEmptyStrings = false)]
    [DataType(DataType.Password)]
    public string Password { get; set; }
    public string? ReturnUrl { get; set; }
}
