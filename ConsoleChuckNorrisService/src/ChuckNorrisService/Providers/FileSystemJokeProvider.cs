using ChuckNorrisService.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace ChuckNorrisService.Providers
{
 
    class FileSystemJokeProvider : IJokeProvider
    {
        private static readonly Random random = new Random();
        private List<Joke> jokeList;
        public async Task<Joke> GetRandomJokeAsync()
        {
            await EnsureJokes();
            return jokeList[random.Next(0, jokeList.Count)];
        }

        private async Task EnsureJokes()
        {
            var path = Path.Combine("Data", "jokes.json");
            var jsonRaw = await File.ReadAllTextAsync(path);

            jokeList = JsonConvert.DeserializeObject<List<Joke>>(jsonRaw);
        }
    }
}
