using HawksNestGolf.NET.Shared.Interfaces.Repositories;
using HawksNestGolf.NET.Shared.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HawksNestGolf.NET.Server.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayersController : BaseDbResourceController<Player>
    {
        public PlayersController(ILogger<PlayersController> logger, IPlayersRepository repo): base(logger, repo)
        {

        }
    }
}
