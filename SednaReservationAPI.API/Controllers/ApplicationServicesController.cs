using Microsoft.AspNetCore.Mvc;
using SednaReservationAPI.Application.Abstractions.Services.Configurations;

namespace SednaReservationAPI.API.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class ApplicationServicesController : ControllerBase
    {

        readonly IApplicationService _applicationService;

        public ApplicationServicesController(IApplicationService applicationService)
        {
            _applicationService = applicationService;
        }

        [HttpGet]
        public IActionResult AuthorizeDefitionEndPoints()
        {
           var datas=  _applicationService.GetAuthorizeDefiniationEndPoints(typeof(Program));
            return Ok(datas);
        }
    }
}
