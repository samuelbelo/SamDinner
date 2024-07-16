using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using SamDinner.Application;
using SamDinner.Application.Common.Errors;

namespace SamDinner.Api;

public class ErrorsController : ControllerBase
{
    [Route("/error")]
    public IActionResult Error() 
    {
        Exception? exception = HttpContext.Features.Get<IExceptionHandlerFeature>()?.Error;

        var (statusCode, message) = exception switch
        {
            IServiceException serviceException => ((int)serviceException.StatusCode, serviceException.ErrorMessage),
            _ => (500, "An error occurred")
        };
        return Problem(statusCode: statusCode, title: message);
    }
}
