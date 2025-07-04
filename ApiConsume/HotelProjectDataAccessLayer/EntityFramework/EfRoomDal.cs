﻿using HotelProjectDataAccessLayer.Abstract;
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
        private readonly Context _context;

        public EfRoomDal(Context context) : base(context)
        {
            _context = context;
        }
        public int RoomCount()
        {
            var values = _context.Rooms.Count();
            return values;

        }
    }
}
