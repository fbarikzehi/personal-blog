using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Common.Ui.Controllers;

public abstract class BaseController : Controller
{
    internal readonly ILogger<BaseController> _logger;

    protected BaseController(ILogger<BaseController> logger)
    {
        _logger = logger;
    }
}