using HotelProjectWebUI.Models.Staff;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace HotelProjectWebUI.ViewComponents.Dashboard
{
    public class _DashboardWidgetPartial  :ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _configuration;
        private readonly string _apiBaseUrl;

        public _DashboardWidgetPartial(IHttpClientFactory httpClientFactory, IConfiguration configuration)
        {
            _httpClientFactory = httpClientFactory;
            _configuration = configuration;
            _apiBaseUrl = _configuration["ApiBaseUrl"];
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {

            await HelperMet("StaffCount");
            await HelperMet("BookingCount");
            await HelperMet("AppUserCount");
            await HelperMet("BookingCount"); 
            return View();
        }


        private async Task HelperMet(string isModelCount)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"{_apiBaseUrl}/api/DashboardWidgetsControllers/{isModelCount}");
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            ViewBag[isModelCount] = jsonData;
        }

    }
}
