using Microsoft.AspNetCore.Mvc;

[Route("Error/")]
[ApiController]
public class ErrorController : Controller
{
    [HttpGet("/Error")]
    public IActionResult NotFoundError()
    {
        return View("NotFoundPage");
    }
}
