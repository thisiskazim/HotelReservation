using HotelProjectDataAccessLayer.Abstract;
using HotelProjectDataAccessLayer.Concrete;
using HotelProjectDataAccessLayer.Repositories;
using HotelProjectEntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProjectDataAccessLayer.EntityFramework
{
    
     public class EfRoomDal :GenericRepository<Room> ,IRoomDal
    {
        public EfRoomDal(Context context): base(context)
        {

        }

        public int RoomCount()
        {
           var context = new Context();
            var values = context.Rooms.Count();
            return values;

        }
    }
}
