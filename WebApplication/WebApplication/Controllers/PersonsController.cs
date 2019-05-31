using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication.Controllers
{
    [Route("api/[controller]")]
    public class PersonsController : ControllerBase
    {
        public List<Person> persons = new List<Person>();
        
        [HttpGet]
        public ActionResult<IEnumerable<Person>> GetAll()
        {
            if(ModelState.IsValid)
            {
                return persons; 
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpGet("{id}")]
        public ActionResult<Person> GetPersonById(Guid id)
        {
            return persons.Where(p => p.Id == id).FirstOrDefault();
        }

        [HttpPost]
        public ActionResult<Person> AddNewPerson([FromBody]Person person)
        {
            person.Id = Guid.NewGuid();
            persons.Add(person);
            return CreatedAtAction(nameof(GetPersonById), new { id = person.Id }, person);
        }
    }
}