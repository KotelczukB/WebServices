using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChuckNorrisService.Models;
using ChuckNorrisService.Providers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ChuckNorrisService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JokesController : ControllerBase
    {
        public FileSystemJokeProvider provider { get; }

        public JokesController(IJokeProvider provider)
        {
        }

        // GET: api/Jokes
        [HttpGet("random")]
        public async Task<ActionResult<Joke>> GetRandomJoke()
        {
            var joke = await provider.GetRandomJokeAsync();
            return joke;
        }
    }
}
