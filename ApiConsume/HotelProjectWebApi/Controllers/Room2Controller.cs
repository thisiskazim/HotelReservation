﻿using AutoMapper;
using HotelProjectBusinessLayer.Abstract;
using HotelProjectDtoLayer.Dtos.RoomDto;
using HotelProjectEntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace HotelProjectWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Room2Controller : ControllerBase
    {
        private readonly IRoomService _roomservice;
        private readonly IMapper _mapper;


        public Room2Controller(IRoomService roomservice, IMapper mapper)
        {
            _roomservice = roomservice;
            _mapper = mapper;
        }

        [HttpGet]

        public  IActionResult Index()
        {

            var values = _roomservice.TGetList();
            return Ok(values);
        }
        [HttpPost]
        public IActionResult AddRoom(RoomAddDto roomAddDto)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest();
            }
            var values=_mapper.Map<Room>(roomAddDto);
            _roomservice.TInsert(values);
            return Ok();
        }  
        [HttpPut]
        public IActionResult UpdateRoom(UpdateRoomDto updateRoomDto)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest();
            }
            var values=_mapper.Map<Room>(updateRoomDto);
            _roomservice.TUpdate(values);
            return Ok("Başarıyla Güncellendi");
        }
    }
}
