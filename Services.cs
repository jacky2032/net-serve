using Microsoft.AspNetCore.Mvc;

namespace Testing {
    [ApiController]
    [Route("api/test")]
    public class MyController:ControllerBase {
        [HttpGet]
        public IActionResult Get() {
            return Ok(new {
                Message ="Hello, World"
            });
        }
    }
}