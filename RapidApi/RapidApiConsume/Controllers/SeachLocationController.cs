using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using RapidApiConsume.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using static RapidApiConsume.Models.SearcLocationViewModel;
using Hotel = RapidApiConsume.Models.SearcLocationViewModel.Hotel;

namespace RapidApiConsume.Controllers
{
    public class SeachLocationController : Controller
    {
        public async Task<IActionResult> Index()
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://booking-com15.p.rapidapi.com/api/v1/hotels/searchHotels?dest_id=-2092174&search_type=CITY&arrival_date=2025-05-24&departure_date=2025-05-26&adults=1&children_age=0%2C17&room_qty=1&page_number=1&units=metric&temperature_unit=c&languagecode=en-us&currency_code=AED&location=US"),
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

                var hotelList = new List<Hotel>();

                var json = JObject.Parse(body);
                var hotels = json["data"]?["hotels"];

                if (hotels != null)
                {
                    foreach (var item in hotels)
                    {
                        var hotel = new Hotel
                        {
                            hotel_id = item["hotel_id"]?.Value<int>() ?? 0,
                            accessibilityLabel = item["accessibilityLabel"]?.ToString()
                        };
                        hotelList.Add(hotel);
                    }
                }

                return View(hotelList);
            }
        }
    }
}
