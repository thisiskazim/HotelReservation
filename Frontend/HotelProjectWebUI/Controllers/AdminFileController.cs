using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR.Protocol;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace HotelProjectWebUI.Controllers
{
    public class AdminFileController : Controller
    {
     
        private readonly IConfiguration _configuration;
        private readonly string _apiBaseUrl;

        public AdminFileController( IConfiguration configuration)
        {
            _configuration = configuration;
            _apiBaseUrl = _configuration["ApiBaseUrl"];
        }


        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(IFormFile file)
        {
            var stream = new MemoryStream();
            await file.CopyToAsync(stream);
            var bytes = stream.ToArray();

            ByteArrayContent byteArrayContent = new ByteArrayContent(bytes);
            byteArrayContent.Headers.ContentType = new MediaTypeHeaderValue(file.ContentType);
            MultipartFormDataContent multipartFormDataContent = new MultipartFormDataContent();
            multipartFormDataContent.Add(byteArrayContent, "file", file.FileName);
            var HttpClient = new HttpClient();
            await HttpClient.PostAsync($"{_apiBaseUrl}/api/FileProcess", multipartFormDataContent);

            return View();
        }
    }
}
