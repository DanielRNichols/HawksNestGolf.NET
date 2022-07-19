using HawksNestGolf.NET.Shared.Interfaces.Repositories;
using HawksNestGolf.NET.Shared.Models;
using Microsoft.AspNetCore.Mvc;

namespace HawksNestGolf.NET.Server.Controllers.Api
{
    [ApiController]
    [Area("api")]
    [Route("[area]/[controller]")]
    public class TournamentsController : BaseDbResourceController<Tournament>
    {
        public TournamentsController(ILogger<TournamentsController> logger, ITournamentsRepository repo) : base(logger, repo)
        {
        }
    }
}