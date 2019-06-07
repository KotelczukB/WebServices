using FluentValidation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace ChuckNorrisService.Models
{
    public class Joke
    {
        public string Id { get; set; }

      /*  [Required]
        [StringLength(500, ErrorMessage ="To long Joke")]*/
        public string JokeText { get; set; }
        public IReadOnlyCollection<JokeCategory> Categories { get; set; }
    }    

    public class JokaValidator: AbstractValidator<Joke>
    {
        public JokaValidator()
        {
            RuleFor(joke => joke.JokeText).NotEmpty().MaximumLength(500);
        }
    }

    public class JokeDto
    {
        public string Id { get; set; }
        public string JokeText { get; set; }
        public string[] Category { get; set; }
    }
}
