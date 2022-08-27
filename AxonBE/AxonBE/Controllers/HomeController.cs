using AxonBE.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace AxonBE.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet("api/v1/state")]
        public async Task<IActionResult> State()
        {
            return Ok(new Response { data = new ResponseIndicentOfficer(), error = null});
        }
    }
}
