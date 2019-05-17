using ChuckNorrisService.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ChuckNorrisService.Providers
{
    class ApiJokeProvider : IJokeProvider
    {
        private static HttpClient http = new HttpClient() { BaseAddress = new Uri("https://api.chucknorris.io/jokes/") };
        public async Task<Joke> GetRandomJokeAsync()
        {
            var responseMessage = await http.GetAsync("random");
            responseMessage.EnsureSuccessStatusCode();

            return await responseMessage.Content.ReadAsAsync<Joke>();
        }
    }
}
