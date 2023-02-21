using front.ViewModels;
using Common.Ui.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace front.Controllers;

public class AuthController : BaseController
{
    public AuthController(ILogger<BaseController> logger) : base(logger)
    {

    }

    public IActionResult Login(string returnUrl = null)
    {
        return View("Login", new LoginViewModel());
    }

    [HttpPost]
    public IActionResult Login(LoginViewModel viewModel)
    {
        if (!ModelState.IsValid)
        {
            return View(viewModel);
        }

        return View();
    }

}
