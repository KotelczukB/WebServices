using System;

namespace ChuckNorrisService.Models
{
    public class Joke
    {
        public string Id { get; set; }
        public string Value { get; set; }

        public static Joke CreateFrom(string joke) => new Joke { Id = Guid.NewGuid().ToString(), Value = joke };
    }
}
