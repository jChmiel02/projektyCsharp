using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using NASAWebService.Base;

namespace NASAWebService.Controllers
{
    [ApiController]
    [Route("api/apod")]
    public class ApodController : ControllerBase
    {
        private readonly IApodService _apodService;

        public ApodController(IApodService apodService)
        {
            _apodService = apodService;
        }

        [HttpGet]
        public async Task<IActionResult> GetApod()
        {
            var result = await _apodService.GetApodAsync();
            return Ok(result);
        }
    }

}
