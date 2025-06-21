using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelProjectDataAccessLayer.Abstract;
using HotelProjectDataAccessLayer.Concrete;
using HotelProjectDataAccessLayer.Repositories;
using HotelProjectEntityLayer.Concrete;

namespace HotelProjectDataAccessLayer.EntityFramework
{
    public class EfServiceDal :GenericRepository<Service>,IServicesDal
    {

        public EfServiceDal(Context context) : base(context)
        {

        }
    }
}
