using Microsoft.AspNetCore.Mvc;

namespace Core_Practical_16.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class PrintController : ControllerBase
    {
        private readonly ILogger<PrintController> _logger;

        public PrintController(ILogger<PrintController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public async Task Get()
        {
            // This is log of only PrintController Get action 
            _logger.LogInformation("Hello World API Print From End Point : " + HttpContext.Request.Path);
            _logger.LogInformation("Hello World API Request Method : " + HttpContext.Request.Method);
            _logger.LogInformation("Hello World API Request Host Name : " + HttpContext.Request.Host);
            _logger.LogInformation("Hello World API Request is Https( Use SSL ) ? : " + HttpContext.Request.IsHttps);
            _logger.LogInformation("Hello World API Request Protocol : " + HttpContext.Request.Protocol);
            await HttpContext.Response.WriteAsync("Hello World!");
        }

        [HttpGet]
        public string Demo()
        {
            return "Hello Demo Message Here!";
        }
    }
}