using common.ui.ViewModels;

namespace front.ViewModels;

public class LoginViewModel:ViewModelBase<Guid>
{
    public string  Username { get; set; }
    public string Password { get; set; }
}
