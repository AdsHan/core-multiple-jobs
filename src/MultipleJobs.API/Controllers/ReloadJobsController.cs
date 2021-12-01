using Microsoft.AspNetCore.Mvc;
using MultipleJobs.API.Services;
using System.Threading.Tasks;

namespace MultipleJobs.API.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class ReloadJobsController : ControllerBase
    {

        IImportBackgroundService _reload;
        public ReloadJobsController(IImportBackgroundService reload)
        {
            _reload = reload;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {

            await _reload.StopJobs();

            await Task.Delay(5000);

            await _reload.StartJobs();
            return Ok();

        }
    }
}
