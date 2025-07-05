using System.Linq;
using HotelProjectWebUI.Dtos.BookingDto;
using HotelProjectWebUI.Dtos.SubscribeDto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;

namespace HotelProjectWebUI.Controllers
{
    [AllowAnonymous]
    public class BookingController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _configuration;
        private readonly string _apiBaseUrl;

        public BookingController(IHttpClientFactory httpClientFactory, IConfiguration configuration)
        {
            _httpClientFactory = httpClientFactory;
            _configuration = configuration;
            _apiBaseUrl = _configuration["ApiBaseUrl"];
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet] 
        public PartialViewResult AddBooking()
        {
            return PartialView();

        }       
        [HttpPost] 
        public async Task<IActionResult> AddBooking(CreateBookingDto createBookingDto)
        {

            if (!ModelState.IsValid)
            {
                return View("Index",createBookingDto);
            }

             
                var client = _httpClientFactory.CreateClient();
                var jsonData = JsonConvert.SerializeObject(createBookingDto);
                StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
                var response = await client.PostAsync($"{_apiBaseUrl}/api/Booking", stringContent);



                if (response.IsSuccessStatusCode)
                {
                    createBookingDto.Status = "Onay Bekliyor";
                   ViewBag.SuccessMessage = "Rezervasyon başarıyla tamamlandı.";
                    return View("Index");
                }
                else if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
                {
                    var errorJson = await response.Content.ReadAsStringAsync();

                    var errors = JsonConvert.DeserializeObject<List<string>>(errorJson);

                    foreach (var error in errors)
                    {
                        ModelState.AddModelError(string.Empty, error);
                    }

                    return View("Index", createBookingDto);
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Beklenmeyen bir hata oluştu.");
                    return View("Index", createBookingDto);
                }

                


        }
    }
}
