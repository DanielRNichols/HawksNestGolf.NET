using HawksNestGolf.NET.Shared.Interfaces.Repositories;
using HawksNestGolf.NET.Shared.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HawksNestGolf.NET.Server.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class GolfersController : BaseDbResourceController<Golfer>
    {
        public GolfersController(ILogger<GolfersController> logger, IGolfersRepository repo): base(logger, repo)
        {

        }
    }
}
