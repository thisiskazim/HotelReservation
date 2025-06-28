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

namespace HotelProjectWebUI.Controllers
{
    [AllowAnonymous]
    public class BookingController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public BookingController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
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

                createBookingDto.Status = "Onay Bekliyor";
                var client = _httpClientFactory.CreateClient();
                var jsonData = JsonConvert.SerializeObject(createBookingDto);
                StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
                var response = await client.PostAsync("http://localhost:5001/api/Booking", stringContent);



                if (response.IsSuccessStatusCode)
                {
                     ViewBag.SuccessMessage = "Rezervasyon başarıyla tamamlandı.";
                    return View("Index");
                }
                else if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
                {
                    // Hata mesajlarını JSON olarak al
                    var errorJson = await response.Content.ReadAsStringAsync();

                    // Hata mesajlarını List<string> olarak deserialize et
                    var errors = JsonConvert.DeserializeObject<List<string>>(errorJson);

                    // ModelState'e ekle ki View'da gösterilsin
                    foreach (var error in errors)
                    {
                        ModelState.AddModelError(string.Empty, error);
                    }

                    // Formu tekrar hatalarla birlikte göster
                    return View("Index", createBookingDto);
                }
                else
                {
                    // Başka hata varsa genel hata mesajı verebilirsin
                    ModelState.AddModelError(string.Empty, "Beklenmeyen bir hata oluştu.");
                    return View("Index", createBookingDto);
                }

                


        }
    }
}
