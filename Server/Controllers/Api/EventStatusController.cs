using HawksNestGolf.NET.Shared.Interfaces.Repositories;
using HawksNestGolf.NET.Shared.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HawksNestGolf.NET.Server.Controllers.Api
{
    [Area("api")]
    [Route("[area]/[controller]")]
    [ApiController]
    public class EventStatusController : BaseDbResourceController<EventStatus>
    {
        public EventStatusController(ILogger<EventStatusController> logger, IEventStatusesRepository repo) : base(logger, repo)
        {
        }

    }
}
