using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Collections.Generic;
using HotelProjectWebUI.Dtos.FollowersDto;
using Newtonsoft.Json;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Org.BouncyCastle.Asn1.Ocsp;

namespace HotelProjectWebUI.ViewComponents.Dashboard
{
    public class _DashboardSubscribeCountPartial : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            // Instagram
            try
            {
                var client = new HttpClient();
                var request = new HttpRequestMessage
                {
                    Method = HttpMethod.Get,
                    RequestUri = new Uri("https://instagram-scraper-20251.p.rapidapi.com/userinfo/?username_or_id=murattycedag"),
                    Headers =
                {
                    { "x-rapidapi-key", "20f4234472msh6f1aa5d52c53782p16454fjsnf3b656456ff4" },
                    { "x-rapidapi-host", "instagram-scraper-20251.p.rapidapi.com" },
                },
                };

                var response = await client.SendAsync(request);
                if (response.IsSuccessStatusCode)
                {
                    var body = await response.Content.ReadAsStringAsync();
                    var result = JsonConvert.DeserializeObject<ResultInstagramFollowersDto>(body);
                    ViewBag.v1 = result.data.follower_count;
                    ViewBag.v2 = result.data.following_count;
                }
                else
                {
                    ViewBag.v1 = ViewBag.v2 = 0;
                }
            }
            catch
            {
                ViewBag.v1 = ViewBag.v2 = 0;
            }

            // Twitter
            try
            {
                var client2 = new HttpClient();
                var request2 = new HttpRequestMessage
                {
                    Method = HttpMethod.Get,
                    RequestUri = new Uri("https://twitter154.p.rapidapi.com/user/details?username=omarmhaimdat&user_id=96479162"),
                    Headers =
                {
                    { "x-rapidapi-key", "20f4234472msh6f1aa5d52c53782p16454fjsnf3b656456ff4" },
                    { "x-rapidapi-host", "twitter154.p.rapidapi.com" },
                },
                };

                var response2 = await client2.SendAsync(request2);
                if (response2.IsSuccessStatusCode)
                {
                    var body2 = await response2.Content.ReadAsStringAsync();
                    var result2 = JsonConvert.DeserializeObject<ResultTwitterFollowersDto>(body2);
                    ViewBag.t1 = result2.follower_count;
                    ViewBag.t2 = result2.following_count;
                }
                else
                {
                    ViewBag.t1 = ViewBag.t2 = 0;
                }
            }
            catch
            {
                ViewBag.t1 = ViewBag.t2 = 0;
            }

            // LinkedIn
            try
            {
                var client3 = new HttpClient();
                var request3 = new HttpRequestMessage
                {
                    Method = HttpMethod.Get,
                    RequestUri = new Uri("https://fresh-linkedin-profile-data.p.rapidapi.com/get-linkedin-profile?linkedin_url=https%3A%2F%2Fwww.linkedin.com%2Fin%2Fnarin-ulu%25C4%25B1%25C5%259F%25C4%25B1k-aa7758246%2F&include_skills=false&include_certifications=false"),
                    Headers =
                {
                    { "x-rapidapi-key", "20f4234472msh6f1aa5d52c53782p16454fjsnf3b656456ff4" },
                    { "x-rapidapi-host", "fresh-linkedin-profile-data.p.rapidapi.com" },
                },
                };

                var response3 = await client3.SendAsync(request3);
                if (response3.IsSuccessStatusCode)
                {
                    var body3 = await response3.Content.ReadAsStringAsync();
                    var result3 = JsonConvert.DeserializeObject<ResultLinkedinFolloweersDto>(body3);
                    ViewBag.l1 = result3.data.follower_count;
                    ViewBag.l2 = result3.data.connection_count;
                }
                else
                {
                    ViewBag.l1 = ViewBag.l2 = 0;
                }
            }
            catch
            {
                ViewBag.l1 = ViewBag.l2 = 0;
            }

            return View();
        }
    }

}
