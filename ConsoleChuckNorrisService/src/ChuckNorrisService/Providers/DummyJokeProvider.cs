using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ChuckNorrisService.Models;

namespace ChuckNorrisService.Providers
{
    class DummyJokeProvider : IJokeProvider
    {
        private List<Joke> jokesList;
        private static readonly Random random = new Random();

        public DummyJokeProvider()
        {
            jokesList = new List<Joke>();
            AddJoke("Chuck");
            AddJoke("Chuck Ned");
            AddJoke("Chuck Bad");
            AddJoke("Chuck Sad");


            void AddJoke(string jokeText) => jokesList.Add(Joke.CreateFrom(jokeText));
        }
        public Task<Joke> GetRandomJokeAsync()
        {
            return Task.FromResult(GetRandomJoke());

            //return Task.FromResult(new Joke
            //{
            //    Id = Guid.NewGuid().ToString(),
            //    Value = "No man is an island, except Chuck Norris.Chuck Norris is an island sometimes."
            //});

            //var joke = new Joke();
            //joke.Id = Guid.NewGuid().ToString();
            //joke.Value = "No man is an island, except Chuck Norris.Chuck Norris is an island sometimes.";

            //return Task.FromResult(joke);
        }

        private Joke GetRandomJoke() => jokesList[random.Next(0, jokesList.Count)];
    }
}
