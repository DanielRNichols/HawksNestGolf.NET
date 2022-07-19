using HawksNestGolf.NET.Shared.Interfaces.Repositories;
using HawksNestGolf.NET.Shared.Models;
using Microsoft.AspNetCore.Mvc;

namespace HawksNestGolf.NET.Server.Controllers.Api
{
    [ApiController]
    [Area("api")]
    [Route("[area]/[controller]")]
    public class BetsController : BaseDbResourceController<Bet>
    {
        public BetsController(ILogger<BetsController> logger, IBetsRepository repo) : base(logger, repo)
        {
        }
    }
}