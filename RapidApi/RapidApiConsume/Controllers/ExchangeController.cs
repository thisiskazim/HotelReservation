using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using RapidApiConsume.Models;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Linq;

namespace RapidApiConsume.Controllers
{
    public class ExchangeController : Controller
    {
        public async Task<IActionResult> Index()
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://booking-com15.p.rapidapi.com/api/v1/meta/getExchangeRates?base_currency=TRY"),
                Headers =
    {
        { "x-rapidapi-key", "20f4234472msh6f1aa5d52c53782p16454fjsnf3b656456ff4" },
        { "x-rapidapi-host", "booking-com15.p.rapidapi.com" },
    },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();

                // Deserialize edilmiştir
                var values = JsonConvert.DeserializeObject<ExchangeViewModel.Rootobject>(body);

                // Exchange rates dizisini almak
                var exchangeRates = values.data?.exchange_rates?.ToList();

                // Eğer exchange_rates verisi varsa, görüntüle
                if (exchangeRates != null)
                {
                    return View(exchangeRates);
                }
                else
                {
                    // Verisi gelmediyse, hata mesajı verebilirsiniz
                    return View("Error");
                }
            }
        }
    }
}
