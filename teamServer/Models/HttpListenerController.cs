using Microsoft.AspNetCore.Mvc;
//https://docs.microsoft.com/en-us/aspnet/mvc/overview/older-versions-1/overview/understanding-models-views-and-controllers-cs

namespace teamServer.Models
{
    [Controller]
    public class HttpListenerController : ControllerBase
    {
        //IActionResult: Defines a contract that represents the result of an action method.
        public IActionResult HandleReuest()
        {
            return Ok("code works");
        }
    }
}
