using ChuckNorrisService.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using System.Threading.Tasks;

namespace ChuckNorrisService.Controllers
{
    [Route("api/[controller]")]
    public class JokesController : ControllerBase
    {
        private readonly IJokeRepository _jokeRepository;

        public JokesController(IJokeRepository jokeRepository)
        {
            _jokeRepository = jokeRepository;
        }

        // Getter
        [HttpGet("random")]
        public async Task<IActionResult> GetRandomJoke()
        {
            return Ok(await _jokeRepository.GetRandomJoke());
        }

        [HttpGet]
        public async Task<IActionResult> GetJokes()
        {
            return Ok(await _jokeRepository.GetAll());
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetJokeByID(string id)
        {
            var joke = Ok(await _jokeRepository.GetById(id));
            if(joke == null)
            {
                return NotFound();
            }
            return Ok(joke);
        }
        [HttpPost("create")]
        public async Task<IActionResult> PostNewJoke()
        {
            return Ok(await _jokeRepository.Add(new Joke()));
        }

        // Create 
        [HttpPost]
        public async Task<ActionResult<Joke>> Post([FromBody]Joke joke)
        {
            if(joke == null)
            {
                return BadRequest();
            }

            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var createdJoke = await _jokeRepository.Add(joke);
            return CreatedAtAction(nameof(GetJokeByID), new { id = joke.Id }, joke);
        } 

        // Update
        [HttpPut("{id}")]
        public async Task<ActionResult<Joke>> UpdateJoke(string id, [FromBody] Joke joke)
        {
            if( joke == null )
            {
                return BadRequest();
            }
            var exsists = await _jokeRepository.GetById(id);
            if(exsists == null)
                return NotFound();

            var updated = await _jokeRepository.Update(joke);
            return Ok(updated);
        }

        [HttpPatch("{id}")]
        public async Task<ActionResult<Joke>> UpdatePartJoke(string id, [FromBody] JsonPatchDocument<Joke> doc)
        {
            if (doc == null)
            {
                return BadRequest();
            }
            var exsists = await _jokeRepository.GetById(id);
            if (exsists == null)
                return NotFound();
            doc.ApplyTo(exsists);
            var updatedJoke = await _jokeRepository.Update(exsists);
            return Ok(updatedJoke);
        }

    }
}
