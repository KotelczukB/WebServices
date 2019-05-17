using ChuckNorrisService.Providers;
using System;
using System.IO;
using System.Threading.Tasks;

namespace ChuckNorrisService
{
    class Program
    {
        static async Task Main(string[] args)
        {
            DummyJokeProvider jokeProvider = new DummyJokeProvider();
            var joke = await jokeProvider.GetRandomJokeAsync();
            WriteJoke(joke);

            //FileSystemJokeProvider sysJoke = new FileSystemJokeProvider();
            //var jokes = sysJoke.Joke;
            //WriteJoke(jokes);

            await MakeAJoke();

            await MakeAJokeApi();



        }

        private static async Task MakeAJoke()
        {
            FileSystemJokeProvider jokeProvider = new FileSystemJokeProvider();
            var joke = await jokeProvider.GetRandomJokeAsync();
            WriteJoke(joke);
        }

        private static async Task MakeAJokeApi()
        {
            ApiJokeProvider jokeProvider = new ApiJokeProvider();
            var joke = await jokeProvider.GetRandomJokeAsync();
            WriteJoke(joke);
        }

        private static void WriteJoke(Models.Joke joke)
        {
            Console.WriteLine(new string('*', 20));
            Console.WriteLine(joke.Value);
            Console.WriteLine(new string('*', 20));
        }
    }
}
