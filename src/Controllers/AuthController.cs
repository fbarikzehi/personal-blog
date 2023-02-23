using blog.ViewModels;
using Base.Controllers;
using Microsoft.AspNetCore.Mvc;
using Data.Persistence;
using Utilities.Security.Encryption;
using Data.Model;

namespace blog.Controllers;

public class AuthController : BaseController
{
    public AuthController(ILogger<BaseController> logger) : base(logger)
    {

    }

    public IActionResult Login(string? returnUrl = null)
    {
        var command = new UserCommand();
        var user = command.Get(new UserModel { Username = "admin" });
        if (user == null)
            command.Create(new UserModel { Username = "admin", PasswordHash = Cryptographer.Hash("FbDev_1234!@#") });

        return View("Login", new LoginViewModel { ReturnUrl = returnUrl });
    }

    [HttpPost]
    public IActionResult Login(LoginViewModel viewModel)
    {
        if (!ModelState.IsValid)
        {
            // _logger.LogInformation(ModelState.Values.FirstOrDefault()?.Errors.FirstOrDefault()?.ErrorMessage);
            return View(viewModel);
        }
        var command = new UserCommand();
        var user = command.Get(new UserModel { Username = viewModel.Username });
        if (user == null)
        {
            viewModel.ChangeSuccess(false, "User not found");
            return View(viewModel);
        }
        else if (!Cryptographer.Verify(user.PasswordHash, viewModel.Password))
        {
            viewModel.ChangeSuccess(false, "Incorrect Password");
            return View(viewModel);
        }
        
        return Redirect("/admin/home/index");
    }

}
