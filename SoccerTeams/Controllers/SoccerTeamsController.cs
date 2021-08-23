using Bogus;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace SoccerTeams.Controllers
{
    [ApiController]
    [Route("api/v1/teams")]
    public class SoccerTeamsController : ControllerBase
    {
        [HttpGet("{count}")]
        public IEnumerable<Team> Get(int count)
        {
            return new Faker<Team>()
                .RuleFor(x => x.Name, (f, u) => "FC " + f.Name.LastName())
                .RuleFor(x => x.Logo, (f, u) => f.Image.LoremFlickrUrl(width: 150, height: 150, keywords: "football"))
                .Generate(count);
        }
    }
}
