using Microsoft.AspNetCore.Mvc;
using teamServer.Services;
using teamServer.Models;
using ApiModels.Requests;

namespace teamServer.Controllers
{

    [ApiController]
    [Route("[Controller]")]
    public class ListenerControllers : ControllerBase
    {
        private readonly IListenerServices _listeners;

        public ListenerControllers(IListenerServices listeners)
        {
            _listeners = listeners;
        }


        [HttpGet]
        public IActionResult Getlisteners()
        {
            var listeners = _listeners.GetListeners();
            return Ok(listeners);
        }

        [HttpGet("{name}")]

        public IActionResult Getlistener(string name)
        {
            var listener = _listeners.GetListener(name);
            if (listener == null) return NotFound();
            return Ok(listener);
        }

        [HttpPost]

        public IActionResult StartListener([FromBody] StartHttpListenerRequests request)
        {
            var listener = new HttpListener(request.Name, request.BindPort);
            listener.start();

            _listeners.AddListener(listener);

            var root = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host}{HttpContext.Request.Path}";
            var path = $"{root}/{listener.Name}";
            return Created(path, listener);

        }

    }
}
