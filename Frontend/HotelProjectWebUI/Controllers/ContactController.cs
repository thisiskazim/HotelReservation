 using HotelProjectWebUI.Dtos.BookingDto;
using HotelProjectWebUI.Dtos.ContactDto;
using HotelProjectWebUI.Dtos.MessageCatecoryDto;
using HotelProjectWebUI.Dtos.RoomDto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;


namespace HotelProjectWebUI.Controllers
{
    [AllowAnonymous]
    public class ContactController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _configuration;
        private readonly string _apiBaseUrl;

        public ContactController(IHttpClientFactory httpClientFactory, IConfiguration configuration)
        {
            _httpClientFactory = httpClientFactory;
            _configuration = configuration;
            _apiBaseUrl = _configuration["ApiBaseUrl"];
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"{_apiBaseUrl}/api/MessageCategory");
           
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultMessageCategoryDto>>(jsonData);
           
            List<SelectListItem> values2 = (from x in values
                                           select new SelectListItem
                                           {
                                               Text = x.MessageCategoryName,
                                               Value = x.MessageCategoryID.ToString()
                                           }) .ToList();
            ViewBag.v = values2;
            return View();
        }


        [HttpGet]
        public PartialViewResult SendMessage()
        {
            return PartialView();

        }
        [HttpPost]
        public async Task<IActionResult> SendMessage(CreateContactDto createContactDto)
        {
            createContactDto.Date =DateTime.Parse(DateTime.Now.ToShortDateString());
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createContactDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync($"{_apiBaseUrl}/api/Contact", stringContent);
           
                return RedirectToAction("Index", "Default");
          
      

        }
    }
}
