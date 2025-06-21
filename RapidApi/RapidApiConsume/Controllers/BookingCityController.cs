using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RapidApiConsume.Models;
using System.Net.Http;
using System;
using System.Threading.Tasks;

namespace RapidApiConsume.Controllers
{
    public class BookingCityController : Controller
    {
        public async Task<IActionResult> Index(string cityID)
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("$https://booking-com15.p.rapidapi.com/api/v1/hotels/searchHotels?dest_id=&search_type=CITY&arrival_date=2025-05-17&departure_date=2025-05-21&adults=1&children_age=0%2C17&room_qty=1&page_number=1&units=metric&temperature_unit=c&languagecode=en-us&currency_code=AED&location=US"),
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
                var values = JsonConvert.DeserializeObject<BookingApiViewModel>(body);
                return View(values.data.hotels); // .properties değil artık .hotels

            }
        }
       
    }
}