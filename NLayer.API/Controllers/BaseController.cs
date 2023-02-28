using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NLayer.API.Filter;

namespace NLayer.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ValidateFilter]
    public class BaseController : ControllerBase
    {
    }
}
