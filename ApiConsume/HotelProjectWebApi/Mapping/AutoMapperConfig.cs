using AutoMapper;
using HotelProjectDtoLayer.Dtos.RoomDto;
using HotelProjectEntityLayer.Concrete;

namespace HotelProjectWebApi.Mapping
{
    public class AutoMapperConfig  :Profile
    {
        public AutoMapperConfig() {

            CreateMap<RoomAddDto, Room>();
            CreateMap<Room, RoomAddDto>();
            CreateMap<UpdateRoomDto,Room>().ReverseMap();
        }
   
    }
}
