using HotelProjectWebUI.Dtos.ContactDto;
using HotelProjectWebUI.Dtos.SendMessageController;
using HotelProjectWebUI.Models.Staff;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace HotelProjectWebUI.Controllers
{
    [AllowAnonymous]
    public class AdminContactController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AdminContactController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }


        public async Task<IActionResult> InBox()
        {
            var client = _httpClientFactory.CreateClient();

            var responseMessage = await client.GetAsync("http://localhost:5000/api/Contact");
            var responseMessage2 = await client.GetAsync("http://localhost:5000/api/Contact/GetContactCount");
            var responseMessage3 = await client.GetAsync("http://localhost:5000/api/SendMessage/GetSendMessageCount");

            List<InboxContactDto> values = new List<InboxContactDto>();

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                values = JsonConvert.DeserializeObject<List<InboxContactDto>>(jsonData);
            }

            if (responseMessage2.IsSuccessStatusCode)
            {
                var jsonData2 = await responseMessage2.Content.ReadAsStringAsync();
                if (int.TryParse(jsonData2, out int contactCount))
                {
                    ViewBag.ContactCount = contactCount;
                }
                else
                {
                    ViewBag.ContactCount = "0";
                }
            }
            else
            {
                ViewBag.ContactCount = "0";
            }

            if (responseMessage3.IsSuccessStatusCode)
            {
                var jsonData3 = await responseMessage3.Content.ReadAsStringAsync();
                if (int.TryParse(jsonData3, out int sendMessageCount))
                {
                    ViewBag.SendMessageCount = sendMessageCount;
                }
                else
                {
                    ViewBag.SendMessageCount = "0";
                }
            }
            else
            {
                ViewBag.SendMessageCount = "0";
            }

            return View(values);
        }


        public async Task<IActionResult> SendBox()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("http://localhost:5000/api/SendMessage");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultSendBoxDto>>(jsonData);
                return View(values);
            }
            return View();
        }


         [HttpGet]
        public PartialViewResult AddSendMessage()
        {
            return PartialView();

        }
        [HttpPost]
        public async Task<IActionResult> AddSendMessage(CreateSendMessage createSendMessage)
        {
            createSendMessage.SenderMail = "ADMİN@GMAİL.COM";
            createSendMessage.SenderName = "admin";
            createSendMessage.Date = DateTime.Parse(DateTime.Now.ToShortDateString());
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createSendMessage);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("http://localhost:5000/api/SendMessage", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            
            {

                return RedirectToAction("SendBox");

            }

            return View();


        }
    
    public  async Task<PartialViewResult> SideBarAdminContactPartial()
        {

            return PartialView();
        }  
        public  PartialViewResult SideBarAdminContactCategoryPartial()
        {
            return PartialView();
        }


        public async Task<IActionResult> MessageDetailsByInbox(int id) {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"http://localhost:5000/api/SendMessage/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<GetMessageByIdDto>(jsonData);
                return View(values);
            }
            return View();
          
        }
   
        public async Task<IActionResult> MessageDetailsBySendbox(int id) {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"http://localhost:5000/api/Contact/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<InboxContactDto>(jsonData);
                return View(values);
            }
            return View();
          
        }


        //public async Task<IActionResult>GetContactCount()
        //{
        //    var client = _httpClientFactory.CreateClient();
        //    var responseMessage = await client.GetAsync("http://localhost:5000/api/GetContactCount");
        //    if (responseMessage.IsSuccessStatusCode)
        //    {
        //        var jsonData = await responseMessage.Content.ReadAsStringAsync();
        //    //    var values = JsonConvert.DeserializeObject<List<InboxContactDto>>(jsonData);
        //        return View();
        //    }
        //    return View();

        //}


    }
}
