using Common.Controllers;
using front.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace front.Controllers;

public class AuthController:BaseController
{
    public AuthController(ILogger<BaseController> logger):base(logger)
    {   

    }

    public IActionResult Login()
    {
        return View("Login");
    }

    [HttpPost]
    public IActionResult Login(LoginViewModel viewModel)
    {

        
        return View();
    }

}
