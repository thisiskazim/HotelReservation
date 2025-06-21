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
   public  class EfSubscribeDal :GenericRepository<Subscribe>,ISubscribeDal
    {

        public EfSubscribeDal(Context context) : base(context)
        {

        }
    }
}
