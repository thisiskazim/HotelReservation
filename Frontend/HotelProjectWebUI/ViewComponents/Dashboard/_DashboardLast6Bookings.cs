using HotelProjectWebUI.Dtos.BookingDto;
using HotelProjectWebUI.Dtos.StaffDto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace HotelProjectWebUI.ViewComponents.Dashboard
{
	public class _DashboardLast6Bookings : ViewComponent
	{
		private readonly IHttpClientFactory _httpClientFactory;

		public _DashboardLast6Bookings(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}

		public async Task<IViewComponentResult> InvokeAsync()
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync("http://localhost:5000/api/Booking/Last6Bookings");
			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<List<ResultLast6BookingDto>>(jsonData);
				return View(values);
			}
			return View();
		}
	}
}
