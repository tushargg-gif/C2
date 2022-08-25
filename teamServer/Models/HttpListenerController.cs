using Microsoft.AspNetCore.Mvc;
//https://docs.microsoft.com/en-us/aspnet/mvc/overview/older-versions-1/overview/understanding-models-views-and-controllers-cs

/* SECURITY WARNING
 * Any public method in a controller is exposed as a controller action. You need to be careful about this. 
 * This means that any public method contained in a controller can be invoked by anyone with access to the 
 * Internet by entering the right URL into a browser.
 */

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
