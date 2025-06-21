using HotelProjectBusinessLayer.Abstract;
using HotelProjectEntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace HotelProjectWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IContactService _contactService;

        public ContactController(IContactService contactService)
        {
            _contactService = contactService;
        }
        [HttpPost]
        public IActionResult AddContact(Contact contact)
        {
            contact.Date=Convert.ToDateTime(DateTime.Now.ToString());  
            _contactService.TInsert(contact);
            return Ok();
        }

        [HttpGet]
        public IActionResult InboxListContact()
        {
            var values = _contactService.TGetList();

            return Ok(values);
        }
        [HttpGet("id")]
        public IActionResult SendMessageList(int id)
        {
            var values = _contactService.TGetByID(id);

            return Ok(values);
        }
        [HttpGet("GetContactCount")]

        public IActionResult GetContactCount() {
        
        return Ok(_contactService.TGetContactCount());
        }


    }
}
