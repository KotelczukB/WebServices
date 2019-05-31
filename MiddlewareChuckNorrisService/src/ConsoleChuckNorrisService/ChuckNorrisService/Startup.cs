using ChuckNorrisService.Providers;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ChuckNorrisService
{
    public class Startup
    {
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            var provider = new FileSystemJokeProvider();

            if(env.IsDevelopment())
            {
                app.Use(async (context, next) =>
                { 
                    await Task.Delay(TimeSpan.FromSeconds(2));
                    await next();
                });

            }

            app.Map("api/jokes/random", jokeBranch =>
            {
                jokeBranch.Run(async context =>
                {
                    var joke = await provider.GetRandomJokeAsync();
                    var raw = JsonConvert.SerializeObject(joke);
                    context.Response.StatusCode = (int)HttpStatusCode.OK;
                    await context.Response.WriteAsync(raw);
                });
            });


            app.Run(async context =>
            {
                context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                await context.Response.WriteAsync("False Api");
            });
        }
     }
}
