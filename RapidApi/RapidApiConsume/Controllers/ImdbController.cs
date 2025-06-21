using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net.Http;
using System;
using System.Threading.Tasks;
using RapidApiConsume.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace RapidApiConsume.Controllers
{
    public class ImdbController : Controller
    {
        public async Task<IActionResult> Index()
        {
            List<ApiMovieViewModel> apiMovieViewModels = new List<ApiMovieViewModel>();

            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri("https://imdb-top-1000-movies-series.p.rapidapi.com/byrating"),
                Headers =
                {
                    { "x-rapidapi-key", "20f4234472msh6f1aa5d52c53782p16454fjsnf3b656456ff4" },
                    { "x-rapidapi-host", "imdb-top-1000-movies-series.p.rapidapi.com" },
                },
                Content = new FormUrlEncodedContent(new Dictionary<string, string>
                {
                    { "above", "8.1" },
                    { "under", "8.2" },
                }),
            };

            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();

                // result dizisini ayıkla
                JObject jsonObject = JObject.Parse(body);
                JToken resultToken = jsonObject["result"];

                apiMovieViewModels = JsonConvert.DeserializeObject<List<ApiMovieViewModel>>(resultToken.ToString());

                return View(apiMovieViewModels);
            }
        }
    }
}
